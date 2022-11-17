namespace AssignmentApp
{
    partial class Form1
    {
        /// <summary>
        ///  Required designer variable.
        /// </summary>
        private System.ComponentModel.IContainer components = null;

        /// <summary>
        ///  Clean up any resources being used.
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
        ///  Required method for Designer support - do not modify
        ///  the contents of this method with the code editor.
        /// </summary>
        private void InitializeComponent()
        {
            this.inputTextBox = new System.Windows.Forms.RichTextBox();
            this.submitButton = new System.Windows.Forms.Button();
            this.clearButton = new System.Windows.Forms.Button();
            this.commandLineInput = new System.Windows.Forms.TextBox();
            this.outputCanvas = new System.Windows.Forms.PictureBox();
            this.outputLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
<<<<<<< Updated upstream
            this.inputTextBox.Location = new System.Drawing.Point(20, 24);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(646, 666);
            this.inputTextBox.TabIndex = 2;
=======
            this.inputTextBox.Location = new System.Drawing.Point(12, 12);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(379, 335);
            this.inputTextBox.TabIndex = 0;
>>>>>>> Stashed changes
            this.inputTextBox.Text = "";
            // 
            // submitButton
            // 
<<<<<<< Updated upstream
            this.submitButton.Location = new System.Drawing.Point(20, 764);
            this.submitButton.Margin = new System.Windows.Forms.Padding(6);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(192, 86);
            this.submitButton.TabIndex = 3;
=======
            this.submitButton.Location = new System.Drawing.Point(12, 382);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(112, 43);
            this.submitButton.TabIndex = 2;
>>>>>>> Stashed changes
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // clearButton
            // 
<<<<<<< Updated upstream
            this.clearButton.Location = new System.Drawing.Point(680, 764);
            this.clearButton.Margin = new System.Windows.Forms.Padding(6);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(192, 86);
=======
            this.clearButton.Location = new System.Drawing.Point(397, 382);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(112, 43);
>>>>>>> Stashed changes
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // commandLineInput
            // 
<<<<<<< Updated upstream
            this.commandLineInput.Location = new System.Drawing.Point(20, 706);
            this.commandLineInput.Margin = new System.Windows.Forms.Padding(6);
            this.commandLineInput.Name = "commandLineInput";
            this.commandLineInput.Size = new System.Drawing.Size(646, 35);
            this.commandLineInput.TabIndex = 5;
            this.commandLineInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLineInput_KeyDown);
            // 
            // testOutput
            // 
            this.testOutput.Location = new System.Drawing.Point(936, 786);
            this.testOutput.Margin = new System.Windows.Forms.Padding(6);
            this.testOutput.Name = "testOutput";
            this.testOutput.Size = new System.Drawing.Size(316, 35);
            this.testOutput.TabIndex = 6;
            // 
=======
            this.commandLineInput.Location = new System.Drawing.Point(12, 353);
            this.commandLineInput.Name = "commandLineInput";
            this.commandLineInput.Size = new System.Drawing.Size(379, 23);
            this.commandLineInput.TabIndex = 1;
            this.commandLineInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLineInput_KeyDown);
            // 
>>>>>>> Stashed changes
            // outputCanvas
            // 
            this.outputCanvas.BackColor = System.Drawing.Color.Silver;
            this.outputCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
<<<<<<< Updated upstream
            this.outputCanvas.Location = new System.Drawing.Point(680, 24);
            this.outputCanvas.Margin = new System.Windows.Forms.Padding(6);
            this.outputCanvas.Name = "outputCanvas";
            this.outputCanvas.Size = new System.Drawing.Size(650, 724);
=======
            this.outputCanvas.Location = new System.Drawing.Point(397, 12);
            this.outputCanvas.Name = "outputCanvas";
            this.outputCanvas.Size = new System.Drawing.Size(381, 364);
>>>>>>> Stashed changes
            this.outputCanvas.TabIndex = 7;
            this.outputCanvas.TabStop = false;
            this.outputCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.outputCanvas_Paint);
            // 
            // outputLog
            // 
            this.outputLog.BackColor = System.Drawing.SystemColors.ScrollBar;
<<<<<<< Updated upstream
            this.outputLog.Location = new System.Drawing.Point(222, 764);
            this.outputLog.Margin = new System.Windows.Forms.Padding(6);
            this.outputLog.Name = "outputLog";
            this.outputLog.ReadOnly = true;
            this.outputLog.Size = new System.Drawing.Size(444, 82);
            this.outputLog.TabIndex = 8;
=======
            this.outputLog.Location = new System.Drawing.Point(130, 382);
            this.outputLog.Name = "outputLog";
            this.outputLog.ReadOnly = true;
            this.outputLog.Size = new System.Drawing.Size(261, 43);
            this.outputLog.TabIndex = 3;
>>>>>>> Stashed changes
            this.outputLog.Text = "";
            // 
            // Form1
            // 
<<<<<<< Updated upstream
            this.AutoScaleDimensions = new System.Drawing.SizeF(12F, 30F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1354, 874);
=======
            this.AutoScaleDimensions = new System.Drawing.SizeF(7F, 15F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(790, 437);
>>>>>>> Stashed changes
            this.Controls.Add(this.outputLog);
            this.Controls.Add(this.outputCanvas);
            this.Controls.Add(this.commandLineInput);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.inputTextBox);
            this.Name = "Form1";
            this.Text = "Form1";
            ((System.ComponentModel.ISupportInitialize)(this.outputCanvas)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private RichTextBox inputTextBox;
        private Button submitButton;
        private Button clearButton;
        private TextBox commandLineInput;
        private PictureBox outputCanvas;
        private RichTextBox outputLog;
    }
}