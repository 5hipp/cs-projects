namespace PaintingProg
{
    public partial class Form1 : Form
    {
        Graphics graphics;
        Boolean cursorMoving = false;
        Pen cursorPen;
        int cursorX = -1;
        int cursorY = -1;
        public Form1()
        {
            InitializeComponent();
            graphics = canvas.CreateGraphics();
            cursorPen = new Pen(Color.Black, 5);
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button 1 Pressed");
            cursorPen = new Pen(Color.Red, 5);
        }

        private void button2_Click(object sender, EventArgs e)
        {
            Console.WriteLine("Button 1 Pressed");
            cursorPen = new Pen(Color.Blue, 5);
        }

        private void canvas_MouseDown(object sender, MouseEventArgs e)
        {
            cursorMoving = true;
            cursorX = e.X;
            cursorY = e.Y;
        }

        private void canvas_MouseUp(object sender, MouseEventArgs e)
        {
            cursorMoving = false;
            cursorX = -1;
            cursorY = -1;
        }

        private void canvas_MouseMove(object sender, MouseEventArgs e)
        {
            if (cursorX != -1 && cursorY != -1 && cursorMoving == true)
            {
                graphics.DrawLine(cursorPen, new Point(cursorX, cursorY), e.Location);
                cursorX = e.X;
                cursorY = e.Y;
            }

        }
    }
}