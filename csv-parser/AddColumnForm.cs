using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace csv_parser
{
    public partial class AddColumnForm : Form
    {
        public string ColumnName { get; private set; }

        public AddColumnForm()
        {
            InitializeComponent();
            btnOK.Enabled = false; // Initially disable the OK button
            textBoxColumnName.TextChanged += TextBoxColumnName_TextChanged;
        }
        private void TextBoxColumnName_TextChanged(object sender, EventArgs e)
        {
            // Enable the OK button only if there is text in the text box
            btnOK.Enabled = !string.IsNullOrWhiteSpace(textBoxColumnName.Text);
        }

        private void btnOK_Click(object sender, EventArgs e)
        {
            ColumnName = textBoxColumnName.Text.Trim();
            DialogResult = DialogResult.OK;
            Close();
        }

        private void btnCancel_Click(object sender, EventArgs e)
        {
            DialogResult = DialogResult.Cancel;
            Close();
        }
    }

}
