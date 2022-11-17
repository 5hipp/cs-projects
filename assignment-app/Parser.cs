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
    internal class Parser
    {
        internal static string Parse(string text)
        {
<<<<<<< HEAD

        }


        public void Parse(string text)
        {
=======
>>>>>>> parent of b5aa1ce (further implementation of parser)
            String[] commandLine = text.Split(" ");
            string command;
            int[] parametersInt = {0,0,0,0};

            if (commandLine.Length > 0)
            {
                command = commandLine[0];
                string[] parameters = commandLine[1].Split(",");
                for (int i = 0; i < parameters.Length; i++)
                {
                    parametersInt[i] = int.Parse(parameters[i]);
                }
            } else
            {
                command = commandLine[0];
                int parameter = int.Parse(commandLine[1]);
            }

            if (command.Equals("moveto")==true)
            {
<<<<<<< HEAD
                canvas.DrawLine(parametersInt[0], parametersInt[1]);
            } 
=======
                Canvas Canvas = new Canvas();
                Canvas.MoveCursor(parametersInt[0], parametersInt[1]);
            }
            
            return text;
>>>>>>> parent of b5aa1ce (further implementation of parser)
        }
    }
}
