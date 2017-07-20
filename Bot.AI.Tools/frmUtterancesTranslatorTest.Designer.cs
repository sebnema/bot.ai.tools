namespace Bot.AI.Tools
{
    partial class frmUtterancesTranslatorTest
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
            this.txtSource = new System.Windows.Forms.TextBox();
            this.ofdSource = new System.Windows.Forms.OpenFileDialog();
            this.button1 = new System.Windows.Forms.Button();
            this.label1 = new System.Windows.Forms.Label();
            this.txtDestination = new System.Windows.Forms.TextBox();
            this.label2 = new System.Windows.Forms.Label();
            this.button2 = new System.Windows.Forms.Button();
            this.chkTranslateToEnglish = new System.Windows.Forms.CheckBox();
            this.chkTestSpecificLine = new System.Windows.Forms.CheckBox();
            this.txtLineNumber = new System.Windows.Forms.TextBox();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.label3 = new System.Windows.Forms.Label();
            this.cmdIndexNames = new System.Windows.Forms.ComboBox();
            this.radioButton1 = new System.Windows.Forms.RadioButton();
            this.rbTestFullSenario = new System.Windows.Forms.RadioButton();
            this.rbTestLUISAndSearch = new System.Windows.Forms.RadioButton();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // txtSource
            // 
            this.txtSource.Location = new System.Drawing.Point(116, 11);
            this.txtSource.Name = "txtSource";
            this.txtSource.Size = new System.Drawing.Size(334, 20);
            this.txtSource.TabIndex = 0;
            // 
            // ofdSource
            // 
            this.ofdSource.FileName = "ofdSource";
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(456, 9);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(103, 23);
            this.button1.TabIndex = 1;
            this.button1.Text = "Select Source";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(51, 14);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(41, 13);
            this.label1.TabIndex = 2;
            this.label1.Text = "Source";
            // 
            // txtDestination
            // 
            this.txtDestination.Location = new System.Drawing.Point(116, 37);
            this.txtDestination.Name = "txtDestination";
            this.txtDestination.Size = new System.Drawing.Size(334, 20);
            this.txtDestination.TabIndex = 3;
            this.txtDestination.Text = "C:\\Temp\\Results.csv";
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(50, 40);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(60, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Destination";
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(125, 276);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(298, 56);
            this.button2.TabIndex = 6;
            this.button2.Text = "Generate";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // chkTranslateToEnglish
            // 
            this.chkTranslateToEnglish.AutoSize = true;
            this.chkTranslateToEnglish.Location = new System.Drawing.Point(116, 120);
            this.chkTranslateToEnglish.Margin = new System.Windows.Forms.Padding(2);
            this.chkTranslateToEnglish.Name = "chkTranslateToEnglish";
            this.chkTranslateToEnglish.Size = new System.Drawing.Size(125, 17);
            this.chkTranslateToEnglish.TabIndex = 7;
            this.chkTranslateToEnglish.Text = "Translate to English?";
            this.chkTranslateToEnglish.UseVisualStyleBackColor = true;
            // 
            // chkTestSpecificLine
            // 
            this.chkTestSpecificLine.AutoSize = true;
            this.chkTestSpecificLine.Location = new System.Drawing.Point(202, 31);
            this.chkTestSpecificLine.Margin = new System.Windows.Forms.Padding(2);
            this.chkTestSpecificLine.Name = "chkTestSpecificLine";
            this.chkTestSpecificLine.Size = new System.Drawing.Size(117, 17);
            this.chkTestSpecificLine.TabIndex = 9;
            this.chkTestSpecificLine.Text = "Test Specific Line?";
            this.chkTestSpecificLine.UseVisualStyleBackColor = true;
            // 
            // txtLineNumber
            // 
            this.txtLineNumber.Location = new System.Drawing.Point(318, 30);
            this.txtLineNumber.Margin = new System.Windows.Forms.Padding(2);
            this.txtLineNumber.Name = "txtLineNumber";
            this.txtLineNumber.Size = new System.Drawing.Size(52, 20);
            this.txtLineNumber.TabIndex = 10;
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.txtLineNumber);
            this.groupBox1.Controls.Add(this.chkTestSpecificLine);
            this.groupBox1.Location = new System.Drawing.Point(52, 89);
            this.groupBox1.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox1.Size = new System.Drawing.Size(512, 76);
            this.groupBox1.TabIndex = 12;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Basic Test";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.cmdIndexNames);
            this.groupBox2.Controls.Add(this.radioButton1);
            this.groupBox2.Controls.Add(this.rbTestFullSenario);
            this.groupBox2.Controls.Add(this.rbTestLUISAndSearch);
            this.groupBox2.Location = new System.Drawing.Point(52, 178);
            this.groupBox2.Margin = new System.Windows.Forms.Padding(2);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Padding = new System.Windows.Forms.Padding(2);
            this.groupBox2.Size = new System.Drawing.Size(512, 93);
            this.groupBox2.TabIndex = 13;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LUIS Test";
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Location = new System.Drawing.Point(44, 53);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(70, 13);
            this.label3.TabIndex = 14;
            this.label3.Text = "Search Index";
            // 
            // cmdIndexNames
            // 
            this.cmdIndexNames.FormattingEnabled = true;
            this.cmdIndexNames.Location = new System.Drawing.Point(120, 50);
            this.cmdIndexNames.Name = "cmdIndexNames";
            this.cmdIndexNames.Size = new System.Drawing.Size(205, 21);
            this.cmdIndexNames.TabIndex = 1;
            // 
            // radioButton1
            // 
            this.radioButton1.AutoSize = true;
            this.radioButton1.Checked = true;
            this.radioButton1.Location = new System.Drawing.Point(286, 28);
            this.radioButton1.Margin = new System.Windows.Forms.Padding(2);
            this.radioButton1.Name = "radioButton1";
            this.radioButton1.Size = new System.Drawing.Size(107, 17);
            this.radioButton1.TabIndex = 0;
            this.radioButton1.TabStop = true;
            this.radioButton1.Text = "Test Search Only";
            this.radioButton1.UseVisualStyleBackColor = true;
            // 
            // rbTestFullSenario
            // 
            this.rbTestFullSenario.AutoSize = true;
            this.rbTestFullSenario.Location = new System.Drawing.Point(173, 28);
            this.rbTestFullSenario.Margin = new System.Windows.Forms.Padding(2);
            this.rbTestFullSenario.Name = "rbTestFullSenario";
            this.rbTestFullSenario.Size = new System.Drawing.Size(104, 17);
            this.rbTestFullSenario.TabIndex = 0;
            this.rbTestFullSenario.Text = "Test Full Senario";
            this.rbTestFullSenario.UseVisualStyleBackColor = true;
            // 
            // rbTestLUISAndSearch
            // 
            this.rbTestLUISAndSearch.AutoSize = true;
            this.rbTestLUISAndSearch.Location = new System.Drawing.Point(38, 28);
            this.rbTestLUISAndSearch.Margin = new System.Windows.Forms.Padding(2);
            this.rbTestLUISAndSearch.Name = "rbTestLUISAndSearch";
            this.rbTestLUISAndSearch.Size = new System.Drawing.Size(132, 17);
            this.rbTestLUISAndSearch.TabIndex = 0;
            this.rbTestLUISAndSearch.Text = "Test LUIS And Search";
            this.rbTestLUISAndSearch.UseVisualStyleBackColor = true;
            // 
            // frmUtterancesTranslatorTest
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(589, 346);
            this.Controls.Add(this.chkTranslateToEnglish);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.txtDestination);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.button1);
            this.Controls.Add(this.txtSource);
            this.Controls.Add(this.groupBox1);
            this.Controls.Add(this.groupBox2);
            this.Name = "frmUtterancesTranslatorTest";
            this.Text = "Test KB Info";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtSource;
        private System.Windows.Forms.OpenFileDialog ofdSource;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox txtDestination;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.CheckBox chkTranslateToEnglish;
        private System.Windows.Forms.CheckBox chkTestSpecificLine;
        private System.Windows.Forms.TextBox txtLineNumber;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.RadioButton radioButton1;
        private System.Windows.Forms.RadioButton rbTestFullSenario;
        private System.Windows.Forms.RadioButton rbTestLUISAndSearch;
        private System.Windows.Forms.ComboBox cmdIndexNames;
        private System.Windows.Forms.Label label3;
    }
}

