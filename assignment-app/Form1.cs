using System.Drawing;
using System.Linq.Expressions;

namespace AssignmentApp
{
    public partial class Form1 : Form
    {
        Canvas Canvas;
        Bitmap OutputBitmap = new Bitmap(640, 480);

        public Form1()
        {
            InitializeComponent();
            Canvas = new Canvas(Graphics.FromImage(OutputBitmap));
            Canvas.MoveCursor(0, 0);
        }

        private void submitButton_Click(object sender, EventArgs e)
        {
            Parser.Parse(inputTextBox.Text);
            Refresh();
        }

        /*private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter) 
            {
                String[] commandInputs = commandLineInput.Text.Split(' ');

                if (commandInputs[0].Trim().ToLower().Equals("lineto") == true)
                {
                    Canvas.DrawLine(int.Parse(commandInputs[1]), int.Parse(commandInputs[2]));
                  
                } else if (commandInputs[0].Trim().ToLower().Equals("square") == true) {
                    try
                    {
                        int x = Int32.Parse(commandInputs[1]);
                        Canvas.DrawSquare(x);
                    } catch 
                    {
                        MessageBox.Show("You must input a size!");
                    }
                } else if (commandInputs[0].Trim().ToLower().Equals("circle") == true) {
                    try
                    {
                        int x = Int32.Parse(commandInputs[1]);
                        Canvas.DrawCircle(x);
                    } catch
                    {
                        MessageBox.Show("You must input a radius!");
                    }
                } else if (commandInputs[0].Trim().ToLower().Equals("moveto") == true)
                {
                    try
                    {
                        Canvas.MoveCursor(int.Parse(commandInputs[1]), int.Parse(commandInputs[2]));

                    }
                    catch
                    {
                        MessageBox.Show("You must input a value!");
                    }
                    Refresh();
                }
                commandLineInput.Text = "";
                Refresh();
            }
        }*/

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                Parser.Parse(commandLineInput.Text);
                Refresh();
            }

        }
        
        private void clearButton_Click(object sender, EventArgs e)
        {
            Canvas.Clear();
            Refresh();
        }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

    }
}