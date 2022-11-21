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

        /// <summary>
        /// CheckSyntax Method
        /// 
        /// this method checks the syntax of the given text by comparing it to an array of pre defined commands.
        /// </summary>
        /// <param name="text"></param>
        /// <returns></returns>
        public bool CheckSyntax(string text)
        {
            // splits the text by the new line
            String[] commandLine = text.ToLower().Split("\n");
            String[] arrayOfCommands = { "moveto", "circle", "rectangle", "drawto" , "reset","pen" };
            String[] wholeCommand;
            String command;
            bool check = false;

            if (commandLine.Length > 1)
            {
                for (int i = 0; i < commandLine.Length; i++)
                {
                    // splits the commandLine by space to find the command
                    wholeCommand = commandLine[i].Split(' ');
                    command = wholeCommand[0];

                    // checks the command spelling against the predefined list of commnands
                    if (arrayOfCommands.Contains(command))
                    {
                        check = true;
                    } else if (!arrayOfCommands.Contains(command)) 
                    {
                        // breaks the loop if found false
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
            // returns the boolean check value to the form allowing for the log output 
            return check;
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
            String[] wholeCommand;
            String command;
            int x, y;
           
            
            if (commandLine.Length > 1)
            {
                for (int i = 0; i < commandLine.Length; i++)
                {
                    // splits by space and assigns to string
                    wholeCommand = commandLine[i].Split(' ');
                    command = wholeCommand[0];

                    //trys the command against the pre defined commands and sends to canvas with parameters
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
                        else if (command.Equals("rectangle"))
                        {
                            x = int.Parse(wholeCommand[1]);
                            y = int.Parse(wholeCommand[2]);

                            canvas.DrawRect(x,y);

                        }
                        else if (command.Equals("moveto"))
                        {
                            x = int.Parse(wholeCommand[1]);
                            y = int.Parse(wholeCommand[2]);
                            canvas.MoveCursor(x, y);
                        } else if (command.Equals("reset"))
                        {
                            canvas.MoveCursor(2, 2);
                        } else if (command.Equals("pen"))
                        {
                            canvas.ChangePen(wholeCommand[1]);
                        }
                    }
                    // catches if the parameters inputted cannot be parsed to Int32, causing a FormatException
                    catch
                    {
                        MessageBox.Show("Your parameters must contain numbers only!");
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
                    else if (command.Equals("rectangle"))
                    {
                        x = Int32.Parse(wholeCommand[1]);
                        y = Int32.Parse(wholeCommand[2]);

                        canvas.DrawRect(x,y);

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
                    } else if (command.Equals("pen"))
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
