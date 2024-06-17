using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.IO;


namespace csv_parser
{
    public partial class Form1 : Form
    {
        private bool isFilteredView = false;
        private DataTable fullCsvData;
        private DataTable filteredCsvData;

        public Form1()
        {
            InitializeComponent();
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
        }

        private DataTable ReadCsvFile(string filePath)
        {
            DataTable dt = new DataTable();
            string[] lines = File.ReadAllLines(filePath);

            if (lines.Length > 0)
            {
                // Adding columns
                string[] headerLabels = lines[0].Split(',');
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                // Adding rows
                for (int r = 1; r < lines.Length; r++)
                {
                    string[] dataWords = lines[r].Split(',');
                    DataRow dr = dt.NewRow();
                    for (int col = 0; col < headerLabels.Length; col++)
                    {
                        dr[col] = dataWords[col];
                    }
                    dt.Rows.Add(dr);
                }
            }

            return dt;
        }

        private void ApplyFilter()
        {
            List<string> selectedHeaders = checkedListBoxHeaders.CheckedItems.Cast<string>().ToList();
            if (selectedHeaders.Count > 0)
            {
                filteredCsvData = FilterCsvData(fullCsvData, selectedHeaders);
                dataGridView.DataSource = filteredCsvData;
                btnToggleView.Text = "Show Full Table";
            }
            else
            {
                MessageBox.Show("Please select at least one header to filter by.");
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

        private void btnExportCsv_Click(object sender, EventArgs e)
        {
            if (dataGridView.DataSource != null)
            {
                DataTable dt = (DataTable)dataGridView.DataSource;

                // Prompt user for file save location
                SaveFileDialog saveFileDialog = new SaveFileDialog();
                saveFileDialog.Filter = "CSV files (*.csv)|*.csv|All files (*.*)|*.*";
                saveFileDialog.FileName = "ExportedData.csv";
                if (saveFileDialog.ShowDialog() == DialogResult.OK)
                {
                    // Get the file path
                    string filePath = saveFileDialog.FileName;

                    // Write CSV file
                    try
                    {
                        using (StreamWriter sw = new StreamWriter(filePath, false, Encoding.UTF8))
                        {
                            // Write headers
                            foreach (DataColumn column in dt.Columns)
                            {
                                sw.Write(column.ColumnName + ",");
                            }
                            sw.WriteLine();

                            // Write data rows
                            foreach (DataRow row in dt.Rows)
                            {
                                object[] array = row.ItemArray;
                                for (int i = 0; i < array.Length; i++)
                                {
                                    sw.Write(array[i].ToString() + ",");
                                }
                                sw.WriteLine();
                            }
                        }

                        MessageBox.Show("CSV file exported successfully.", "Export Complete", MessageBoxButtons.OK, MessageBoxIcon.Information);
                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show("Error exporting CSV file: " + ex.Message, "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                }
            }
            else
            {
                MessageBox.Show("No data to export.", "Export Error", MessageBoxButtons.OK, MessageBoxIcon.Warning);
            }
        }
    }
}
