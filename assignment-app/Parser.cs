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
            
            canvas.DrawLine(100, 100);
            /*String[] commandLine = text.Split("\n");
            string command;
            int[] parametersInt = { 0, 0, 0, 0 };

            if (commandLine.Length > 0)
            {
                command = commandLine[0];
                string[] parameters = commandLine[0].Split(" ");
                for (int i = 0; i < parameters.Length; i++)
                {
                    parametersInt[i] = int.Parse(parameters[i]);
                }
            }
            else
            {
                command = commandLine[0];
                int parameter = int.Parse(commandLine[1]);
            } */
        }

    }
}
