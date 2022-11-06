using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace ProgrammingLanguageEnvironment
{
    public partial class MainForm : Form
    {
        
        //bitmap that will be displayed in OutputWindow picturebox
        Bitmap OutputBitmap = new Bitmap(640, 480); // TO DO CHANGE THIS JUST FROM EXAMPLE VIDEO
        //Canvass MyCanvass;
        ArrayList shapes = new ArrayList();
        public MainForm()
        {
            InitializeComponent();
           // MyCanvass = new Canvass(Graphics.FromImage(OutputBitmap));
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

                var result = Parser.ParseInput(ProgramWindow.Text);
                var input1 = result.Action;
                var input2 = result.Paramaters.ToArray();

                //shapes.Add(new Rectangle(Color.Black, 10, 100, 100, 150));

                

                switch(input1)
                {
                    case Action.Line:
                        shapes.Add(new Line(Color.Black, 50, 50, input2[0], input2[1]));
                        break;
                    case Action.Square:
                        shapes.Add(new Rectangle(Color.Black, 50, 50, input2[0], input2[0]));
                        break;
                    case Action.Circle:
                        shapes.Add(new Circle(Color.Black, 70, 70, input2[0]));
                        break;
                    case Action.Triangle:
                        shapes.Add(new Triangle(Color.Black, 60, 60, input2[0], input2[1], input2[2]));
                        break;
                }
                
                CommandLine.Text = ""; // clears the commandline
                Refresh(); // update the outputwindow
            }
        }

        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            
            Graphics g = e.Graphics; // get graphics context of the form
            g.DrawImageUnscaled(OutputBitmap, 0, 0); // put the bitmap on the form
            for (int i = 0; i < shapes.Count; i++)
            {
                Shape s;
                s = (Shape)shapes[i];
                s.draw(g);
                Console.WriteLine(s.ToString());
            }
        }

        private void ProgramWindow_TextChanged(object sender, EventArgs e)
        {

        }
    }
}
