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
    ///   <para>
    /// holds methods for executing actions and applying graphics objects to the form
    /// </para>
    ///   <para>calls methods from Parser class on input to define commands to execute </para>
    /// </summary>
    public class Execute
    {
        /// <summary>The program counter, counts numbers of lines in the program</summary>
        public static int programCounter = 0;
        /// <summary>The factory, used to set and define shapes drawn by the program</summary>
        public static ShapeFactory factory = new ShapeFactory();
        /// <summary>Array to hold the list of shapes to be drawn</summary>
        public ArrayList shapes = new ArrayList();
        /// <summary>The current shape to be passed to the array</summary>
        public static Shape s;
        /// <summary>The x-axis default position</summary>
        public static int xDef = 0;
        /// <summary>The y-axiis default position</summary>
        public static int yDef = 0;
        /// <summary>The current colour shapes are drawn using (default is black)</summary>
        public static Color colour = Color.Black;
        /// <summary>Bool to allow selection of drawing shapes filled or unfilled</summary>
        public static bool fill;
        /// <summary>The loop counter, counts the number of iterations through the current loop</summary>
        public static int loopCounter = 0;
        /// <summary>The total number times to perform the loop</summary>
        public static int loopSize = 0;
        /// <summary>The total number of lines within the loop</summary>
        public static int loopLength = 0;
        /// <summary>Flag to show if we are inside a loop or not</summary>
        public static bool loopFlag = false;
        /// <summary>Flag to show if lines are being skipped (for IF or Methods)</summary>
        public static bool executeLinesFlag = true;
        /// <summary>The number of lines in the input or "program"</summary>
        public static int programLength = 0;
        /// <summary>Gets or sets the list of feedback added to as the program executes.</summary>
        /// <value>The feedback strings entered from Execute Class</value>
        public static List<string> feedback { get; set; } = new List<string>();
        /// <summary>The array of set variable names</summary>
        public static string[] variableNames = new string[200];
        /// <summary>The array of set variable values</summary>
        public static int[] variableValues = new int[200];
        /// <summary>The variable counter
        /// for numbers of vars set by the program</summary>
        public static int variableCounter = 0;
        /// <summary>The first integer found when processing IF statements</summary>
        public static int firstasint = 0;
        /// <summary>The second integer found when processing IF statments</summary>
        public static int secondasint = 0;
        /// <summary>Array for holding split elements of the input line being processed</summary>
        public static string[] splitLine;
        /// <summary>The number of times a loop is to be performed</summary>
        public static int loopParam;
        /// <summary>String for holding the current line of the program</summary>
        public static string inputline = string.Empty;
        /*        public static Thread newThread;
                public static bool running = false;
                public static bool threadflag = false;
                public static bool endThread = false;*/




        /// <summary>calls the parser methods on user input
        /// executes the input actions and paramaters to create shapes
        /// adds shapes to the shapes array</summary>
        /// <param name="inputtext">the user input</param>
        /// <param name="shapes">a list of shapes to be drawn onto</param>
        /// <returns>an array of shapes to be drawn<br /></returns>
        public static object ExecuteParse(string inputtext, ArrayList shapes)
        {
            // ensuring key values are reset
            programCounter = 0;
            loopSize = 0;
            loopParam = 0;
            loopLength = 0;
            feedback.Clear();
            // checking for valid input
            if (inputtext == null || inputtext == String.Empty)
            {
                Console.WriteLine("no input detected");
                feedback.Add("No Input Detected");
            }
            // ensuring program does not get stuck in a loop
            else if (programCounter < 0)
            {
                Console.WriteLine("programCounter < 0 ");
                feedback.Add("Error computing program, please clear the program, ProgramCounter is less than 0 ("+programCounter+")");
            }
            // begin processing the input
            else
            {
                string[] lines = inputtext.Split('\n');// input is split by line
                inputline = "";// ensures inputline is empty
                programLength = lines.Count();// sets programLength to size of the input
                while (programCounter < programLength)// checks position within the program
                {
                    try//catching errors for bad input
                    {
                        inputline = lines[programCounter].Trim();// passed the current line to a variable
                        splitLine = inputline.Split(' ', ','); // split the current line
                    }
                    catch (Exception)
                    {
                        feedback.Add("Error computing program, please clear the program: ProgramCounter(" +programCounter+") cannot be reduced by ProgramLength ("+programLength+")");
                    }
                    if (inputline == "endif")//resumes line execution following IF statments
                    {
                        executeLinesFlag = true;
                    }
                    if (executeLinesFlag == true) // checks we are executing lines, skips the execution if not
                    {
                        if (variableCounter != 0) // if there is a variable set 
                        {
                            for (int i = 0; i < splitLine.Length; i++)// loop through the elements of the line
                            {
                                string s = splitLine[i].Trim();//trims the line element
                                var fpos = i;
                                if (variableNames.Contains(s))//check if the element matches a declared variable name
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
                            case Action.If: // action for the IF statments
                                string[] splits = inputline.Split(' '); // array of the input line
                                var firstVal = splits[1];
                                var secondVal = splits[3];
                                var theOperator = splits[2];
                                bool ifCondition = false; // if true, execute the lines following the statment
                                try // attempts to pass values to ints and calculate using operator
                                {
                                    firstasint = int.Parse(firstVal);
                                    secondasint = int.Parse(secondVal);
                                    string str = theOperator;
                                    switch (str) // switch for IF operators
                                    {
                                        case "=": // if equals
                                            if (firstVal == secondVal)
                                            {
                                                ifCondition = true;
                                            }
                                            else
                                            {
                                                ifCondition = false;
                                            }
                                            break;
                                        case ">":// if greaterthan
                                            if (firstasint > secondasint)
                                            {
                                                ifCondition = true;
                                            }
                                            else
                                            {
                                                ifCondition = false;
                                            }
                                            break;
                                        case "<":// if lessthan
                                            if (firstasint < secondasint)
                                            {
                                                ifCondition = true;
                                            }
                                            else
                                            {
                                                ifCondition = false;
                                            }
                                            break;
                                        case "!=":// if not equal
                                            if (firstasint != secondasint)
                                            {
                                                ifCondition = true;
                                            }
                                            else
                                            {
                                                ifCondition = false;
                                            }
                                            break;
                                    }
                                }
                                catch (Exception) // catches bad paramaters for the IF
                                {
                                    feedback.Add("IF cannot be calculated with paramaters: " + inputline+ " on line " + (programCounter + 1));
                                }
                                if (ifCondition == false) // misses the rest of the IF until it finds the endif
                                {
                                    executeLinesFlag = false;
                                }
                                break;
                            case Action.Endif:
                                executeLinesFlag = true; // resumes executing the program
                                break;
                            case Action.Loop:
                                loopFlag = true; // begin counting the size of the loop
                                loopParam = param[0]; // gets the requested number of iterations
                                loopSize = loopParam - 1; // number of times to execute this loop (minus one to miss the loop declaration)
                                /*string[] thearrayofinputlines = lines;*/
                                int loopStart = programCounter; // finds the position of the start of the loop
                                loopCounter = 0; // times through this loop
                                break;
                            case Action.Endloop:
                                int iterations = loopSize;// sets the size of the loop 
                                loopFlag = false;// ends counting the loop
                                if (loopCounter++ < iterations)//compares performed loops to requested 
                                {
                                    programCounter = programCounter - (loopLength);// returns to start of loop 
                                }
                                if (loopCounter == (iterations + 1))// feedsback count of loops
                                {
                                    feedback.Add("Loop Executed " + (iterations + 1) + " times" + " finished on line " + (programCounter + 1));
                                }
                                Console.WriteLine("loop executed " + loopCounter + " times");
                                break;
                            case Action.Clear:// clears relevant variables 
                                xDef = 0;
                                yDef = 0;
                                variableCounter = 0;
                                programCounter = 0;
                                programLength = 0;
                                loopLength = 0;
                                variableNames = new string[200];
                                variableValues = new int[200];
                                colour = Color.Black;
                                Console.WriteLine("clear");
                                break;
                            case Action.Var:
                                try // trys to calculate paramaters 
                                {
                                    var computed = "";
                                    var sensiblenumber = 0;
                                    string[] splits2 = inputline.Split(' '); // gets the input line as an array
                                    string varname = splits2[0];// finds the first element, the var
                                    List<string> after = inputline.Split('=').Select(p => p.Trim()).ToList();// get a list of things that are not the var
                                    string[] aftercount = after[1].Split(' ');// an array used for counting the elements after the operator
                                    if (variableNames.Contains(varname)) // checks for the existing variable name
                                    {
                                        int pos = Array.IndexOf(variableNames, varname);//finds the position of the match from variableNames
                                        try // checks for a computable value
                                        {
                                            using (var dt = new DataTable())
                                            {
                                                try
                                                {
                                                    computed = dt.Compute(after[1], "").ToString(); // trys to compute line following operator
                                                }
                                                catch (EvaluateException)// informs user of error
                                                {
                                                    feedback.Add("Line " + after[1] + " could not be computed on line " + (programCounter + 1));
                                                    Console.WriteLine("This could not be computed :(");
                                                }
                                            }
                                        }
                                        catch (Exception)// if the var cannot be commputed, but contains operators
                                        {
                                            feedback.Add("cannot calculate this var " + after[1] + " on line " + (programCounter + 1));
                                            Console.WriteLine("cannot calculate this var");
                                        }
                                        sensiblenumber = int.Parse(computed);
                                        if (sensiblenumber > 5000000)// checks the computed number is withing a reasonable range
                                        {
                                            Console.WriteLine("sorry, var " + varname + " " + sensiblenumber + " is too large to set. Current Value is: " + variableValues[pos]);
                                            feedback.Add("sorry, var " + varname + " " + sensiblenumber + " is too large to set. Current Value is: " + variableValues[pos] + " on line " + (programCounter + 1));
                                        }
                                        else // variable is computable and an integer
                                        {
                                            variableNames[pos] = varname; // overwrites varname
                                            variableValues[pos] = int.Parse(computed);// overwirtes value
                                            string currentVarName = variableNames[pos];// gets new varname
                                            feedback.Add("var " + currentVarName + " overwritten: New Value = " + variableValues[pos] + " on line " + (programCounter + 1));
                                            Console.WriteLine("var " + currentVarName + " overwritten: New Value = " + variableValues[pos]);
                                        }
                                    }
                                    else // if the var name is not found in the array
                                    {
                                        if (after != null && (aftercount.Count() > 1))//this is a new variable with an expression
                                        {
                                            try
                                            {
                                                using (var dt = new DataTable())// try and calculate the expression
                                                {
                                                    try
                                                    {
                                                        computed = dt.Compute(after[1], "").ToString();
                                                    }
                                                    catch (EvaluateException) // catch errors and report
                                                    {
                                                        feedback.Add("cannot compute var " + after[1] + " on line " + (programCounter + 1));
                                                        Console.WriteLine("This could not be computed :(");
                                                    }
                                                }
                                            }
                                            catch (Exception)
                                            {
                                                feedback.Add("cannot compute var " + after[1]+ " on line " + (programCounter + 1));
                                                Console.WriteLine("cannot calculate this var");
                                            }
                                            variableNames[variableCounter] = varname; // if successful, pass new variable name 
                                            variableValues[variableCounter++] = int.Parse(computed);// if successful pass new variable value
                                        }
                                        else // not an expression
                                        {
                                            if (param.Length != 0) // variables must have paramaters 
                                            {
                                                try // try and set var
                                                {
                                                    variableNames[variableCounter] = varname;
                                                    variableValues[variableCounter++] = param[0];
                                                }
                                                catch (Exception) // report failing to set var
                                                {
                                                    feedback.Add("cannot define parameter for " + varname+" on line " + (programCounter + 1));
                                                    Console.WriteLine("cannot define this paramater");
                                                }

                                            }
                                        }
                                    }
                                }
                                catch (Exception) // catch anything that drops through all 
                                {
                                    feedback.Add("incorrect parameters for var on line " + (programCounter + 1));
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
                                Console.WriteLine("incorrect paramaters for command -> action on line " + (programCounter + 1)); // seems to report incorrectly when using vars
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
                                    feedback.Add("incorrect paramaters for moveto on line " + (programCounter + 1));
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
                                    feedback.Add("incorrect paramaters for drawto on line " + (programCounter + 1));
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
                                    feedback.Add("incorrect partamates for line on line " + (programCounter + 1));
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
                                        feedback.Add("incorrect paramaters for Square on line " + (programCounter + 1));
                                        Console.WriteLine("incorrect paramaters for Square");
                                    }

                                }
                                else
                                {
                                    feedback.Add("no paramaters found for " + action + " using the variable on line " + (programCounter + 1));
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
                                    feedback.Add("incorrect paramaters for Rectangle on line " + (programCounter + 1));
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
                                    feedback.Add("incorrect paramaters for Rectangle on line " + (programCounter + 1));
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
                                    feedback.Add("incorrect paramaters for circle on line " + (programCounter + 1));
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
                                    feedback.Add("incorrect paramaters for triangle on line "+(programCounter+1));
                                    Console.WriteLine("incorrect paramaters for triangle");
                                }
                                break;
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
                    else
                    {
                        programCounter++;
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
