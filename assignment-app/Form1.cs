using System.Drawing;
using System.Linq.Expressions;

namespace AssignmentApp
{
    public partial class Form1 : Form
    {
        Parser FormParser = new Parser();
        Canvas FormCanvas = new Canvas();

        public Form1()
        {
            InitializeComponent();
            FormCanvas.MoveCursor(10, 10);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            FormParser.Parse();
           }

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormParser.Parse();
            }

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

    }
}