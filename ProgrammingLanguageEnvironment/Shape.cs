using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>Abstract class to establish paramaters for shapes</summary>
    public abstract class Shape
        {
        /// <summary>The colour
        /// of the shape to be drawn</summary>
        public Color colour;
        /// <summary>
        /// The values to be used to draw the shape
        /// </summary>
        public int x, y;
        /// <summary>
        /// Initializes a new instance of the <see cref="Shape"/> class.
        /// </summary>
        public Shape()
        {

        }
        /// <summary>
        /// shape method to set the values of a shape
        /// </summary>
        /// <param name="colour">the colour of the shape</param>
        /// <param name="x">the x axis position to be drawn from</param>
        /// <param name="y">the y axis position to be drawn from</param>
        public Shape(Color colour, int x, int y)
        {
            this.colour = colour; //colour of the shape
            this.x = x; // the x position
            this.y = y; // the y position

        }
        /// <summary>
        /// Sets the specified values for the shape.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <param name="list">The list.</param>
        public virtual void set(Color colour, params int[] list)
        {
            this.colour = colour;
            this.x = list[0];
            this.y = list[1];
        }
                /// <summary>
        /// method for adding shapes to a graphics object
        /// </summary>
        /// <param name="g">the stored graphics to be output</param>
        public abstract void draw(Graphics g);
        /// <summary>
        /// method for adding filled shapes to a graphics object
        /// </summary>
        /// <param name="g">the filled shapes to be graphics object</param>
        public abstract void drawfilled(Graphics g);
        /// <summary>
        /// overrides ToString method to return the paramaters for a shape
        /// </summary>
        /// <returns>the string requested + the coordinated and colour</returns>
        public override string ToString()
        {
            return base.ToString() + "     " + this.x + " , " + this.y + " : " + this.colour;
        }
    }
}
