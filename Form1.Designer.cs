
namespace ElementPackageTask
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
            this.splitContainer1 = new System.Windows.Forms.SplitContainer();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.Adjacency_btn = new System.Windows.Forms.Button();
            this.Adjacency = new System.Windows.Forms.Label();
            this.ElementSize = new System.Windows.Forms.Label();
            this.ElementSize_btn = new System.Windows.Forms.Button();
            this.Start_btn = new System.Windows.Forms.Button();
            this.folderBrowserDialogXY = new System.Windows.Forms.FolderBrowserDialog();
            this.openSizeFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openAdjacencyFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).BeginInit();
            this.splitContainer1.Panel1.SuspendLayout();
            this.splitContainer1.Panel2.SuspendLayout();
            this.splitContainer1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.SuspendLayout();
            // 
            // splitContainer1
            // 
            this.splitContainer1.AllowDrop = true;
            this.splitContainer1.Dock = System.Windows.Forms.DockStyle.Fill;
            this.splitContainer1.IsSplitterFixed = true;
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.Adjacency_btn);
            this.splitContainer1.Panel2.Controls.Add(this.Adjacency);
            this.splitContainer1.Panel2.Controls.Add(this.ElementSize);
            this.splitContainer1.Panel2.Controls.Add(this.ElementSize_btn);
            this.splitContainer1.Panel2.Controls.Add(this.Start_btn);
            this.splitContainer1.Size = new System.Drawing.Size(1111, 692);
            this.splitContainer1.SplitterDistance = 792;
            this.splitContainer1.TabIndex = 0;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(789, 522);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // Adjacency_btn
            // 
            this.Adjacency_btn.Location = new System.Drawing.Point(222, 563);
            this.Adjacency_btn.Name = "Adjacency_btn";
            this.Adjacency_btn.Size = new System.Drawing.Size(81, 33);
            this.Adjacency_btn.TabIndex = 4;
            this.Adjacency_btn.Text = "Browse";
            this.Adjacency_btn.UseVisualStyleBackColor = true;
            this.Adjacency_btn.Click += new System.EventHandler(this.Adjacency_btn_Click);
            // 
            // Adjacency
            // 
            this.Adjacency.Location = new System.Drawing.Point(51, 563);
            this.Adjacency.Name = "Adjacency";
            this.Adjacency.Size = new System.Drawing.Size(146, 33);
            this.Adjacency.TabIndex = 3;
            this.Adjacency.Text = "Select path for adjacency matrix";
            this.Adjacency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ElementSize
            // 
            this.ElementSize.Location = new System.Drawing.Point(48, 602);
            this.ElementSize.Name = "ElementSize";
            this.ElementSize.Size = new System.Drawing.Size(149, 33);
            this.ElementSize.TabIndex = 2;
            this.ElementSize.Text = "Select path for elements\' sizes";
            this.ElementSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ElementSize_btn
            // 
            this.ElementSize_btn.Location = new System.Drawing.Point(222, 602);
            this.ElementSize_btn.Name = "ElementSize_btn";
            this.ElementSize_btn.Size = new System.Drawing.Size(81, 33);
            this.ElementSize_btn.TabIndex = 1;
            this.ElementSize_btn.Text = "Browse";
            this.ElementSize_btn.UseVisualStyleBackColor = true;
            this.ElementSize_btn.Click += new System.EventHandler(this.ElementSize_btn_Click);
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(122, 643);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(75, 23);
            this.Start_btn.TabIndex = 0;
            this.Start_btn.Text = "Start";
            this.Start_btn.UseVisualStyleBackColor = true;
            this.Start_btn.Click += new System.EventHandler(this.Start_btn_Click);
            // 
            // openSizeFileDialog1
            // 
            this.openSizeFileDialog1.FileName = "openSizeFileDialog1";
            // 
            // openAdjacencyFileDialog1
            // 
            this.openAdjacencyFileDialog1.FileName = "openFileDialog1";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(1111, 692);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel2.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.splitContainer1)).EndInit();
            this.splitContainer1.ResumeLayout(false);
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.SplitContainer splitContainer1;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Button Start_btn;
        private System.Windows.Forms.Button ElementSize_btn;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialogXY;
        private System.Windows.Forms.Label ElementSize;
        private System.Windows.Forms.OpenFileDialog openSizeFileDialog1;
        private System.Windows.Forms.Label Adjacency;
        private System.Windows.Forms.Button Adjacency_btn;
        private System.Windows.Forms.OpenFileDialog openAdjacencyFileDialog1;
    }
}