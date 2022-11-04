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
        public void DrawLine(int toX, int toY)
        {
            //drawing the line using the current pen, x and y positions to the given x and y positions
            g.DrawLine(Pen, cursorX, cursorY, toX, toY);

            // once the drawing has been completed, the new x and y positions will be updated
            cursorX = toX;
            cursorY = toY;
        }

        public void DrawSquare(int size)
        {
            g.DrawRectangle(Pen, cursorX, cursorY, cursorX + size, cursorY + size);
        }

        public void DrawCircle(int radius)
        {
           
        }
    }
}
