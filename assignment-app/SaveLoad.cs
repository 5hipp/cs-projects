using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Windows.Forms.VisualStyles;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;

namespace AssignmentApp
{
    /// <summary>The <see cref="SaveLoad" /> class houses the Saving and Loading methods, allowing for the extraction and insertion of code from a file into the program.</summary>
    public class SaveLoad
    {
        /// <summary>Saves the specified text.</summary>
        /// <param name="text">The text.</param>
        public void Save(string text)
        {
            // creates a windows save dialog with the predeinfed file name and type
            var SaveFileDialog = new SaveFileDialog
            {
                FileName = "program.txt",
                Filter = @"Text File | *.txt"
            };

            if (SaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }
            // writes to the file that is being saved the contents of the inputted text
            var writer = new StreamWriter(SaveFileDialog.OpenFile());

            WriteToFile(writer, text);
        }

        /// <summary>Writes to file.</summary>
        /// <param name="writer">The writer.</param>
        /// <param name="text">The text.</param>
        /// <exception cref="System.IO.IOException">An error occured while saving the prgram to the file system: {e.Message}</exception>
        internal void WriteToFile(StreamWriter writer, string text)
        {
            try
            {
                text.Split('\n')
                    .ToList()
                    .ForEach(writer.WriteLine);
            }
            catch (Exception e)
            {
                throw new IOException($"An error occured while saving the prgram to the file system: {e.Message}");
            }
            finally
            {
                writer.Dispose();
                writer.Close();
            }
        }

        /// <summary>Loads the specified text.</summary>
        /// <param name="text">The text.</param>
        public string Load()
        {
            Stream myStream = null;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();
            string fileContents;

            openFileDialog1.Filter = "txt files (*.txt)|*.txt|All files (*.*)|*.*";
            openFileDialog1.FilterIndex = 2;
            openFileDialog1.RestoreDirectory = true;

            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    if ((myStream = openFileDialog1.OpenFile()) != null)
                    {
                        using (myStream)
                        {
                            fileContents = File.ReadAllText(openFileDialog1.FileName);
                            return fileContents;
                        }
                    }
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Error: Could not read file from disk. Original error: " + ex.Message);
                }
            }
            return null;
        }
    }
      
}
