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
        SyntaxChecker checkSyntax;

        public Form1()
        {
            this.FormSaveLoad = new SaveLoad();
            this.FormCanvas = new Canvas();
            this.FormParser = new Parser(FormCanvas);
            this.checkSyntax = new SyntaxChecker();
            InitializeComponent();
            FormCanvas.MoveCursor(2, 2);

        }
        // checks the input text has the correct syntax then parses
        private void submitButton_Click(object sender, EventArgs e)
        {

            FormParser.Parse(inputTextBox.Text);

  
            Refresh();
        }  


        // checks if the user has inputted run to execute the input box test, if not will parse the single command in the box as a regular command
        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter)
            {
                return;
            }

            FormParser.singleParse(commandLineInput.Text);
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
        
        // clears the canvas
        private void clearButton_Click(object sender, EventArgs e)
        {
            FormCanvas.Clear();
            Refresh();
        }

        // assigns the graphics to the canvas to allow for drawing
        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(FormCanvas.outputBitmap, 0, 0);
        }

        // reports the current x and y coordinates of the mouse to the log box
        private void outputCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            outputLog.Text = "Cursor X:" + e.X + "\nCursor Y:" + e.Y;
        }

        //saves the current inputbox text to a file
        private void saveButton_Click(object sender, EventArgs e)
        {
            FormSaveLoad.Save(inputTextBox.Text);
        }
        
        //not yet implemented
        private void loadButton_Click(object sender, EventArgs e)
        {
            FormSaveLoad.Load(inputTextBox.Text);
        }

        // checks the syntax of the inputbox text and reports to the log if correct or incorrect
        private void syntaxCheckButton_Click(object sender, EventArgs e)
        {

            if (checkSyntax.CheckSyntax(inputTextBox.Text))
            {
                outputLog.Text = "Syntax Correct";

            }
            else if (checkSyntax.CheckSyntax(commandLineInput.Text))
            {
                outputLog.Text = "Syntax Correct";

            } else
            {
                outputLog.Text = "Syntax incorrect";
                // call messagebox creation
            }
        }
    }
}