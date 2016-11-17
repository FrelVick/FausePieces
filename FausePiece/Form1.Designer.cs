namespace FausePiece
{
    partial class Form1
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
            this.Answer = new System.Windows.Forms.TextBox();
            this.LocalMax = new System.Windows.Forms.Label();
            this.label1 = new System.Windows.Forms.Label();
            this.numberOfBags = new System.Windows.Forms.NumericUpDown();
            this.label2 = new System.Windows.Forms.Label();
            this.maxPieces = new System.Windows.Forms.NumericUpDown();
            this.Log = new System.Windows.Forms.RichTextBox();
            this.RefreshStatus = new System.Windows.Forms.Button();
            this.progressBar1 = new System.Windows.Forms.ProgressBar();
            this.Clear = new System.Windows.Forms.Button();
            ((System.ComponentModel.ISupportInitialize)(this.numberOfBags)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPieces)).BeginInit();
            this.SuspendLayout();
            // 
            // button1
            // 
            this.button1.Location = new System.Drawing.Point(392, 265);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(75, 23);
            this.button1.TabIndex = 0;
            this.button1.Text = "Start";
            this.button1.UseVisualStyleBackColor = true;
            this.button1.Click += new System.EventHandler(this.button1_Click);
            // 
            // Answer
            // 
            this.Answer.Location = new System.Drawing.Point(32, 154);
            this.Answer.Name = "Answer";
            this.Answer.Size = new System.Drawing.Size(383, 20);
            this.Answer.TabIndex = 1;
            // 
            // LocalMax
            // 
            this.LocalMax.AutoSize = true;
            this.LocalMax.Location = new System.Drawing.Point(432, 161);
            this.LocalMax.Name = "LocalMax";
            this.LocalMax.Size = new System.Drawing.Size(35, 13);
            this.LocalMax.TabIndex = 2;
            this.LocalMax.Text = "label1";
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Location = new System.Drawing.Point(29, 13);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(82, 13);
            this.label1.TabIndex = 3;
            this.label1.Text = "Number of bags";
            // 
            // numberOfBags
            // 
            this.numberOfBags.Location = new System.Drawing.Point(121, 13);
            this.numberOfBags.Minimum = new decimal(new int[] {
            3,
            0,
            0,
            0});
            this.numberOfBags.Name = "numberOfBags";
            this.numberOfBags.Size = new System.Drawing.Size(46, 20);
            this.numberOfBags.TabIndex = 4;
            this.numberOfBags.Value = new decimal(new int[] {
            10,
            0,
            0,
            0});
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Location = new System.Drawing.Point(29, 44);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(85, 13);
            this.label2.TabIndex = 5;
            this.label2.Text = "Maximum pieces";
            // 
            // maxPieces
            // 
            this.maxPieces.Location = new System.Drawing.Point(121, 40);
            this.maxPieces.Maximum = new decimal(new int[] {
            100000,
            0,
            0,
            0});
            this.maxPieces.Name = "maxPieces";
            this.maxPieces.Size = new System.Drawing.Size(43, 20);
            this.maxPieces.TabIndex = 6;
            this.maxPieces.Value = new decimal(new int[] {
            500,
            0,
            0,
            0});
            // 
            // Log
            // 
            this.Log.Location = new System.Drawing.Point(487, 13);
            this.Log.Name = "Log";
            this.Log.Size = new System.Drawing.Size(270, 303);
            this.Log.TabIndex = 7;
            this.Log.Text = "";
            // 
            // RefreshStatus
            // 
            this.RefreshStatus.Enabled = false;
            this.RefreshStatus.Location = new System.Drawing.Point(311, 264);
            this.RefreshStatus.Name = "RefreshStatus";
            this.RefreshStatus.Size = new System.Drawing.Size(75, 23);
            this.RefreshStatus.TabIndex = 8;
            this.RefreshStatus.Text = "Refresh";
            this.RefreshStatus.UseVisualStyleBackColor = true;
            this.RefreshStatus.Click += new System.EventHandler(this.Refresh_Click);
            // 
            // progressBar1
            // 
            this.progressBar1.Location = new System.Drawing.Point(32, 180);
            this.progressBar1.Name = "progressBar1";
            this.progressBar1.Size = new System.Drawing.Size(383, 23);
            this.progressBar1.TabIndex = 9;
            this.progressBar1.Value = 50;
            this.progressBar1.Visible = false;
            // 
            // Clear
            // 
            this.Clear.Location = new System.Drawing.Point(391, 9);
            this.Clear.Name = "Clear";
            this.Clear.Size = new System.Drawing.Size(75, 23);
            this.Clear.TabIndex = 10;
            this.Clear.Text = "Clear log";
            this.Clear.UseVisualStyleBackColor = true;
            this.Clear.Click += new System.EventHandler(this.Clear_Click);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(760, 328);
            this.Controls.Add(this.Clear);
            this.Controls.Add(this.progressBar1);
            this.Controls.Add(this.RefreshStatus);
            this.Controls.Add(this.Log);
            this.Controls.Add(this.maxPieces);
            this.Controls.Add(this.label2);
            this.Controls.Add(this.numberOfBags);
            this.Controls.Add(this.label1);
            this.Controls.Add(this.LocalMax);
            this.Controls.Add(this.Answer);
            this.Controls.Add(this.button1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.FormClosed += new System.Windows.Forms.FormClosedEventHandler(this.Form1_FormClosed);
            ((System.ComponentModel.ISupportInitialize)(this.numberOfBags)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.maxPieces)).EndInit();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.TextBox Answer;
        private System.Windows.Forms.Label LocalMax;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.NumericUpDown numberOfBags;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.NumericUpDown maxPieces;
        private System.Windows.Forms.RichTextBox Log;
        private System.Windows.Forms.Button RefreshStatus;
        private System.Windows.Forms.ProgressBar progressBar1;
        private System.Windows.Forms.Button Clear;
    }
}

