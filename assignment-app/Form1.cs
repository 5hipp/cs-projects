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
            
        }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(FormCanvas.outputBitmap, 0, 0);
        }

    }
}