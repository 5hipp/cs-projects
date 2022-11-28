using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WindowsFormsApp1
{
    class Parser
    {
        public String[] Parse(string text)
        {
            String[] commandLine = text.Trim().Split('\n');
            List<string> list = new List<string>();


            for (int i = 0; i < commandLine.Length; i++)
            {
                if (commandLine[i].Contains(@"/1/")) {
                    String newLine = commandLine[i];
                    list.Add(newLine);
                } else { }
            }

            String[] str = list.ToArray();

            return str;
            
        }
    }
}
