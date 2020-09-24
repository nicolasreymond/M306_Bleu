namespace M306_Bleu_Projet
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
            this.groupBox1 = new System.Windows.Forms.GroupBox();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.groupBox4 = new System.Windows.Forms.GroupBox();
            this.lblSony = new System.Windows.Forms.Label();
            this.lblTimeHour = new System.Windows.Forms.Label();
            this.lblTimeMinute = new System.Windows.Forms.Label();
            this.lblTimeFormat = new System.Windows.Forms.Label();
            this.groupBox1.SuspendLayout();
            this.groupBox4.SuspendLayout();
            this.SuspendLayout();
            // 
            // groupBox1
            // 
            this.groupBox1.Controls.Add(this.lblSony);
            this.groupBox1.Controls.Add(this.groupBox4);
            this.groupBox1.Location = new System.Drawing.Point(12, 434);
            this.groupBox1.Name = "groupBox1";
            this.groupBox1.Size = new System.Drawing.Size(776, 205);
            this.groupBox1.TabIndex = 0;
            this.groupBox1.TabStop = false;
            this.groupBox1.Text = "groupBox1";
            // 
            // groupBox2
            // 
            this.groupBox2.Location = new System.Drawing.Point(11, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 205);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "groupBox1";
            // 
            // groupBox3
            // 
            this.groupBox3.Location = new System.Drawing.Point(12, 12);
            this.groupBox3.Name = "groupBox3";
            this.groupBox3.Size = new System.Drawing.Size(776, 205);
            this.groupBox3.TabIndex = 0;
            this.groupBox3.TabStop = false;
            this.groupBox3.Text = "groupBox1";
            // 
            // groupBox4
            // 
            this.groupBox4.Controls.Add(this.lblTimeFormat);
            this.groupBox4.Controls.Add(this.lblTimeMinute);
            this.groupBox4.Controls.Add(this.lblTimeHour);
            this.groupBox4.Location = new System.Drawing.Point(143, 59);
            this.groupBox4.Name = "groupBox4";
            this.groupBox4.Size = new System.Drawing.Size(503, 130);
            this.groupBox4.TabIndex = 0;
            this.groupBox4.TabStop = false;
            this.groupBox4.Text = "groupBox4";
            // 
            // lblSony
            // 
            this.lblSony.AutoSize = true;
            this.lblSony.Font = new System.Drawing.Font("Microsoft Sans Serif", 24F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblSony.Location = new System.Drawing.Point(349, 19);
            this.lblSony.Name = "lblSony";
            this.lblSony.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblSony.Size = new System.Drawing.Size(93, 37);
            this.lblSony.TabIndex = 1;
            this.lblSony.Text = "Sony";
            // 
            // lblTimeHour
            // 
            this.lblTimeHour.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeHour.Location = new System.Drawing.Point(166, 43);
            this.lblTimeHour.Name = "lblTimeHour";
            this.lblTimeHour.Size = new System.Drawing.Size(80, 55);
            this.lblTimeHour.TabIndex = 0;
            this.lblTimeHour.Text = "6";
            this.lblTimeHour.TextAlign = System.Drawing.ContentAlignment.MiddleRight;
            // 
            // lblTimeMinute
            // 
            this.lblTimeMinute.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeMinute.Location = new System.Drawing.Point(252, 43);
            this.lblTimeMinute.Name = "lblTimeMinute";
            this.lblTimeMinute.Size = new System.Drawing.Size(80, 55);
            this.lblTimeMinute.TabIndex = 0;
            this.lblTimeMinute.Text = "6";
            this.lblTimeMinute.TextAlign = System.Drawing.ContentAlignment.MiddleLeft;
            // 
            // lblTimeFormat
            // 
            this.lblTimeFormat.AutoSize = true;
            this.lblTimeFormat.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTimeFormat.Location = new System.Drawing.Point(126, 73);
            this.lblTimeFormat.Name = "lblTimeFormat";
            this.lblTimeFormat.RightToLeft = System.Windows.Forms.RightToLeft.No;
            this.lblTimeFormat.Size = new System.Drawing.Size(34, 20);
            this.lblTimeFormat.TabIndex = 1;
            this.lblTimeFormat.Text = "PM";
            this.lblTimeFormat.Click += new System.EventHandler(this.label1_Click_1);
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 656);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.groupBox1);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.groupBox1.ResumeLayout(false);
            this.groupBox1.PerformLayout();
            this.groupBox4.ResumeLayout(false);
            this.groupBox4.PerformLayout();
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox groupBox1;
        private System.Windows.Forms.Label lblSony;
        private System.Windows.Forms.GroupBox groupBox4;
        private System.Windows.Forms.Label lblTimeFormat;
        private System.Windows.Forms.Label lblTimeMinute;
        private System.Windows.Forms.Label lblTimeHour;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
    }
}

