using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    abstract class Shape
    {
        //example code commented out
        //public static Point DefaultPosition;
        //public Point Position { get; set; }

        // public Shape() : this(DefaultPosition)
        // {

        // }
        // public Shape(Point position)
        // {
        //  Position = position;
        // }
        protected Color colour; //the colour of the shape to be drawn
        protected int x, y; // values to be used to draw the shape

        public Shape(Color colour, int x, int y)
        {
            this.colour = colour; //colour of the shape
            this.x = x; // the x position
            this.y = y; // the y position

        }
        public abstract void draw(Graphics g);

        public override string ToString()
        {
            return base.ToString() + "     " + this.x + " , " + this.y + " : ";

        }




    }
}
