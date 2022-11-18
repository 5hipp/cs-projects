using System.Drawing;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace AssignmentApp
{
    public partial class Form1 : Form
    {
        Canvas FormCanvas;
        Parser FormParser;
        SaveLoad FormSaveLoad;

        public Form1()
        {
            this.FormSaveLoad = new SaveLoad();
            this.FormCanvas = new Canvas();
            this.FormParser = new Parser(FormCanvas);
            InitializeComponent();
            FormCanvas.MoveCursor(2, 2);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            if (FormParser.CheckSyntax(inputTextBox.Text).Equals(false))
            {
                outputLog.Text = "You must correct syntax errors before continuing";
            } else {
                 FormParser.Parse(inputTextBox.Text);
                outputLog.Text = "";
            }
  
            Refresh();
        }  

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            FormParser.Parse(commandLineInput.Text);
            Refresh();

            if (commandLineInput.Text.Trim().ToLower().Equals("run"))
            {
                FormParser.Parse(inputTextBox.Text);
                Refresh();            
                commandLineInput.Text = "";
            }

            e.Handled = true;
            e.SuppressKeyPress = true;
        }
        
        private void clearButton_Click(object sender, EventArgs e)
        {
            FormCanvas.Clear();
            Refresh();
        }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(FormCanvas.outputBitmap, 0, 0);
        }

        private void outputCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            outputLog.Text = "Cursor X:" + e.X + "\nCursor Y:" + e.Y;
        }

        private void saveButton_Click(object sender, EventArgs e)
        {
            FormSaveLoad.Save(inputTextBox.Text);
        }

        private void loadButton_Click(object sender, EventArgs e)
        {
            FormSaveLoad.Load(inputTextBox.Text);
        }

        private void syntaxCheckButton_Click(object sender, EventArgs e)
        {
            bool x;
            x = FormParser.CheckSyntax(inputTextBox.Text);

            if (x.Equals(true))
            {
                outputLog.Text = "Correct";

            } else if (x.Equals(false))
            {
                outputLog.Text = "Incorrect";

            }
        }
    }
}