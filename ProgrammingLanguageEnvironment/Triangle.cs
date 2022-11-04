using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    class Triangle : Shape
    {
        int side1, side2, side3;
        
        public Triangle(Color colour, int x, int y, int side1, int side2, int side3): base(colour, x,y)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            Point[] points =
            {
                new Point(x, y),
                new Point(x-side1, y+side2),
                new Point(x+side2, y+side3)
            };

            g.DrawPolygon(p, points);
        }
        class Rectangle : Shape
        {
            int width, height;

            public Rectangle(Color colour, int x, int y, int width, int height) : base(colour, x, y)
            {
                this.width = width;
                this.height = height;
            }
            public override void draw(Graphics g)
            {
                Pen p = new Pen(Color.Black, 2);
                g.DrawRectangle(p, x, y, width, height);
            }
        }
    }
}

