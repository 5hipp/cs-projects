using System;
using System.Collections.Generic;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Windows.Forms;
using System.IO;
using OfficeOpenXml;

namespace csv_parser
{
    public partial class Form1 : Form
    {
        private Dictionary<string, Color> wordColors = new Dictionary<string, Color>();
        private bool isFilteredView = false;
        private DataTable fullCsvData;
        private DataTable filteredCsvData;
        private HashSet<DataRow> highlightedDuplicates = new HashSet<DataRow>();

        public Form1()
        {
            InitializeComponent();
            btnAddCommentColumn.Click += btnAddCommentColumn_Click;
            btnHighlightDuplicates.Click += new EventHandler(btnHighlightDuplicates_Click);
            btnDeleteDuplicates.Click += new EventHandler(btnDeleteDuplicates_Click);
        }

        private void btnOpenFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                openFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    string filePath = openFileDialog.FileName;
                    fullCsvData = ReadCsvFile(filePath);
                    dataGridView.DataSource = fullCsvData;
                    PopulateCheckedListBox(fullCsvData);
                }
            }
        }

        private void btnToggleView_Click(object sender, EventArgs e)
        {
            if (isFilteredView)
            {
                dataGridView.DataSource = fullCsvData;
                btnToggleView.Text = "Apply Filter";
            }
            else
            {
                ApplyFilter();
            }
            isFilteredView = !isFilteredView;
            ApplyCellColors();
        }


        private DataTable ReadCsvFile(string filePath)
        {
            DataTable dt = new DataTable();

            try
            {
                using (StreamReader sr = new StreamReader(filePath))
                {
                    // Read the first line to get headers
                    string[] headers = ParseCsvLine(sr.ReadLine());

                    // Add columns to DataTable
                    foreach (string header in headers)
                    {
                        dt.Columns.Add(header.Trim()); // Trim to remove any leading/trailing whitespace
                    }

                    // Read remaining lines
                    while (!sr.EndOfStream)
                    {
                        string line = sr.ReadLine();
                        string[] fields = ParseCsvLine(line);

                        if (fields.Length == dt.Columns.Count)
                        {
                            dt.Rows.Add(fields);
                        }
                        else
                        {
                            // Handle mismatched columns or malformed lines as needed
                            MessageBox.Show($"Skipping line: {line}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Error reading CSV file: {ex.Message}", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }

            return dt;
        }

        private string[] ParseCsvLine(string line)
        {
            List<string> fields = new List<string>();
            bool inQuotes = false;
            StringBuilder sb = new StringBuilder();

            for (int i = 0; i < line.Length; i++)
            {
                char c = line[i];

                if (c == '"')
                {
                    // Toggle inQuotes flag
                    inQuotes = !inQuotes;
                }
                else if (c == ',' && !inQuotes)
                {
                    // Add field to list, trimming leading/trailing whitespace and quotes if needed
                    fields.Add(sb.ToString().Trim('"').Trim());
                    sb.Clear(); // Clear StringBuilder for next field
                }
                else
                {
                    // Append character to StringBuilder
                    sb.Append(c);
                }
            }

            // Add the last field
            fields.Add(sb.ToString().Trim('"').Trim());

            return fields.ToArray();
        }

        private void ApplyFilter()
        {
            List<string> selectedHeaders = checkedListBoxHeaders.CheckedItems.Cast<string>().ToList();
            if (selectedHeaders.Count > 0)
            {
                // Include "Comments" column if it exists
                if (fullCsvData.Columns.Contains("Comments"))
                {
                    selectedHeaders.Add("Comments");
                }

                filteredCsvData = FilterCsvData(fullCsvData, selectedHeaders);
                dataGridView.DataSource = filteredCsvData;
                btnToggleView.Text = "Show Full Table";
            }
            else
            {
                MessageBox.Show("Please select at least one header to filter by.", "No Headers Selected", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }


        private DataTable FilterCsvData(DataTable dataTable, List<string> columns)
        {
            DataTable filteredTable = new DataTable();
            foreach (string column in columns)
            {
                filteredTable.Columns.Add(new DataColumn(column));
            }

            foreach (DataRow row in dataTable.Rows)
            {
                DataRow newRow = filteredTable.NewRow();
                foreach (string column in columns)
                {
                    newRow[column] = row[column];
                }
                filteredTable.Rows.Add(newRow);
            }

            return filteredTable;
        }

        private void PopulateCheckedListBox(DataTable dataTable)
        {
            checkedListBoxHeaders.Items.Clear();
            foreach (DataColumn column in dataTable.Columns)
            {
                checkedListBoxHeaders.Items.Add(column.ColumnName);
            }
        }

        private void btnExportExcel_Click(object sender, EventArgs e)
        {
            ExportExcel(dataGridView.DataSource as DataTable);
        }

        private void ExportExcel(DataTable dt)
        {
            if (dt != null)
            {
                // Prompt user for file save location
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "Excel files (*.xlsx)|*.xlsx|All files (*.*)|*.*";
                saveFileDialog.FileName = "ExportedData.xlsx";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the file path
                    string filePath = saveFileDialog.FileName;

                    // Export to Excel
                    try
                    {
                        using (ExcelPackage package = new ExcelPackage())
                        {
                            // Add a new worksheet to the empty workbook
                            ExcelWorksheet worksheet = package.Workbook.Worksheets.Add("Data");

                            // Fill the Excel sheet
                            worksheet.Cells["A1"].LoadFromDataTable(dt, true);

                            // Apply cell styles (including colors)
                            for (int r = 0; r < dt.Rows.Count; r++)
                            {
                                for (int c = 0; c < dt.Columns.Count; c++)
                                {
                                    var cell = worksheet.Cells[r + 2, c + 1]; // +2 because Excel rows and columns are 1-based
                                    var cellContent = dt.Rows[r][c].ToString();
                                    if (wordColors.ContainsKey(cellContent))
                                    {
                                        cell.Style.Fill.PatternType = OfficeOpenXml.Style.ExcelFillStyle.Solid;
                                        cell.Style.Fill.BackgroundColor.SetColor(wordColors[cellContent]);
                                    }
                                }
                            }

                            // Save the Excel file
                            package.SaveAs(new FileInfo(filePath));
                        }

                        MessageBox.Show("Excel file exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting Excel file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnChangeCellColor_Click(object sender, EventArgs e)
        {
            if (dataGridView.SelectedCells.Count > 0)
            {
                ColorDialog colorDialog = new ColorDialog();
                if (colorDialog.ShowDialog() == DialogResult.OK)
                {
                    foreach (DataGridViewCell cell in dataGridView.SelectedCells)
                    {
                        var cellContent = cell.Value.ToString();
                        if (!wordColors.ContainsKey(cellContent))
                        {
                            wordColors.Add(cellContent, colorDialog.Color);
                        }
                        else
                        {
                            wordColors[cellContent] = colorDialog.Color;
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please select at least one cell to change its color.", "No Cell Selected", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
            ApplyCellColors();
        }

        private void dataGridView_Sorted(object sender, EventArgs e)
        {
            ApplyCellColors();
        }

        private void ApplyCellColors()
        {
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                foreach (DataGridViewCell cell in row.Cells)
                {
                    if (cell.Value != null) // Check if cell value is not null
                    {
                        var cellContent = cell.Value.ToString();

                        // Check if the key exists in the dictionary
                        if (wordColors.ContainsKey(cellContent))
                        {
                            cell.Style.BackColor = wordColors[cellContent];
                        }
                        else
                        {
                            cell.Style.BackColor = Color.Empty; // Reset to default if no color is found
                        }
                    }
                    else
                    {
                        cell.Style.BackColor = Color.Empty; // Reset to default if cell value is null
                    }
                }
            }
        }
        private void btnAddCommentColumn_Click(object sender, EventArgs e)
        {
            // Check if a DataTable is already loaded
            if (fullCsvData != null)
            {
                // Check if the column already exists
                if (!fullCsvData.Columns.Contains("Comments"))
                {
                    // Add a new column for comments
                    DataColumn commentColumn = new DataColumn("Comments", typeof(string));
                    fullCsvData.Columns.Add(commentColumn);

                    // Update the DataGridView only if it's showing full data
                    if (!isFilteredView)
                    {
                        dataGridView.DataSource = null; // Clear the DataSource to force refresh
                        dataGridView.DataSource = fullCsvData;
                    }
                }
                // Remove the else statement to avoid showing message box unnecessarily
            }
            else
            {
                MessageBox.Show("Please load a CSV file first.", "No Data Loaded", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnAddColumn_Click(object sender, EventArgs e)
        {
            // Check if fullCsvData is loaded
            if (fullCsvData != null)
            {
                using (AddColumnForm addColumnForm = new AddColumnForm())
                {
                    if (addColumnForm.ShowDialog() == DialogResult.OK)
                    {
                        string newColumnName = addColumnForm.ColumnName;

                        if (!string.IsNullOrEmpty(newColumnName))
                        {
                            // Add column to DataTable
                            DataColumn newColumn = new DataColumn(newColumnName);
                            fullCsvData.Columns.Add(newColumn);

                            // Update DataGridView
                            dataGridView.DataSource = fullCsvData;

                            // Add column to header filter box (checkedListBoxHeaders)
                            checkedListBoxHeaders.Items.Add(newColumnName);

                            // Select the new column in the filter box if it's a Comments column
                            if (newColumnName.Equals("Comments", StringComparison.OrdinalIgnoreCase))
                            {
                                checkedListBoxHeaders.SetItemChecked(checkedListBoxHeaders.Items.Count - 1, true);
                            }
                        }
                    }
                }
            }
            else
            {
                MessageBox.Show("Please load a CSV file first.", "No Data Loaded", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            btnHighlightDuplicates.Click += btnHighlightDuplicates_Click;
            btnDeleteDuplicates.Click += btnDeleteDuplicates_Click;
        }

        private void btnHighlightDuplicates_Click(object sender, EventArgs e)
        {
            if (dataGridView.DataSource != null)
            {
                HighlightDuplicateRows();
            }
            else
            {
                MessageBox.Show("Please load a CSV file first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void btnDeleteDuplicates_Click(object sender, EventArgs e)
        {
            if (dataGridView.DataSource != null)
            {
                DeleteHighlightedDuplicates();
            }
            else
            {
                MessageBox.Show("Please load a CSV file first.", "No Data", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }

        private void HighlightDuplicateRows()
        {
            if (fullCsvData == null)
            {
                MessageBox.Show("No data loaded.", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                return;
            }

            var duplicateRows = fullCsvData.AsEnumerable()
                .GroupBy(row => string.Join(",", row.ItemArray))
                .Where(group => group.Count() > 1)
                .SelectMany(group => group)
                .ToList();

            highlightedDuplicates.Clear();
            foreach (DataGridViewRow row in dataGridView.Rows)
            {
                if (row.DataBoundItem == null)
                {
                    continue;
                }

                var dataRow = ((DataRowView)row.DataBoundItem).Row;
                if (duplicateRows.Contains(dataRow))
                {
                    row.DefaultCellStyle.BackColor = Color.Yellow;
                    highlightedDuplicates.Add(dataRow);
                }
                else
                {
                    row.DefaultCellStyle.BackColor = Color.White;
                }
            }

            MessageBox.Show($"{highlightedDuplicates.Count} duplicate rows highlighted.", "Duplicates Highlighted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }

        private void DeleteHighlightedDuplicates()
        {
            if (highlightedDuplicates.Count == 0)
            {
                MessageBox.Show("No highlighted duplicates to delete.", "No Duplicates", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            foreach (var row in highlightedDuplicates.ToList())
            {
                fullCsvData.Rows.Remove(row);
            }

            dataGridView.DataSource = null;
            dataGridView.DataSource = fullCsvData;
            highlightedDuplicates.Clear();

            MessageBox.Show("Highlighted duplicate rows deleted.", "Duplicates Deleted", MessageBoxButtons.OK, MessageBoxIcon.Information);
        }


    }
}
