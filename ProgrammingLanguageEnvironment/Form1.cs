using System;
using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Drawing.Text;
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
        
        Bitmap OutputBitmap = new Bitmap(640, 480); // bitmap to output grpahics objects onto and apply to form
        public ArrayList shapes = new ArrayList();// creates a list to hold shapes to be drawn
        public List<string> feedback = new List<string>()
        {
            "test","test","test"
        };
       /// <summary>
       /// initalise the form
       /// </summary>
       /// 


        public MainForm()
        {
            InitializeComponent(); 
/*            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval=50;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();*/
            
        }
/*        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("refreshed");
            Refresh();
        }*/
        private void Form1_Load(object sender, EventArgs e)
        {

        }

        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// detects when the user presses return to submit command line data
        /// if thwere is data in the command line it is executed
        /// if run is entered the program window is executed
        /// iif clear is entered the values for the program are cleared
        /// </summary>
        /// <param name="sender">the command line</param>
        /// <param name="e">the keypressed event</param>
        private void CommandLine_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Enter)//check the key pressed was enter
            {
                var input = CommandLine.Text;//gets command line data
                if (input.Trim() == "clear")//checks for clear command
                {
                    string clear = "clear";
                    var parse = Execute.ExecuteParse(clear, shapes);//parses the input from the Program Window
                    shapes = new ArrayList();//clears array
                    ProgramWindow.Text = "";//clears program window
                    CommandLine.Text = "";//clears command line
                    Refresh();// update  the output window
                    e.SuppressKeyPress = true;
                }
                else if (CommandLine.Text.Trim() == "run")//checks for run command
                {
                    var parse = Execute.ExecuteParse(ProgramWindow.Text, shapes);//parses the input from the Program Window
                    shapes = (ArrayList)parse;//adds shapes to be drawn to array
                    Console.WriteLine("run");//reports a run command
                    CommandLine.Text = "";//clears the command line
                    Refresh(); // update the outputwindow
                    e.SuppressKeyPress = true;
                }
                else
                {
                    var parse = Execute.ExecuteParse(CommandLine.Text, shapes);//executes the command line
                    shapes = (ArrayList)parse;//adds shapes to the array
                    CommandLine.Text = "";//clears the command line
                    Refresh(); // update the outputwindow
                    e.SuppressKeyPress = true;
                }
            }
            
        }
        /// <summary>
        /// event for clicking the run button
        /// </summary>
        /// <param name="sender">the run button</param>
        /// <param name="e">the click event</param>
        private void button1_Click(object sender, EventArgs e)
        {

            if (string.IsNullOrWhiteSpace(CommandLine.Text.Trim()))//if the command line is empty or whitespace
            {
                if (ProgramWindow.Text.Trim() == "clear")//check program window for clear command
                {
                    string clear = "clear";
                    var parse = Execute.ExecuteParse(clear, shapes);//parses the input from the Program Window
                    shapes = new ArrayList();
                    ProgramWindow.Text = "";
                    Refresh();
                }
                else
                {
                    var parse = Execute.ExecuteParse(ProgramWindow.Text, shapes);//executes program window
                    shapes = (ArrayList)parse;//adds shapes to the array
                    Refresh(); // update the outputwindow
                }
            }
            else
            {
                var input = CommandLine.Text;//if the command line has data, execute command line then clear it
                if (input.Trim() == "clear")//checks command liine for clear commmand
                {
                    string clear = "clear";
                    var parse = Execute.ExecuteParse(clear, shapes);
                    shapes = new ArrayList();
                    ProgramWindow.Text = "";
                    CommandLine.Text = "";
                    Refresh();
                }

                else if (CommandLine.Text.Trim() == "run")//checks command line for run command, runs program window
                {
                    var parse = Execute.ExecuteParse(ProgramWindow.Text, shapes);
                    shapes = (ArrayList)parse;
                    Console.WriteLine("run");
                    CommandLine.Text = "";
                    Refresh(); // update the outputwindow
                }
                else
                {
                    var parse = Execute.ExecuteParse(CommandLine.Text, shapes);//executes the command line
                    shapes = (ArrayList)parse;
                    CommandLine.Text = "";
                    Refresh(); // update the outputwindow
                }

            }

        }
        /// <summary>
        /// gets values for the ouput window
        /// </summary>
        /// <param name="sender">the output paint window</param>
        /// <param name="e"></param>
        private void OutputWindow_Paint(object sender, PaintEventArgs e)
        {
            Graphics g = e.Graphics; // get graphics context of the form
            g.DrawImageUnscaled(OutputBitmap, 0, 0); // put the bitmap on the form
           
                for (int i = 0; i < shapes.Count; i++)//loops through shapes array
                {
                Shape s;
                    s = (Shape)shapes[i];//creates a shape for each shape in the array
                    if (Execute.fill == true)// checks fill bool
                    {
                        s.drawfilled(g);//draws a filled shape
       
                    }
                    else
                    {
                        s.draw(g);//draws a empty shape
                    }                
                }
            for (int i = 0; i < feedback.Count; i++)//loops through feedback
            {
                string f = feedback[i].ToString();
                feedbackBox.Text +=f+ Environment.NewLine ;
            }
        }
        private void ProgramWindow_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// clear button
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the click</param>
        private void button1_Click_1(object sender, EventArgs e)
        {
            string clear = "clear";
            var parse = Execute.ExecuteParse(clear, shapes);//parses the input from the Program Window
            shapes = new ArrayList();//clears array
            //ProgramWindow.Text = "";//clears program window // this is actually annoying to clear
            //CommandLine.Text = "";//clears command line // as above
            Refresh();// updat  the output window
        }
        /// <summary>
        /// save button
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the click</param>
        private void button2_Click(object sender, EventArgs e)
        {
            SaveFileDialog saveFile1 = new SaveFileDialog(); // Create a SaveFileDialog to request a path and file name to save to.        
            saveFile1.DefaultExt = "*.txt";// Initialize the SaveFileDialog to specify the RTF extension for the file.
            saveFile1.Filter = "Text Files (*.txt)|*.txt|RTF Files (*.rtf)|*.rtf";//filters for .rtf and .txt          
            if (saveFile1.ShowDialog() == System.Windows.Forms.DialogResult.OK &&
               saveFile1.FileName.Length > 0)// Determine if the user selected a file name from the saveFileDialog.
            {
                ProgramWindow.SaveFile(saveFile1.FileName, RichTextBoxStreamType.PlainText); // Save the contents of the RichTextBox into the file.
                MessageBox.Show("save successfully", "Address File : " + saveFile1.FileName, MessageBoxButtons.OK, MessageBoxIcon.Information);//reports successful save
            }
        }
        /// <summary>
        /// the load button
        /// </summary>
        /// <param name="sender">the button</param>
        /// <param name="e">the click</param>
        private void button3_Click(object sender, EventArgs e)
        {
            Stream myStream; // a new memory stream
            OpenFileDialog openFileDialog1 = new OpenFileDialog();// a new file dialog for locating the file to be loaded

            if (openFileDialog1.ShowDialog() == System.Windows.Forms.DialogResult.OK)//Determine if the user selected a file to be loaded
            {
                if ((myStream =openFileDialog1.OpenFile()) != null)
                {
                    string strfilename = openFileDialog1.FileName;//gets the name of the file
                    string filetext = File.ReadAllText(strfilename);//passes the text fo the file to string
                    ProgramWindow.Text = filetext;//changes the program window text to the file text
                    Console.WriteLine("load");// reports a successful load
                }
            }
        }

        private void CommandLine_TextChanged(object sender, EventArgs e)
        {

        }

        private void feedbackBox_TextChanged(object sender, EventArgs e)
        {

        }
    }
}


   
