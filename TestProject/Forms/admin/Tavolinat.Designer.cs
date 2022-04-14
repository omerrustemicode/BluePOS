namespace TestProject.Forms.admin
{
    partial class tavolinat
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
            this.label1 = new System.Windows.Forms.Label();
            this.numritxt = new System.Windows.Forms.TextBox();
            this.shtobtn = new System.Windows.Forms.Button();
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.numriupd = new System.Windows.Forms.TextBox();
            this.label3 = new System.Windows.Forms.Label();
            this.selectcomb = new System.Windows.Forms.ComboBox();
            this.delbtn = new System.Windows.Forms.Button();
            this.updbtn = new System.Windows.Forms.Button();
            this.label2 = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.SuspendLayout();
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label1.ForeColor = System.Drawing.Color.White;
            this.label1.Location = new System.Drawing.Point(15, 56);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(184, 20);
            this.label1.TabIndex = 1;
            this.label1.Text = "Emri/Numri i Tavolines:";
            // 
            // numritxt
            // 
            this.numritxt.Location = new System.Drawing.Point(16, 79);
            this.numritxt.MaxLength = 4;
            this.numritxt.Name = "numritxt";
            this.numritxt.Size = new System.Drawing.Size(243, 22);
            this.numritxt.TabIndex = 0;
            // 
            // shtobtn
            // 
            this.shtobtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.shtobtn.Location = new System.Drawing.Point(52, 107);
            this.shtobtn.Name = "shtobtn";
            this.shtobtn.Size = new System.Drawing.Size(171, 37);
            this.shtobtn.TabIndex = 2;
            this.shtobtn.Text = "SHTO TAVOLINEN";
            this.shtobtn.UseVisualStyleBackColor = true;
            this.shtobtn.Click += new System.EventHandler(this.shtobtn_Click);
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.shtobtn);
            this.groupBox1.Controls.Add(this.numritxt);
            this.groupBox1.Controls.Add(this.label1);
            this.groupBox1.ForeColor = System.Drawing.Color.White;
            this.groupBox1.Location = new System.Drawing.Point(22, 66);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(283, 208);
            this.groupBox1.TabIndex = 2;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "Shto Tavoline";
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.numriupd);
            this.groupBox2.Controls.Add(this.label3);
            this.groupBox2.Controls.Add(this.selectcomb);
            this.groupBox2.Controls.Add(this.delbtn);
            this.groupBox2.Controls.Add(this.updbtn);
            this.groupBox2.Controls.Add(this.label2);
            this.groupBox2.ForeColor = System.Drawing.Color.White;
            this.groupBox2.Location = new System.Drawing.Point(311, 66);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(359, 208);
            this.groupBox2.TabIndex = 3;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "Ndrysho/Fshije Tavolinen";
            // 
            // numriupd
            // 
            this.numriupd.BackColor = System.Drawing.Color.White;
            this.numriupd.ForeColor = System.Drawing.Color.Black;
            this.numriupd.Location = new System.Drawing.Point(16, 102);
            this.numriupd.MaxLength = 4;
            this.numriupd.Name = "numriupd";
            this.numriupd.Size = new System.Drawing.Size(247, 22);
            this.numriupd.TabIndex = 3;
            this.numriupd.TextChanged += new System.EventHandler(this.numriupd_TextChanged);
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Microsoft Sans Serif", 9F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label3.ForeColor = System.Drawing.Color.White;
            this.label3.Location = new System.Drawing.Point(14, 29);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(245, 18);
            this.label3.TabIndex = 6;
            this.label3.Text = "Tavolina qe doni ta Ndryshoni/Fshini";
            // 
            // selectcomb
            // 
            this.selectcomb.DropDownStyle = System.Windows.Forms.ComboBoxStyle.DropDownList;
            this.selectcomb.FormattingEnabled = true;
            this.selectcomb.Location = new System.Drawing.Point(18, 52);
            this.selectcomb.Name = "selectcomb";
            this.selectcomb.Size = new System.Drawing.Size(245, 24);
            this.selectcomb.TabIndex = 5;
            this.selectcomb.SelectedIndexChanged += new System.EventHandler(this.selectcomb_SelectedIndexChanged);
            // 
            // delbtn
            // 
            this.delbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.delbtn.Location = new System.Drawing.Point(263, 45);
            this.delbtn.Name = "delbtn";
            this.delbtn.Size = new System.Drawing.Size(90, 37);
            this.delbtn.TabIndex = 3;
            this.delbtn.Text = "FSHIJE";
            this.delbtn.UseVisualStyleBackColor = true;
            this.delbtn.Click += new System.EventHandler(this.delbtn_Click);
            // 
            // updbtn
            // 
            this.updbtn.ForeColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.updbtn.Location = new System.Drawing.Point(169, 130);
            this.updbtn.Name = "updbtn";
            this.updbtn.Size = new System.Drawing.Size(90, 37);
            this.updbtn.TabIndex = 2;
            this.updbtn.Text = "NDRYHO";
            this.updbtn.UseVisualStyleBackColor = true;
            this.updbtn.Click += new System.EventHandler(this.button1_Click);
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Microsoft Sans Serif", 10F, System.Drawing.FontStyle.Regular, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.label2.ForeColor = System.Drawing.Color.White;
            this.label2.Location = new System.Drawing.Point(14, 79);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(82, 20);
            this.label2.TabIndex = 1;
            this.label2.Text = "Emri i ri?";
            // 
            // tavolinat
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(8F, 16F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(13)))), ((int)(((byte)(71)))), ((int)(((byte)(161)))));
            this.ClientSize = new System.Drawing.Size(691, 363);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.FormBorderStyle = System.Windows.Forms.FormBorderStyle.None;
            this.MaximizeBox = false;
            this.MaximumSize = new System.Drawing.Size(691, 363);
            this.MinimizeBox = false;
            this.MinimumSize = new System.Drawing.Size(691, 363);
            this.Name = "tavolinat";
            this.StartPosition = System.Windows.Forms.FormStartPosition.CenterScreen;
            this.Text = "tavolinat";
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.groupBox2.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.TextBox numritxt;
        private System.Windows.Forms.Button shtobtn;
        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.Button delbtn;
        private System.Windows.Forms.Button updbtn;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.ComboBox selectcomb;
        private System.Windows.Forms.TextBox numriupd;
    }
}