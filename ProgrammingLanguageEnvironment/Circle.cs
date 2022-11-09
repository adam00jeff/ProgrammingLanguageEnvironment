using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// Class to draw Circles
    /// </summary>
    public class Circle : Shape
    {
        public readonly int radius; //the radius of the circle        
        /// <summary>
        /// constructor for circles
        /// </summary>
        /// <param name="colour">the colour of the circle</param>
        /// <param name="x">the x axis posiition</param>
        /// <param name="y">the y axis position</param>
        /// <param name="radius">the radius of the circle</param>
        public Circle(Color colour, int x, int y, int radius) : base(colour, x, y)
        {
            this.radius = radius;
        }
        /// <summary>
        /// overrides draw method when Circle.Draw is called
        /// draws a circle on the graphics object
        /// </summary>
        /// <param name="g">the graphics object to be output</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);//creates a pen with the selected colour
            g.DrawEllipse(p, x, y, radius * 2, radius * 2);//calls method to draw ellipse using paramaters / radius
        }
        /// <summary>
        /// overrides drawfilled method to draw filled circles
        /// draws filled circles on the graphics object
        /// </summary>
        /// <param name="g">the graphics object to be output</param>
        public override void drawfilled(Graphics g)
        {
            SolidBrush b = new SolidBrush(colour);//creates a solid pen with the selected colour
            g.FillEllipse(b, x, y, radius * 2, radius * 2);//draws a filled circle using paramaters / radius
        }
        /// <summary>
        /// when ToString() called on circle, returns with radius appedned
        /// </summary>
        /// <returns>ToString()+radius</returns>
        public override string ToString()
        {
            return base.ToString()+ "     "+this.radius;
        }
    }
}
