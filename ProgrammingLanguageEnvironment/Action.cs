using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProgrammingLanguageEnvironment
{
    /// <summary>
    /// Sets up a list of actions that can be performed by the program
    /// Actions are exectuted in the Execute class
    /// </summary>
    public enum Action
    {
        /// <summary>The action for drawing circles</summary>
        Circle,
        /// <summary>The action for drawing squares</summary>
        Square,
        /// <summary>The action for drawing rectangles</summary>
        Rectangle,
        /// <summary>The action for drawing rectangles</summary>
        Rect,
        /// <summary>The action for drawing triangles</summary>
        Triangle,
        /// <summary>The action for drawing lines</summary>
        Line,
        /// <summary>The action for moving the drawing position</summary>
        Moveto,
        /// <summary>The action for drawing a line from the drawing position to another</summary>
        Drawto,
        /// <summary>The action for clearing the bitmap and the program</summary>
        Clear,
        /// <summary>The action for resetting the drawing position to default values (0,0)</summary>
        Reset,
        /// <summary>The action for selecting the colour red</summary>
        Colourred,
        /// <summary>The action for selecting the colour flashing between red and green</summary>
        Colourredgreen,
        /// <summary>The action for selecting the colour green</summary>
        Colourgreen,
        /// <summary>The action for selecting the colour blue</summary>
        Colourblue,
        /// <summary>The action for selecting the default colour black</summary>
        Colourreset,
        /// <summary>The action for selecting the drawn shapes to be filled</summary>
        Fillon,
        /// <summary>The action for selecting the drawn shapes to be unfilled</summary>
        Filloff,
        /// <summary>The action for selecting a while loop</summary>
        While,
        /// <summary>The action for selecting a regular loop</summary>
        Loop,
        /// <summary>The action for ending a loop</summary>
        Endloop,
        /// <summary>The action for selecting an IF statement</summary>
        If,
        /// <summary>The action for ending an IF statement</summary>
        Endif,
        /// <summary>The action for setting a variable</summary>
        Var,
        /// <summary>The action placeholder for an action not being set</summary>
        None
    }
}
/*        /// <summary>The action for selecting a while loop</summary>
Colour,*/

//Test, // action to call for testing