using Diety.helpers;

using cornerbtn = GaryPerkin.UserControls.Buttons.RoundButton;

namespace Diety
{
    partial class Game
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
            this.lblVolgers = new System.Windows.Forms.Label();
            this.btnStart = new GaryPerkin.UserControls.Buttons.RoundButton();
            this.AantalVolgers = new System.Windows.Forms.Label();
            this.GeloofNaam = new System.Windows.Forms.Label();
            this.Tijd = new System.Windows.Forms.Label();
            this.lblTijd = new System.Windows.Forms.Label();
            this.Gebeden = new System.Windows.Forms.Label();
            this.lblGebeden = new System.Windows.Forms.Label();
            this.Voedsel = new System.Windows.Forms.Label();
            this.lblVoedsel = new System.Windows.Forms.Label();
            this.pnlMenu = new System.Windows.Forms.Panel();
            this.btnStop = new GaryPerkin.UserControls.Buttons.RoundButton();
            this.tbxGeloof = new System.Windows.Forms.TextBox();
            this.pnlActies = new System.Windows.Forms.Panel();
            this.label1 = new System.Windows.Forms.Label();
            this.btnSneller = new GaryPerkin.UserControls.Buttons.RoundButton();
            this.btnTrager = new GaryPerkin.UserControls.Buttons.RoundButton();
            this.btnPlayPause = new GaryPerkin.UserControls.Buttons.RoundButton();
            this.btnUpdate = new GaryPerkin.UserControls.Buttons.RoundButton();
            this.pnlEvents = new System.Windows.Forms.Panel();
            this.tbxEvents = new System.Windows.Forms.RichTextBox();
            this.lblEvents = new System.Windows.Forms.Label();
            this.pnlStats = new System.Windows.Forms.Panel();
            this.Hout = new System.Windows.Forms.Label();
            this.lblHout = new System.Windows.Forms.Label();
            this.Ervaring = new System.Windows.Forms.Label();
            this.lblErvaring = new System.Windows.Forms.Label();
            this.VoedselMaximum = new System.Windows.Forms.Label();
            this.populatielimiet = new System.Windows.Forms.Label();
            this.pictureBox4 = new System.Windows.Forms.PictureBox();
            this.pictureBox3 = new System.Windows.Forms.PictureBox();
            this.pictureBox2 = new System.Windows.Forms.PictureBox();
            this.pictureBox1 = new System.Windows.Forms.PictureBox();
            this.pnlTijd = new System.Windows.Forms.Panel();
            this.label3 = new System.Windows.Forms.Label();
            this.pnlTech = new System.Windows.Forms.Panel();
            this.label2 = new System.Windows.Forms.Label();
            this.pnlView = new Diety.helpers.DoubleBufferPanel();
            this.HoutMaximum = new System.Windows.Forms.Label();
            this.pnlMenu.SuspendLayout();
            this.pnlActies.SuspendLayout();
            this.pnlEvents.SuspendLayout();
            this.pnlStats.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).BeginInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).BeginInit();
            this.pnlTijd.SuspendLayout();
            this.pnlTech.SuspendLayout();
            this.SuspendLayout();
            // 
            // lblVolgers
            // 
            this.lblVolgers.AutoSize = true;
            this.lblVolgers.Location = new System.Drawing.Point(33, 27);
            this.lblVolgers.Name = "lblVolgers";
            this.lblVolgers.Size = new System.Drawing.Size(48, 13);
            this.lblVolgers.TabIndex = 0;
            this.lblVolgers.Text = "Volgers :";
            // 
            // btnStart
            // 
            this.btnStart.BackColor = System.Drawing.Color.FromArgb(((int)(((byte)(0)))), ((int)(((byte)(192)))), ((int)(((byte)(0)))));
            this.btnStart.Dome = true;
            this.btnStart.Location = new System.Drawing.Point(12, 3);
            this.btnStart.Name = "btnStart";
            this.btnStart.RecessDepth = 0;
            this.btnStart.Size = new System.Drawing.Size(49, 35);
            this.btnStart.TabIndex = 1;
            this.btnStart.Text = "Start";
            this.btnStart.UseVisualStyleBackColor = false;
            this.btnStart.Click += new System.EventHandler(this.btnStart_Click);
            // 
            // AantalVolgers
            // 
            this.AantalVolgers.AutoSize = true;
            this.AantalVolgers.Location = new System.Drawing.Point(87, 29);
            this.AantalVolgers.Name = "AantalVolgers";
            this.AantalVolgers.Size = new System.Drawing.Size(13, 13);
            this.AantalVolgers.TabIndex = 2;
            this.AantalVolgers.Text = "0";
            // 
            // GeloofNaam
            // 
            this.GeloofNaam.AutoSize = true;
            this.GeloofNaam.Font = new System.Drawing.Font("Showcard Gothic", 20.75F);
            this.GeloofNaam.Location = new System.Drawing.Point(167, 5);
            this.GeloofNaam.Name = "GeloofNaam";
            this.GeloofNaam.Size = new System.Drawing.Size(196, 35);
            this.GeloofNaam.TabIndex = 3;
            this.GeloofNaam.Text = "GeloofNaam";
            // 
            // Tijd
            // 
            this.Tijd.AutoSize = true;
            this.Tijd.Location = new System.Drawing.Point(87, 14);
            this.Tijd.Name = "Tijd";
            this.Tijd.Size = new System.Drawing.Size(13, 13);
            this.Tijd.TabIndex = 8;
            this.Tijd.Text = "0";
            // 
            // lblTijd
            // 
            this.lblTijd.AutoSize = true;
            this.lblTijd.Location = new System.Drawing.Point(51, 14);
            this.lblTijd.Name = "lblTijd";
            this.lblTijd.Size = new System.Drawing.Size(30, 13);
            this.lblTijd.TabIndex = 7;
            this.lblTijd.Text = "Tijd :";
            // 
            // Gebeden
            // 
            this.Gebeden.AutoSize = true;
            this.Gebeden.Location = new System.Drawing.Point(87, 55);
            this.Gebeden.Name = "Gebeden";
            this.Gebeden.Size = new System.Drawing.Size(13, 13);
            this.Gebeden.TabIndex = 6;
            this.Gebeden.Text = "0";
            // 
            // lblGebeden
            // 
            this.lblGebeden.AutoSize = true;
            this.lblGebeden.Location = new System.Drawing.Point(24, 53);
            this.lblGebeden.Name = "lblGebeden";
            this.lblGebeden.Size = new System.Drawing.Size(57, 13);
            this.lblGebeden.TabIndex = 5;
            this.lblGebeden.Text = "Gebeden :";
            // 
            // Voedsel
            // 
            this.Voedsel.AutoSize = true;
            this.Voedsel.Location = new System.Drawing.Point(87, 42);
            this.Voedsel.Name = "Voedsel";
            this.Voedsel.Size = new System.Drawing.Size(13, 13);
            this.Voedsel.TabIndex = 4;
            this.Voedsel.Text = "0";
            // 
            // lblVoedsel
            // 
            this.lblVoedsel.AutoSize = true;
            this.lblVoedsel.Location = new System.Drawing.Point(30, 40);
            this.lblVoedsel.Name = "lblVoedsel";
            this.lblVoedsel.Size = new System.Drawing.Size(51, 13);
            this.lblVoedsel.TabIndex = 3;
            this.lblVoedsel.Text = "Voedsel :";
            // 
            // pnlMenu
            // 
            this.pnlMenu.AutoSize = true;
            this.pnlMenu.BackColor = System.Drawing.Color.Transparent;
            this.pnlMenu.Controls.Add(this.btnStop);
            this.pnlMenu.Controls.Add(this.btnStart);
            this.pnlMenu.Location = new System.Drawing.Point(692, 46);
            this.pnlMenu.Name = "pnlMenu";
            this.pnlMenu.Size = new System.Drawing.Size(124, 43);
            this.pnlMenu.TabIndex = 5;
            // 
            // btnStop
            // 
            this.btnStop.BackColor = System.Drawing.Color.Red;
            this.btnStop.Dome = true;
            this.btnStop.Location = new System.Drawing.Point(67, 3);
            this.btnStop.Name = "btnStop";
            this.btnStop.RecessDepth = 0;
            this.btnStop.Size = new System.Drawing.Size(48, 37);
            this.btnStop.TabIndex = 3;
            this.btnStop.Text = "Exit";
            this.btnStop.UseVisualStyleBackColor = false;
            this.btnStop.Click += new System.EventHandler(this.btnStop_Click);
            // 
            // tbxGeloof
            // 
            this.tbxGeloof.Font = new System.Drawing.Font("Microsoft Sans Serif", 18.25F);
            this.tbxGeloof.Location = new System.Drawing.Point(167, 5);
            this.tbxGeloof.Name = "tbxGeloof";
            this.tbxGeloof.Size = new System.Drawing.Size(275, 35);
            this.tbxGeloof.TabIndex = 2;
            this.tbxGeloof.Click += new System.EventHandler(this.RemoveText);
            // 
            // pnlActies
            // 
            this.pnlActies.AutoSize = true;
            this.pnlActies.BackColor = System.Drawing.Color.Transparent;
            this.pnlActies.Controls.Add(this.label1);
            this.pnlActies.Location = new System.Drawing.Point(12, 306);
            this.pnlActies.Name = "pnlActies";
            this.pnlActies.Size = new System.Drawing.Size(235, 324);
            this.pnlActies.TabIndex = 7;
            // 
            // label1
            // 
            this.label1.AutoSize = true;
            this.label1.Font = new System.Drawing.Font("Showcard Gothic", 10.75F);
            this.label1.Location = new System.Drawing.Point(3, -3);
            this.label1.Name = "label1";
            this.label1.Size = new System.Drawing.Size(72, 18);
            this.label1.TabIndex = 11;
            this.label1.Text = "Powers";
            // 
            // btnSneller
            // 
            this.btnSneller.Location = new System.Drawing.Point(155, 46);
            this.btnSneller.Name = "btnSneller";
            this.btnSneller.RecessDepth = 0;
            this.btnSneller.Size = new System.Drawing.Size(73, 23);
            this.btnSneller.TabIndex = 3;
            this.btnSneller.Text = "Sneller";
            this.btnSneller.UseVisualStyleBackColor = true;
            this.btnSneller.Click += new System.EventHandler(this.btnSneller_Click);
            // 
            // btnTrager
            // 
            this.btnTrager.Location = new System.Drawing.Point(2, 46);
            this.btnTrager.Name = "btnTrager";
            this.btnTrager.RecessDepth = 1;
            this.btnTrager.Size = new System.Drawing.Size(58, 23);
            this.btnTrager.TabIndex = 2;
            this.btnTrager.Text = "Trager";
            this.btnTrager.UseVisualStyleBackColor = true;
            this.btnTrager.Click += new System.EventHandler(this.btnTrager_Click);
            // 
            // btnPlayPause
            // 
            this.btnPlayPause.BevelDepth = 2;
            this.btnPlayPause.Location = new System.Drawing.Point(0, 17);
            this.btnPlayPause.Name = "btnPlayPause";
            this.btnPlayPause.RecessDepth = 1;
            this.btnPlayPause.Size = new System.Drawing.Size(225, 23);
            this.btnPlayPause.TabIndex = 1;
            this.btnPlayPause.Text = "Pause";
            this.btnPlayPause.UseVisualStyleBackColor = true;
            this.btnPlayPause.Click += new System.EventHandler(this.btnPlayPause_Click);
            // 
            // btnUpdate
            // 
            this.btnUpdate.Location = new System.Drawing.Point(67, 47);
            this.btnUpdate.Name = "btnUpdate";
            this.btnUpdate.RecessDepth = 1;
            this.btnUpdate.Size = new System.Drawing.Size(82, 22);
            this.btnUpdate.TabIndex = 0;
            this.btnUpdate.Text = "Vooruit";
            this.btnUpdate.UseVisualStyleBackColor = true;
            this.btnUpdate.Click += new System.EventHandler(this.btnUpdate_Click);
            // 
            // pnlEvents
            // 
            this.pnlEvents.AutoSize = true;
            this.pnlEvents.Controls.Add(this.tbxEvents);
            this.pnlEvents.Controls.Add(this.lblEvents);
            this.pnlEvents.Location = new System.Drawing.Point(929, 46);
            this.pnlEvents.Name = "pnlEvents";
            this.pnlEvents.Size = new System.Drawing.Size(313, 587);
            this.pnlEvents.TabIndex = 8;
            // 
            // tbxEvents
            // 
            this.tbxEvents.Location = new System.Drawing.Point(6, 23);
            this.tbxEvents.Name = "tbxEvents";
            this.tbxEvents.Size = new System.Drawing.Size(304, 561);
            this.tbxEvents.TabIndex = 11;
            this.tbxEvents.Text = "";
            // 
            // lblEvents
            // 
            this.lblEvents.AutoSize = true;
            this.lblEvents.Font = new System.Drawing.Font("Showcard Gothic", 10.75F);
            this.lblEvents.Location = new System.Drawing.Point(3, 0);
            this.lblEvents.Name = "lblEvents";
            this.lblEvents.Size = new System.Drawing.Size(63, 18);
            this.lblEvents.TabIndex = 10;
            this.lblEvents.Text = "Events";
            // 
            // pnlStats
            // 
            this.pnlStats.AutoSize = true;
            this.pnlStats.Controls.Add(this.HoutMaximum);
            this.pnlStats.Controls.Add(this.Hout);
            this.pnlStats.Controls.Add(this.lblHout);
            this.pnlStats.Controls.Add(this.Ervaring);
            this.pnlStats.Controls.Add(this.lblErvaring);
            this.pnlStats.Controls.Add(this.VoedselMaximum);
            this.pnlStats.Controls.Add(this.populatielimiet);
            this.pnlStats.Controls.Add(this.pictureBox4);
            this.pnlStats.Controls.Add(this.pictureBox3);
            this.pnlStats.Controls.Add(this.pictureBox2);
            this.pnlStats.Controls.Add(this.pictureBox1);
            this.pnlStats.Controls.Add(this.Tijd);
            this.pnlStats.Controls.Add(this.lblTijd);
            this.pnlStats.Controls.Add(this.Gebeden);
            this.pnlStats.Controls.Add(this.lblGebeden);
            this.pnlStats.Controls.Add(this.Voedsel);
            this.pnlStats.Controls.Add(this.lblVoedsel);
            this.pnlStats.Controls.Add(this.lblVolgers);
            this.pnlStats.Controls.Add(this.AantalVolgers);
            this.pnlStats.Location = new System.Drawing.Point(12, 46);
            this.pnlStats.Name = "pnlStats";
            this.pnlStats.Size = new System.Drawing.Size(147, 141);
            this.pnlStats.TabIndex = 4;
            // 
            // Hout
            // 
            this.Hout.AutoSize = true;
            this.Hout.Location = new System.Drawing.Point(87, 81);
            this.Hout.Name = "Hout";
            this.Hout.Size = new System.Drawing.Size(13, 13);
            this.Hout.TabIndex = 18;
            this.Hout.Text = "0";
            // 
            // lblHout
            // 
            this.lblHout.AutoSize = true;
            this.lblHout.Location = new System.Drawing.Point(45, 79);
            this.lblHout.Name = "lblHout";
            this.lblHout.Size = new System.Drawing.Size(36, 13);
            this.lblHout.TabIndex = 17;
            this.lblHout.Text = "Hout :";
            // 
            // Ervaring
            // 
            this.Ervaring.AutoSize = true;
            this.Ervaring.Location = new System.Drawing.Point(87, 68);
            this.Ervaring.Name = "Ervaring";
            this.Ervaring.Size = new System.Drawing.Size(13, 13);
            this.Ervaring.TabIndex = 16;
            this.Ervaring.Text = "0";
            // 
            // lblErvaring
            // 
            this.lblErvaring.AutoSize = true;
            this.lblErvaring.Location = new System.Drawing.Point(29, 66);
            this.lblErvaring.Name = "lblErvaring";
            this.lblErvaring.Size = new System.Drawing.Size(52, 13);
            this.lblErvaring.TabIndex = 15;
            this.lblErvaring.Text = "Ervaring :";
            // 
            // VoedselMaximum
            // 
            this.VoedselMaximum.AutoSize = true;
            this.VoedselMaximum.Location = new System.Drawing.Point(120, 42);
            this.VoedselMaximum.Name = "VoedselMaximum";
            this.VoedselMaximum.Size = new System.Drawing.Size(21, 13);
            this.VoedselMaximum.TabIndex = 14;
            this.VoedselMaximum.Text = "/ 0";
            // 
            // populatielimiet
            // 
            this.populatielimiet.AutoSize = true;
            this.populatielimiet.Location = new System.Drawing.Point(120, 29);
            this.populatielimiet.Name = "populatielimiet";
            this.populatielimiet.Size = new System.Drawing.Size(21, 13);
            this.populatielimiet.TabIndex = 13;
            this.populatielimiet.Text = "/ 0";
            // 
            // pictureBox4
            // 
            this.pictureBox4.BackgroundImage = global::Diety.Properties.Resources.iconprayer;
            this.pictureBox4.InitialImage = global::Diety.Properties.Resources.iconprayer;
            this.pictureBox4.Location = new System.Drawing.Point(4, 53);
            this.pictureBox4.Name = "pictureBox4";
            this.pictureBox4.Size = new System.Drawing.Size(15, 13);
            this.pictureBox4.TabIndex = 12;
            this.pictureBox4.TabStop = false;
            // 
            // pictureBox3
            // 
            this.pictureBox3.BackgroundImage = global::Diety.Properties.Resources.iconfood;
            this.pictureBox3.InitialImage = global::Diety.Properties.Resources.iconfood;
            this.pictureBox3.Location = new System.Drawing.Point(4, 40);
            this.pictureBox3.Name = "pictureBox3";
            this.pictureBox3.Size = new System.Drawing.Size(15, 13);
            this.pictureBox3.TabIndex = 11;
            this.pictureBox3.TabStop = false;
            // 
            // pictureBox2
            // 
            this.pictureBox2.BackgroundImage = global::Diety.Properties.Resources.iconvolger;
            this.pictureBox2.InitialImage = global::Diety.Properties.Resources.iconvolger;
            this.pictureBox2.Location = new System.Drawing.Point(4, 27);
            this.pictureBox2.Name = "pictureBox2";
            this.pictureBox2.Size = new System.Drawing.Size(15, 13);
            this.pictureBox2.TabIndex = 10;
            this.pictureBox2.TabStop = false;
            // 
            // pictureBox1
            // 
            this.pictureBox1.BackgroundImage = global::Diety.Properties.Resources.iconclock;
            this.pictureBox1.InitialImage = global::Diety.Properties.Resources.iconclock;
            this.pictureBox1.Location = new System.Drawing.Point(4, 14);
            this.pictureBox1.Name = "pictureBox1";
            this.pictureBox1.Size = new System.Drawing.Size(15, 13);
            this.pictureBox1.TabIndex = 9;
            this.pictureBox1.TabStop = false;
            // 
            // pnlTijd
            // 
            this.pnlTijd.BackColor = System.Drawing.Color.Transparent;
            this.pnlTijd.Controls.Add(this.label3);
            this.pnlTijd.Controls.Add(this.btnPlayPause);
            this.pnlTijd.Controls.Add(this.btnUpdate);
            this.pnlTijd.Controls.Add(this.btnSneller);
            this.pnlTijd.Controls.Add(this.btnTrager);
            this.pnlTijd.Location = new System.Drawing.Point(692, 127);
            this.pnlTijd.Name = "pnlTijd";
            this.pnlTijd.Size = new System.Drawing.Size(231, 72);
            this.pnlTijd.TabIndex = 9;
            // 
            // label3
            // 
            this.label3.AutoSize = true;
            this.label3.Font = new System.Drawing.Font("Showcard Gothic", 10.75F);
            this.label3.Location = new System.Drawing.Point(3, 0);
            this.label3.Name = "label3";
            this.label3.Size = new System.Drawing.Size(40, 18);
            this.label3.TabIndex = 13;
            this.label3.Text = "Tijd";
            // 
            // pnlTech
            // 
            this.pnlTech.AutoSize = true;
            this.pnlTech.BackColor = System.Drawing.Color.Transparent;
            this.pnlTech.Controls.Add(this.label2);
            this.pnlTech.Location = new System.Drawing.Point(360, 306);
            this.pnlTech.Name = "pnlTech";
            this.pnlTech.Size = new System.Drawing.Size(233, 324);
            this.pnlTech.TabIndex = 8;
            // 
            // label2
            // 
            this.label2.AutoSize = true;
            this.label2.Font = new System.Drawing.Font("Showcard Gothic", 10.75F);
            this.label2.Location = new System.Drawing.Point(3, 0);
            this.label2.Name = "label2";
            this.label2.Size = new System.Drawing.Size(47, 18);
            this.label2.TabIndex = 12;
            this.label2.Text = "Tech";
            // 
            // pnlView
            // 
            this.pnlView.AutoSize = true;
            this.pnlView.BackColor = System.Drawing.Color.Transparent;
            this.pnlView.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.pnlView.Location = new System.Drawing.Point(167, 46);
            this.pnlView.Name = "pnlView";
            this.pnlView.Size = new System.Drawing.Size(502, 241);
            this.pnlView.TabIndex = 6;
            this.pnlView.Paint += new System.Windows.Forms.PaintEventHandler(this.pnlViewPaint);
            // 
            // HoutMaximum
            // 
            this.HoutMaximum.AutoSize = true;
            this.HoutMaximum.Location = new System.Drawing.Point(123, 81);
            this.HoutMaximum.Name = "HoutMaximum";
            this.HoutMaximum.Size = new System.Drawing.Size(21, 13);
            this.HoutMaximum.TabIndex = 19;
            this.HoutMaximum.Text = "/ 0";
            // 
            // Game
            // 
            this.AutoScaleDimensions = new System.Drawing.SizeF(6F, 13F);
            this.AutoScaleMode = System.Windows.Forms.AutoScaleMode.Font;
            this.BackgroundImage = global::Diety.Properties.Resources.background;
            this.BackgroundImageLayout = System.Windows.Forms.ImageLayout.Stretch;
            this.ClientSize = new System.Drawing.Size(1353, 656);
            this.Controls.Add(this.pnlTech);
            this.Controls.Add(this.pnlTijd);
            this.Controls.Add(this.pnlEvents);
            this.Controls.Add(this.tbxGeloof);
            this.Controls.Add(this.pnlActies);
            this.Controls.Add(this.pnlView);
            this.Controls.Add(this.pnlMenu);
            this.Controls.Add(this.pnlStats);
            this.Controls.Add(this.GeloofNaam);
            this.DoubleBuffered = true;
            this.Name = "Game";
            this.Text = "Form1";
            this.pnlMenu.ResumeLayout(false);
            this.pnlActies.ResumeLayout(false);
            this.pnlActies.PerformLayout();
            this.pnlEvents.ResumeLayout(false);
            this.pnlEvents.PerformLayout();
            this.pnlStats.ResumeLayout(false);
            this.pnlStats.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox4)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox3)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox2)).EndInit();
            ((System.ComponentModel.ISupportInitialize)(this.pictureBox1)).EndInit();
            this.pnlTijd.ResumeLayout(false);
            this.pnlTijd.PerformLayout();
            this.pnlTech.ResumeLayout(false);
            this.pnlTech.PerformLayout();
            this.ResumeLayout(false);
            this.PerformLayout();

        }

        #endregion

        private System.Windows.Forms.Label lblVolgers;
        private cornerbtn btnStart;
        private System.Windows.Forms.Label AantalVolgers;
        private System.Windows.Forms.Label GeloofNaam;
        private System.Windows.Forms.Panel pnlMenu;
        private DoubleBufferPanel pnlView;
        private System.Windows.Forms.Panel pnlActies;
        private System.Windows.Forms.Panel pnlEvents;
        private System.Windows.Forms.TextBox tbxGeloof;
        private System.Windows.Forms.Label Voedsel;
        private System.Windows.Forms.Label lblVoedsel;
        private System.Windows.Forms.Label Gebeden;
        private System.Windows.Forms.Label lblGebeden;
        private System.Windows.Forms.Label lblEvents;
        private cornerbtn btnStop;
        private cornerbtn btnUpdate;
        private System.Windows.Forms.Label Tijd;
        private System.Windows.Forms.Label lblTijd;
        private cornerbtn btnPlayPause;
        private cornerbtn btnSneller;
        private cornerbtn btnTrager;
        private System.Windows.Forms.Panel pnlStats;
        private System.Windows.Forms.PictureBox pictureBox4;
        private System.Windows.Forms.PictureBox pictureBox3;
        private System.Windows.Forms.PictureBox pictureBox2;
        private System.Windows.Forms.PictureBox pictureBox1;
        private System.Windows.Forms.Label VoedselMaximum;
        private System.Windows.Forms.Label populatielimiet;
        private System.Windows.Forms.Panel pnlTijd;
        private System.Windows.Forms.Label label1;
        private System.Windows.Forms.Panel pnlTech;
        private System.Windows.Forms.Label label2;
        private System.Windows.Forms.RichTextBox tbxEvents;
        private System.Windows.Forms.Label label3;
        private System.Windows.Forms.Label Ervaring;
        private System.Windows.Forms.Label lblErvaring;
        private System.Windows.Forms.Label Hout;
        private System.Windows.Forms.Label lblHout;
        private System.Windows.Forms.Label HoutMaximum;
    }
}

