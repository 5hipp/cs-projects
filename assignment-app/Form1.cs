namespace AssignmentApp
{
    public partial class Form1 : Form
    {
        Canvas Canvas;
        Bitmap OutputBitmap = new Bitmap(640, 480);
        int cursorX = -1;
        int cursorY = -1;

        public Form1()
        {
            InitializeComponent();
            Canvas = new Canvas(Graphics.FromImage(OutputBitmap));
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            
        }

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                String[] commandInputs = commandLineInput.Text.Split(' ');

                if (commandInputs[0].Equals("line") == true)
                {
                    int x = Int32.Parse(commandInputs[1]);
                    int y = Int32.Parse(commandInputs[2]);
                    Canvas.DrawLine(x,y);
                } else if (commandInputs[0].Equals("square") == true)
                {
                    int x = Int32.Parse(commandInputs[1]);
                    Canvas.DrawSquare(x);
                }
                commandLineInput.Text = "";
                Refresh();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            
        }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

        private void outputCanvas_MouseDown(object sender, MouseEventArgs e)
        {
            cursorX = e.X;
            cursorY = e.Y;
            Canvas.SetCursorPos(cursorX, cursorY);
            
        }
    }
}