﻿using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    class Circle : Shape
    {
        int radius;

        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            this.radius = radius;
        }

        public override void draw(Graphics g)
        {
            Pen p = new Pen(Color.Black, 2);
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);

        }
        public override string ToString()
        {
            return base.ToString()+ "     "+this.radius;
        }
    }
}