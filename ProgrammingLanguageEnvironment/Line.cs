using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    class Line : Shape
    {
        int tox, toy;

        public Line(Color colour, int x, int y, int tox,int toy) : base(colour, x, y)
        {
            this.tox = tox;
            this.toy = toy;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            g.DrawLine(p, x, y, tox, toy);
        }
        public override void drawfilled(Graphics g)
        {
            Pen p = new Pen(colour, 2);
            g.DrawLine(p, x, y, tox, toy);
        }

    }
}
