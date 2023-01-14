using System;
using System.Collections.Generic;
using System.DirectoryServices.ActiveDirectory;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp
{
    public class SyntaxChecker
    {
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
            String[] arrayOfCommands = { "moveto", "circle", "rectangle", "drawto", "reset", "pen", "var", "loop", "end" , "=" };
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
