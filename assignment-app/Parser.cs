using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

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

        string[] variableNames = { "", "", "" , "", ""};
        int[] variableValues = { 0, 1, 2, 3, 4 };
        int variableCounter = 0;

        public void Parse(string text)
        {
            // splits the input by line
            string[] commandLine = text.ToLower().Split("\n");
            string[] wholeCommandArray = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            string command;
            string parameter;
            string secondParameter;
            int x, y;
            int programCounter = 0;
            int loopCounter = 0;
            int iterations = 0;
            int loopSize = 0;
            bool check = false;
            bool loopFlag = false;
            bool executeLinesFlag = true;

            if (commandLine.Length > 0) { 

                for (int i = 0; i < commandLine.Length; i++)
                {
                    programCounter++;
                    // splits by space and assigns to string
                    wholeCommandArray = commandLine[i].Split(' ');

                    command = wholeCommandArray[0];
                    parameter = wholeCommandArray[1];
                   
                    if (executeLinesFlag.Equals(false)) 
                        continue;

                    //declaring the variable
                    if (command == "var")
                    {
                        int found = checkVariables(command);
                        if (found >= 0)
                        {
                            //report syntax error variable already declared
                        }
                        else
                        {
                            variableNames[variableCounter] = parameter;
                            variableValues[variableCounter++] = 0;                               
                        }   
                    }
                 
                    if (parameter == "=")
                    {
                        int found = checkVariables(command);
                        if (found >= 0)
                        {
                            variableNames[found] = command;
                            variableValues[found] = Int32.Parse(wholeCommandArray[2]);
                        }
                        else
                        {
                            //report syntax error variable not declared
                        }
                    }

                    if (command == "loop")
                    {
                        iterations = Int32.Parse(parameter);
                        loopFlag = true;
                        loopCounter = 0;
                        loopSize = 0;
                    }

                    if (command == "end")
                    {
                        loopFlag = false;
                        if (loopCounter++ < iterations)
                        {
                            programCounter = programCounter - loopSize;
                        }
                    }

                    if (loopFlag == true)
                    {
                        loopSize++;
                    }

                    if (command == "drawto")
                    {
                        try
                        {
                            Int32.Parse(parameter);
                            check = true;
                        }
                        catch
                        {
                            check = false;
                        }

                        if (check)
                        {
                            x = Int32.Parse(parameter);
                            y = Int32.Parse(wholeCommandArray[2]);
                            canvas.DrawLine(x, y);
                        }
                        else
                        {
                            int found = checkVariables(parameter);
                            int found2 = checkVariables(wholeCommandArray[2]);
                            if (found >= 0)
                            {
                                if (found2 >= 0)
                                {
                                    x = variableValues[found];
                                    y = variableValues[found2];
                                    canvas.DrawLine(x, y);
                                }
                            }
                        }
                    }



                    if (command == "circle")
                    {
                        try
                        {
                            Int32.Parse(parameter);
                            check = true;
                        }
                        catch
                        {
                            check = false;
                        }

                        if (check)
                        {
                            x = Int32.Parse(parameter);
                            canvas.DrawCircle(x);
                        } else
                        {
                            int found = checkVariables(parameter);
                            if (found >= 0)
                            {
                                x = variableValues[found];
                                canvas.DrawCircle(x);
                            }
                        }
                    }

                    if (command == "rectangle")
                    {
                        x = Int32.Parse(parameter);
                        y = Int32.Parse(wholeCommandArray[2]);
                        canvas.DrawRect(x, y);
                    }

                    if (command == "moveto")
                    {
                        x = Int32.Parse(parameter);
                        y = Int32.Parse(wholeCommandArray[2]);
                        canvas.MoveCursor(x, y);
                    }

                    if (command == "reset")
                    {
                        canvas.MoveCursor(2, 2);
                    }

                    if (command == "pen")
                    {
                        canvas.ChangePen(parameter);
                    }

                }

            }
        }

        public int checkVariables(string name)
        {
            for (int i = 0; i<variableCounter; i++)
            {
                if (variableNames[i] == name)
                    return i;
            }
            return -1;
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
