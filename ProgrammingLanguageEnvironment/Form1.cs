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
        public ArrayList shapes = new ArrayList();
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
                var parse = Execute.ExecuteParse(ProgramWindow.Text, shapes);
                shapes = (ArrayList)parse;
                Refresh(); // update the outputwindow
            }
        }
       private void button1_Click(object sender, EventArgs e)
        {
            var parse = Execute.ExecuteParse(ProgramWindow.Text, shapes);
            shapes = (ArrayList)parse;
            Refresh(); // update the outputwindow
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
