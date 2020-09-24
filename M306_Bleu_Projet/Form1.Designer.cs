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
            this.components = new System.ComponentModel.Container();
            this.gbHorlogeFront = new System.Windows.Forms.GroupBox();
            this.lblSony = new System.Windows.Forms.Label();
            this.gbClock = new System.Windows.Forms.GroupBox();
            this.lblTimeFormat = new System.Windows.Forms.Label();
            this.lblTime = new System.Windows.Forms.Label();
            this.groupBox2 = new System.Windows.Forms.GroupBox();
            this.groupBox3 = new System.Windows.Forms.GroupBox();
            this.timerGlobal = new System.Windows.Forms.Timer(this.components);
            this.btnSnooze = new System.Windows.Forms.Button();
            this.btnTimeSetDroite = new System.Windows.Forms.Button();
            this.btnTimeSetGauche = new System.Windows.Forms.Button();
            this.btnAlarmOnOffGauche = new System.Windows.Forms.Button();
            this.btnAlarmOnOffDroite = new System.Windows.Forms.Button();
            this.btnSonVagues = new System.Windows.Forms.Button();
            this.btnSonOiseau = new System.Windows.Forms.Button();
            this.btnSonPluie = new System.Windows.Forms.Button();
            this.button4 = new System.Windows.Forms.Button();
            this.button5 = new System.Windows.Forms.Button();
            this.gbNatureSoundEffects = new System.Windows.Forms.GroupBox();
            this.gbAlarmReset = new System.Windows.Forms.GroupBox();
            this.button7 = new System.Windows.Forms.Button();
            this.gbBand = new System.Windows.Forms.GroupBox();
            this.button1 = new System.Windows.Forms.Button();
            this.btnSleep = new System.Windows.Forms.Button();
            this.btnVolumeDown = new System.Windows.Forms.Button();
            this.btnVolumeUp = new System.Windows.Forms.Button();
            this.gbVolume = new System.Windows.Forms.GroupBox();
            this.gbHorlogeFront.SuspendLayout();
            this.gbClock.SuspendLayout();
            this.groupBox2.SuspendLayout();
            this.gbNatureSoundEffects.SuspendLayout();
            this.gbAlarmReset.SuspendLayout();
            this.gbBand.SuspendLayout();
            this.gbVolume.SuspendLayout();
            this.SuspendLayout();
            // 
            // gbHorlogeFront
            // 
            this.gbHorlogeFront.Controls.Add(this.lblSony);
            this.gbHorlogeFront.Controls.Add(this.gbClock);
            this.gbHorlogeFront.Location = new System.Drawing.Point(12, 434);
            this.gbHorlogeFront.Name = "gbHorlogeFront";
            this.gbHorlogeFront.Size = new System.Drawing.Size(776, 205);
            this.gbHorlogeFront.TabIndex = 0;
            this.gbHorlogeFront.TabStop = false;
            this.gbHorlogeFront.Text = "L\'AVANT DE L\'ALARME";
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
            // gbClock
            // 
            this.gbClock.Controls.Add(this.lblTimeFormat);
            this.gbClock.Controls.Add(this.lblTime);
            this.gbClock.Location = new System.Drawing.Point(143, 59);
            this.gbClock.Name = "gbClock";
            this.gbClock.Size = new System.Drawing.Size(503, 130);
            this.gbClock.TabIndex = 0;
            this.gbClock.TabStop = false;
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
            // 
            // lblTime
            // 
            this.lblTime.Font = new System.Drawing.Font("Microsoft Sans Serif", 36F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.lblTime.Location = new System.Drawing.Point(166, 43);
            this.lblTime.Name = "lblTime";
            this.lblTime.Size = new System.Drawing.Size(177, 55);
            this.lblTime.TabIndex = 0;
            this.lblTime.Text = "22:22";
            this.lblTime.TextAlign = System.Drawing.ContentAlignment.MiddleCenter;
            // 
            // groupBox2
            // 
            this.groupBox2.Controls.Add(this.gbVolume);
            this.groupBox2.Controls.Add(this.gbBand);
            this.groupBox2.Controls.Add(this.btnSleep);
            this.groupBox2.Controls.Add(this.gbAlarmReset);
            this.groupBox2.Controls.Add(this.gbNatureSoundEffects);
            this.groupBox2.Controls.Add(this.btnAlarmOnOffGauche);
            this.groupBox2.Controls.Add(this.btnTimeSetGauche);
            this.groupBox2.Controls.Add(this.btnAlarmOnOffDroite);
            this.groupBox2.Controls.Add(this.btnTimeSetDroite);
            this.groupBox2.Controls.Add(this.btnSnooze);
            this.groupBox2.Location = new System.Drawing.Point(11, 223);
            this.groupBox2.Name = "groupBox2";
            this.groupBox2.Size = new System.Drawing.Size(776, 205);
            this.groupBox2.TabIndex = 0;
            this.groupBox2.TabStop = false;
            this.groupBox2.Text = "LE DESSUS DE L\'ALARME";
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
            // timerGlobal
            // 
            this.timerGlobal.Interval = 1000;
            this.timerGlobal.Tick += new System.EventHandler(this.timerGlobal_Tick);
            // 
            // btnSnooze
            // 
            this.btnSnooze.Font = new System.Drawing.Font("Microsoft Sans Serif", 8.25F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSnooze.Location = new System.Drawing.Point(144, 159);
            this.btnSnooze.Name = "btnSnooze";
            this.btnSnooze.Size = new System.Drawing.Size(503, 36);
            this.btnSnooze.TabIndex = 0;
            this.btnSnooze.Text = "SNOOZE / BRIGHTNESS";
            this.btnSnooze.UseVisualStyleBackColor = true;
            // 
            // btnTimeSetDroite
            // 
            this.btnTimeSetDroite.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeSetDroite.Location = new System.Drawing.Point(677, 77);
            this.btnTimeSetDroite.Name = "btnTimeSetDroite";
            this.btnTimeSetDroite.Size = new System.Drawing.Size(75, 36);
            this.btnTimeSetDroite.TabIndex = 0;
            this.btnTimeSetDroite.Text = "TIME SET";
            this.btnTimeSetDroite.UseVisualStyleBackColor = true;
            // 
            // btnTimeSetGauche
            // 
            this.btnTimeSetGauche.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnTimeSetGauche.Location = new System.Drawing.Point(22, 77);
            this.btnTimeSetGauche.Name = "btnTimeSetGauche";
            this.btnTimeSetGauche.Size = new System.Drawing.Size(75, 36);
            this.btnTimeSetGauche.TabIndex = 0;
            this.btnTimeSetGauche.Text = "TIME SET";
            this.btnTimeSetGauche.UseVisualStyleBackColor = true;
            // 
            // btnAlarmOnOffGauche
            // 
            this.btnAlarmOnOffGauche.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarmOnOffGauche.Location = new System.Drawing.Point(22, 35);
            this.btnAlarmOnOffGauche.Name = "btnAlarmOnOffGauche";
            this.btnAlarmOnOffGauche.Size = new System.Drawing.Size(75, 36);
            this.btnAlarmOnOffGauche.TabIndex = 0;
            this.btnAlarmOnOffGauche.Text = "ALARM ON/OFF";
            this.btnAlarmOnOffGauche.UseVisualStyleBackColor = true;
            // 
            // btnAlarmOnOffDroite
            // 
            this.btnAlarmOnOffDroite.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnAlarmOnOffDroite.Location = new System.Drawing.Point(677, 35);
            this.btnAlarmOnOffDroite.Name = "btnAlarmOnOffDroite";
            this.btnAlarmOnOffDroite.Size = new System.Drawing.Size(75, 36);
            this.btnAlarmOnOffDroite.TabIndex = 0;
            this.btnAlarmOnOffDroite.Text = "ALARM ON/OFF";
            this.btnAlarmOnOffDroite.UseVisualStyleBackColor = true;
            // 
            // btnSonVagues
            // 
            this.btnSonVagues.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSonVagues.Location = new System.Drawing.Point(11, 19);
            this.btnSonVagues.Name = "btnSonVagues";
            this.btnSonVagues.Size = new System.Drawing.Size(40, 36);
            this.btnSonVagues.TabIndex = 0;
            this.btnSonVagues.Text = "🌊";
            this.btnSonVagues.UseVisualStyleBackColor = true;
            // 
            // btnSonOiseau
            // 
            this.btnSonOiseau.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSonOiseau.Location = new System.Drawing.Point(57, 19);
            this.btnSonOiseau.Name = "btnSonOiseau";
            this.btnSonOiseau.Size = new System.Drawing.Size(40, 36);
            this.btnSonOiseau.TabIndex = 0;
            this.btnSonOiseau.Text = "🐦";
            this.btnSonOiseau.UseVisualStyleBackColor = true;
            // 
            // btnSonPluie
            // 
            this.btnSonPluie.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSonPluie.Location = new System.Drawing.Point(103, 19);
            this.btnSonPluie.Name = "btnSonPluie";
            this.btnSonPluie.Size = new System.Drawing.Size(40, 36);
            this.btnSonPluie.TabIndex = 0;
            this.btnSonPluie.Text = "☂️";
            this.btnSonPluie.UseVisualStyleBackColor = true;
            // 
            // button4
            // 
            this.button4.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button4.Location = new System.Drawing.Point(149, 19);
            this.button4.Name = "button4";
            this.button4.Size = new System.Drawing.Size(40, 36);
            this.button4.TabIndex = 0;
            this.button4.Text = "💦";
            this.button4.UseVisualStyleBackColor = true;
            // 
            // button5
            // 
            this.button5.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button5.Location = new System.Drawing.Point(195, 19);
            this.button5.Name = "button5";
            this.button5.Size = new System.Drawing.Size(40, 36);
            this.button5.TabIndex = 0;
            this.button5.Text = "🐟";
            this.button5.UseVisualStyleBackColor = true;
            // 
            // gbNatureSoundEffects
            // 
            this.gbNatureSoundEffects.Controls.Add(this.btnSonOiseau);
            this.gbNatureSoundEffects.Controls.Add(this.button5);
            this.gbNatureSoundEffects.Controls.Add(this.btnSonVagues);
            this.gbNatureSoundEffects.Controls.Add(this.button4);
            this.gbNatureSoundEffects.Controls.Add(this.btnSonPluie);
            this.gbNatureSoundEffects.Location = new System.Drawing.Point(119, 19);
            this.gbNatureSoundEffects.Name = "gbNatureSoundEffects";
            this.gbNatureSoundEffects.Size = new System.Drawing.Size(248, 62);
            this.gbNatureSoundEffects.TabIndex = 1;
            this.gbNatureSoundEffects.TabStop = false;
            this.gbNatureSoundEffects.Text = "NATURE SOUND / PRESET";
            // 
            // gbAlarmReset
            // 
            this.gbAlarmReset.Controls.Add(this.button7);
            this.gbAlarmReset.Location = new System.Drawing.Point(373, 19);
            this.gbAlarmReset.Name = "gbAlarmReset";
            this.gbAlarmReset.Size = new System.Drawing.Size(108, 62);
            this.gbAlarmReset.TabIndex = 1;
            this.gbAlarmReset.TabStop = false;
            this.gbAlarmReset.Text = "ALARM RESET";
            // 
            // button7
            // 
            this.button7.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button7.Location = new System.Drawing.Point(27, 19);
            this.button7.Name = "button7";
            this.button7.Size = new System.Drawing.Size(54, 36);
            this.button7.TabIndex = 0;
            this.button7.Text = "OFF";
            this.button7.UseVisualStyleBackColor = true;
            // 
            // gbBand
            // 
            this.gbBand.Controls.Add(this.button1);
            this.gbBand.Location = new System.Drawing.Point(487, 19);
            this.gbBand.Name = "gbBand";
            this.gbBand.Size = new System.Drawing.Size(108, 62);
            this.gbBand.TabIndex = 1;
            this.gbBand.TabStop = false;
            this.gbBand.Text = "BAND";
            // 
            // button1
            // 
            this.button1.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.button1.Location = new System.Drawing.Point(29, 19);
            this.button1.Name = "button1";
            this.button1.Size = new System.Drawing.Size(54, 36);
            this.button1.TabIndex = 0;
            this.button1.Text = "RADIO";
            this.button1.UseVisualStyleBackColor = true;
            // 
            // btnSleep
            // 
            this.btnSleep.Font = new System.Drawing.Font("Microsoft Sans Serif", 6F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnSleep.Location = new System.Drawing.Point(601, 35);
            this.btnSleep.Name = "btnSleep";
            this.btnSleep.Size = new System.Drawing.Size(54, 36);
            this.btnSleep.TabIndex = 0;
            this.btnSleep.Text = "SLEEP";
            this.btnSleep.UseVisualStyleBackColor = true;
            // 
            // btnVolumeDown
            // 
            this.btnVolumeDown.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolumeDown.Location = new System.Drawing.Point(6, 19);
            this.btnVolumeDown.Name = "btnVolumeDown";
            this.btnVolumeDown.Size = new System.Drawing.Size(38, 38);
            this.btnVolumeDown.TabIndex = 0;
            this.btnVolumeDown.Text = "-";
            this.btnVolumeDown.UseVisualStyleBackColor = true;
            // 
            // btnVolumeUp
            // 
            this.btnVolumeUp.Font = new System.Drawing.Font("Microsoft Sans Serif", 12F, System.Drawing.FontStyle.Bold, System.Drawing.GraphicsUnit.Point, ((byte)(0)));
            this.btnVolumeUp.Location = new System.Drawing.Point(50, 19);
            this.btnVolumeUp.Name = "btnVolumeUp";
            this.btnVolumeUp.Size = new System.Drawing.Size(38, 38);
            this.btnVolumeUp.TabIndex = 0;
            this.btnVolumeUp.Text = "+";
            this.btnVolumeUp.UseVisualStyleBackColor = true;
            // 
            // gbVolume
            // 
            this.gbVolume.Controls.Add(this.btnVolumeDown);
            this.gbVolume.Controls.Add(this.btnVolumeUp);
            this.gbVolume.Location = new System.Drawing.Point(658, 129);
            this.gbVolume.Name = "gbVolume";
            this.gbVolume.Size = new System.Drawing.Size(94, 66);
            this.gbVolume.TabIndex = 2;
            this.gbVolume.TabStop = false;
            this.gbVolume.Text = "Volume";
            // 
            // Form1
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.ClientSize = new System.Drawing.Size(799, 656);
            this.Controls.Add(this.groupBox3);
            this.Controls.Add(this.groupBox2);
            this.Controls.Add(this.gbHorlogeFront);
            this.Name = "Form1";
            this.Text = "Form1";
            this.Load += new System.EventHandler(this.Form1_Load);
            this.gbHorlogeFront.ResumeLayout(false);
            this.gbHorlogeFront.PerformLayout();
            this.gbClock.ResumeLayout(false);
            this.gbClock.PerformLayout();
            this.groupBox2.ResumeLayout(false);
            this.gbNatureSoundEffects.ResumeLayout(false);
            this.gbAlarmReset.ResumeLayout(false);
            this.gbBand.ResumeLayout(false);
            this.gbVolume.ResumeLayout(false);
            this.ResumeLayout(false);

        }

        #endregion

        private System.Windows.Forms.GroupBox gbHorlogeFront;
        private System.Windows.Forms.Label lblSony;
        private System.Windows.Forms.GroupBox gbClock;
        private System.Windows.Forms.Label lblTimeFormat;
        private System.Windows.Forms.Label lblTime;
        private System.Windows.Forms.GroupBox groupBox2;
        private System.Windows.Forms.GroupBox groupBox3;
        private System.Windows.Forms.Timer timerGlobal;
        private System.Windows.Forms.Button btnSnooze;
        private System.Windows.Forms.GroupBox gbNatureSoundEffects;
        private System.Windows.Forms.Button btnSonOiseau;
        private System.Windows.Forms.Button button5;
        private System.Windows.Forms.Button btnSonVagues;
        private System.Windows.Forms.Button button4;
        private System.Windows.Forms.Button btnSonPluie;
        private System.Windows.Forms.Button btnAlarmOnOffGauche;
        private System.Windows.Forms.Button btnTimeSetGauche;
        private System.Windows.Forms.Button btnAlarmOnOffDroite;
        private System.Windows.Forms.Button btnTimeSetDroite;
        private System.Windows.Forms.GroupBox gbBand;
        private System.Windows.Forms.Button button1;
        private System.Windows.Forms.Button btnSleep;
        private System.Windows.Forms.GroupBox gbAlarmReset;
        private System.Windows.Forms.Button button7;
        private System.Windows.Forms.GroupBox gbVolume;
        private System.Windows.Forms.Button btnVolumeDown;
        private System.Windows.Forms.Button btnVolumeUp;
    }
}

