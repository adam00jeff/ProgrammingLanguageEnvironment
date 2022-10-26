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
    {
        ///
        ///
        Graphics g;
        Pen Pen;
        int xPos, yPos; //positional reference when drawing

        public Canvass(Graphics g)
        {
            this.g = g;
            xPos = yPos = 20;
            Pen = new Pen(Color.Black, 1);
        }

        public void DrawLine(int toX, int toY)
        {
            g.DrawLine(Pen, xPos, yPos, toX, toY);
            xPos = toX;
            yPos = toY;
        }

        public void DrawSquare(int size)
        {
            g.DrawRectangle(Pen, xPos, yPos, xPos = size, yPos + size);
        }
    }

}
