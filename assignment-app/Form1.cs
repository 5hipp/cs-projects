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
<<<<<<< HEAD
<<<<<<< Updated upstream
            FormParser.Parse();
           }
=======

            String[] commandLine = inputTextBox.Text.Split('\n');

            outputLog.Text = "Log: Words in array " + commandLine[0] + " + " + commandLine[1] + " + " + commandLine[2];
            /// make a loop that takes the first item from the array, checks it against list of commands
            /// if the command matches it then splits the value from that item in the array and draws based from the command
            String[] individualCommand;
            for (int i = 0; i < commandLine.Length; i++)
            {
                individualCommand = commandLine[i].Split(' ');
            }

            for (int i = 0; i < commandLine.Length; i++)
            {
                if (commandLine[i].Contains("line"))
                {
                    Canvas.DrawLine();
                } else if (commandLine[i].Contains("square"))
                {
                    Canvas.DrawSquare(100);
                } else if (commandLine[i].Contains("circle"))
                {
                    Canvas.DrawCircle(100);
                }
            } 

        }
>>>>>>> Stashed changes
=======
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
>>>>>>> parent of b5aa1ce (further implementation of parser)

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
<<<<<<< HEAD
                FormParser.Parse(commandLineInput.Text);
=======
                Parser.Parse(commandLineInput.Text);
                Refresh();
>>>>>>> parent of b5aa1ce (further implementation of parser)
            }

        }
        
        private void clearButton_Click(object sender, EventArgs e)
        {
<<<<<<< HEAD
<<<<<<< Updated upstream
            FormCanvas.Clear();
=======
            Canvas.Clear();
>>>>>>> Stashed changes
=======
            Canvas.Clear();
>>>>>>> parent of b5aa1ce (further implementation of parser)
            Refresh();
        }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(OutputBitmap, 0, 0);
        }

    }
}