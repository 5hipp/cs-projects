using System.Drawing;
using System.Linq.Expressions;

namespace AssignmentApp
{
    public partial class Form1 : Form
    {
        Canvas Canvas;
        Bitmap OutputBitmap = new Bitmap(640, 480);
        int cursorX, cursorY = -1;
        int cursorUpX, cursorUpY = -1;

        public Form1()
        {
            InitializeComponent();
            Canvas = new Canvas(Graphics.FromImage(OutputBitmap));
        }

        private void submitButton_Click(object sender, EventArgs e)
        {

            String[] commandLine = inputTextBox.Text.Split('\n');

            outputLog.Text = "Log: Words in array " + commandLine[0] + " + " + commandLine[1] + " + " + commandLine[2];
            /// make a loop that takes the first item from the array, checks it against list of commands
            /// if the command matches it then splits the value from that item in the array and draws based from the command

            for (int i = 0; i < commandLine.Length; i++)
            {
                String[] individualCommmand = commandLine[i].Split(' ');

                if (individualCommmand[i].ToLower() == "line")
                {
                    Canvas.DrawLine();
                }
                else if (individualCommmand[i].ToLower() == "square")
                {
                    Canvas.DrawSquare(individualCommmand[i + 1]);
                }
                else if (individualCommmand[i].ToLower() == "circle")
                {
                    Canvas.DrawCircle(individualCommmand[i + 1]);
                }
            }

        }

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                String[] commandInputs = commandLineInput.Text.Split(' ');

                if (commandInputs[0].Equals("line") == true)
                {
                    Canvas.DrawLine();

                }
                else if (commandInputs[0].Equals("square") == true)
                {
                    try
                    {
                        int x = Int32.Parse(commandInputs[1]);
                        Canvas.DrawSquare(x);
                    }
                    catch
                    {
                        MessageBox.Show("You must input a size!");
                    }
                }
                else if (commandInputs[0].Equals("circle") == true)
                {
                    try
                    {
                        int x = Int32.Parse(commandInputs[1]);
                        Canvas.DrawCircle(x);
                    }
                    catch
                    {
                        MessageBox.Show("You must input a radius!");
                    }
                }
                commandLineInput.Text = "";
                Refresh();
            }
        }

        private void clearButton_Click(object sender, EventArgs e)
        {
            Canvas.Clear();
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
            outputLog.Text = "Log: Cursor position set to X:" + cursorX + " Y:" + cursorY;
        }

        private void outputCanvas_MouseUp(object sender, MouseEventArgs e)
        {
            cursorUpX = e.X;
            cursorUpY = e.Y;
            Canvas.SetSecondCursorPos(cursorUpX, cursorUpY);
            outputLog.Text = "Log: Second Cursor position set to X:" + cursorUpX + " Y:" + cursorUpY;
        }
    }
}