using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml;
using System.Xml.Schema;

namespace AssignmentApp
{
    public class Canvas
    {
        Graphics g;
        public Bitmap outputBitmap = new Bitmap(640, 480);
        Pen Pen, cursorPen;
        float cursorX, cursorY = 0;

        public Canvas()
        {
            this.g = Graphics.FromImage(outputBitmap);
            Pen = new Pen(Color.White, 1);
            cursorPen = new Pen(Color.Red, 5);
        }

        public void Clear()
        { 
            g.Clear(Color.Silver);
        }

        public void MoveCursor(float x, float y)
        {
            g.DrawEllipse(Pen, x/2, y/2, x, y);
            this.cursorX = x;
            this.cursorY = y;

        }

        public void DrawLine(float x, float y)
        {
            g.DrawLine(Pen, cursorX, cursorY, x, y);
            this.cursorX = x;
            this.cursorY = y;
        }

        public void DrawSquare(float length)
        {
            g.DrawRectangle(Pen, cursorX - length/2, cursorY - length/2, length, length);
        }

        public void DrawCircle(float radius)
        {
           g.DrawEllipse(Pen, cursorX -radius/2, cursorY - radius/2, radius, radius);
        }

    }
}
