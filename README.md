# ProgrammingLanguageEnvironment
Submission for Advanced Software Engineering module

## Program Use
The program simluates a basic programming language by allowing multi-line user input to draw in the output window.

The functions of the main form window are as follows:
- **Input Box**
multi line commands can be written for the program here
- **Output**
program output is drawn to the output bitmap
- **Syntax Feedback**
syntax feedback from user input is displayed here
- **Command Line**
a single line command-line for the program, actions can be called directly by their name e.g. "run", "clear" or "reset"
- **Run**
runs the command in the Input box, or command line if Input box is empty
- **Clear**
clears the output and syntax boxes, clears program variables, preserves input box. To clear input box type "clear" in command line
- **Syntax Check**
checks the syntax of the contents of the input box without drawing to the output
- **Save**
saves the contents of the inputbox as a .txt file
- **Load**
loads a .txt file to the input box

## Command Syntax
The program accepts known actions and paramaters, and can compute and assign variables.
Variables can be used as action or drawing paramaters, and calculation and processing errors are reported to the user.
User input must be formatted correctly or error feedback will be reported and shapes not drawn.
### Actions
Actions are the main commands accepted by the program:
#### Shape Actions
Shapes are drawn with their name and a number value for each paramater required.
Actions are not case-sensitive. Paramaters have varying input conditions defined for each type.
Paramaters be seperated by comma or spaces.
-**Circle**"circle 50" will draw a circle with a 50px radius
-**Square**"square 50" will draw a square with a 50px side-length
-**Rectangle**"rectangle 50, 70" will draw a rectangle with a 5opx width and a 70px height
-**Triangle**"triangle 30, 40 ,50" will draw a triangle with sides equal to the 3 input paramaters
-**Line**"line 100, 100" draws a line from the default position to the defined coordinate position
-**Drawto**"drawto 50, 50" same as line method, used in varying input styles so both included
### Program Actions
Program actions call additional functionality to the input. Most require paramaters to be passed in. Loops and If statments must be closed with their appropriate "end" command.
-**Loop** "loop 50" will execute all lines between "loop 50" and "end loop" a number of times defined by the paramater.
-**If** "if 12 > 15" will compute the statment and apply the condition to the code block leading up to "end if"
   ##### If Syntax
   - 
### Control Actions
Control actions affect the form or output window without drawing shapes 
-**Moveto**"moveto 40, 40" moves the starting draw position to the defined coordinate position
-**Reset**"reset" resets the starting draw position (default is 0,0)
-**Clear** "clear" clears the output, syntax feedback, input box and program values
#### Colour Controls
Changing the program colour affects all shapes drawn after the colour is changed until the program is cleared or "colourreset" is input.
-**Colour Red** "colourred" sets the draw colour to red
-**Colour Green** "colourgreen" sets the draw colour to green
-**Colour Blue** "colour blue "sets the draw colour to blue
-**Colour Reset** "colour reset" resets the draw colour to default (black)

