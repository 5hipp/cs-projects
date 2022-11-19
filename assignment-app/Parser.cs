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

        public bool CheckSyntax(string text)
        {
            String[] commandLine = text.ToLower().Split("\n");
            String[] arrayOfCommands = { "moveto", "circle", "square", "drawto" , "reset" };
            String[] wholeCommand;
            String command;
            bool check = false;

            if (commandLine.Length > 1)
            {
                for (int i = 0; i < commandLine.Length; i++)
                {
                    wholeCommand = commandLine[i].Split(' ');
                    command = wholeCommand[0];

                    if (arrayOfCommands.Contains(command))
                    {
                        check = true;
                    } else if (!arrayOfCommands.Contains(command)) 
                    {
                        check = false;
                        break;
                    }
                }

            } else if (commandLine.Length.Equals(1)) {

                wholeCommand = commandLine[0].Split(' ');
                command = wholeCommand[0];

                if (arrayOfCommands.Any(command.Equals))
                {
                    check = true;
                } else if (arrayOfCommands.Any(command!.Equals)) 
                {
                    check = false;
                }
            }
            return check;
        }

        public void Parse(string text)
        {  
            String[] commandLine = text.ToLower().Split("\n");
            String[] wholeCommand;
            String command;
            int x, y;

            if (commandLine.Length > 1)
            {
                for (int i = 0; i < commandLine.Length; i++)
                {
                    wholeCommand = commandLine[i].Split(' ');
                    command = wholeCommand[0];

                    try
                    {
                        if (command.Equals("drawto"))
                        {
                            x = int.Parse(wholeCommand[1]);
                            y = int.Parse(wholeCommand[2]);
                            canvas.DrawLine(x, y);

                        }
                        else if (command.Equals("circle"))
                        {
                            x = int.Parse(wholeCommand[1]);

                            canvas.DrawCircle(x);

                        }
                        else if (command.Equals("square"))
                        {
                            x = int.Parse(wholeCommand[1]);

                            canvas.DrawSquare(x);

                        }
                        else if (command.Equals("moveto"))
                        {
                            x = int.Parse(wholeCommand[1]);
                            y = int.Parse(wholeCommand[2]);
                            canvas.MoveCursor(x, y);
                        } else if (command.Equals("reset"))
                        {
                            canvas.MoveCursor(2, 2);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Your parameters must contain numbers only!");
                        throw new FormatException("Incorrect Parameter");
                    }

                    
                }

            } else if (commandLine.Length == 1)
            {
                wholeCommand = commandLine[0].Split(" ");
                command = wholeCommand[0];

                try
                {
                    if (command.Equals("drawto"))
                    {
                        x = Int32.Parse(wholeCommand[1]);
                        y = Int32.Parse(wholeCommand[2]);
                        canvas.DrawLine(x, y);

                    }
                    else if (command.Equals("circle"))
                    {
                        x = Int32.Parse(wholeCommand[1]);

                        canvas.DrawCircle(x);

                    }
                    else if (command.Equals("square"))
                    {
                        x = Int32.Parse(wholeCommand[1]);

                        canvas.DrawSquare(x);

                    }
                    else if (command.Equals("moveto"))
                    {
                        x = Int32.Parse(wholeCommand[1]);
                        y = Int32.Parse(wholeCommand[2]);
                        canvas.MoveCursor(x, y);
                    }                    
                    else if (command.Equals("reset"))
                    {
                        canvas.MoveCursor(2, 2);
                    }
                }
                catch
                {
                    MessageBox.Show("Your parameters must contain numbers only!");
                }

                
            }

        }

    }
}
