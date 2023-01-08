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
using System.Net.NetworkInformation;
using System.Threading;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// holds methods for executing actions
    /// and applying graphics objects to the form
    /// </summary>
    public class Execute
    {
        public static int programCounter = 0; // number of lines in the program
        public static ShapeFactory factory = new ShapeFactory();
        public ArrayList shapes = new ArrayList(); // creates a list to store shape objects
        public static Shape s;
        public static int xDef = 0;//default x axis position
        public static int yDef = 0;//default y axis position
        public static Color colour = Color.Black;//default colour for shapes
        public static bool fill;//default fill for shapes is unfilled
        public static int loopCounter = 0; // current iteratioins through loop
        public static int loopSize = 0; // size of the loop
        public static int loopLength = 0;
        public static bool loopFlag = false; // flag to show if program is inside loop
        public static bool executeLinesFlag = true; // flag to show if we are executing lines (for IF or Method)
        public static int programLength = 0;
        public static Thread newThread;
        public static bool running = false;
        public static bool threadflag = false;
        public static bool endThread = false;
        public static List<string> feedback { get; set; } = new List<string>();
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
            programCounter = 0;
            feedback.Clear();
            if (inputtext == null || inputtext == String.Empty)
            {
                Console.WriteLine("no input detected");
                feedback.Add("No Input Detected");
            }
            else
            {
                string[] lines = inputtext.Split('\n');// ensures the input is split by line
                programLength = lines.Count();// sets programLength to size of the input
                while (programCounter < programLength)// checks position within the program
                {
                    string inputline = lines[programCounter].Trim();// passed the current line to a variable
                    var splitLine = inputline.Split(' ', ','); // split the current line
                    if (executeLinesFlag == true) // checks we are executing lines
                    {


                        if (variableCounter != 0) // if there is a variable set 
                        {
                            for (int i = 0; i < splitLine.Length; i++)// loop through the elements of the line
                            {
                                string s = splitLine[i].Trim();//trims the line element
                                var fpos = i;
                                if (variableNames.Contains(s))//check if the element matches a declared variable name
                                                              //swapping declared variables for values
                                                              //need to not calculate, and leave first reference to var, swapping others
                                {
                                    int first = Array.IndexOf(splitLine, s);// if the first element is a variable it should be unchanged here
                                    if (first != 0 || fpos != 0) // misses the first occurence of the var
                                    {
                                        int pos = Array.IndexOf(variableNames, s);//finds the position of the match from variableNames
                                        int value = variableValues[pos];//gets the value of variableValue from matching position 
                                        splitLine[i] = value.ToString();//replaces the element with the matching value
                                    }
                                }
                            }
                            inputline = String.Join(" ", splitLine);//returns the splitlist as a full line
                        }

                        var result = Parser.ParseInput(inputline);//parses the line
                        var action = result.Action;//the action to be executed
                        var param = result.Paramaters.ToArray();//the paramaters for the action, as an array
                                                                //check if any paramaters are too large
                        switch (action)//switch for each action case, paramater errors are caught by relevant case
                        {
                            case Action.If:

                                // get the statement and evaluate it
                                // if it is true keep going through the code


                                // if it is false lines unitl endif are ignored
                                // if condition = false executelinesflag = false

                                break;
                            case Action.Endif:
                                executeLinesFlag = true; // resumes executing the program
                                break;
                            case Action.Loop:
                                loopFlag = true;
                                int loopParam = param[0];
                                loopSize = loopParam - 1; // number of times to execute this loop (minus one to miss the loop declaration)
                                string[] thearrayofinputlines = lines;
                                int loopStart = programCounter;
                                loopCounter = 0; // times through loop
                                break;
                            case Action.Endloop:
                                int iterations = loopSize;
                                loopFlag = false;
                                if (loopCounter++ < iterations)
                                {
                                    programCounter = programCounter - loopLength;
                                }
                                if (loopCounter == (iterations + 1))
                                {
                                    feedback.Add("Loop Executed " + (iterations + 1) + " times");
                                }
                                Console.WriteLine("loop executed " + loopCounter + " times");
                                break;
                            case Action.Clear:
                                xDef = 0;
                                yDef = 0;
                                variableCounter = 0;
                                programCounter = 0;
                                programLength = 0;
                                loopLength = 0;
                                variableNames = new string[200];
                                variableValues = new int[200];
                                colour = Color.Black;
                                /*                            feedback.Add("clear");*/
                                Console.WriteLine("clear");
                                break;
                            case Action.Var:
                                // replace the occurences of the var with value
                                // check if variable exists
                                // varibale value = param[0]
                                try
                                {
                                    var computed = "";
                                    var sensiblenumber = 0;
                                    string[] splits = inputline.Split(' ');
                                    string varname = splits[0];
                                    List<string> after = inputline.Split('=').Select(p => p.Trim()).ToList();
                                    string[] aftercount = after[1].Split(' ');
                                    if (variableNames.Contains(varname)) // need a flag for loops
                                    {
                                        int pos = Array.IndexOf(variableNames, varname);//finds the position of the match from variableNames
                                        try
                                        {
                                            using (var dt = new DataTable())
                                            {
                                                try
                                                {
                                                    computed = dt.Compute(after[1], "").ToString();
                                                }
                                                catch (EvaluateException)
                                                {
                                                    feedback.Add("Line " + after[1] + " could not be computed");
                                                    Console.WriteLine("This could not be computed :(");
                                                }
                                            }
                                        }
                                        catch (Exception)
                                        {
                                            feedback.Add("cannot calculate this var " + after[1]);
                                            Console.WriteLine("cannot calculate this var");
                                        }
                                        try
                                        {
                                            sensiblenumber = int.Parse(computed);
                                        }
                                        catch
                                        {

                                        }
                                        if (sensiblenumber > 5000000)
                                        {
                                            Console.WriteLine("sorry, var " + varname + " " + sensiblenumber + " is too large to set. Current Value is: " + variableValues[pos]);
                                            feedback.Add("sorry, var " + varname + " " + sensiblenumber + " is too large to set. Current Value is: " + variableValues[pos]);
                                        }
                                        else
                                        {
                                            variableNames[pos] = varname;
                                            variableValues[pos] = int.Parse(computed);
                                            string currentVarName = variableNames[pos];
                                            feedback.Add("var " + currentVarName + " overwritten: New Value = " + variableValues[pos]);
                                            Console.WriteLine("var " + currentVarName + " overwritten: New Value = " + variableValues[pos]);
                                        }
                                    }
                                    else
                                    {
                                        if (after != null && (aftercount.Count() > 1))//this is an expression
                                                                                      //maybe save the expression to an array
                                        {
                                            try
                                            {
                                                using (var dt = new DataTable())
                                                {
                                                    try
                                                    {
                                                        computed = dt.Compute(after[1], "").ToString();
                                                    }
                                                    catch (EvaluateException)
                                                    {
                                                        feedback.Add("cannot compute var " + after[1]);
                                                        Console.WriteLine("This could not be computed :(");
                                                    }
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                feedback.Add("cannot compute var " + after[1]);
                                                Console.WriteLine("cannot calculate this var");
                                            }
                                            variableNames[variableCounter] = varname;
                                            variableValues[variableCounter++] = int.Parse(computed);
                                        }
                                        else // not an expression
                                        {
                                            if (param.Length != 0)
                                            {
                                                try
                                                {
                                                    variableNames[variableCounter] = varname;
                                                    variableValues[variableCounter++] = param[0];
                                                }
                                                catch (Exception)
                                                {
                                                    feedback.Add("cannot define parameter for" + varname);
                                                    Console.WriteLine("cannot define this paramater");
                                                }

                                            }
                                            /*                                        feedback.Add("no action or parameter found for " + varname);
                                                                                    Console.WriteLine("no parameter found");*/
                                        }
                                    }
                                }
                                catch (Exception)
                                {
                                    feedback.Add("incorrect parameters for var");
                                    Console.WriteLine("incorrect paramaters for var");
                                }
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
                                Console.WriteLine("incorrect paramaters for command -> action: none"); // seems to report incorrectly when using vars
                                feedback.Add("incorrect paramaters for command -> action: none");
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
                                    feedback.Add("incorrect paramaters for moveto");
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
                                    feedback.Add("incorrect paramaters for drawto");
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
                                    feedback.Add("incorrect partamates for line");
                                    Console.WriteLine("incorrect partamates for line");
                                }
                                break;
                            case Action.Square://draws a rectangle with 4 equal sides

                                if (param.Length != 0)
                                {
                                    try
                                    {
                                        s = factory.getShape("rectangle");
                                        s.set(colour, xDef, yDef, param[0], param[0]);
                                        shapes.Add(s);
                                        Console.WriteLine("square");
                                    }
                                    catch (Exception)
                                    {
                                        feedback.Add("incorrect paramaters for Square");
                                        Console.WriteLine("incorrect paramaters for Square");
                                    }

                                }
                                else
                                {
                                    feedback.Add("no paramaters found for " + action + " using the variable");
                                    Console.WriteLine("no paramaters found");
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
                                    feedback.Add("incorrect paramaters for Rectangle");
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
                                    feedback.Add("incorrect paramaters for Rectangle");
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
                                    feedback.Add("incorrect paramaters for circle");
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
                                    feedback.Add("incorrect paramaters for triangle");
                                    Console.WriteLine("incorrect paramaters for triangle");
                                }
                                break;
                                //case Action.Test://command to call for testing
                                //      Console.WriteLine("test");
                                //    break;
                        }
                        if (inputtext != "clear")
                        {
                            programCounter++;
                        }

                        if (loopFlag == true)
                        {
                            loopLength++;
                        }
                    }
                }


            }
            return shapes; // returns the array of shapes

        }

    }
}
