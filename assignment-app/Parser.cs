using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection.Metadata;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;
using System.Xml.Linq;
using static System.Net.Mime.MediaTypeNames;

namespace AssignmentApp
{

    /// <summary>Class Parser is to parse information from the main form to useable code.<br /></summary>
    public class Parser
    {
        Canvas canvas;
        SyntaxChecker syntaxChecker;
        ErrorFactory errorFactory;
        DataTable dt;

        /// <summary>Initializes a new instance of the <see cref="Parser" /> class and new instances of the other classes for use in the <see cref="Parser" /></summary>
        /// <param name="canvas">The canvas.</param>
        public Parser(Canvas canvas)
        {
            this.canvas = canvas;
            this.dt = new DataTable();
            this.errorFactory = new ErrorFactory();
            this.syntaxChecker = new SyntaxChecker();
        }



        // the variable arrays must be defined outside the parse method as the checkVariables method must also access it
        public string[] variableNames = { "", "", "" , "", ""};
        public int[] variableValues = { 0, 1, 2, 3, 4 };
        public int variableCounter = 0;
        public string[] methodNames = { "", "", "", "", "", "" };
        public int[] methodLocation = { 0, 0, 0, 0, 0, 0, 0 };
        public int methodCounter = 0;
        public int programCounter = 0;

        /// <summary>Parses the specified text.</summary>
        /// the parse method splits the given text into its parameters and commands, then forwards these to the canvas class to be drawn to the screen
        /// there is a try catch system to prevent invalid parameters being parsed.
        /// <param name="text">The text.</param>
        public void Parse(string text)
        {
            // splits the input by line
            string[] commandLine = text.ToLower().Split("\n");
            string[] wholeCommandArray = { "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "", "" };
            char[] delimiterChar = { '+', '-', '*', '/' };
            string command;
            string parameter;
            string secondParameter;
            int x, y;
            int loopCounter = 0;
            int iterations = 0;
            int loopSize = 0;
            int saveProgramCounter = 0;
            bool check = false;
            bool loopFlag = false;
            bool methodFlag = false;
            bool methodExecuting = false;
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

                        if (command == "meth" && methodExecuting == false)
                        {
                            methodFlag = false;
                        }

                        if (command == "meth" && methodExecuting == true)
                        {
                            methodExecuting = false;
                            programCounter = saveProgramCounter;
                            continue;
                        }

                        if (methodFlag.Equals(true))
                            continue;

                        if (executeLinesFlag.Equals(false))
                            continue;

                        //delcaring the method and its location
                        if (command == "method".Trim().ToLower())
                        {
                            methodNames[methodCounter] = parameter;
                            methodLocation[methodCounter++] = programCounter;
                            methodFlag = true;
                        }

                        if (command == "meth" && methodExecuting == false)
                        {
                            methodFlag = false;
                        }
                        

                        if (command == "meth" && methodExecuting == true)
                        {
                            methodExecuting = false;
                            programCounter = saveProgramCounter;
                            continue;
                        }

                        if (command == "call")
                        {
                            int found = checkMethod(parameter);
                            if (found >= 0)
                            {
                                saveProgramCounter = programCounter + 1;
                                programCounter = methodLocation[found];
                                methodExecuting= true;
                                continue;
                            } else
                            {
                                errorFactory.ErrorHandle("no such method found on line: " + programCounter + "\nPlease create the method first.", "Syntax");
                            }
                        }

                        //declaring the variable
                        if (command == "var".Trim().ToLower())
                        {
                            int found = checkVariables(parameter);
                            if (found >= 0)
                            {
                                // errors are being passed out to a class that handles each error using a template
                                errorFactory.ErrorHandle("variable already declared, please change the name of the duplicate variable.", "Syntax");
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

                        /// the following statement is responsible for handling each of the varible assignment methods.
                        if (parameter == "=")
                        {
                            int found = checkVariables(command);
                            if (found >= 0)
                            {
                                variableNames[found] = command;

                                /// if the assignment can be immediately computed without need for variable finding then that is done here
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
                                        /// the following statements handle each of the types of math assignment that can be done.
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
                                    else
                                    {
                                        errorFactory.ErrorHandle("variable declared not as an integer on line:" + programCounter + "\nPlease change to an integer to continue", "Format");
                                    }
                                }

                            }
                            else
                            {
                                errorFactory.ErrorHandle("variable not declared on line:"+programCounter+"\nPlease declare the variable before continuing.", "Syntax");
                                //canvas.Clear();
                            }
                        }

                        if (command == "loop".Trim().ToLower())
                        {
                            /// this small series of try catch and if statments simply check if the parameter after the command is parsable as an integer
                            /// if so the command will be ran with the parameter unchanged, if not the value is deemed as a variable that has been previously assigned
                            /// and so it is passed through to be checked and have its value returned.
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

                        if (command == "end".Trim().ToLower())
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

                        if (command == "drawto".Trim().ToLower())
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

                        if (command == "fill".Trim().ToLower())
                        {
                            bool toggle = false;

                            if (parameter == "enable".Trim().ToLower())
                            {
                                toggle = true;
                                canvas.enableFill(toggle);
                            } else if (parameter == "disable".Trim().ToLower())
                            {
                                toggle = false;
                                canvas.enableFill(toggle);
                            } else
                            {
                                errorFactory.ErrorHandle("you have typed an incorrect option on line: " + programCounter + " \nPlease chose either Enable or Disable", "Syntax");
                            }
                        }

                        if (command == "circle".Trim().ToLower())
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

                        if (command == "triangle".Trim().ToLower())
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
                                canvas.DrawTriangle(x);
                            }
                            else
                            {
                                int found = checkVariables(parameter);
                                if (found >= 0)
                                {
                                    x = variableValues[found];
                                    canvas.DrawTriangle(x);
                                }
                            }
                        }

                        if (command == "rectangle".Trim().ToLower())
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

                        if (command == "moveto".Trim().ToLower())
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

                        if (command == "reset".Trim().ToLower())
                        {
                            canvas.MoveCursor(2, 2);
                        }

                        if (command == "pen".Trim().ToLower())
                        {
                            canvas.ChangePen(parameter);
                        }

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
        /// if the variable is not being stored in the array the method will return -1 to indicate that its available.
        /// </summary>
        /// <param name="name">this name string is the varible name needing to be checked</param>
        /// <returns>the method returns an integer to indicate whether or not the variable was found and if so its location in the respective arrays.</returns>
        public int checkVariables(string name)
        {
            for (int i = 0; i<variableCounter; i++)
            {
                if (variableNames[i] == name)
                    return i;
            }
            return -1;
        }
        public int checkMethod(string name)
        {
            for (int i = 0; i < methodCounter; i++)
            {
                if (methodNames[i] == name)
                    return i;
            }
            return -1;
        }

        /// <summary>
        /// this parse method is an altered version of the above parse method for single line use only.
        /// this method is simplified in a sense that it will only need to handle single commands rather than loops or variables.
        /// </summary>
        /// <param name="text">this string is the inbound text from Form1's commandLineTextBox</param>
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
                        if (command.Equals("drawto".Trim().ToLower()))
                        {
                            x = Int32.Parse(wholeCommand[1]);
                            y = Int32.Parse(wholeCommand[2]);
                            canvas.DrawLine(x, y);

                        }
                        else if (command.Equals("circle".Trim().ToLower()))
                        {
                            x = Int32.Parse(wholeCommand[1]);

                            canvas.DrawCircle(x);

                        }
                        else if (command.Equals("triangle".Trim().ToLower()))
                        {
                            x = Int32.Parse(wholeCommand[1]);

                            canvas.DrawTriangle(x);

                        }
                        else if (command.Equals("rectangle".Trim().ToLower()))
                        {
                            x = Int32.Parse(wholeCommand[1]);
                            y = Int32.Parse(wholeCommand[2]);

                            canvas.DrawRect(x, y);

                        }
                        else if (command.Equals("moveto".Trim().ToLower()))
                        {
                            x = Int32.Parse(wholeCommand[1]);
                            y = Int32.Parse(wholeCommand[2]);
                            canvas.MoveCursor(x, y);
                        }
                        else if (command.Equals("reset".Trim().ToLower()))
                        {
                            canvas.MoveCursor(2, 2);
                        }
                        else if (command.Equals("pen".Trim().ToLower()))
                        {
                            canvas.ChangePen(wholeCommand[1]);
                        }
                        else if (command.Equals("clear".Trim().ToLower()))
                        {
                            for (int i = 0; i < variableCounter; i++)
                            {
                                variableNames[i] = "";
                                variableValues[i] = 0;
                            }
                        } else if (command == "fill".Trim().ToLower())
                        {
                            bool toggle = false;

                            if (wholeCommand[1] == "enable".Trim().ToLower())
                            {
                                toggle = true;
                                canvas.enableFill(toggle);
                            }
                            else if (wholeCommand[1] == "disable".Trim().ToLower())
                            {
                                toggle = false;
                                canvas.enableFill(toggle);
                            }
                            else
                            {
                                errorFactory.ErrorHandle("you have typed an incorrect option\nPlease chose either Enable or Disable", "Syntax");
                            }
                        }
                    }
                    catch
                    {
                        errorFactory.ErrorHandle("the parameters in the command box must only contain numbers, please use the input box above if you wish to use variables.", "Syntax");
                    }
                }
            } else
            {
                errorFactory.ErrorHandle("Syntax Error \nPlease address before continuing", "Syntax");

            }
        }
        /// <summary>
        /// Clears the names values and positions for variables and methods within the instance.
        /// </summary>
        public void Clear()
        {
            for (int i = 0; i < variableCounter; i++)
            {
                variableNames[i] = "";
                variableValues[i] = 0;
            }
            variableCounter = 0;
            for (int i = 0; i < methodCounter; i++)
            {
                methodNames[i] = "";
                methodLocation[i] = 0;
            }
            methodCounter = 0;
        }
    }
}
