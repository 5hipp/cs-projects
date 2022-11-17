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

        private void Form1_Load(object sender, EventArgs e)
        {

        }


        private void submitButton_Click(object sender, EventArgs e)
        {
            FormParser.Parse(inputTextBox.Text);
            Refresh();
        }  

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {

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

        }
    }
}