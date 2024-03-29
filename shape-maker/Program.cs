﻿using System.Xml.Schema;

class shapeMaker
{
    public class test
    {
        public static void Main()
        {
            Shape s = new Shape(100,100);

            Console.WriteLine("Shape values are " + s.X + " and " + s.Y);
            
            Circle c = new Circle(100,100,20.0);

            Console.WriteLine("Circle values are " + c.X + " " + c.Y + " and "+ c.Radius);

            Triangle t = new Triangle(100, 250, 300);

            Console.WriteLine("Triangle values are " + t.X + " " + t.Y + " and " + t.Z);

        }
    }
   public class Shape
    {
        public int x;
        public int y;

        public Shape()
        {

        }

        public Shape (int xValue, int yValue)
        {
            x = xValue;
            y = yValue;
        }

        public int X
        {
            get
            {
                return x;
            } 
            set
            {
                x = value;
            }
        }

        public void setValues(int x, int y)
        {
            this.x = x;
            this.y = y;
        }

        public int Y
        {
            get
            {
                return y;
            }
            set
            {
                y = value;
            }
        }
    }

    public class Circle : Shape
    {
        private double radius;
        public Circle()
        {

        }


        public Circle(int xValue, int yValue, double radiusIn)
        {
            X = xValue;
            Y = yValue;

            radius = radiusIn;

        }

        public void setData(int xValue, int yValue, double radiusIn)
        {
            setValues(xValue, yValue);
            radius = radiusIn;
        }

        public double Radius
        {
            get
            {
                return radius;
            }
            set
            {
                if (value > 0.0)
                    radius = value;
            }
        }
    }

    public class Triangle : Shape
    {
        private int z;

        public Triangle()
        {
        }

        public Triangle(int xValue, int yValue, int zValue)
        {
            X = xValue;
            Y = yValue;

            z = zValue;
        }

        public void setData(int xValue, int yValue, int zValue)
        {
            setValues(xValue, yValue);
            z = zValue;
        }

        public int Z
        {
            get
            {
                return z;
            }
            set
            {
                z = value;
            }
        }
    }
}