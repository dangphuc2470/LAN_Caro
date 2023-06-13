namespace LAN_Caro
{
    partial class MenuForm
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
            System.ComponentModel.ComponentResourceManager resources = new System.ComponentModel.ComponentResourceManager(typeof(MenuForm));
            pnStartMenu = new Panel();
            panel2 = new Panel();
            panel1 = new Panel();
            label1 = new Label();
            btPlaySingle = new Addon_Custom_Button();
            lbAbout = new CustomLabel();
            lbSetting = new CustomLabel();
            lbHelp = new CustomLabel();
            btLan = new Addon_Custom_Button();
            ptbBackround = new PictureBox();
            pnMultiplayer = new Panel();
            pnStartMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBackround).BeginInit();
            SuspendLayout();
            // 
            // pnStartMenu
            // 
            pnStartMenu.Controls.Add(panel2);
            pnStartMenu.Controls.Add(panel1);
            pnStartMenu.Controls.Add(label1);
            pnStartMenu.Controls.Add(btPlaySingle);
            pnStartMenu.Controls.Add(lbAbout);
            pnStartMenu.Controls.Add(lbSetting);
            pnStartMenu.Controls.Add(lbHelp);
            pnStartMenu.Controls.Add(btLan);
            pnStartMenu.Controls.Add(ptbBackround);
            pnStartMenu.Dock = DockStyle.Fill;
            pnStartMenu.Location = new Point(0, 0);
            pnStartMenu.Name = "pnStartMenu";
            pnStartMenu.Size = new Size(1480, 788);
            pnStartMenu.TabIndex = 20;
            // 
            // panel2
            // 
            panel2.BackColor = Color.Gainsboro;
            panel2.Location = new Point(799, 708);
            panel2.Name = "panel2";
            panel2.Size = new Size(3, 48);
            panel2.TabIndex = 23;
            // 
            // panel1
            // 
            panel1.BackColor = Color.Gainsboro;
            panel1.Location = new Point(629, 708);
            panel1.Name = "panel1";
            panel1.Size = new Size(3, 48);
            panel1.TabIndex = 22;
            // 
            // label1
            // 
            label1.AutoSize = true;
            label1.BackColor = Color.Transparent;
            label1.Font = new Font("Segoe UI", 6F, FontStyle.Regular, GraphicsUnit.Point);
            label1.ForeColor = Color.White;
            label1.Location = new Point(8, 2);
            label1.Name = "label1";
            label1.Size = new Size(74, 15);
            label1.TabIndex = 25;
            label1.Text = "v0.0.1 (BETA)";
            // 
            // btPlaySingle
            // 
            btPlaySingle.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btPlaySingle.BackColor = Color.MediumSlateBlue;
            btPlaySingle.BackgroundColor = Color.MediumSlateBlue;
            btPlaySingle.BackgroundImage = Properties.Resources.Picsart_23_06_13_09_08_41_819;
            btPlaySingle.BackgroundImageLayout = ImageLayout.Stretch;
            btPlaySingle.BorderColor = Color.White;
            btPlaySingle.BorderRadius = 4;
            btPlaySingle.BorderSize = 1;
            btPlaySingle.FlatAppearance.BorderSize = 0;
            btPlaySingle.FlatStyle = FlatStyle.Flat;
            btPlaySingle.Font = new Font("Impact", 25F, FontStyle.Regular, GraphicsUnit.Point);
            btPlaySingle.ForeColor = Color.White;
            btPlaySingle.Location = new Point(38, 578);
            btPlaySingle.Name = "btPlaySingle";
            btPlaySingle.Size = new Size(329, 86);
            btPlaySingle.TabIndex = 20;
            btPlaySingle.Text = "PLAY";
            btPlaySingle.TextColor = Color.White;
            btPlaySingle.UseVisualStyleBackColor = false;
            btPlaySingle.Click += btPlayMM_Click;
            // 
            // lbAbout
            // 
            lbAbout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbAbout.AutoSize = true;
            lbAbout.BackColor = Color.Transparent;
            lbAbout.FlatStyle = FlatStyle.Flat;
            lbAbout.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lbAbout.ForeColor = Color.White;
            lbAbout.Location = new Point(655, 708);
            lbAbout.Name = "lbAbout";
            lbAbout.Size = new Size(124, 48);
            lbAbout.TabIndex = 24;
            lbAbout.Text = "ABOUT";
            lbAbout.Click += lbAbout_Click;
            // 
            // lbSetting
            // 
            lbSetting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbSetting.AutoSize = true;
            lbSetting.BackColor = Color.Transparent;
            lbSetting.FlatStyle = FlatStyle.Flat;
            lbSetting.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lbSetting.ForeColor = Color.White;
            lbSetting.Location = new Point(463, 708);
            lbSetting.Name = "lbSetting";
            lbSetting.Size = new Size(149, 48);
            lbSetting.TabIndex = 23;
            lbSetting.Text = "SETTING";
            // 
            // lbHelp
            // 
            lbHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbHelp.AutoSize = true;
            lbHelp.BackColor = Color.Transparent;
            lbHelp.FlatStyle = FlatStyle.Flat;
            lbHelp.Font = new Font("Impact", 20F, FontStyle.Regular, GraphicsUnit.Point);
            lbHelp.ForeColor = Color.White;
            lbHelp.Location = new Point(822, 708);
            lbHelp.Name = "lbHelp";
            lbHelp.Size = new Size(94, 48);
            lbHelp.TabIndex = 22;
            lbHelp.Text = "HELP";
            lbHelp.Click += lbHelp_Click;
            // 
            // btLan
            // 
            btLan.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btLan.BackColor = Color.MediumSlateBlue;
            btLan.BackgroundColor = Color.MediumSlateBlue;
            btLan.BackgroundImage = Properties.Resources.PSFix_20230605_223910_auto_x2_2;
            btLan.BackgroundImageLayout = ImageLayout.Stretch;
            btLan.BorderColor = Color.White;
            btLan.BorderRadius = 4;
            btLan.BorderSize = 1;
            btLan.FlatAppearance.BorderSize = 0;
            btLan.FlatStyle = FlatStyle.Flat;
            btLan.Font = new Font("Impact", 25F, FontStyle.Regular, GraphicsUnit.Point);
            btLan.ForeColor = Color.White;
            btLan.Location = new Point(38, 670);
            btLan.Name = "btLan";
            btLan.Size = new Size(329, 86);
            btLan.TabIndex = 21;
            btLan.Text = "MULTIPLAYER";
            btLan.TextColor = Color.White;
            btLan.UseVisualStyleBackColor = false;
            btLan.Click += btLan_Click;
            // 
            // ptbBackround
            // 
            ptbBackround.Dock = DockStyle.Fill;
            ptbBackround.Image = Properties.Resources.backround;
            ptbBackround.Location = new Point(0, 0);
            ptbBackround.Name = "ptbBackround";
            ptbBackround.Size = new Size(1480, 788);
            ptbBackround.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbBackround.TabIndex = 0;
            ptbBackround.TabStop = false;
            // 
            // pnMultiplayer
            // 
            pnMultiplayer.BackgroundImage = Properties.Resources.Picsart_23_06_07_08_41_09_453;
            pnMultiplayer.BackgroundImageLayout = ImageLayout.Stretch;
            pnMultiplayer.Dock = DockStyle.Fill;
            pnMultiplayer.Location = new Point(0, 0);
            pnMultiplayer.Name = "pnMultiplayer";
            pnMultiplayer.Size = new Size(1480, 788);
            pnMultiplayer.TabIndex = 21;
            pnMultiplayer.Visible = false;
            pnMultiplayer.ControlRemoved += pnMultiplayer_ControlRemoved;
            // 
            // MenuForm
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            ClientSize = new Size(1480, 788);
            Controls.Add(pnStartMenu);
            Controls.Add(pnMultiplayer);
            FormBorderStyle = FormBorderStyle.FixedDialog;
            Icon = (Icon)resources.GetObject("$this.Icon");
            KeyPreview = true;
            Name = "MenuForm";
            Text = "Paper & Pencil";
            ResizeEnd += MenuForm_SizeChanged;
            KeyDown += MenuForm_KeyDown;
            Move += MenuForm_Move;
            pnStartMenu.ResumeLayout(false);
            pnStartMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBackround).EndInit();
            ResumeLayout(false);
        }

        #endregion

        private Panel pnStartMenu;
        private PictureBox ptbBackround;
        private Addon_Custom_Button btPlaySingle;
        private CustomLabel lbAbout;
        private CustomLabel lbSetting;
        private CustomLabel lbHelp;
        private Addon_Custom_Button btLan;
        private Panel pnMultiplayer;
        private Label label1;
        private Panel panel1;
        private Panel panel2;
    }
}