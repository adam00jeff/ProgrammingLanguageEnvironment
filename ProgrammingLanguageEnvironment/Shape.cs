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
        public static Point DefaultPosition;
        public Point Position { get; set; }

        public Shape() : this(DefaultPosition)
        {

        }
        public Shape(Point position)
        {
            Position = position;
        }




    }
}
