using System;
using System.Collections.Generic;
using System.Data;
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
        ErrorFactory errorFactory;
        DataTable dt;
        public Parser(Canvas canvas)
        {
            this.canvas = canvas;
            this.dt = new DataTable();
            this.errorFactory = new ErrorFactory();
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

        // the variable arrays must be defined outside the parse method as the checkVariables method must also access it
        string[] variableNames = { "", "", "" , "", ""};
        int[] variableValues = { 0, 1, 2, 3, 4 };
        int variableCounter = 0;

        public void Parse(string text)
        {
            // splits the input by line
            string[] commandLine = text.ToLower().Split("\n");
            string[] wholeCommandArray = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            char[] delimiterChar = { '+', '-', '*', '/' };
            string command;
            string parameter;
            string secondParameter;
            int x, y, z;
            int programCounter = 0;
            int loopCounter = 0;
            int iterations = 0;
            int loopSize = 0;
            bool check = false;
            bool loopFlag = false;
            bool executeLinesFlag = true;

            if (syntaxChecker.CheckSyntax(text))
            {
                if (commandLine.Length > 0)
                {

                    // this for loop keeps the current line number as a program counter so it can be referenced 
                    // and altered during the program by loops.
                    for (programCounter = 0; programCounter < commandLine.Length; programCounter++)
                    {
                        // splits by space and assigns to string
                        wholeCommandArray = commandLine[programCounter].Split(' ');

                        command = wholeCommandArray[0];
                        parameter = wholeCommandArray[1];

                        if (executeLinesFlag.Equals(false))
                            continue;

                        //declaring the variable
                        if (command == "var")
                        {
                            int found = checkVariables(parameter);
                            if (found >= 0)
                            {
                                // errors are being passed out to a class that handles each error using a template
                                //errorFactory.ErrorHandle("variable already declared, please change the name of the duplicate variable.", "Syntax");
                                //canvas.Clear(); 
                            }
                            else
                            {
                                //if the variable doesn't already exist, it is created in the variable names array 
                                //and its position in the variable values array is initialised.
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
                                try
                                {
                                    try
                                    {
                                        variableValues[found] = (int)dt.Compute(wholeCommandArray[2], "");
                                    }
                                    catch (System.Data.EvaluateException)
                                    {
                                        secondParameter = wholeCommandArray[2];
                                        string[] computeArray = secondParameter.Split(delimiterChar);
                                        int found2 = checkVariables(computeArray[0]);
                                        if (found2 >= 0)
                                        {
                                            if (wholeCommandArray[2].Contains("+"))
                                            {
                                                variableValues[found] = Int32.Parse(computeArray[1]) + variableValues[found2];
                                            }
                                            if (wholeCommandArray[2].Contains("-"))
                                            {
                                                variableValues[found] = Int32.Parse(computeArray[1]) - variableValues[found2];
                                            }
                                            if (wholeCommandArray[2].Contains("*"))
                                            {
                                                variableValues[found] = Int32.Parse(computeArray[1]) * variableValues[found2];
                                            }
                                            if (wholeCommandArray[2].Contains("/"))
                                            {
                                                variableValues[found] = Int32.Parse(computeArray[1]) / variableValues[found2];
                                            }
                                        }
                                    }
                                }
                                catch (System.FormatException)
                                {
                                    errorFactory.ErrorHandle("variable declared as string not integer on line:"+programCounter+"\nPlease change to an integer to continue", "Format");
                                }
                            }
                            else
                            {
                                errorFactory.ErrorHandle("variable not declared on line:"+programCounter+"\nPlease declare the variable before continuing.", "Syntax");
                                //canvas.Clear();
                            }
                        }

                        if (command == "loop")
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
                                iterations = Int32.Parse(parameter);
                            }
                            else
                            {
                                int found = checkVariables(parameter);
                                if (found >= 0)
                                {
                                    iterations = variableValues[found];
                                }
                            }
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
                            }
                            else
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
                                canvas.DrawRect(x, y);
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
                                        canvas.DrawRect(x, y);
                                    }
                                }
                            }
                        }

                        if (command == "moveto")
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
                                canvas.MoveCursor(x, y);
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
                                        canvas.MoveCursor(x, y);
                                    }
                                }
                            }
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
                    for (int i = 0; i < variableCounter; i++)
                    {
                        variableNames[i] = "";
                        variableValues[i] = 0;
                    }
                }
            } else
            {
                errorFactory.ErrorHandle("Syntax Error on line: " + programCounter + "\nPlease address before continuing","Syntax");
            }
        }

        /// <summary>
        /// this method uses a for loop to check that the variable being used in the context
        /// is currently being stored in the variableNames array, if it is the location of it will be returned.
        /// 
        /// if the variable is not being stored in the array the method will return -1 to indicate that its available.
        /// </summary>
        /// <param name="name"></param>
        /// <returns></returns>
        public int checkVariables(string name)
        {
            for (int i = 0; i<variableCounter; i++)
            {
                if (variableNames[i] == name)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// this parse method is an altered version of the above parse method for single line use only. 
        /// this method is simplified in a sense that it will only need to handle single commands rather than loops or variables.
        /// 
        /// </summary>
        /// <param name="text"></param>
        public void singleParse(string text)
            {
                //the program is read through and split on each new line into the array
                String[] commandLine = text.ToLower().Split("\n");
                String[] wholeCommand;
                String command;
                int x, y;

                // the inputted command is checked for syntax errors from the syntax checker class.
                if (syntaxChecker.CheckSyntax(text))
                {
                    if (commandLine.Length == 1)
                    {
                        // the line is then seperated by the space in order to handle each part
                        wholeCommand = commandLine[0].Split(" ");
                        command = wholeCommand[0];

                        // then parsed to each individual draw method in the canvas class.
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
                            else if (command.Equals("clear"))
                            {
                                for (int i = 0; i < variableCounter; i++)
                                {
                                    variableNames[i] = "";
                                    variableValues[i] = 0;
                                }
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
