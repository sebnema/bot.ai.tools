﻿namespace Bot.AI.Tools
{
    partial class frmMain
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
            this.button1 = new System.Windows.Forms.Button();
            this.button2 = new System.Windows.Forms.Button();
            this.btnAddBatchUtterances = new System.Windows.Forms.Button();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(176, 83);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(163, 53);
            this.button1.TabIndex = 0;
            this.button1.Text = "Utterance Translator Test";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // button2
            // 
            this.button2.Location = new System.Drawing.Point(12, 83);
            this.button2.Name = "button2";
            this.button2.Size = new System.Drawing.Size(135, 53);
            this.button2.TabIndex = 1;
            this.button2.Text = "Add Search Tags";
            this.button2.UseVisualStyleBackColor = true;
            this.button2.Click += new System.EventHandler(this.button2_Click);
            // 
            // btnAddBatchUtterances
            // 
            this.btnAddBatchUtterances.Location = new System.Drawing.Point(12, 12);
            this.btnAddBatchUtterances.Name = "btnAddBatchUtterances";
            this.btnAddBatchUtterances.Size = new System.Drawing.Size(140, 53);
            this.btnAddBatchUtterances.TabIndex = 2;
            this.btnAddBatchUtterances.Text = "Add Batch Utterances";
            this.btnAddBatchUtterances.UseVisualStyleBackColor = true;
            this.btnAddBatchUtterances.Click += new System.EventHandler(this.btnAddBatchUtterances_Click);
            // 
            // frmMain
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(462, 167);
            this.Controls.Add(this.btnAddBatchUtterances);
            this.Controls.Add(this.button2);
            this.Controls.Add(this.button1);
            this.Name = "frmMain";
            this.Text = "Bot AI Tools";
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button button2;
        private System.Windows.Forms.Button btnAddBatchUtterances;
    }
}