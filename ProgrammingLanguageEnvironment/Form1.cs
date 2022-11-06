using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Security.Cryptography;
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
                var input = CommandLine.Text;
                //var firstAction = input.Select(ToLower).FirstOrDefault(input);

                if (input.Trim() == "clear")
                {
                    shapes = new ArrayList();
                    Console.WriteLine("clear");
                    ProgramWindow.Text = "";
                    CommandLine.Text = "";
                    Refresh();
                }
                else if (CommandLine.Text.Trim() == "run")
                {
                    var parse = Execute.ExecuteParse(ProgramWindow.Text, shapes);
                    shapes = (ArrayList)parse;
                    Console.WriteLine("run");
                    Refresh(); // update the outputwindow
                }
                else
                {
                    var parse = Execute.ExecuteParse(CommandLine.Text, shapes);
                    shapes = (ArrayList)parse;
                    Console.WriteLine("run");
                    Refresh(); // update the outputwindow
                }
            }
        }
        private void button1_Click(object sender, EventArgs e)
        {
            if (ProgramWindow.Text.Trim() == "clear")
            {
                shapes = new ArrayList();
                Console.WriteLine("clear");
                ProgramWindow.Text = "";
                Refresh();
            }
            else
            {
                var parse = Execute.ExecuteParse(ProgramWindow.Text, shapes);
                shapes = (ArrayList)parse;
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

        private void button1_Click_1(object sender, EventArgs e)
        {
            //clear button
            shapes = new ArrayList();
            Console.WriteLine("clear");
            ProgramWindow.Text = "";
            CommandLine.Text = "";
            Refresh();
        }

        private void button2_Click(object sender, EventArgs e)
        {
            //save button
            // Create a SaveFileDialog to request a path and file name to save to.
            SaveFileDialog saveFile1 = new SaveFileDialog();

            // Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.DefaultExt = "*.txt";
            saveFile1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";

            // Determine if the user selected a file name from the saveFileDialog.
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)
            {
                // Save the contents of the RichTextBox into the file.
                ProgramWindow.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText);
                MessageBox.Show("save successfully", "Address File : " + saveFile1.FileName, MessageBoxButtons.OK, MessageBoxIcon.Information);

            }
        }
        private void button3_Click(object sender, EventArgs e)
        {
            //load button
            Stream myStream;
            OpenFileDialog openFileDialog1 = new OpenFileDialog();

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)
            {
                if ((myStream =openFileDialog1.OpenFile()) != null)
                {
                    string strfilename = openFileDialog1.FileName;
                    string filetext = File.ReadAllText(strfilename);
                    ProgramWindow.Text = filetext;
                    Console.WriteLine("load");
                }
            }
        }
    }
}


   
