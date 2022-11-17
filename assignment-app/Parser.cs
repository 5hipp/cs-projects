using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace AssignmentApp
{
    public class Parser
    {
        Canvas canvas;
        public Parser(Canvas canvas)
        {
            this.canvas = canvas;
        }

        public void Parse(string text)
        {
            
            String[] commandLine = text.Split("\n");
            String[] wholeCommand;
            String command;
            int x, y;

            if (commandLine.Length > 1)
            {
                for (int i = 0; i < commandLine.Length; i++)
                {
                    wholeCommand = commandLine[i].Split(' ');
                    command = wholeCommand[0];


                    if (command.Equals("line"))
                    {
                        x = int.Parse(wholeCommand[1]);
                        y = int.Parse(wholeCommand[2]);
                        canvas.DrawLine(x, y);

                    } else if (command.Equals("circle"))
                    {
                        x = int.Parse(wholeCommand[1]);

                        canvas.DrawCircle(x);

                    } else if (command.Equals("square"))
                    {
                        x = int.Parse(wholeCommand[1]);

                        canvas.DrawSquare(x);

                    } else if (command.Equals("moveto"))
                    {
                        x = int.Parse(wholeCommand[1]);
                        y = int.Parse(wholeCommand[2]);
                        canvas.MoveCursor(x, y);
                    }
                }

            } else if (commandLine.Length == 1)
            {
                command = commandLine[0];


                if (command.Equals("line"))
                {
                    x = Int32.Parse(commandLine[1]);
                    y = Int32.Parse(commandLine[2]);
                    canvas.DrawLine(x, y);

                }
                else if (command.Equals("circle"))
                {
                    x = Int32.Parse(commandLine[1]);

                    canvas.DrawCircle(x);

                }
                else if (command.Equals("square"))
                {
                    x = Int32.Parse(commandLine[1]);

                    canvas.DrawSquare(x);

                }
                else if (command.Equals("moveto"))
                {
                    x = Int32.Parse(commandLine[1]);
                    y = Int32.Parse(commandLine[2]);
                    canvas.MoveCursor(x, y);
                }
            }

        }

    }
}
