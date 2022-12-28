﻿using System;
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
using System.Net.NetworkInformation;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// holds methods for executing actions
    /// and applying graphics objects to the form
    /// </summary>
    public class Execute
    {
        public static ShapeFactory factory = new ShapeFactory();
        public ArrayList shapes = new ArrayList(); // creates a list to store shape objects
        public static Shape s;
        public static int xDef = 0;//default x axis position
        public static int yDef = 0;//default y axis position
        public static Color colour = Color.Black;//default colour for shapes
        public static bool fill;//default fill for shapes is unfilled

        /*public static ArrayList variableNames = new ArrayList();*/
        public static string[] variableNames = new string[200];
        public static int[] variableValues = new int[200];
        public static int variableCounter = 0;
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
                /// parse commands from input
                /// execute commands
                /// adds shapes to the array
            string[] lines = inputtext.Split('\n');// ensures the input is split by line
                foreach (string line in lines)// excutes line by line
                {
                    string inputline = line.Trim();// passed the current line to a variable
                    if (variableCounter != 0) // if there is a variable set 
                    {
                        var splitLine = inputline.Split(' ', ','); // split the current line
                        for (int i=0;i< splitLine.Length; i++)// loop through the elements of the line
                        {
                            string s = splitLine[i].Trim();//trims the line element
                            if (variableNames.Contains(s))//check if the element matches a declared variable name
                            {
                                int pos = Array.IndexOf(variableNames, s);//finds the position of the match from variableNames
                                int value = variableValues[pos];//gets the value of variableValue from matching position 
                                splitLine[i] = value.ToString();//replaces the element with the matching value
                            }  
                        }
                        inputline = String.Join(", ",splitLine);//returns the splitlist as a full line
                    }

                    var result = Parser.ParseInput(inputline);//parses the line
                    var action = result.Action;//the action to be executed
                    var param = result.Paramaters.ToArray();//the paramaters for the action, as an array

                    switch (action)//switch for each action case, paramater errors are caught by relevant case
                    {
                        case Action.Var:
                            // replace the occurences of the var with value
                            //check if variable exists
                            // varibale value = param[0]
                            string varname = inputline.Split(' ')[0];
                            variableNames[variableCounter] = varname;
                            variableValues[variableCounter++] = param[0];

                            break;
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
                            Console.WriteLine("reset");
                            break;
                        case Action.Moveto://moves drawing position to new paramaters
                            try
                            {
                                xDef = param[0];
                                yDef = param[1];
                                Console.WriteLine("move to");
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for moveto");
                            }
                            break;
                        case Action.Drawto://draws a line to paramaters
                            try
                            {
                                s = factory.getShape("line");
                                s.set(colour, xDef, yDef, param[0], param[1]);
                                shapes.Add(s);
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
                                s = factory.getShape("line");
                                s.set(colour, xDef, yDef, param[0], param[1]);
                                shapes.Add(s);

                                Console.WriteLine("line");
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect partamates for line");
                            }
                            break;
                        case Action.Square://draws a rectangle with 4 equal sides
                            try
                            {
                                s = factory.getShape("rectangle");
                                s.set(colour, xDef, yDef, param[0], param[0]);
                                shapes.Add(s);
                                Console.WriteLine("square");
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for Square");
                            }
                            break;
                        case Action.Rect://draws a rectangle with 2 equal sets of sides
                            try
                            {
                                s = factory.getShape("rectangle");
                                s.set(colour, xDef, yDef, param[0], param[1]);
                                shapes.Add(s);
                                Console.WriteLine("rectangle");
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for Rectangle");
                            }
                            break;
                        case Action.Rectangle://draws a rectangle with 2 equal sets of sides
                            try
                            {
                                s = factory.getShape("rectangle");
                                s.set(colour, xDef, yDef, param[0], param[1]);
                                shapes.Add(s);
                                Console.WriteLine("rectangle");
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for Rectangle");
                            }
                            break;
                        case Action.Circle:// draws a circle
                            try
                            {
                                s = factory.getShape("circle");
                                s.set(colour, xDef, yDef, param[0]);
                                shapes.Add(s);
                                Console.WriteLine("circle");
                            }
                            catch (IndexOutOfRangeException)//catches incorrect paramaters
                            {
                                Console.WriteLine("incorrect paramaters for circle");
                            }
                            break;
                        case Action.Triangle:// draws a triangle
                            try
                            {
                                s = factory.getShape("triangle");
                                s.set(colour, xDef, yDef, param[0], param[1], param[2]);
                                shapes.Add(s);
                                Console.WriteLine("triangle");
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
