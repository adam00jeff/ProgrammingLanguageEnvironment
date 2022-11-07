using System;
using System.Collections;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Runtime.Remoting;
using System.Runtime.Remoting.Contexts;
using System.Text;
using System.Threading.Tasks;
using static System.Windows.Forms.VisualStyles.VisualStyleElement;
using System.Windows.Forms;
using System.Data;

namespace ProgrammingLanguageEnvironment
{
    public class Execute
    {
        public ArrayList shapes = new ArrayList();
        public static int xDef = 0;
        public static int yDef = 0;
        public static Color colour = Color.Black;
        public static bool fill;


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
                    case Action.Filloff:
                        fill = false;
                        Console.WriteLine("filloff"+fill);
                        break;
                    case Action.Fillon:
                        fill = true;
                        Console.WriteLine("fillon"+fill);
                        break;
                    case Action.None:
                        Console.WriteLine("not a known command");
                        break;
                    case Action.Test:
                        Console.WriteLine("test");
                        break;
                    case Action.Colourred:
                        colour = Color.Red;
                        Console.WriteLine("red selected");
                        break;
                    case Action.Colourgreen:
                        colour = Color.Green;
                        Console.WriteLine("green selected");
                        break;
                    case Action.Colourblue:
                        colour = Color.Blue;
                        Console.WriteLine("blue selected");
                        break;
                    case Action.Colourreset:
                        colour = Color.Black;
                        Console.WriteLine("black selected");
                        break;
                    case Action.Reset:
                        xDef = 0;
                        yDef = 0;
                        break;
                    case Action.Moveto:
                        try
                        {
                            xDef = input2[0];
                        yDef = input2[1];
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("incorrect paramaters for moveto");
                        }
                        break;
                    case Action.Drawto:
                        try
                        {
                            shapes.Add(new Line(colour, xDef, yDef, input2[0], input2[1]));
                            xDef = input2[0];
                            yDef = input2[1];
                            Console.WriteLine("Drawto");
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("incorrect paramaters for drawto");
                        }
                        break;
                     case Action.Line:
                        try
                        {
                            shapes.Add(new Line(colour, xDef, yDef, input2[0], input2[1]));
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("incorrect partamates for square");
                        }
                        Console.WriteLine("line");
                        break;
                    case Action.Square:
                        try
                        {
                            shapes.Add(new Rectangle(colour, xDef, yDef, input2[0], input2[0]));
                        }
                        catch (IndexOutOfRangeException e)
                        {
                             Console.WriteLine("incorrect paramaters for Rectangle");
                        }
                        break;
                    case Action.Rect:
                        try
                        {
                            shapes.Add(new Rectangle(colour, xDef, yDef, input2[0], input2[1]));
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("incorrect paramaters for Rectangle");
                        }
                        break;
                    case Action.Rectangle:
                        try
                        {
                            shapes.Add(new Rectangle(colour, xDef, yDef, input2[0], input2[1]));
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("incorrect paramaters for Rectangle");
                        }
                        break;
                    case Action.Circle:
                        try { 
                        shapes.Add(new Circle(colour, xDef, yDef, input2[0]));
                        }
                        catch (IndexOutOfRangeException e)
                        {
                        Console.WriteLine("incorrect paramaters for circle");
                        }
                         break;
                    case Action.Triangle:
                        try
                        {
                            shapes.Add(new Triangle(colour, xDef, yDef, input2[0], input2[1], input2[2]));
                        }
                        catch (IndexOutOfRangeException e)
                        {
                            Console.WriteLine("incorrect paramaters for triangle");
                        }
                        break;
                }
            }

            return shapes;
            
        }

    }
}
