﻿namespace ProgrammingLanguageEnvironment
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
            this.RunButton = new System.Windows.Forms.Button();
            this.OutputWindow = new System.Windows.Forms.PictureBox();
            this.ProgramWindow = new System.Windows.Forms.RichTextBox();
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
            // RunButton
            // 
            this.RunButton.FlatStyle = System.Windows.Forms.FlatStyle.Popup;
            this.RunButton.Location = new System.Drawing.Point(12, 388);
            this.RunButton.Name = "RunButton";
            this.RunButton.Size = new System.Drawing.Size(113, 50);
            this.RunButton.TabIndex = 1;
            this.RunButton.Text = "Run";
            this.RunButton.UseVisualStyleBackColor = true;
            this.RunButton.Click += new System.EventHandler(this.button1_Click);
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
            // MainForm
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(800, 450);
            this.Controls.Add(this.ProgramWindow);
            this.Controls.Add(this.OutputWindow);
            this.Controls.Add(this.RunButton);
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
        private System.Windows.Forms.Button RunButton;
        private System.Windows.Forms.PictureBox OutputWindow;
        private System.Windows.Forms.RichTextBox ProgramWindow;
    }
}

