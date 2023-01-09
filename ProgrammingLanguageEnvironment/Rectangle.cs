using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// Class for drawing rectangles (squares are draw as rectangles with matched paramaters)
    /// </summary>
    /// <seealso cref="ProgrammingLanguageEnvironment.Shape" />
    public class Rectangle : Shape
    {
        /// <summary>
        /// The width and height variables for rectangles
        /// </summary>
        public long width, height;
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        public Rectangle() : base ()
        {

        }
        /// <summary>
        /// Initializes a new instance of the <see cref="Rectangle"/> class.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <param name="x">The x.</param>
        /// <param name="y">The y.</param>
        /// <param name="width">The width.</param>
        /// <param name="height">The height.</param>
        public Rectangle(Color colour, int x, int y, int width, int height) :base(colour, x,y)
        {
            this.width = width;
            this.height = height;
        }
        /// <summary>
        /// Sets the specified variables of the shape.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <param name="list">The list.</param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.width = list[2];
            this.height = list[3];
        }
        /// <summary>
        /// method for adding shapes to a graphics object
        /// </summary>
        /// <param name="g">the stored graphics to be output</param>
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
        /// <summary>
        /// method for adding filled shapes to a graphics object
        /// </summary>
        /// <param name="g">the filled shapes to be graphics object</param>
        public override void drawfilled(Graphics g)
        {
            SolidBrush b = new SolidBrush(colour);
            g.FillRectangle(b, x, y, width, height);
        }
    }
}
