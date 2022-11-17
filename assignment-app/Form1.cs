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

        private void commandLineInput_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                FormParser.Parse(commandLineInput.Text);
            }

        }
        
        private void clearButton_Click(object sender, EventArgs e)
        {
<<<<<<< Updated upstream
            FormCanvas.Clear();
=======
            Canvas.Clear();
>>>>>>> Stashed changes
            Refresh();
        }

        private void outputCanvas_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics;
            g.DrawImageUnscaled(FormCanvas.outputBitmap, 0, 0);
        }

    }
}