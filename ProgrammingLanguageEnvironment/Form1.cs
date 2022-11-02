using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageEnvironment
{
    public partial class MainForm : Form
    {
        //bitmap that will be displayed in OutputWindow picturebox
        Bitmap OutputBitmap = new Bitmap(640, 480); // TO DO CHANGE THIS JUST FROM EXAMPLE VIDEO
        Canvass MyCanvass;
        public MainForm()
        {
            InitializeComponent();
            MyCanvass = new Canvass(Graphics.FromImage(OutputBitmap));
        }

        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// detects when the user presses return to submit command line data
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)
            {
                //var Command = Parser.ParseInput(CommandLine.Text);
                //TO DO EXTRACT CODE AND PARAMATERS FROM COMMAND LINE
                //Methodise the below to allow calling from elsewhere
                // call new process method here
               // String Command = CommandLine.Text.Trim().ToLower(); 
                // read + sanitise commandline // change this to parser class
                // switch (command typed) <- add a switch to replace the if
                //if (Command.Action.Equals("line") == true)

                var result = Parser.ParseInput(CommandLine.Text);
                var input1 = result.Action;
                var input2 = result.Paramaters;

                if (input1.Equals(Action.Line) == true)
                {
                    MyCanvass.DrawLine(160, 120);
                    Console.WriteLine("LINE");
                }
                else if (input1.Equals(Action.Square) == true)
                {
                    MyCanvass.DrawSquare(50);
                    Console.WriteLine("SQUARE");
                }
                else if (input1.Equals(Action.Triangle) == true)
                {
                    MyCanvass.DrawTriangle(55, 55, 55);
                    Console.WriteLine("TRIANGLE");
                }
                CommandLine.Text = ""; // clears the commandline
                Refresh(); // update the outputwindow

                //Console.WriteLine("enter pressed");
            }
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics; // get graphics context of the form
            g.DrawImageUnscaled(OutputBitmap, 0, 0); // put the bitmap on the form
            
        }
    }
}
