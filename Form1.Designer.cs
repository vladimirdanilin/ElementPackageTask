
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
            this.ProgramResultLabel = new System.Windows.Forms.Label();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.RestartBtn = new System.Windows.Forms.Button();
            this.Save_btn = new System.Windows.Forms.Button();
            this.Save = new System.Windows.Forms.Label();
            this.MutationPercent = new System.Windows.Forms.TextBox();
            this.MutationLabel = new System.Windows.Forms.Label();
            this.NumOfGenerationsl = new System.Windows.Forms.Label();
            this.NumOfGConst = new System.Windows.Forms.TextBox();
            this.PCBh = new System.Windows.Forms.Label();
            this.PCBw = new System.Windows.Forms.Label();
            this.PCBheight = new System.Windows.Forms.TextBox();
            this.PCBwidth = new System.Windows.Forms.TextBox();
            this.NumSpecies = new System.Windows.Forms.TextBox();
            this.NumOfSpeciesLabel = new System.Windows.Forms.Label();
            this.Adjacency_btn = new System.Windows.Forms.Button();
            this.Adjacency = new System.Windows.Forms.Label();
            this.ElementSize = new System.Windows.Forms.Label();
            this.ElementSize_btn = new System.Windows.Forms.Button();
            this.Start_btn = new System.Windows.Forms.Button();
            this.folderBrowserDialogXY = new System.Windows.Forms.FolderBrowserDialog();
            this.openSizeFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.openAdjacencyFileDialog1 = new System.Windows.Forms.OpenFileDialog();
            this.folderBrowserDialog1 = new System.Windows.Forms.FolderBrowserDialog();
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
            this.splitContainer1.Location = new System.Drawing.Point(0, 0);
            this.splitContainer1.Name = "splitContainer1";
            // 
            // splitContainer1.Panel1
            // 
            this.splitContainer1.Panel1.Controls.Add(this.ProgramResultLabel);
            this.splitContainer1.Panel1.Controls.Add(this.pictureBox1);
            // 
            // splitContainer1.Panel2
            // 
            this.splitContainer1.Panel2.Controls.Add(this.RestartBtn);
            this.splitContainer1.Panel2.Controls.Add(this.Save_btn);
            this.splitContainer1.Panel2.Controls.Add(this.Save);
            this.splitContainer1.Panel2.Controls.Add(this.MutationPercent);
            this.splitContainer1.Panel2.Controls.Add(this.MutationLabel);
            this.splitContainer1.Panel2.Controls.Add(this.NumOfGenerationsl);
            this.splitContainer1.Panel2.Controls.Add(this.NumOfGConst);
            this.splitContainer1.Panel2.Controls.Add(this.PCBh);
            this.splitContainer1.Panel2.Controls.Add(this.PCBw);
            this.splitContainer1.Panel2.Controls.Add(this.PCBheight);
            this.splitContainer1.Panel2.Controls.Add(this.PCBwidth);
            this.splitContainer1.Panel2.Controls.Add(this.NumSpecies);
            this.splitContainer1.Panel2.Controls.Add(this.NumOfSpeciesLabel);
            this.splitContainer1.Panel2.Controls.Add(this.Adjacency_btn);
            this.splitContainer1.Panel2.Controls.Add(this.Adjacency);
            this.splitContainer1.Panel2.Controls.Add(this.ElementSize);
            this.splitContainer1.Panel2.Controls.Add(this.ElementSize_btn);
            this.splitContainer1.Panel2.Controls.Add(this.Start_btn);
            this.splitContainer1.Size = new System.Drawing.Size(743, 692);
            this.splitContainer1.SplitterDistance = 442;
            this.splitContainer1.TabIndex = 0;
            // 
            // ProgramResultLabel
            // 
            this.ProgramResultLabel.AutoSize = true;
            this.ProgramResultLabel.Location = new System.Drawing.Point(12, 525);
            this.ProgramResultLabel.Name = "ProgramResultLabel";
            this.ProgramResultLabel.Size = new System.Drawing.Size(0, 13);
            this.ProgramResultLabel.TabIndex = 1;
            this.ProgramResultLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // pictureBox1
            // 
            this.pictureBox1.Location = new System.Drawing.Point(0, 0);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(438, 522);
            this.pictureBox1.TabIndex = 0;
            this.pictureBox1.TabStop = false;
            this.pictureBox1.Click += new System.EventHandler(this.pictureBox1_Click);
            // 
            // RestartBtn
            // 
            this.RestartBtn.Location = new System.Drawing.Point(13, 641);
            this.RestartBtn.Name = "RestartBtn";
            this.RestartBtn.Size = new System.Drawing.Size(89, 39);
            this.RestartBtn.TabIndex = 16;
            this.RestartBtn.Text = "Restart";
            this.RestartBtn.UseVisualStyleBackColor = true;
            this.RestartBtn.Click += new System.EventHandler(this.RestartBtn_Click);
            // 
            // Save_btn
            // 
            this.Save_btn.Location = new System.Drawing.Point(194, 489);
            this.Save_btn.Name = "Save_btn";
            this.Save_btn.Size = new System.Drawing.Size(81, 33);
            this.Save_btn.TabIndex = 15;
            this.Save_btn.Text = "Browse";
            this.Save_btn.UseVisualStyleBackColor = true;
            this.Save_btn.Click += new System.EventHandler(this.Save_btn_Click);
            // 
            // Save
            // 
            this.Save.Location = new System.Drawing.Point(10, 489);
            this.Save.Name = "Save";
            this.Save.Size = new System.Drawing.Size(146, 33);
            this.Save.TabIndex = 14;
            this.Save.Text = "Выберите путь сохранения файла";
            this.Save.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // MutationPercent
            // 
            this.MutationPercent.Location = new System.Drawing.Point(222, 166);
            this.MutationPercent.Name = "MutationPercent";
            this.MutationPercent.Size = new System.Drawing.Size(62, 20);
            this.MutationPercent.TabIndex = 13;
            this.MutationPercent.TextChanged += new System.EventHandler(this.MutationPercent_TextChanged);
            // 
            // MutationLabel
            // 
            this.MutationLabel.Location = new System.Drawing.Point(48, 162);
            this.MutationLabel.Name = "MutationLabel";
            this.MutationLabel.Size = new System.Drawing.Size(145, 27);
            this.MutationLabel.TabIndex = 12;
            this.MutationLabel.Text = "Введите процент мутаций";
            this.MutationLabel.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumOfGenerationsl
            // 
            this.NumOfGenerationsl.Location = new System.Drawing.Point(10, 104);
            this.NumOfGenerationsl.Name = "NumOfGenerationsl";
            this.NumOfGenerationsl.Size = new System.Drawing.Size(206, 48);
            this.NumOfGenerationsl.TabIndex = 11;
            this.NumOfGenerationsl.Text = "Введите кол-во поколений, на протяжении которого F неизменно";
            this.NumOfGenerationsl.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // NumOfGConst
            // 
            this.NumOfGConst.Location = new System.Drawing.Point(222, 119);
            this.NumOfGConst.Name = "NumOfGConst";
            this.NumOfGConst.Size = new System.Drawing.Size(62, 20);
            this.NumOfGConst.TabIndex = 10;
            this.NumOfGConst.TextChanged += new System.EventHandler(this.NumOfGConst_TextChanged);
            // 
            // PCBh
            // 
            this.PCBh.Location = new System.Drawing.Point(161, 69);
            this.PCBh.Name = "PCBh";
            this.PCBh.Size = new System.Drawing.Size(55, 34);
            this.PCBh.TabIndex = 9;
            this.PCBh.Text = "Высота платы";
            this.PCBh.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PCBw
            // 
            this.PCBw.Location = new System.Drawing.Point(3, 69);
            this.PCBw.Name = "PCBw";
            this.PCBw.Size = new System.Drawing.Size(74, 34);
            this.PCBw.TabIndex = 0;
            this.PCBw.Text = "Ширина платы";
            this.PCBw.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // PCBheight
            // 
            this.PCBheight.Location = new System.Drawing.Point(222, 77);
            this.PCBheight.Name = "PCBheight";
            this.PCBheight.Size = new System.Drawing.Size(62, 20);
            this.PCBheight.TabIndex = 8;
            this.PCBheight.TextChanged += new System.EventHandler(this.PCBheight_TextChanged);
            // 
            // PCBwidth
            // 
            this.PCBwidth.Location = new System.Drawing.Point(83, 77);
            this.PCBwidth.Name = "PCBwidth";
            this.PCBwidth.Size = new System.Drawing.Size(62, 20);
            this.PCBwidth.TabIndex = 7;
            this.PCBwidth.TextChanged += new System.EventHandler(this.PCBwidth_TextChanged);
            // 
            // NumSpecies
            // 
            this.NumSpecies.Location = new System.Drawing.Point(222, 36);
            this.NumSpecies.Name = "NumSpecies";
            this.NumSpecies.Size = new System.Drawing.Size(62, 20);
            this.NumSpecies.TabIndex = 6;
            this.NumSpecies.TextChanged += new System.EventHandler(this.NumSpecies_TextChanged);
            // 
            // NumOfSpeciesLabel
            // 
            this.NumOfSpeciesLabel.AutoSize = true;
            this.NumOfSpeciesLabel.Location = new System.Drawing.Point(48, 39);
            this.NumOfSpeciesLabel.Name = "NumOfSpeciesLabel";
            this.NumOfSpeciesLabel.Size = new System.Drawing.Size(149, 13);
            this.NumOfSpeciesLabel.TabIndex = 5;
            this.NumOfSpeciesLabel.Text = "Введите количество особей";
            // 
            // Adjacency_btn
            // 
            this.Adjacency_btn.Location = new System.Drawing.Point(194, 563);
            this.Adjacency_btn.Name = "Adjacency_btn";
            this.Adjacency_btn.Size = new System.Drawing.Size(81, 33);
            this.Adjacency_btn.TabIndex = 4;
            this.Adjacency_btn.Text = "Browse";
            this.Adjacency_btn.UseVisualStyleBackColor = true;
            this.Adjacency_btn.Click += new System.EventHandler(this.Adjacency_btn_Click);
            // 
            // Adjacency
            // 
            this.Adjacency.Location = new System.Drawing.Point(10, 563);
            this.Adjacency.Name = "Adjacency";
            this.Adjacency.Size = new System.Drawing.Size(146, 33);
            this.Adjacency.TabIndex = 3;
            this.Adjacency.Text = "Выберите путь матрицы смежности";
            this.Adjacency.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ElementSize
            // 
            this.ElementSize.Location = new System.Drawing.Point(10, 602);
            this.ElementSize.Name = "ElementSize";
            this.ElementSize.Size = new System.Drawing.Size(149, 33);
            this.ElementSize.TabIndex = 2;
            this.ElementSize.Text = "Выберите путь матрицы размеров";
            this.ElementSize.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // ElementSize_btn
            // 
            this.ElementSize_btn.Location = new System.Drawing.Point(194, 602);
            this.ElementSize_btn.Name = "ElementSize_btn";
            this.ElementSize_btn.Size = new System.Drawing.Size(81, 33);
            this.ElementSize_btn.TabIndex = 1;
            this.ElementSize_btn.Text = "Browse";
            this.ElementSize_btn.UseVisualStyleBackColor = true;
            this.ElementSize_btn.Click += new System.EventHandler(this.ElementSize_btn_Click);
            // 
            // Start_btn
            // 
            this.Start_btn.Location = new System.Drawing.Point(194, 641);
            this.Start_btn.Name = "Start_btn";
            this.Start_btn.Size = new System.Drawing.Size(81, 39);
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
            this.ClientSize = new System.Drawing.Size(743, 692);
            this.Controls.Add(this.splitContainer1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.splitContainer1.Panel1.ResumeLayout(false);
            this.splitContainer1.Panel1.PerformLayout();
            this.splitContainer1.Panel2.ResumeLayout(false);
            this.splitContainer1.Panel2.PerformLayout();
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
        private System.Windows.Forms.TextBox NumSpecies;
        private System.Windows.Forms.Label NumOfSpeciesLabel;
        private System.Windows.Forms.TextBox PCBheight;
        private System.Windows.Forms.TextBox PCBwidth;
        private System.Windows.Forms.Label PCBh;
        private System.Windows.Forms.Label PCBw;
        private System.Windows.Forms.Label NumOfGenerationsl;
        private System.Windows.Forms.TextBox NumOfGConst;
        private System.Windows.Forms.TextBox MutationPercent;
        private System.Windows.Forms.Label MutationLabel;
        private System.Windows.Forms.Label ProgramResultLabel;
        private System.Windows.Forms.Button Save_btn;
        private System.Windows.Forms.Label Save;
        private System.Windows.Forms.FolderBrowserDialog folderBrowserDialog1;
        private System.Windows.Forms.Button RestartBtn;
    }
}