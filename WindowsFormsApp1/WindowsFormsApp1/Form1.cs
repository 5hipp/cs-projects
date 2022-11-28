using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace WindowsFormsApp1
{
    public partial class Form1 : Form
    {
        Parser Parser;
        public Form1()
        {
            this.Parser = new Parser();
            InitializeComponent();
        }

        private void button_Click(object sender, EventArgs e)
        {
            string result = string.Join("\n", Parser.Parse(inputTextBox.Text));
            outputTextBox.Text = result;
        }
    }
}
