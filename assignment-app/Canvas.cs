using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml;

namespace AssignmentApp
{
    internal class Canvas
    {
        Graphics g;
        Pen Pen;
        int cursorX, cursorY;
        int cursorUpX, cursorUpY;

        public Canvas(Graphics g)
        {
            this.g = g;

            Pen = new Pen(Color.White,1);
        }

        public void SetCursorPos(int cursorX, int cursorY)
        {
            this.cursorX = cursorX;
            this.cursorY = cursorY;
        }
        public void SetSecondCursorPos(int cursorUpX, int cursorUpY)
        {
            this.cursorUpX = cursorUpX;
            this.cursorUpY = cursorUpY;
        }

        public void DrawLine()
        {
            //drawing the line using the current pen, x and y positions to the given x and y positions
            g.DrawLine(Pen, cursorX, cursorY, cursorUpX, cursorUpY);
       }

        public void DrawSquare(int length)
        {
            g.DrawRectangle(Pen, cursorX, cursorY, length, length);
        }

        public void DrawCircle(int radius)
        {
           g.DrawEllipse(Pen, cursorX, cursorY, radius, radius);
        }
    }
}
