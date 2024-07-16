namespace csv_parser
{
    partial class Form1
    {
        private System.ComponentModel.IContainer components = null;
        private System.Windows.Forms.Button btnOpenFile;
        private System.Windows.Forms.CheckedListBox checkedListBoxHeaders;
        private System.Windows.Forms.Button btnToggleView;
        private System.Windows.Forms.DataGridView dataGridView;

        protected override void Dispose(bool disposing)
        {
            if (disposing && (components != null))
            {
                components.Dispose();
            }
            base.Dispose(disposing);
        }

        private void InitializeComponent()
        {
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(Form1));
            this.btnOpenFile = new System.Windows.Forms.Button();
            this.checkedListBoxHeaders = new System.Windows.Forms.CheckedListBox();
            this.btnToggleView = new System.Windows.Forms.Button();
            this.dataGridView = new System.Windows.Forms.DataGridView();
            this.btnExportExcel = new System.Windows.Forms.Button();
            this.btnChangeCellColor = new System.Windows.Forms.Button();
            this.btnAddCommentColumn = new System.Windows.Forms.Button();
            this.btnAddColumn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.label2 = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.btnHighlightDuplicates = new System.Windows.Forms.Button();
            this.btnDeleteDuplicates = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).BeginInit();
            this.groupBox1.SuspendLayout();
            this.SuspendLayout();
            // 
            // btnOpenFile
            // 
            this.btnOpenFile.Location = new System.Drawing.Point(6, 27);
            this.btnOpenFile.Name = "btnOpenFile";
            this.btnOpenFile.Size = new System.Drawing.Size(75, 23);
            this.btnOpenFile.TabIndex = 0;
            this.btnOpenFile.Text = "Open CSV";
            this.btnOpenFile.UseVisualStyleBackColor = true;
            this.btnOpenFile.Click += new System.EventHandler(this.btnOpenFile_Click);
            // 
            // checkedListBoxHeaders
            // 
            this.checkedListBoxHeaders.FormattingEnabled = true;
            this.checkedListBoxHeaders.Location = new System.Drawing.Point(13, 10);
            this.checkedListBoxHeaders.Name = "checkedListBoxHeaders";
            this.checkedListBoxHeaders.Size = new System.Drawing.Size(269, 124);
            this.checkedListBoxHeaders.TabIndex = 1;
            // 
            // btnToggleView
            // 
            this.btnToggleView.Location = new System.Drawing.Point(6, 85);
            this.btnToggleView.Name = "btnToggleView";
            this.btnToggleView.Size = new System.Drawing.Size(77, 23);
            this.btnToggleView.TabIndex = 2;
            this.btnToggleView.Text = "Apply Filter";
            this.btnToggleView.UseVisualStyleBackColor = true;
            this.btnToggleView.Click += new System.EventHandler(this.btnToggleView_Click);
            // 
            // dataGridView
            // 
            this.dataGridView.AllowUserToOrderColumns = true;
            this.dataGridView.Anchor = ((System.Windows.Forms.AnchorStyles)((((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Bottom) 
            | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.dataGridView.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.dataGridView.Location = new System.Drawing.Point(13, 140);
            this.dataGridView.Name = "dataGridView";
            this.dataGridView.Size = new System.Drawing.Size(542, 298);
            this.dataGridView.TabIndex = 3;
            // 
            // btnExportExcel
            // 
            this.btnExportExcel.BackColor = System.Drawing.Color.Transparent;
            this.btnExportExcel.Location = new System.Drawing.Point(6, 56);
            this.btnExportExcel.Name = "btnExportExcel";
            this.btnExportExcel.Size = new System.Drawing.Size(75, 23);
            this.btnExportExcel.TabIndex = 5;
            this.btnExportExcel.Text = "Export Excel";
            this.btnExportExcel.UseVisualStyleBackColor = false;
            this.btnExportExcel.Click += new System.EventHandler(this.btnExportExcel_Click);
            // 
            // btnChangeCellColor
            // 
            this.btnChangeCellColor.Location = new System.Drawing.Point(87, 85);
            this.btnChangeCellColor.Name = "btnChangeCellColor";
            this.btnChangeCellColor.Size = new System.Drawing.Size(75, 23);
            this.btnChangeCellColor.TabIndex = 6;
            this.btnChangeCellColor.Text = "Change Colour";
            this.btnChangeCellColor.UseVisualStyleBackColor = true;
            this.btnChangeCellColor.Click += new System.EventHandler(this.btnChangeCellColor_Click);
            // 
            // btnAddCommentColumn
            // 
            this.btnAddCommentColumn.Location = new System.Drawing.Point(87, 27);
            this.btnAddCommentColumn.Name = "btnAddCommentColumn";
            this.btnAddCommentColumn.Size = new System.Drawing.Size(75, 23);
            this.btnAddCommentColumn.TabIndex = 7;
            this.btnAddCommentColumn.Text = "Comment";
            this.btnAddCommentColumn.UseVisualStyleBackColor = true;
            this.btnAddCommentColumn.Click += new System.EventHandler(this.btnAddCommentColumn_Click);
            // 
            // btnAddColumn
            // 
            this.btnAddColumn.Location = new System.Drawing.Point(87, 56);
            this.btnAddColumn.Name = "btnAddColumn";
            this.btnAddColumn.Size = new System.Drawing.Size(75, 23);
            this.btnAddColumn.TabIndex = 8;
            this.btnAddColumn.Text = "New Column";
            this.btnAddColumn.UseVisualStyleBackColor = true;
            this.btnAddColumn.Click += new System.EventHandler(this.btnAddColumn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Anchor = ((System.Windows.Forms.AnchorStyles)(((System.Windows.Forms.AnchorStyles.Top | System.Windows.Forms.AnchorStyles.Left) 
            | System.Windows.Forms.AnchorStyles.Right)));
            this.groupBox1.Controls.Add(this.btnDeleteDuplicates);
            this.groupBox1.Controls.Add(this.btnHighlightDuplicates);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.Controls.Add(this.btnToggleView);
            this.groupBox1.Controls.Add(this.btnChangeCellColor);
            this.groupBox1.Controls.Add(this.btnExportExcel);
            this.groupBox1.Controls.Add(this.btnAddColumn);
            this.groupBox1.Controls.Add(this.btnAddCommentColumn);
            this.groupBox1.Controls.Add(this.btnOpenFile);
            this.groupBox1.Location = new System.Drawing.Point(288, 4);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(267, 130);
            this.groupBox1.TabIndex = 9;
            this.groupBox1.TabStop = false;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.BackColor = System.Drawing.SystemColors.Control;
            this.label2.Location = new System.Drawing.Point(432, 11);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(0, 13);
            this.label2.TabIndex = 10;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.BackColor = System.Drawing.SystemColors.Control;
            this.label1.Location = new System.Drawing.Point(3, 11);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(85, 13);
            this.label1.TabIndex = 9;
            this.label1.Text = "Content Controls";
            // 
            // btnHighlightDuplicates
            // 
            this.btnHighlightDuplicates.Location = new System.Drawing.Point(168, 28);
            this.btnHighlightDuplicates.Name = "btnHighlightDuplicates";
            this.btnHighlightDuplicates.Size = new System.Drawing.Size(75, 23);
            this.btnHighlightDuplicates.TabIndex = 11;
            this.btnHighlightDuplicates.Text = "Highlight Duplicates";
            this.btnHighlightDuplicates.UseVisualStyleBackColor = true;
            this.btnHighlightDuplicates.Click += new System.EventHandler(this.btnHighlightDuplicates_Click);
            // 
            // btnDeleteDuplicates
            // 
            this.btnDeleteDuplicates.Location = new System.Drawing.Point(169, 57);
            this.btnDeleteDuplicates.Name = "btnDeleteDuplicates";
            this.btnDeleteDuplicates.Size = new System.Drawing.Size(74, 23);
            this.btnDeleteDuplicates.TabIndex = 12;
            this.btnDeleteDuplicates.Text = "Delete Duplicates";
            this.btnDeleteDuplicates.UseVisualStyleBackColor = true;
            this.btnDeleteDuplicates.Click += new System.EventHandler(this.btnDeleteDuplicates_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.SystemColors.Control;
            this.ClientSize = new System.Drawing.Size(567, 450);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.dataGridView);
            this.Controls.Add(this.checkedListBoxHeaders);
            this.Icon = ((System.Drawing.Icon)(resources.GetObject("$this.Icon")));
            this.MinimumSize = new System.Drawing.Size(583, 489);
            this.Name = "Form1";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "Nippler v1.0";
            this.Load += new System.EventHandler(this.Form1_Load);
            ((System.ComponentModel.ISupportInitialize)(this.dataGridView)).EndInit();
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.ResumeLayout(false);

        }
        private System.Windows.Forms.Button btnExportExcel;
        private System.Windows.Forms.Button btnChangeCellColor;
        private System.Windows.Forms.Button btnAddCommentColumn;
        private System.Windows.Forms.Button btnAddColumn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btnHighlightDuplicates;
        private System.Windows.Forms.Button btnDeleteDuplicates;
    }
}
