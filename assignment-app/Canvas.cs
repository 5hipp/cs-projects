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
    /// <summary>
    /// The <see cref="Canvas" /> class contains all of the graphics commands regarding printing output to the panel, methods include <see cref="drawCircle" /><see cref="drawTriangle" /><see cref="changePen" /> etc.<br /></summary>
    public class Canvas
    {
        // Creation of bitmap and graphics variable, it is created here so that both the parser and form can reference the canvas commands.
        Graphics g;
        public Bitmap outputBitmap = new Bitmap(640, 720);
        public Pen Pen, cursorPen, Eraser;
        public SolidBrush fillBrush;
        public bool toggleFill;
        public bool toggleFlash;
        bool running, flag = false;
        public float cursorX, cursorY = 0;
        public float radius;
        public int x, y, size;
        public float height, width;

        public Canvas()
        {
            this.g = Graphics.FromImage(outputBitmap);
            Pen = new Pen(Color.White, 1);
            fillBrush = new SolidBrush(Pen.Color);
            cursorPen = new Pen(Color.Red, 2);
            Eraser = new Pen(Pen.Color, 2);
        }
        private void flashingMethod()
        {
            while (true)
            {
                if (running != true) continue;
                if (flag == false)
                {
                    fillBrush.Color = Color.Red;
                    g.FillEllipse(fillBrush, cursorX - radius / 2, cursorY - radius / 2, radius, radius);
                    flag = true;
                }
                else
                {
                    fillBrush.Color = Color.Black;
                    g.FillEllipse(fillBrush, cursorX - radius / 2, cursorY - radius / 2, radius, radius);
                    flag = false;
                }
                Thread.Sleep(50);
            }
        }

        // Clears the current canvas do the default "silver" colour.
        public void Clear()
        {
            g.Clear(Color.Silver);

        }

        public void enableFill(bool toggle)
        {
            this.toggleFill = toggle;
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
            this.height = height;
            this.width = width;
            if (toggleFill)
            {
                g.DrawRectangle(Pen, cursorX - height / 2, cursorY - width / 2, height, width);
                g.FillRectangle(fillBrush, cursorX - height / 2, cursorY - width / 2, height, width);
            }else
            {
                g.DrawRectangle(Pen, cursorX - height / 2, cursorY - width / 2, height, width);
            }
        }

        // Draws a triangle with fixed points according to a scale prodivded.
        public void DrawTriangle(float scale)
        {
            //floats are rounded and then cast to integers to be used by the Polygon method.
            x = (int)Math.Round(cursorX);
            y = (int)Math.Round(cursorY);
            size = (int)Math.Round(scale);

            Point point1 = new Point(x, y - size / 2);
            Point point2 = new Point(x + size / 2, y + size / 2);
            Point point3 = new Point(x - size / 2, y + size / 2);
            Point[] curvePoints =
            {
                 point1,
                 point2,
                 point3,
            };
            g.DrawPolygon(Pen, curvePoints);

        }

        // Draws a circle with the given radius, again using half of its radius to calculate the cursor point

        public void DrawCircle(float radius)
        {
            this.radius = radius;
            if (toggleFill)
            {
                g.DrawEllipse(Pen, cursorX - radius / 2, cursorY - radius / 2, radius, radius);
                g.FillEllipse(fillBrush, cursorX - radius /2 , cursorY - radius / 2, radius, radius);
            }
            else
            {
                g.DrawEllipse(Pen, cursorX - radius / 2, cursorY - radius / 2, radius, radius);
            }
        }
        

        //changes the current in use pen colour to the desired colour.

        public void ChangePen(string colour)
        {
            if (colour.ToLower().Equals("red"))
            {
                Pen.Color = Color.Red;
                fillBrush.Color = Color.Red;
            }
            if (colour.ToLower().Equals("green"))
            {
                Pen.Color = Color.Green;
                fillBrush.Color = Color.Green;
            }
            if (colour.ToLower().Equals("blue"))
            {
                Pen.Color = Color.Blue;
                fillBrush.Color = Color.Blue;
            }
            if (colour.ToLower(). Equals("black"))
            {
                Pen.Color = Color.Black;
                fillBrush.Color = Color.Black;
            }
            
        }

    }
}
