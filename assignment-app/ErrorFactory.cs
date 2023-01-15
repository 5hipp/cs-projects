using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp
{
    /// <summary>
    ///   <br />
    /// </summary>
    public class ErrorFactory
    {
        /// <summary>Initializes a new instance of the <see cref="ErrorFactory" /> class.</summary>
        public ErrorFactory() { 
            
        }

        /// <summary>formats user errors into a readble item without causing application crashes.</summary>
        /// <param name="error">The error.</param>
        /// <param name="type">The type.</param>
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
