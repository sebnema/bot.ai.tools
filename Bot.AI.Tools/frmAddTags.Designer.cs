namespace Bot.AI.Tools
{
    partial class frmAddTags
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.btnAddAsTag = new System.Windows.Forms.Button();
            this.panelTags = new System.Windows.Forms.Panel();
            this.txtKBQuestionsFile = new System.Windows.Forms.TextBox();
            this.btGenerateTags = new System.Windows.Forms.Button();
            this.grdFailedKBQuestions = new System.Windows.Forms.DataGridView();
            this.btLoadKBQuestions = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.openFileDialogKBQuestions = new System.Windows.Forms.OpenFileDialog();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.btSave = new System.Windows.Forms.Button();
            this.lstSelectedTags = new System.Windows.Forms.ListBox();
            this.grpValidate = new System.Windows.Forms.GroupBox();
            this.grdSearchValidation = new System.Windows.Forms.DataGridView();
            this.label3 = new System.Windows.Forms.Label();
            this.btSearchValidate = new System.Windows.Forms.Button();
            this.cmdIndexNames = new System.Windows.Forms.ComboBox();
            this.label1 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFailedKBQuestions)).BeginInit();
            this.groupBox2.SuspendLayout();
            this.grpValidate.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchValidation)).BeginInit();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.btnAddAsTag);
            this.groupBox1.Controls.Add(this.panelTags);
            this.groupBox1.Controls.Add(this.txtKBQuestionsFile);
            this.groupBox1.Controls.Add(this.btGenerateTags);
            this.groupBox1.Controls.Add(this.grdFailedKBQuestions);
            this.groupBox1.Controls.Add(this.btLoadKBQuestions);
            this.groupBox1.Controls.Add(this.label2);
            this.groupBox1.Location = new System.Drawing.Point(12, 12);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(722, 486);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Search Questions";
            // 
            // btnAddAsTag
            // 
            this.btnAddAsTag.Location = new System.Drawing.Point(6, 421);
            this.btnAddAsTag.Name = "btnAddAsTag";
            this.btnAddAsTag.Size = new System.Drawing.Size(159, 48);
            this.btnAddAsTag.TabIndex = 10;
            this.btnAddAsTag.Text = "Add as a Tag";
            this.btnAddAsTag.UseVisualStyleBackColor = true;
            this.btnAddAsTag.Click += new System.EventHandler(this.btnAddAsTag_Click);
            // 
            // panelTags
            // 
            this.panelTags.AutoScroll = true;
            this.panelTags.Location = new System.Drawing.Point(9, 310);
            this.panelTags.Name = "panelTags";
            this.panelTags.Size = new System.Drawing.Size(707, 95);
            this.panelTags.TabIndex = 9;
            // 
            // txtKBQuestionsFile
            // 
            this.txtKBQuestionsFile.Location = new System.Drawing.Point(107, 28);
            this.txtKBQuestionsFile.Name = "txtKBQuestionsFile";
            this.txtKBQuestionsFile.Size = new System.Drawing.Size(503, 20);
            this.txtKBQuestionsFile.TabIndex = 8;
            // 
            // btGenerateTags
            // 
            this.btGenerateTags.Location = new System.Drawing.Point(9, 262);
            this.btGenerateTags.Name = "btGenerateTags";
            this.btGenerateTags.Size = new System.Drawing.Size(156, 42);
            this.btGenerateTags.TabIndex = 7;
            this.btGenerateTags.Text = "Generate Tags";
            this.btGenerateTags.UseVisualStyleBackColor = true;
            this.btGenerateTags.Click += new System.EventHandler(this.btGenerateTags_Click);
            // 
            // grdFailedKBQuestions
            // 
            this.grdFailedKBQuestions.AllowUserToAddRows = false;
            this.grdFailedKBQuestions.AllowUserToDeleteRows = false;
            this.grdFailedKBQuestions.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdFailedKBQuestions.Location = new System.Drawing.Point(6, 56);
            this.grdFailedKBQuestions.Name = "grdFailedKBQuestions";
            this.grdFailedKBQuestions.Size = new System.Drawing.Size(710, 200);
            this.grdFailedKBQuestions.TabIndex = 6;
            // 
            // btLoadKBQuestions
            // 
            this.btLoadKBQuestions.Location = new System.Drawing.Point(616, 25);
            this.btLoadKBQuestions.Name = "btLoadKBQuestions";
            this.btLoadKBQuestions.Size = new System.Drawing.Size(100, 23);
            this.btLoadKBQuestions.TabIndex = 5;
            this.btLoadKBQuestions.Text = "Load";
            this.btLoadKBQuestions.UseVisualStyleBackColor = true;
            this.btLoadKBQuestions.Click += new System.EventHandler(this.btLoadKBQuestions_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(6, 31);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(104, 13);
            this.label2.TabIndex = 4;
            this.label2.Text = "Select KB Questions";
            // 
            // openFileDialogKBQuestions
            // 
            this.openFileDialogKBQuestions.FileName = "openFileDialogKBQuestions";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.btSave);
            this.groupBox2.Controls.Add(this.lstSelectedTags);
            this.groupBox2.Location = new System.Drawing.Point(9, 504);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(719, 231);
            this.groupBox2.TabIndex = 8;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Tags";
            // 
            // btSave
            // 
            this.btSave.Location = new System.Drawing.Point(321, 19);
            this.btSave.Name = "btSave";
            this.btSave.Size = new System.Drawing.Size(150, 61);
            this.btSave.TabIndex = 10;
            this.btSave.Text = "Save";
            this.btSave.UseVisualStyleBackColor = true;
            this.btSave.Click += new System.EventHandler(this.btSave_Click);
            // 
            // lstSelectedTags
            // 
            this.lstSelectedTags.FormattingEnabled = true;
            this.lstSelectedTags.Location = new System.Drawing.Point(12, 19);
            this.lstSelectedTags.Name = "lstSelectedTags";
            this.lstSelectedTags.ScrollAlwaysVisible = true;
            this.lstSelectedTags.Size = new System.Drawing.Size(291, 186);
            this.lstSelectedTags.TabIndex = 10;
            // 
            // grpValidate
            // 
            this.grpValidate.Controls.Add(this.grdSearchValidation);
            this.grpValidate.Controls.Add(this.label3);
            this.grpValidate.Controls.Add(this.btSearchValidate);
            this.grpValidate.Controls.Add(this.cmdIndexNames);
            this.grpValidate.Controls.Add(this.label1);
            this.grpValidate.Location = new System.Drawing.Point(752, 12);
            this.grpValidate.Name = "grpValidate";
            this.grpValidate.Size = new System.Drawing.Size(753, 623);
            this.grpValidate.TabIndex = 9;
            this.grpValidate.TabStop = false;
            this.grpValidate.Text = "Validate";
            // 
            // grdSearchValidation
            // 
            this.grdSearchValidation.AllowUserToAddRows = false;
            this.grdSearchValidation.AllowUserToDeleteRows = false;
            this.grdSearchValidation.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdSearchValidation.Location = new System.Drawing.Point(12, 132);
            this.grdSearchValidation.Name = "grdSearchValidation";
            this.grdSearchValidation.Size = new System.Drawing.Size(735, 463);
            this.grdSearchValidation.TabIndex = 14;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.Maroon;
            this.label3.Location = new System.Drawing.Point(11, 31);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(267, 20);
            this.label3.TabIndex = 13;
            this.label3.Text = "Run Azure Search Indexer First!";
            // 
            // btSearchValidate
            // 
            this.btSearchValidate.Location = new System.Drawing.Point(270, 81);
            this.btSearchValidate.Name = "btSearchValidate";
            this.btSearchValidate.Size = new System.Drawing.Size(115, 45);
            this.btSearchValidate.TabIndex = 8;
            this.btSearchValidate.Text = "Validate";
            this.btSearchValidate.UseVisualStyleBackColor = true;
            this.btSearchValidate.Click += new System.EventHandler(this.btSearchValidate_Click);
            // 
            // cmdIndexNames
            // 
            this.cmdIndexNames.FormattingEnabled = true;
            this.cmdIndexNames.Location = new System.Drawing.Point(88, 88);
            this.cmdIndexNames.Name = "cmdIndexNames";
            this.cmdIndexNames.Size = new System.Drawing.Size(163, 21);
            this.cmdIndexNames.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(12, 91);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(70, 13);
            this.label1.TabIndex = 6;
            this.label1.Text = "Search Index";
            // 
            // frmAddTags
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1526, 777);
            this.Controls.Add(this.grpValidate);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "frmAddTags";
            this.Text = "frmAddTags";
            this.WindowState = System.Windows.Forms.FormWindowState.Maximized;
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdFailedKBQuestions)).EndInit();
            this.groupBox2.ResumeLayout(false);
            this.grpValidate.ResumeLayout(false);
            this.grpValidate.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.grdSearchValidation)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Button btLoadKBQuestions;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.OpenFileDialog openFileDialogKBQuestions;
        private System.Windows.Forms.DataGridView grdFailedKBQuestions;
        private System.Windows.Forms.Button btGenerateTags;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.ListBox lstSelectedTags;
        private System.Windows.Forms.GroupBox grpValidate;
        private System.Windows.Forms.ComboBox cmdIndexNames;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Button btSave;
        private System.Windows.Forms.Button btSearchValidate;
        private System.Windows.Forms.TextBox txtKBQuestionsFile;
        private System.Windows.Forms.Panel panelTags;
        private System.Windows.Forms.Button btnAddAsTag;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.DataGridView grdSearchValidation;
    }
}