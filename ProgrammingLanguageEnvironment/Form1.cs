using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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
                //TO DO EXTRACT CODE AND PARAMATERS FROM COMMAND LINE
                //Methodise the below to allow calling from elsewhere
                // call new process method here

                String Command = CommandLine.Text.Trim().ToLower(); // read + sanitise commandline // change this to parser class
                                                                    // switch (command typed) <- add a switch to replace the if
                if (Command.Equals("line") == true)
                {
                    MyCanvass.DrawLine(160, 120);
                    Console.WriteLine("LINE");
                }
                else if (Command.Equals("square") == true)
                {
                    MyCanvass.DrawSquare(25);
                    Console.WriteLine("SQUARE");
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
