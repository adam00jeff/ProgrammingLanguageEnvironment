using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// Class to hold the data to be displayed on the form
    /// </summary>
    class Canvass
        ///must be some kind of inheritance issue
    {
        ///
        ///
        Graphics g;
        Pen Pen;
        int xPos, yPos; //positional reference when drawing

        public Canvass(Graphics g)
        {
            this.g = g;
            xPos = yPos = 50; // this cant be right
            Pen = new Pen(Color.Black, 1);
        }

        // TO DO G.DRAWSTING OUTPUT SYNTAX CHECK

        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        

        public void DrawTriangle(int side1, int side2, int side3)
        {
            Point[] points =
            {
                new Point(xPos, yPos),
                new Point(xPos-side1, yPos+side2),
                new Point(xPos+side2, yPos+side3)
            };
            g.DrawPolygon(Pen, points);
        }
    }

}
