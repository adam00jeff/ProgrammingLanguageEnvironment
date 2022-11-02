using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    public abstract class Shape
    {
        protected Color colour;
        protected int x, y;
        //interface?
        //void draw(graphics g)
        //void set(Color c, param int{} list);
        public static Point DefaultPosition;
        public Point Position { get; set; }

        public Shape() : this(DefaultPosition)
        {

        }
        public Shape(Point position)
        {
            Position = position;
        }

        public Shape(Color colour, int x, int y)
        {
            this.colour = colour;
            this.x = x;
            this.y = y;
        }
        public abstract void draw(Graphics g);

        // public override string ToString()
        //{ return base.ToString() + " " + this.x + "," + this.y + " : ";


    }
}
