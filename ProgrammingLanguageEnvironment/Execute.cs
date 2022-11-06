using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    public class Execute
    {
        public ArrayList shapes = new ArrayList();
        


        internal static object ExecuteParse(string inputtext, ArrayList shapes)
        {
            int xDef = 0;
            int yDef = 0;
            string[] lines = inputtext.Split('\n');
            foreach (string line in lines)
            {
                var result = Parser.ParseInput(line);
                var input1 = result.Action;
                var input2 = result.Paramaters.ToArray();

                switch (input1)
                {
                    case Action.Line:
                        shapes.Add(new Line(Color.Black, xDef, yDef, input2[0], input2[1]));
                        break;
                    case Action.Square:
                        shapes.Add(new Rectangle(Color.Black, xDef, yDef, input2[0], input2[0]));
                        break;
                    case Action.Circle:
                        shapes.Add(new Circle(Color.Black, xDef, yDef, input2[0]));
                        break;
                    case Action.Triangle:
                        shapes.Add(new Triangle(Color.Black, xDef, yDef, input2[0], input2[1], input2[2]));
                        break;
                }
            }

            return shapes;
            
        }

    }
}
