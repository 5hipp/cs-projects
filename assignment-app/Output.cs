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
        int xPos, yPos;

        public Canvas(Graphics g)
        {
            this.g = g;

            xPos = yPos = 0;

            Pen = new Pen(Color.White,1);
        }

        public void DrawLine(int toX, int toY)
        {
            //drawing the line using the current pen, x and y positions to the given x and y positions
            g.DrawLine(Pen, xPos, yPos, toX, toY);

            // once the drawing has been completed, the new x and y positions will be updated
            xPos = toX;
            yPos = toY;
        }

        public void DrawSquare(int size)
        {
            g.DrawRectangle(Pen, xPos, yPos, xPos + size, yPos + size);
        }
    }
}
