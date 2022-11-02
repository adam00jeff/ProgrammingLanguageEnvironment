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
        public static readonly int DefaultHeight = 40;
        public static readonly int DefaultWidth = 40;
        ///
        ///


        internal int Height { get; set; }
        internal int Width { get; set; }

 



        public Rectangle() : this(DefaultHeight, DefaultWidth)
        {

        }

        public Rectangle(int width, int height)
        {
            Height = height;
            Width = width;
        }

        public Rectangle(Point position, int width, int height) : base(position)
        {
            Height = height;
            Width = width;
        }
    }
}
