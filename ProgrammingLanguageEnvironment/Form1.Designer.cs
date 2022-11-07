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
            ((System.ComponentModel.ISupportInitialize)(this.OutputWindow)).BeginInit();
            this.SuspendLayout();
            // 
            // CommandLine
            // 
            this.CommandLine.Location = new System.Drawing.Point(11, 362);
            this.CommandLine.Name = "CommandLine";
            this.CommandLine.Size = new System.Drawing.Size(402, 20);
            this.CommandLine.TabIndex = 0;
            this.CommandLine.KeyDown += new System.Windows.Forms.KeyEventHandler(this.CommandLine_KeyDown);
            // 
            // runButton
            // 
            this.runButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.runButton.Location = new System.Drawing.Point(12, 388);
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
            this.OutputWindow.Location = new System.Drawing.Point(420, 12);
            this.OutputWindow.Name = "OutputWindow";
            this.OutputWindow.Size = new System.Drawing.Size(368, 426);
            this.OutputWindow.TabIndex = 2;
            this.OutputWindow.TabStop = false;
            this.OutputWindow.Click += new System.EventHandler(this.pictureBox1_Click);
            this.OutputWindow.Paint += new System.Windows.Forms.PaintEventHandler(this.OutputWindow_Paint);
            // 
            // ProgramWindow
            // 
            this.ProgramWindow.Location = new System.Drawing.Point(14, 12);
            this.ProgramWindow.Name = "ProgramWindow";
            this.ProgramWindow.Size = new System.Drawing.Size(399, 338);
            this.ProgramWindow.TabIndex = 3;
            this.ProgramWindow.Text = "";
            this.ProgramWindow.TextChanged += new System.EventHandler(this.ProgramWindow_TextChanged);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(132, 389);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(111, 49);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.button1_Click_1);
            // 
            // saveButton
            // 
            this.saveButton.Location = new System.Drawing.Point(289, 388);
            this.saveButton.Name = "saveButton";
            this.saveButton.Size = new System.Drawing.Size(75, 23);
            this.saveButton.TabIndex = 5;
            this.saveButton.Text = "Save";
            this.saveButton.UseVisualStyleBackColor = true;
            this.saveButton.Click += new System.EventHandler(this.button2_Click);
            // 
            // loadButton
            // 
            this.loadButton.Location = new System.Drawing.Point(289, 418);
            this.loadButton.Name = "loadButton";
            this.loadButton.Size = new System.Drawing.Size(75, 23);
            this.loadButton.TabIndex = 6;
            this.loadButton.Text = "Load";
            this.loadButton.UseVisualStyleBackColor = true;
            this.loadButton.Click += new System.EventHandler(this.button3_Click);
            // 
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.loadButton);
            this.Controls.Add(this.saveButton);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.ProgramWindow);
            this.Controls.Add(this.OutputWindow);
            this.Controls.Add(this.runButton);
            this.Controls.Add(this.CommandLine);
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
    }
}

