using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp
{

    /// <summary>Class SyntaxChecker is to hold the methods that <see cref="CheckSyntax" /> within the program</summary>
    public class SyntaxChecker
    {
        /// <summary>
        /// CheckSyntax Method
        /// 
        /// this method checks the syntax of the given text by comparing it to an array of pre defined commands.
        /// </summary>
        /// <param name="text"></param>
        /// <returns>the check returned from this method simple defines if the syntax of the commands is correct or now
        /// allowing the program to continue through runtime.</returns>
        public bool CheckSyntax(string text)
        {
            // splits the text by the new line
            String[] commandLine = text.ToLower().Split("\n");
            String[] arrayOfCommands = { "moveto", "circle", "rectangle", "triangle", "drawto", "reset", "pen", "var", "loop", "end" , "=" , "fill" , "method", "meth" ,"call"};
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
                    }
                    else if (wholeCommand[1].Contains("="))
                    {
                        check = true;
                    } else
                    {
                        check = false;
                    }
                }

            }
            else if (commandLine.Length.Equals(1))
            {

                wholeCommand = commandLine[0].Split(' ');
                command = wholeCommand[0];

                if (arrayOfCommands.Any(command.Equals))
                {
                    check = true;
                }
                else if (arrayOfCommands.Any(command!.Equals))
                {
                    check = false;
                }
            }
            // returns the boolean check value to the form allowing for the log output 
            return check;
        }
    }
}
