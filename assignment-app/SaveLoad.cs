using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp
{
    public class SaveLoad
    {
        public void Save(string text)
        {
            var SaveFileDialog = new SaveFileDialog
            {
                FileName = "program.txt",
                Filter = @"Text File | *.txt"
            };

            if (SaveFileDialog.ShowDialog() != DialogResult.OK)
            {
                return;
            }

            var writer = new StreamWriter(SaveFileDialog.OpenFile());

            WriteToFile(writer, text);
        }

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

    }
      
}
