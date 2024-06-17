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
        private int currentLineIndex = 1;
        private string[] csvLines;

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
                    csvLines = File.ReadAllLines(filePath);
                    DataTable csvData = ReadCsvFile(csvLines);
                    dataGridView.DataSource = csvData;
                }
            }
        }

        private void btnOpenSingleLine_Click(object sender, EventArgs e)
        {
            if (csvLines != null)
            {
                DataTable csvData = ReadSingleLineCsvFile(csvLines, currentLineIndex);
                dataGridView.DataSource = csvData;
            }
        }

        private void btnNextLine_Click(object sender, EventArgs e)
        {
            if (csvLines != null && currentLineIndex < csvLines.Length - 1)
            {
                currentLineIndex++;
                DataTable csvData = ReadSingleLineCsvFile(csvLines, currentLineIndex);
                dataGridView.DataSource = csvData;
            }
        }

        private DataTable ReadCsvFile(string[] lines)
        {
            DataTable dt = new DataTable();

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

        private DataTable ReadSingleLineCsvFile(string[] lines, int lineIndex)
        {
            DataTable dt = new DataTable();

            if (lines.Length > 0 && lineIndex < lines.Length)
            {
                // Adding columns
                string[] headerLabels = lines[0].Split(',');
                foreach (string headerWord in headerLabels)
                {
                    dt.Columns.Add(new DataColumn(headerWord));
                }

                // Adding the specific row
                string[] dataWords = lines[lineIndex].Split(',');
                DataRow dr = dt.NewRow();
                for (int col = 0; col < headerLabels.Length; col++)
                {
                    dr[col] = dataWords[col];
                }
                dt.Rows.Add(dr);
            }

            return dt;
        }
    }
}
