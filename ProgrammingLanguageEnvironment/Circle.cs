using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    public class Circle : Shape
    {
        public static readonly int DefaultRadius = 50;
        internal int Radius { get; set; }

        public Circle() : this(DefaultRadius)
        {

        }
        public Circle(int radius)
        {
            Radius = radius;
        }   
        public Circle(Point position, int radius) : base(position)
        {
            Radius = radius;
        }

        public override void draw(Graphics g)
        {
            throw new NotImplementedException();
        }
    }
}
