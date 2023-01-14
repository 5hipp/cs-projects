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
        // Creation of bitmap and graphics variable, it is created here so that both the parser and form can reference the canvas commands.
        Graphics g;
        public Bitmap outputBitmap = new Bitmap(640, 720);
        Pen Pen, cursorPen, Eraser;
        public float cursorX, cursorY = 0;

        public Canvas()
        {
            this.g = Graphics.FromImage(outputBitmap);
            Pen = new Pen(Color.White, 1);
            cursorPen = new Pen(Color.Red, 2);
            Eraser = new Pen(Color.Silver, 2);
        }

        // Clears the current canvas do the default "silver" colour.
        public void Clear()
        {
            g.Clear(Color.Silver);

        }


        // Moves the cursor to the desired x and y coordinate.
        public void MoveCursor(int x, int y)
        {
            g.DrawEllipse(Eraser, cursorX, cursorY, 2, 2);
            g.DrawEllipse(cursorPen, x, y, 2, 2);
            this.cursorX = x;
            this.cursorY = y;
        }


        // Draws a line to the desired x and y coordinate.

        public void DrawLine(int x, int y)
        {
            g.DrawLine(Pen, cursorX, cursorY, x, y);
            this.cursorX = x;
            this.cursorY = y;
        }


        // Draws a rectangle with the given width and height, aligning to the centre of the cursor


        public void DrawRect(float width, float height)
        {
            g.DrawRectangle(Pen, cursorX - height/2, cursorY - width / 2, height, width);
        }


        // Draws a circle with the given radius, again using half of its radius to calculate the cursor point

        public void DrawCircle(float radius)
        {
           g.DrawEllipse(Pen, cursorX -radius/2, cursorY - radius/2, radius, radius);
        }

        //changes the current in use pen colour to the desired colour.

        public void ChangePen(string colour)
        {
            if (colour.ToLower().Equals("red"))
            {
                Pen.Color = Color.Red;
            }
            if (colour.ToLower().Equals("green"))
            {
                Pen.Color = Color.Green;
            }
            if (colour.ToLower().Equals("blue"))
            {
                Pen.Color = Color.Blue;
            }
            if (colour.ToLower(). Equals("black"))
            {
                Pen.Color = Color.Black;
            }
            
        }

    }
}
