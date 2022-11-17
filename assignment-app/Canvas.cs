﻿using System;
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
        Pen Pen, cursorPen;
        float cursorX, cursorY;

        public Canvas(Graphics g)
        {
            this.g = g;

            Pen = new Pen(Color.White,1);
        }

        public Canvas() { }

        public void Clear()
        {
            
            g.Clear(Color.Silver);
        }

        public void DrawLine(int x, int y)
        {
            //drawing the line using the current pen, x and y positions to the given x and y positions
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

<<<<<<< Updated upstream
        public void DrawTriangle()
=======
        public void DrawSquare(float length)
>>>>>>> Stashed changes
        {
           /// g.DrawPolygon(Pen, cursorX, cursorX+10);
        }

<<<<<<< Updated upstream
        public void MoveCursor(int x, int y)
=======
        public void DrawCircle(float radius)
>>>>>>> Stashed changes
        {
            cursorPen = new Pen(Color.Red, 5);
            this.cursorX = x;
            this.cursorY = y;
            g.DrawEllipse(Pen, x-5, y-5, 10, 10);
        }

    }
}
