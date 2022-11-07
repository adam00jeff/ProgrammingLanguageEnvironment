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
        public static int xDef = 0;
        public static int yDef = 0;
        public static Color colour = Color.Black;



        internal static object ExecuteParse(string inputtext, ArrayList shapes)
        {
            
            string[] lines = inputtext.Split('\n');
            foreach (string line in lines)
            {
                var result = Parser.ParseInput(line);
                var input1 = result.Action;
                var input2 = result.Paramaters.ToArray();
                
                

                switch (input1)
                {
                    case Action.Test:
                        Console.WriteLine("test");
                        break;
                    case Action.Colourred:
                        colour = Color.Red;
                        Console.WriteLine("colour");
                        break;
                    case Action.Colourgreen:
                        colour = Color.Green;
                        break;
                    case Action.Colourblue:
                        colour = Color.Blue;
                        break;
                    case Action.Colourreset:
                        colour = Color.Black;
                        break;
                    case Action.Reset:
                        xDef = 0;
                        yDef = 0;
                        break;
                    case Action.Moveto:
                        xDef = input2[0];
                        yDef = input2[1];
                        break;
                    case Action.Drawto:
                        // testing colour = Color.Red;
                        shapes.Add(new Line(colour, xDef, yDef, input2[0], input2[1]));
                        xDef = input2[0];
                        yDef = input2[1];
                        Console.WriteLine("Drawto");
                        break;
                     case Action.Line:
                        shapes.Add(new Line(colour, xDef, yDef, input2[0], input2[1]));
                        Console.WriteLine("line");
                        break;
                    case Action.Square:
                        shapes.Add(new Rectangle(colour, xDef, yDef, input2[0], input2[0]));
                        break;
                    case Action.Rect:
                        shapes.Add(new Rectangle(colour, xDef, yDef, input2[0], input2[1]));
                        break;
                    case Action.Rectangle:
                        shapes.Add(new Rectangle(colour, xDef, yDef, input2[0], input2[1]));
                        break;
                    case Action.Circle:
                        shapes.Add(new Circle(colour, xDef, yDef, input2[0]));
                        break;
                    case Action.Triangle:
                        shapes.Add(new Triangle(colour, xDef, yDef, input2[0], input2[1], input2[2]));
                        break;
                }
            }

            return shapes;
            
        }

    }
}
