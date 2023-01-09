using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp
{
    public class LoopCommand
    {
        
        public bool Loop(string text, int times)
        {
            int timesToLoop = times;
            string[] contentToLoop = text.Split(" ");
            string[] currentLine;

            for (int i = 0; i < contentToLoop.Length; i++)
            {
                currentLine = contentToLoop[i].Split(" ");


            }

            return true;
        }
    }
}
