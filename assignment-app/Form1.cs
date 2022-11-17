using System.Drawing;
using System.Linq.Expressions;
using static System.Net.Mime.MediaTypeNames;

namespace AssignmentApp
{
    public partial class Form1 : Form
    {
        Canvas FormCanvas;
        Parser FormParser;


        public Form1()
        {
            this.FormCanvas = new Canvas();
            this.FormParser = new Parser(FormCanvas);
            InitializeComponent();
            FormCanvas.MoveCursor(10, 10);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            FormParser.Parse(inputTextBox.Text);
        }  

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                if (commandLineInput.Text.Equals("line"))
                {
                    FormCanvas.DrawLine(100, 100);
                }
            }

        }
        
        private void clearButton_Click(object sender, EventArgs e)
        {
            FormCanvas.Clear();
        }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(FormCanvas.outputBitmap, 0, 0);
        }

    }
}