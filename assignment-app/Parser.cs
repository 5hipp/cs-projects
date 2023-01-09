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
        SyntaxChecker syntaxChecker;
        public Parser(Canvas canvas)
        {
            this.canvas = canvas;
            this.syntaxChecker = new SyntaxChecker();
        }

        /// <summary>
        /// Parse Method
        /// 
        /// the parse method splits the given text into its parameters and commands, then forwards these to the canvas class to be drawn to the screen
        /// there is a try catch system to prevent invalid parameters being parsed.
        /// </summary>
        /// <param name="text"></param>
        /// <exception cref="FormatException"></exception>
        public void Parse(string text)
        {  
            // splits the input by line
            String[] commandLine = text.ToLower().Split("\n");
            String[] wholeCommandArray;
            String command;
            int x, y;

            if (syntaxChecker.CheckSyntax(text))
            {
                if (commandLine.Length > 1)
                {
                    for (int i = 0; i < commandLine.Length; i++)
                    {
                        // splits by space and assigns to string
                        wholeCommandArray = commandLine[i].Split(' ');
                        command = wholeCommandArray[0];

                        //trys the command against the pre defined commands and sends to canvas with parameters
                        try
                        {
                            if (command.Equals("drawto"))
                            {
                                x = int.Parse(wholeCommandArray[1]);
                                y = int.Parse(wholeCommandArray[2]);

                                canvas.DrawLine(x, y);

                            }
                            else if (command.Equals("circle"))
                            {
                                x = int.Parse(wholeCommandArray[1]);

                                canvas.DrawCircle(x);

                            }
                            else if (command.Equals("rectangle"))
                            {
                                x = int.Parse(wholeCommandArray[1]);
                                y = int.Parse(wholeCommandArray[2]);

                                canvas.DrawRect(x, y);

                            }
                            else if (command.Equals("moveto"))
                            {
                                x = int.Parse(wholeCommandArray[1]);
                                y = int.Parse(wholeCommandArray[2]);
                                canvas.MoveCursor(x, y);
                            }
                            else if (command.Equals("reset"))
                            {
                                canvas.MoveCursor(2, 2);
                            }
                            else if (command.Equals("pen"))
                            {
                                canvas.ChangePen(wholeCommandArray[1]);
                            }
                        }
                        // catches if the parameters inputted cannot be parsed to Int32, causing a FormatException
                        catch
                        {
                            MessageBox.Show("Your parameters must contain numbers only!");
                        }


                    }

                }
            } else
            {
                // call dialog box creation class for creating an error message.
            }
        }

        public void singleParse(string text)
        {
            String[] commandLine = text.ToLower().Split("\n");
            String[] wholeCommand;
            String command;
            int x, y;

            if (syntaxChecker.CheckSyntax(text))
            {
                if (commandLine.Length == 1)
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
                        else if (command.Equals("rectangle"))
                        {
                            x = Int32.Parse(wholeCommand[1]);
                            y = Int32.Parse(wholeCommand[2]);

                            canvas.DrawRect(x, y);

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
                        else if (command.Equals("pen"))
                        {
                            canvas.ChangePen(wholeCommand[1]);
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
}
