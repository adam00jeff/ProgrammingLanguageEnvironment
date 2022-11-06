using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    class Rectangle : Shape
    {
        int width, height;

        public Rectangle(Color colour, int x, int y, int width, int height) :base(colour, x,y)
        {
            this.width = width;
            this.height = height;
        }
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            g.DrawRectangle(p, x, y, width, height);
        }
    }
}
