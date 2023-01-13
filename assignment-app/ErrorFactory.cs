using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp
{
    public class ErrorFactory
    {
        public ErrorFactory() { 
            
        }

        public void ErrorHandle(string error, string type)
        {
            MessageBox.Show(
                "Error: " + error,
                type + " Error",
                MessageBoxButtons.OK,
                MessageBoxIcon.Warning 
            );
            
        }
    }
}
