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
            this.testOutput = new System.Windows.Forms.TextBox();
            this.outputCanvas = new System.Windows.Forms.PictureBox();
            this.outputLog = new System.Windows.Forms.RichTextBox();
            ((System.ComponentModel.ISupportInitialize)(this.outputCanvas)).BeginInit();
            this.SuspendLayout();
            // 
            // inputTextBox
            // 
            this.inputTextBox.Location = new System.Drawing.Point(22, 26);
            this.inputTextBox.Margin = new System.Windows.Forms.Padding(6);
            this.inputTextBox.Name = "inputTextBox";
            this.inputTextBox.Size = new System.Drawing.Size(700, 710);
            this.inputTextBox.TabIndex = 2;
            this.inputTextBox.Text = "";
            // 
            // submitButton
            // 
            this.submitButton.Location = new System.Drawing.Point(22, 815);
            this.submitButton.Margin = new System.Windows.Forms.Padding(6);
            this.submitButton.Name = "submitButton";
            this.submitButton.Size = new System.Drawing.Size(208, 92);
            this.submitButton.TabIndex = 3;
            this.submitButton.Text = "Submit";
            this.submitButton.UseVisualStyleBackColor = true;
            this.submitButton.Click += new System.EventHandler(this.submitButton_Click);
            // 
            // clearButton
            // 
            this.clearButton.Location = new System.Drawing.Point(737, 815);
            this.clearButton.Margin = new System.Windows.Forms.Padding(6);
            this.clearButton.Name = "clearButton";
            this.clearButton.Size = new System.Drawing.Size(208, 92);
            this.clearButton.TabIndex = 4;
            this.clearButton.Text = "Clear";
            this.clearButton.UseVisualStyleBackColor = true;
            this.clearButton.Click += new System.EventHandler(this.clearButton_Click);
            // 
            // commandLineInput
            // 
            this.commandLineInput.Location = new System.Drawing.Point(22, 753);
            this.commandLineInput.Margin = new System.Windows.Forms.Padding(6);
            this.commandLineInput.Name = "commandLineInput";
            this.commandLineInput.Size = new System.Drawing.Size(700, 39);
            this.commandLineInput.TabIndex = 5;
            this.commandLineInput.KeyDown += new System.Windows.Forms.KeyEventHandler(this.commandLineInput_KeyDown);
            // 
            // testOutput
            // 
            this.testOutput.Location = new System.Drawing.Point(1014, 838);
            this.testOutput.Margin = new System.Windows.Forms.Padding(6);
            this.testOutput.Name = "testOutput";
            this.testOutput.Size = new System.Drawing.Size(342, 39);
            this.testOutput.TabIndex = 6;
            // 
            // outputCanvas
            // 
            this.outputCanvas.BackColor = System.Drawing.Color.Silver;
            this.outputCanvas.BorderStyle = System.Windows.Forms.BorderStyle.Fixed3D;
            this.outputCanvas.Location = new System.Drawing.Point(737, 26);
            this.outputCanvas.Margin = new System.Windows.Forms.Padding(6);
            this.outputCanvas.Name = "outputCanvas";
            this.outputCanvas.Size = new System.Drawing.Size(704, 772);
            this.outputCanvas.TabIndex = 7;
            this.outputCanvas.TabStop = false;
            this.outputCanvas.Paint += new System.Windows.Forms.PaintEventHandler(this.outputCanvas_Paint);
            this.outputCanvas.MouseDown += new System.Windows.Forms.MouseEventHandler(this.outputCanvas_MouseDown);
            this.outputCanvas.MouseUp += new System.Windows.Forms.MouseEventHandler(this.outputCanvas_MouseUp);
            // 
            // outputLog
            // 
            this.outputLog.BackColor = System.Drawing.SystemColors.ScrollBar;
            this.outputLog.Location = new System.Drawing.Point(241, 815);
            this.outputLog.Margin = new System.Windows.Forms.Padding(6);
            this.outputLog.Name = "outputLog";
            this.outputLog.ReadOnly = true;
            this.outputLog.Size = new System.Drawing.Size(481, 87);
            this.outputLog.TabIndex = 8;
            this.outputLog.Text = "";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(13F, 32F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1467, 932);
            this.Controls.Add(this.outputLog);
            this.Controls.Add(this.outputCanvas);
            this.Controls.Add(this.testOutput);
            this.Controls.Add(this.commandLineInput);
            this.Controls.Add(this.clearButton);
            this.Controls.Add(this.submitButton);
            this.Controls.Add(this.inputTextBox);
            this.Margin = new System.Windows.Forms.Padding(6);
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
        private TextBox testOutput;
        private PictureBox outputCanvas;
        private RichTextBox outputLog;
    }
}