namespace AssignmentApp
{
    public partial class Form1 : Form
    {
        Bitmap OutputBitmap = new Bitmap()
        public Form1()
        {
            InitializeComponent();
            
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {

        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            
        }

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode != Keys.Enter) 
            {
                return;
            }
            
            string parsedText = Parser.Parse(commandLineInput.Text);

            testOutput.Text = parsedText;
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            
        }
    }
}