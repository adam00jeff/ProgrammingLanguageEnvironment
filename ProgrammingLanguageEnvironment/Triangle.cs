using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// Class to draw Triangles
    /// </summary>
    public class Triangle : Shape
    { 
        public int side1, side2, side3; // the paramaters of the triangles
        /// <summary>
        /// Construtor for triangles
        /// </summary>
        /// <param name="colour">the colour of the triangle</param>
        /// <param name="x">its x axis position</param>
        /// <param name="y">its y asix position</param>
        /// <param name="side1">the value for side 1</param>
        /// <param name="side2">the value for side 2</param>
        /// <param name="side3">the value for side 3</param>
        
        public Triangle () : base()
        {

        }

        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.side1 = list[2];
            this.side2 = list[3];
            this.side3 = list[4];
        }
        public Triangle(Color colour, int x, int y, int side1, int side2, int side3): base(colour, x,y)
        {
            this.side1 = side1;
            this.side2 = side2;
            this.side3 = side3;
        }
        /// <summary>
        /// draws an empty triangle
        /// </summary>
        /// <param name="g">the graphics object to be output</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);//new pen of the selected colour
            Point[] points =            // calculates 3 points to draw between to create triangle
            {
                new Point(x, y),
                new Point(x-side1, y+side2),
                new Point(x+side2, y+side3)
            };

            g.DrawPolygon(p, points);   //draws a 3 sided poloygon between the calculated points
        }
        /// <summary>
        /// draws a filled triangle
        /// </summary>
        /// <param name="g">the graphics object to be output</param>
        public override void drawfilled(Graphics g)
        {
            SolidBrush b = new SolidBrush(colour);//creates a new solid brush of the chosen colour
            Point[] points =                        // calculates 3 points to draw between to create triangle
            {
                new Point(x, y),
                new Point(x-side1, y+side2),
                new Point(x+side2, y+side3)
            };

            g.FillPolygon(b, points);//draws a filled 3 sided poloygon between the calculated points
        }
    }
}


