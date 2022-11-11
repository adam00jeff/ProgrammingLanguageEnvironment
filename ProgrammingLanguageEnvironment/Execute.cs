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
    /// <summary>
    /// holds methods for executing actions
    /// and applying graphics objects to the form
    /// </summary>
    public class Execute
    {
        public ArrayList shapes = new ArrayList(); // creates a list to store shape objects
        public static int xDef = 0;//default x axis position
        public static int yDef = 0;//default y axis position
        public static Color colour = Color.Black;//default colour for shapes
        public static bool fill;//default fill for shapes is unfilled
        /// <summary>
        /// calls the parser methods on user input
        /// executes the input actions and paramaters to create shapes
        /// adds shapes to the shapes array
        /// </summary>
        /// <param name="inputtext">the user input</param>
        /// <param name="shapes">a list of shapes to be drawn</param>
        /// <returns></returns>
        public static object ExecuteParse(string inputtext, ArrayList shapes)
        {
            if (inputtext == null || inputtext == String.Empty)
            {
                Console.WriteLine("no input detected");
            }
            else 
            { 
            string[] lines = inputtext.Split('\n');// ensures the input is split by line
                foreach (string line in lines)// excutes line by line
                {
                    var result = Parser.ParseInput(line);//parses the line
                    var action = result.Action;//the action to be executed
                    var param = result.Paramaters.ToArray();//the paramaters for the action, as an array
                    switch (action)//switch for each action case, paramater errors are caught by relevant case
                    {
                        case Action.Filloff://turns the fill off for shapes
                            fill = false;
                            Console.WriteLine("filloff" + fill);
                            break;
                        case Action.Fillon://turns the fill on for shapes
                            fill = true;
                            Console.WriteLine("fillon" + fill);
                            break;
                        case Action.None://reports back an empty command
                            Console.WriteLine("incorrect paramaters for command");
                            break;
                        case Action.Colourred://changes colour to red
                            colour = Color.Red;
                            Console.WriteLine("red selected");
                            break;
                        case Action.Colourgreen://changes colour to green
                            colour = Color.Green;
                            Console.WriteLine("green selected");
                            break;
                        case Action.Colourblue://changes colour to blue
                            colour = Color.Blue;
                            Console.WriteLine("blue selected");
                            break;
                        case Action.Colourreset://changes colour to default
                            colour = Color.Black;
                            Console.WriteLine("black selected");
                            break;
                        case Action.Reset://resets drawing position to 0,0
                            xDef = 0;
                            yDef = 0;
                            break;
                        case Action.Moveto://moves drawing position to new paramaters
                            try
                            {
                                xDef = param[0];
                                yDef = param[1];
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for moveto");
                            }
                            break;
                        case Action.Drawto://draws a line to paramaters
                            try
                            {
                                shapes.Add(new Line(colour, xDef, yDef, param[0], param[1]));//adds a new line to shapes array
                                xDef = param[0];
                                yDef = param[1];
                                Console.WriteLine("Drawto");
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for drawto");
                            }
                            break;
                        case Action.Line://draws a line to paramaters
                            try
                            {
                                shapes.Add(new Line(colour, xDef, yDef, param[0], param[1]));
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect partamates for line");
                            }
                            Console.WriteLine("line");
                            break;
                        case Action.Square://draws a rectangle with 4 equal sides
                            try
                            {
                                shapes.Add(new Rectangle(colour, xDef, yDef, param[0], param[0]));//adds rectangle to shapes array
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for Rectangle");
                            }
                            break;
                        case Action.Rect://draws a rectangle with 2 equal sets of sides
                            try
                            {
                                shapes.Add(new Rectangle(colour, xDef, yDef, param[0], param[1]));//adds rectangle to shapes array
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for Rectangle");
                            }
                            break;
                        case Action.Rectangle://draws a rectangle with 2 equal sets of sides
                            try
                            {
                                shapes.Add(new Rectangle(colour, xDef, yDef, param[0], param[1]));//adds rectangle to shapes array
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for Rectangle");
                            }
                            break;
                        case Action.Circle:// draws a circle
                            try
                            {
                                shapes.Add(new Circle(colour, xDef, yDef, param[0]));//adds a circle to the shapes array
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for circle");
                            }
                            break;
                        case Action.Triangle:// draws a triangle
                            try
                            {
                                shapes.Add(new Triangle(colour, xDef, yDef, param[0], param[1], param[2]));//adds a triangle to the shapes array
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for triangle");
                            }
                            break;
                            //case Action.Test://command to call for testing
                            //      Console.WriteLine("test");
                            //    break;
                    }
                }
            }
            return shapes; // returns the array of shapes
            
        }

    }
}
