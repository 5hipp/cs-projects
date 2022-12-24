using AssignmentApp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AssignmentApp
{
    public class SingleLineParser
    {
        Canvas canvas;
        SyntaxChecker syntaxChecker;
        public SingleLineParser(Canvas canvas)
        {
            this.canvas = canvas;
            this.syntaxChecker = new SyntaxChecker();
        }
        public void Parse(string text)
        {
            // splits the input by line
            String[] commandLine = text.ToLower().Split("\n");
            String[] wholeCommand;
            String command;
            int x, y;

            if (syntaxChecker.CheckSyntax(text)) {
                if (commandLine.Length == 1)
                {
                    wholeCommand = commandLine[0].Split(" ");
                    command = wholeCommand[0];

                    try
                    {
                        if (command.Equals("drawto"))
                        {
                            x = Int32.Parse(wholeCommand[1]);
                            y = Int32.Parse(wholeCommand[2]);
                            canvas.DrawLine(x, y);

                        }
                        else if (command.Equals("circle"))
                        {
                            x = Int32.Parse(wholeCommand[1]);

                            canvas.DrawCircle(x);

                        }
                        else if (command.Equals("rectangle"))
                        {
                            x = Int32.Parse(wholeCommand[1]);
                            y = Int32.Parse(wholeCommand[2]);

                            canvas.DrawRect(x, y);

                        }
                        else if (command.Equals("moveto"))
                        {
                            x = Int32.Parse(wholeCommand[1]);
                            y = Int32.Parse(wholeCommand[2]);
                            canvas.MoveCursor(x, y);
                        }
                        else if (command.Equals("reset"))
                        {
                            canvas.MoveCursor(2, 2);
                        }
                        else if (command.Equals("pen"))
                        {
                            canvas.ChangePen(wholeCommand[1]);
                        }
                    }
                    catch
                    {
                        MessageBox.Show("Your parameters must contain numbers only!");
                    }
                }
            }
        }
    }
}
