using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    public class Execute
    {
        public ArrayList shapes = new ArrayList();
        internal static object ExecuteParse(string inputtext, ArrayList shapes)
        {
            var result = Parser.ParseInput(inputtext);
            var input1 = result.Action;
            var input2 = result.Paramaters.ToArray();

            //shapes.Add(new Rectangle(Color.Black, 10, 100, 100, 150));



            switch (input1)
            {
                case Action.Line:
                    shapes.Add(new Line(Color.Black, 50, 50, input2[0], input2[1]));
                    break;
                case Action.Square:
                    shapes.Add(new Rectangle(Color.Black, 50, 50, input2[0], input2[0]));
                    break;
                case Action.Circle:
                    shapes.Add(new Circle(Color.Black, 70, 70, input2[0]));
                    break;
                case Action.Triangle:
                    shapes.Add(new Triangle(Color.Black, 60, 60, input2[0], input2[1], input2[2]));
                    break;
            }

            return shapes;
            
        }

    }
}
