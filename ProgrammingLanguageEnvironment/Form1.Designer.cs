namespace ProgrammingLanguageEnvironment
{
    partial class MainForm
    {
        /// <summary>
        /// Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        /// Clean up any resources being used.
        /// </summary>
        /// <param name="disposing">true if managed resources should be disposed; otherwise, false.</param>
        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        #region Windows Form Designer generated code

        /// <summary>
        /// Required method for Designer support - do not modify
        /// the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.CommandLine = new System.Windows.Forms.TextBox();
            this.runButton = new System.Windows.Forms.Button();
            this.OutputWindow = new System.Windows.Forms.PictureBox();
            this.ProgramWindow = new System.Windows.Forms.RichTextBox();
            this.clearButton = new System.Windows.Forms.Button();
            this.saveButton = new System.Windows.Forms.Button();
            this.loadButton = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.label2 = new System.Windows.Forms.Label();
            this.label3 = new System.Windows.Forms.Label();
            this.label4 = new System.Windows.Forms.Label();
            this.label5 = new System.Windows.Forms.Label();
            this.label6 = new System.Windows.Forms.Label();
            this.label7 = new System.Windows.Forms.Label();
            this.label8 = new System.Windows.Forms.Label();
            ((System.ComponentModel.ISupportInitialize)(this.OutputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // CommandLine
            // 
            this.CommandLine.Location = new System.Drawing.Point(21, 394);
            this.CommandLine.Name = "CommandLine";
            this.CommandLine.Size = new System.Drawing.Size(432, 20);
            this.CommandLine.TabIndex = 0;
            this.CommandLine.TextChanged += new System.EventHandler(this.CommandLine_TextChanged);
            this.CommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandLine_KeyDown);
            // 
            // runButton
            // 
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.runButton.Location = new System.Drawing.Point(21, 430);
            this.runButton.Name = "runButton";
            this.runButton.Size = new System.Drawing.Size(113, 50);
            this.runButton.TabIndex = 1;
            this.runButton.Text = "Run ";
            this.runButton.UseVisualStyleBackColor = true;
            this.runButton.Click += new System.EventHandler(this.button1_Click);
            // 
            // OutputWindow
            // 
            this.OutputWindow.BackgroundImageLayout = System.Windows.Forms.ImageLayout.None;
            this.OutputWindow.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.OutputWindow.Location = new System.Drawing.Point(502, 33);
            this.OutputWindow.Name = "OutputWindow";
            this.OutputWindow.Size = new System.Drawing.Size(405, 462);
            this.OutputWindow.TabIndex = 2;
            this.OutputWindow.TabStop = false;
            this.OutputWindow.Click += new System.EventHandler(this.pictureBox1_Click);
            this.OutputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.OutputWindow_Paint);
            // 
            // ProgramWindow
            // 
            this.ProgramWindow.Location = new System.Drawing.Point(21, 33);
            this.ProgramWindow.Name = "ProgramWindow";
            this.ProgramWindow.Size = new System.Drawing.Size(432, 355);
            this.ProgramWindow.TabIndex = 3;
            this.ProgramWindow.Text = "";
            this.ProgramWindow.TextChanged += new System.EventHandler(this.ProgramWindow_TextChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(177, 430);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(111, 49);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(328, 431);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(328, 457);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(481, 20);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(22, 13);
            this.label1.TabIndex = 7;
            this.label1.Text = "0,0";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(583, 17);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(34, 13);
            this.label2.TabIndex = 8;
            this.label2.Text = "100,0";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(468, 127);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(34, 13);
            this.label3.TabIndex = 9;
            this.label3.Text = "0,100";
            // 
            // label4
            // 
            this.label4.AutoSize = true;
            this.label4.Location = new System.Drawing.Point(468, 225);
            this.label4.Name = "label4";
            this.label4.Size = new System.Drawing.Size(34, 13);
            this.label4.TabIndex = 10;
            this.label4.Text = "0,200";
            // 
            // label5
            // 
            this.label5.AutoSize = true;
            this.label5.Location = new System.Drawing.Point(468, 326);
            this.label5.Name = "label5";
            this.label5.Size = new System.Drawing.Size(34, 13);
            this.label5.TabIndex = 11;
            this.label5.Text = "0,300";
            // 
            // label6
            // 
            this.label6.AutoSize = true;
            this.label6.Location = new System.Drawing.Point(468, 425);
            this.label6.Name = "label6";
            this.label6.Size = new System.Drawing.Size(34, 13);
            this.label6.TabIndex = 12;
            this.label6.Text = "0,400";
            // 
            // label7
            // 
            this.label7.AutoSize = true;
            this.label7.Location = new System.Drawing.Point(682, 17);
            this.label7.Name = "label7";
            this.label7.Size = new System.Drawing.Size(34, 13);
            this.label7.TabIndex = 13;
            this.label7.Text = "200,0";
            // 
            // label8
            // 
            this.label8.AutoSize = true;
            this.label8.Location = new System.Drawing.Point(784, 17);
            this.label8.Name = "label8";
            this.label8.Size = new System.Drawing.Size(34, 13);
            this.label8.TabIndex = 14;
            this.label8.Text = "300,0";
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(919, 507);
            this.Controls.Add(this.label8);
            this.Controls.Add(this.label7);
            this.Controls.Add(this.label6);
            this.Controls.Add(this.label5);
            this.Controls.Add(this.label4);
            this.Controls.Add(this.label3);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.ProgramWindow);
            this.Controls.Add(this.OutputWindow);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.CommandLine);
            this.DoubleBuffered = true;
            this.Name = "MainForm";
            this.Text = "Programming Language Environment";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.OutputWindow)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox CommandLine;
        private System.Windows.Forms.Button runButton;
        private System.Windows.Forms.PictureBox OutputWindow;
        private System.Windows.Forms.RichTextBox ProgramWindow;
        private System.Windows.Forms.Button clearButton;
        private System.Windows.Forms.Button saveButton;
        private System.Windows.Forms.Button loadButton;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label label4;
        private System.Windows.Forms.Label label5;
        private System.Windows.Forms.Label label6;
        private System.Windows.Forms.Label label7;
        private System.Windows.Forms.Label label8;
    }
}

