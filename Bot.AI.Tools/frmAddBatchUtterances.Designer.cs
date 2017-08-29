namespace Bot.AI.Tools
{
    partial class frmAddBatchUtterances
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
            this.txtUtteranceListFile = new System.Windows.Forms.TextBox();
            this.btLoadUtteranceList = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.grdUtterances = new System.Windows.Forms.DataGridView();
            this.btRun = new System.Windows.Forms.Button();
            this.grdTestIntents = new System.Windows.Forms.DataGridView();
            this.cbAddUtterances = new System.Windows.Forms.CheckBox();
            this.cbTrainLuis = new System.Windows.Forms.CheckBox();
            this.cbValidate = new System.Windows.Forms.CheckBox();
            ((System.ComponentModel.ISupportInitialize)(this.grdUtterances)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestIntents)).BeginInit();
            this.SuspendLayout();
            // 
            // txtUtteranceListFile
            // 
            this.txtUtteranceListFile.Location = new System.Drawing.Point(90, 13);
            this.txtUtteranceListFile.Name = "txtUtteranceListFile";
            this.txtUtteranceListFile.Size = new System.Drawing.Size(503, 20);
            this.txtUtteranceListFile.TabIndex = 11;
            // 
            // btLoadUtteranceList
            // 
            this.btLoadUtteranceList.Location = new System.Drawing.Point(599, 12);
            this.btLoadUtteranceList.Name = "btLoadUtteranceList";
            this.btLoadUtteranceList.Size = new System.Drawing.Size(100, 23);
            this.btLoadUtteranceList.TabIndex = 10;
            this.btLoadUtteranceList.Text = "Load";
            this.btLoadUtteranceList.UseVisualStyleBackColor = true;
            this.btLoadUtteranceList.Click += new System.EventHandler(this.btLoadUtteranceList_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(12, 20);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(53, 13);
            this.label2.TabIndex = 9;
            this.label2.Text = "Select file";
            // 
            // grdUtterances
            // 
            this.grdUtterances.AllowUserToAddRows = false;
            this.grdUtterances.AllowUserToDeleteRows = false;
            this.grdUtterances.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdUtterances.Location = new System.Drawing.Point(15, 41);
            this.grdUtterances.Name = "grdUtterances";
            this.grdUtterances.Size = new System.Drawing.Size(710, 214);
            this.grdUtterances.TabIndex = 12;
            // 
            // btRun
            // 
            this.btRun.Location = new System.Drawing.Point(468, 261);
            this.btRun.Name = "btRun";
            this.btRun.Size = new System.Drawing.Size(257, 42);
            this.btRun.TabIndex = 13;
            this.btRun.Text = "Run";
            this.btRun.UseVisualStyleBackColor = true;
            this.btRun.Click += new System.EventHandler(this.btAddBatch_Click);
            // 
            // grdTestIntents
            // 
            this.grdTestIntents.AllowUserToAddRows = false;
            this.grdTestIntents.AllowUserToDeleteRows = false;
            this.grdTestIntents.ColumnHeadersHeightSizeMode = System.Windows.Forms.DataGridViewColumnHeadersHeightSizeMode.AutoSize;
            this.grdTestIntents.Location = new System.Drawing.Point(15, 318);
            this.grdTestIntents.Name = "grdTestIntents";
            this.grdTestIntents.Size = new System.Drawing.Size(710, 272);
            this.grdTestIntents.TabIndex = 14;
            // 
            // cbAddUtterances
            // 
            this.cbAddUtterances.AutoSize = true;
            this.cbAddUtterances.Location = new System.Drawing.Point(15, 262);
            this.cbAddUtterances.Name = "cbAddUtterances";
            this.cbAddUtterances.Size = new System.Drawing.Size(100, 17);
            this.cbAddUtterances.TabIndex = 15;
            this.cbAddUtterances.Text = "Add Utterances";
            this.cbAddUtterances.UseVisualStyleBackColor = true;
            // 
            // cbTrainLuis
            // 
            this.cbTrainLuis.AutoSize = true;
            this.cbTrainLuis.Location = new System.Drawing.Point(121, 261);
            this.cbTrainLuis.Name = "cbTrainLuis";
            this.cbTrainLuis.Size = new System.Drawing.Size(77, 17);
            this.cbTrainLuis.TabIndex = 15;
            this.cbTrainLuis.Text = "Train LUIS";
            this.cbTrainLuis.UseVisualStyleBackColor = true;
            // 
            // cbValidate
            // 
            this.cbValidate.AutoSize = true;
            this.cbValidate.Location = new System.Drawing.Point(204, 261);
            this.cbValidate.Name = "cbValidate";
            this.cbValidate.Size = new System.Drawing.Size(64, 17);
            this.cbValidate.TabIndex = 16;
            this.cbValidate.Text = "Validate";
            this.cbValidate.UseVisualStyleBackColor = true;
            // 
            // frmAddBatchUtterances
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(740, 602);
            this.Controls.Add(this.cbValidate);
            this.Controls.Add(this.cbTrainLuis);
            this.Controls.Add(this.cbAddUtterances);
            this.Controls.Add(this.grdTestIntents);
            this.Controls.Add(this.btRun);
            this.Controls.Add(this.grdUtterances);
            this.Controls.Add(this.txtUtteranceListFile);
            this.Controls.Add(this.btLoadUtteranceList);
            this.Controls.Add(this.label2);
            this.Name = "frmAddBatchUtterances";
            this.Text = "Add Batch Utterances";
            ((System.ComponentModel.ISupportInitialize)(this.grdUtterances)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.grdTestIntents)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.TextBox txtUtteranceListFile;
        private System.Windows.Forms.Button btLoadUtteranceList;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.DataGridView grdUtterances;
        private System.Windows.Forms.Button btRun;
        private System.Windows.Forms.DataGridView grdTestIntents;
        private System.Windows.Forms.CheckBox cbAddUtterances;
        private System.Windows.Forms.CheckBox cbTrainLuis;
        private System.Windows.Forms.CheckBox cbValidate;
    }
}