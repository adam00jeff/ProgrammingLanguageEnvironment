using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// class to draw lines 
    /// line method called from DrawTo
    /// </summary>
    public class Line : Shape
    {
        /// <summary>The destination value of the x/y axis</summary>
        public int tox, toy;
        /// <summary>
        /// Initializes a new instance of the <see cref="Line"/> class.
        /// </summary>
        public Line () : base()
        {

        } 
        /// <summary>
        /// constructor for lines
        /// </summary>
        /// <param name="colour">the colour of the line</param>
        /// <param name="x">starting x axis position</param>
        /// <param name="y">starting y axis position</param>
        /// <param name="tox">ending x axis position</param>
        /// <param name="toy">ending y axis position</param>
        /// 
        public Line(Color colour, int x, int y, int tox,int toy) : base(colour, x, y)
        {
            this.tox = tox;
            this.toy = toy;
        }
        /// <summary>
        /// Sets the specified values of the line.
        /// </summary>
        /// <param name="colour">The colour.</param>
        /// <param name="list">The list.</param>
        public override void set(Color colour, params int[] list)
        {
            base.set(colour, list[0], list[1]);
            this.tox = list[2];
            this.toy = list[3];
        }
        /// <summary>
        /// draws a line on the graphics object
        /// </summary>
        /// <param name="g">graphics object to be output</param>
        public override void draw(Graphics g)
        {
            Pen p = new Pen(colour, 2);//creates a new pen of chosen colour
            g.DrawLine(p, x, y, tox, toy);//draws a line from starting position to new position
        }
        /// <summary>
        /// method to call when fill is selected
        /// does not change the lines
        /// </summary>
        /// <param name="g">the graphics object to be output</param>
        public override void drawfilled(Graphics g)
        {
            Pen p = new Pen(colour, 2);//creates a new pen of chosen colour
            g.DrawLine(p, x, y, tox, toy);//draws a line from starting position to new position
        }

    }
}
