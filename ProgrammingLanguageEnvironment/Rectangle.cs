using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    public class Rectangle : Shape
    {
     
        public long width, height;
        

        public Rectangle() : base ()
        {

        }

        public Rectangle(Color colour, int x, int y, int width, int height) :base(colour, x,y)
        {
            this.width = width;
            this.height = height;
        }

        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];
        }
        public override void draw(Graphics g)
        {
            try
            {
            Pen p = new Pen(colour, 2);
            g.DrawRectangle(p, x, y, width, height);
            }
            catch (OverflowException)//catches incorrect paramaters
            {
                Console.WriteLine("incorrect paramaters for Square");
            }

        }

        public override void drawfilled(Graphics g)
        {
            SolidBrush b = new SolidBrush(colour);
            g.FillRectangle(b, x, y, width, height);
        }

    }
}
