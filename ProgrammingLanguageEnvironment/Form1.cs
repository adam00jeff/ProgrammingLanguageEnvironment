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

    /// <summary>Holds the main elements for the form</summary>
    public partial class MainForm : Form
    {
        /// <summary>The output bitmap</summary>
        /// 


        Image OutputBitmap = new Bitmap(640, 480);
        /// <summary>The shapes
        /// to be drawn</summary>
        public ArrayList shapes = new ArrayList();
        /// <summary>The array of feedback strings to be output</summary>
        public List<string> feedback = new List<string>();
       /// <summary>
       /// initalise the form
       /// </summary>
       public MainForm()
       {
            InitializeComponent(); 
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
            var list = Execute.feedback;
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
            for (int i = 0; i < list.Count; i++)//loops through feedback
            {
                string f = list[i].ToString();
                feedbackBox.Text +=f+ Environment.NewLine ;
            }
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
            Execute.feedback.Clear();
            feedbackBox.Text = "";
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
        /// <summary>
        /// Handles the 2 event of the syntax button control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void button1_Click_2(object sender, EventArgs e)
        {

            var parse = Execute.ExecuteParse(ProgramWindow.Text, shapes);//executes program window
            shapes.Clear();
            Refresh(); // update the outputwindow
        }
        /// <summary>
        /// Handles the Load event of the Form1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void Form1_Load(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the Click event of the pictureBox1 control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void pictureBox1_Click(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the TextChanged event of the CommandLine control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void CommandLine_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the TextChanged event of the ProgramWindow control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void ProgramWindow_TextChanged(object sender, EventArgs e)
        {

        }
        /// <summary>
        /// Handles the TextChanged event of the feedbackBox control.
        /// </summary>
        /// <param name="sender">The source of the event.</param>
        /// <param name="e">The <see cref="EventArgs"/> instance containing the event data.</param>
        private void feedbackBox_TextChanged(object sender, EventArgs e)
        {

        }

    }     
        
}

/*            System.Windows.Forms.Timer timer1 = new System.Windows.Forms.Timer();
            timer1.Interval=50;
            timer1.Tick += new System.EventHandler(timer1_Tick);
            timer1.Start();*/
/*        private void timer1_Tick(object sender, EventArgs e)
        {
            Console.WriteLine("refreshed");
            Refresh();
        }*/

