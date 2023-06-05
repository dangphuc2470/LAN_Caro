using System.Drawing.Text;

namespace LAN_Caro
{
    partial class Caro
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
            components = new System.ComponentModel.Container();
            pnTable = new Addon_Round_Panel();
            btConnect = new Button();
            tbIPAdress = new TextBox();
            chbServer = new CheckBox();
            imageList1 = new ImageList(components);
            imgTurn = new PictureBox();
            btMenu = new Addon_Custom_Button();
            rtbLog = new RichTextBox();
            pnPause = new Addon_Transparent_Panel();
            customLabel1 = new CustomLabel();
            lbChangeTurn = new CustomLabel();
            randomPatternLabel = new CustomLabel();
            lbRandom = new CustomLabel();
            lbPause = new CustomLabel();
            lbRestart = new CustomLabel();
            lbExit = new CustomLabel();
            lbLeaveMatch = new CustomLabel();
            lbMatchLog = new CustomLabel();
            lbSettings = new CustomLabel();
            lbOptions = new CustomLabel();
            lbResume = new CustomLabel();
            lbMenu = new CustomLabel();
            timer1 = new System.Windows.Forms.Timer(components);
            lbTimer = new Label();
            btReady = new Addon_Custom_Button();
            pnStartMenu = new Panel();
            btPlayMM = new Addon_Custom_Button();
            btLan = new Addon_Custom_Button();
            lbHelp = new CustomLabel();
            lbSetting = new CustomLabel();
            lbAbout = new CustomLabel();
            pictureBox1 = new PictureBox();
            ((System.ComponentModel.ISupportInitialize)imgTurn).BeginInit();
            pnPause.SuspendLayout();
            pnStartMenu.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).BeginInit();
            SuspendLayout();
            // 
            // pnTable
            // 
            pnTable.AutoScroll = true;
            pnTable.BackColor = Color.White;
            pnTable.CornerRadius = 25;
            pnTable.Location = new Point(286, 32);
            pnTable.Name = "pnTable";
            pnTable.Size = new Size(996, 711);
            pnTable.TabIndex = 0;
            // 
            // btConnect
            // 
            btConnect.BackColor = Color.White;
            btConnect.FlatStyle = FlatStyle.Flat;
            btConnect.Location = new Point(34, 446);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(112, 34);
            btConnect.TabIndex = 3;
            btConnect.Text = "Connect";
            btConnect.UseVisualStyleBackColor = false;
            btConnect.Click += Connect_Click;
            // 
            // tbIPAdress
            // 
            tbIPAdress.Location = new Point(43, 363);
            tbIPAdress.Name = "tbIPAdress";
            tbIPAdress.Size = new Size(150, 31);
            tbIPAdress.TabIndex = 4;
            // 
            // chbServer
            // 
            chbServer.AutoSize = true;
            chbServer.Checked = true;
            chbServer.CheckState = CheckState.Checked;
            chbServer.Location = new Point(172, 451);
            chbServer.Name = "chbServer";
            chbServer.Size = new Size(87, 29);
            chbServer.TabIndex = 5;
            chbServer.Text = "Server";
            chbServer.UseVisualStyleBackColor = true;
            chbServer.CheckedChanged += chbServer_CheckedChanged;
            // 
            // imageList1
            // 
            imageList1.ColorDepth = ColorDepth.Depth8Bit;
            imageList1.ImageSize = new Size(16, 16);
            imageList1.TransparentColor = Color.Transparent;
            // 
            // imgTurn
            // 
            imgTurn.Image = Properties.Resources.x;
            imgTurn.ImageLocation = "";
            imgTurn.InitialImage = null;
            imgTurn.Location = new Point(225, 359);
            imgTurn.Name = "imgTurn";
            imgTurn.Size = new Size(35, 35);
            imgTurn.TabIndex = 9;
            imgTurn.TabStop = false;
            imgTurn.SizeChanged += imgTurn_SizeChanged;
            // 
            // btMenu
            // 
            btMenu.BackColor = Color.FromArgb(213, 227, 255);
            btMenu.BackgroundColor = Color.FromArgb(213, 227, 255);
            btMenu.BorderColor = Color.PaleVioletRed;
            btMenu.BorderRadius = 20;
            btMenu.BorderSize = 0;
            btMenu.FlatAppearance.BorderSize = 0;
            btMenu.FlatStyle = FlatStyle.Flat;
            btMenu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btMenu.ForeColor = Color.FromArgb(0, 28, 59);
            btMenu.Image = Properties.Resources.icons8_settings_24;
            btMenu.Location = new Point(9, 700);
            btMenu.Name = "btMenu";
            btMenu.Size = new Size(60, 60);
            btMenu.TabIndex = 5;
            btMenu.TextColor = Color.FromArgb(0, 28, 59);
            btMenu.UseVisualStyleBackColor = false;
            btMenu.Click += Menu_Click;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.FromArgb(75, 75, 75);
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rtbLog.ForeColor = Color.White;
            rtbLog.Location = new Point(320, 63);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(933, 652);
            rtbLog.TabIndex = 13;
            rtbLog.Text = "";
            rtbLog.Visible = false;
            rtbLog.TextChanged += richTextBox1_TextChanged;
            // 
            // pnPause
            // 
            pnPause.Controls.Add(customLabel1);
            pnPause.Controls.Add(lbChangeTurn);
            pnPause.Controls.Add(randomPatternLabel);
            pnPause.Controls.Add(lbRandom);
            pnPause.Controls.Add(lbPause);
            pnPause.Controls.Add(lbRestart);
            pnPause.Controls.Add(lbExit);
            pnPause.Controls.Add(lbLeaveMatch);
            pnPause.Controls.Add(lbMatchLog);
            pnPause.Controls.Add(lbSettings);
            pnPause.Controls.Add(lbOptions);
            pnPause.Controls.Add(lbResume);
            pnPause.Controls.Add(lbMenu);
            pnPause.Controls.Add(rtbLog);
            pnPause.Location = new Point(994, 604);
            pnPause.Name = "pnPause";
            pnPause.Size = new Size(177, 99);
            pnPause.TabIndex = 14;
            pnPause.Tag = "0";
            pnPause.VisibleChanged += pnPause_VisibleChanged;
            // 
            // customLabel1
            // 
            customLabel1.AutoSize = true;
            customLabel1.BackColor = Color.Transparent;
            customLabel1.Font = new Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point);
            customLabel1.ForeColor = Color.White;
            customLabel1.Location = new Point(583, 458);
            customLabel1.Name = "customLabel1";
            customLabel1.Size = new Size(184, 24);
            customLabel1.TabIndex = 27;
            customLabel1.Text = "(Testing purpose only)";
            customLabel1.Visible = false;
            // 
            // lbChangeTurn
            // 
            lbChangeTurn.AutoSize = true;
            lbChangeTurn.BackColor = Color.Transparent;
            lbChangeTurn.ForeColor = Color.White;
            lbChangeTurn.Location = new Point(320, 430);
            lbChangeTurn.Name = "lbChangeTurn";
            lbChangeTurn.Size = new Size(132, 25);
            lbChangeTurn.TabIndex = 26;
            lbChangeTurn.Text = "CHANGE TURN";
            lbChangeTurn.Visible = false;
            lbChangeTurn.Click += lbChangeTurn_Click;
            // 
            // randomPatternLabel
            // 
            randomPatternLabel.AutoSize = true;
            randomPatternLabel.BackColor = Color.Transparent;
            randomPatternLabel.Font = new Font("Arial Narrow", 10F, FontStyle.Bold, GraphicsUnit.Point);
            randomPatternLabel.ForeColor = Color.White;
            randomPatternLabel.Location = new Point(583, 391);
            randomPatternLabel.Name = "randomPatternLabel";
            randomPatternLabel.Size = new Size(184, 24);
            randomPatternLabel.TabIndex = 25;
            randomPatternLabel.Text = "(Testing purpose only)";
            randomPatternLabel.Visible = false;
            // 
            // lbRandom
            // 
            lbRandom.AutoSize = true;
            lbRandom.BackColor = Color.Transparent;
            lbRandom.ForeColor = Color.White;
            lbRandom.Location = new Point(320, 363);
            lbRandom.Name = "lbRandom";
            lbRandom.Size = new Size(167, 25);
            lbRandom.TabIndex = 24;
            lbRandom.Text = "RANDOM PATTERN";
            lbRandom.Visible = false;
            lbRandom.Click += lbRandom_Click;
            // 
            // lbPause
            // 
            lbPause.AutoSize = true;
            lbPause.BackColor = Color.Transparent;
            lbPause.ForeColor = Color.White;
            lbPause.Location = new Point(320, 290);
            lbPause.Name = "lbPause";
            lbPause.Size = new Size(64, 25);
            lbPause.TabIndex = 23;
            lbPause.Text = "PAUSE";
            lbPause.Visible = false;
            lbPause.Click += lbPause_Click;
            // 
            // lbRestart
            // 
            lbRestart.AutoSize = true;
            lbRestart.BackColor = Color.Transparent;
            lbRestart.ForeColor = Color.White;
            lbRestart.Location = new Point(320, 220);
            lbRestart.Name = "lbRestart";
            lbRestart.Size = new Size(81, 25);
            lbRestart.TabIndex = 22;
            lbRestart.Text = "RESTART";
            lbRestart.Visible = false;
            lbRestart.VisibleChanged += lbRestart_VisibleChanged;
            lbRestart.Click += lbRestart_Click;
            // 
            // lbExit
            // 
            lbExit.AutoSize = true;
            lbExit.BackColor = Color.Transparent;
            lbExit.ForeColor = Color.White;
            lbExit.Location = new Point(45, 570);
            lbExit.Name = "lbExit";
            lbExit.Size = new Size(152, 25);
            lbExit.TabIndex = 21;
            lbExit.Text = "EXIT TO DESKTOP";
            lbExit.Click += lbExit_Click;
            // 
            // lbLeaveMatch
            // 
            lbLeaveMatch.AutoSize = true;
            lbLeaveMatch.BackColor = Color.Transparent;
            lbLeaveMatch.ForeColor = Color.White;
            lbLeaveMatch.Location = new Point(45, 500);
            lbLeaveMatch.Name = "lbLeaveMatch";
            lbLeaveMatch.Size = new Size(124, 25);
            lbLeaveMatch.TabIndex = 20;
            lbLeaveMatch.Text = "LEAVE MATCH";
            lbLeaveMatch.Click += lbLeaveMatch_Click;
            // 
            // lbMatchLog
            // 
            lbMatchLog.AutoSize = true;
            lbMatchLog.BackColor = Color.Transparent;
            lbMatchLog.ForeColor = Color.White;
            lbMatchLog.Location = new Point(45, 430);
            lbMatchLog.Name = "lbMatchLog";
            lbMatchLog.Size = new Size(109, 25);
            lbMatchLog.TabIndex = 19;
            lbMatchLog.Text = "MATCH LOG";
            lbMatchLog.Click += lbMatchLog_Click;
            // 
            // lbSettings
            // 
            lbSettings.AutoSize = true;
            lbSettings.BackColor = Color.Transparent;
            lbSettings.ForeColor = Color.White;
            lbSettings.Location = new Point(45, 360);
            lbSettings.Name = "lbSettings";
            lbSettings.Size = new Size(89, 25);
            lbSettings.TabIndex = 18;
            lbSettings.Text = "SETTINGS";
            lbSettings.Click += lbSettings_Click;
            // 
            // lbOptions
            // 
            lbOptions.AutoSize = true;
            lbOptions.BackColor = Color.Transparent;
            lbOptions.ForeColor = Color.White;
            lbOptions.Location = new Point(45, 290);
            lbOptions.Name = "lbOptions";
            lbOptions.Size = new Size(87, 25);
            lbOptions.TabIndex = 17;
            lbOptions.Text = "OPTIONS";
            lbOptions.Click += lbOptions_Click;
            // 
            // lbResume
            // 
            lbResume.AutoSize = true;
            lbResume.BackColor = Color.Transparent;
            lbResume.ForeColor = Color.White;
            lbResume.Location = new Point(45, 220);
            lbResume.Name = "lbResume";
            lbResume.Size = new Size(79, 25);
            lbResume.TabIndex = 16;
            lbResume.Text = "RESUME";
            lbResume.Click += lbResume_Click;
            // 
            // lbMenu
            // 
            lbMenu.AutoSize = true;
            lbMenu.BackColor = Color.Transparent;
            lbMenu.ForeColor = Color.White;
            lbMenu.Location = new Point(34, 110);
            lbMenu.Name = "lbMenu";
            lbMenu.Size = new Size(62, 25);
            lbMenu.TabIndex = 15;
            lbMenu.Text = "MENU";
            // 
            // timer1
            // 
            timer1.Interval = 1000;
            timer1.Tick += timer1_Tick;
            // 
            // lbTimer
            // 
            lbTimer.AutoSize = true;
            lbTimer.BackColor = Color.Transparent;
            lbTimer.Location = new Point(60, 78);
            lbTimer.Name = "lbTimer";
            lbTimer.Size = new Size(0, 25);
            lbTimer.TabIndex = 16;
            lbTimer.Tag = "0";
            // 
            // btReady
            // 
            btReady.BackColor = Color.FromArgb(213, 227, 255);
            btReady.BackgroundColor = Color.FromArgb(213, 227, 255);
            btReady.BorderColor = Color.PaleVioletRed;
            btReady.BorderRadius = 20;
            btReady.BorderSize = 0;
            btReady.FlatAppearance.BorderSize = 0;
            btReady.FlatStyle = FlatStyle.Flat;
            btReady.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btReady.ForeColor = Color.WhiteSmoke;
            btReady.Location = new Point(94, 700);
            btReady.Name = "btReady";
            btReady.Size = new Size(166, 60);
            btReady.TabIndex = 17;
            btReady.Tag = 0;
            btReady.Text = "Ready";
            btReady.TextColor = Color.WhiteSmoke;
            btReady.UseVisualStyleBackColor = false;
            btReady.Click += btReady_Click;
            btReady.MouseHover += btReady_MouseHover;
            // 
            // pnStartMenu
            // 
            pnStartMenu.BackgroundImageLayout = ImageLayout.Stretch;
            pnStartMenu.Controls.Add(btPlayMM);
            pnStartMenu.Controls.Add(btLan);
            pnStartMenu.Controls.Add(lbHelp);
            pnStartMenu.Controls.Add(lbSetting);
            pnStartMenu.Controls.Add(lbAbout);
            pnStartMenu.Controls.Add(pictureBox1);
            pnStartMenu.Dock = DockStyle.Fill;
            pnStartMenu.Location = new Point(0, 0);
            pnStartMenu.Name = "pnStartMenu";
            pnStartMenu.Size = new Size(1344, 712);
            pnStartMenu.TabIndex = 19;
            // 
            // btPlayMM
            // 
            btPlayMM.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btPlayMM.BackColor = Color.MediumSlateBlue;
            btPlayMM.BackgroundColor = Color.MediumSlateBlue;
            btPlayMM.BackgroundImage = Properties.Resources.PSFix_20230605_223910_auto_x2_3;
            btPlayMM.BackgroundImageLayout = ImageLayout.Stretch;
            btPlayMM.BorderColor = Color.White;
            btPlayMM.BorderRadius = 4;
            btPlayMM.BorderSize = 1;
            btPlayMM.FlatAppearance.BorderSize = 0;
            btPlayMM.FlatStyle = FlatStyle.Flat;
            btPlayMM.ForeColor = Color.White;
            btPlayMM.Location = new Point(34, 497);
            btPlayMM.Name = "btPlayMM";
            btPlayMM.Size = new Size(329, 86);
            btPlayMM.TabIndex = 19;
            btPlayMM.Text = "PLAY";
            btPlayMM.TextColor = Color.White;
            btPlayMM.UseVisualStyleBackColor = false;
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
            btLan.ForeColor = Color.White;
            btLan.Location = new Point(34, 599);
            btLan.Name = "btLan";
            btLan.Size = new Size(329, 86);
            btLan.TabIndex = 18;
            btLan.Text = "MULTIPLAYER";
            btLan.TextColor = Color.White;
            btLan.UseVisualStyleBackColor = false;
            btLan.Click += btLan_Click;
            // 
            // lbHelp
            // 
            lbHelp.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbHelp.AutoSize = true;
            lbHelp.BackColor = Color.Transparent;
            lbHelp.FlatStyle = FlatStyle.Flat;
            lbHelp.ForeColor = Color.Black;
            lbHelp.Location = new Point(579, 630);
            lbHelp.Name = "lbHelp";
            lbHelp.Size = new Size(52, 25);
            lbHelp.TabIndex = 17;
            lbHelp.Text = "HELP";
            // 
            // lbSetting
            // 
            lbSetting.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbSetting.AutoSize = true;
            lbSetting.BackColor = Color.Transparent;
            lbSetting.FlatStyle = FlatStyle.Flat;
            lbSetting.ForeColor = Color.Black;
            lbSetting.Location = new Point(408, 630);
            lbSetting.Name = "lbSetting";
            lbSetting.Size = new Size(79, 25);
            lbSetting.TabIndex = 5;
            lbSetting.Text = "SETTING";
            // 
            // lbAbout
            // 
            lbAbout.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            lbAbout.AutoSize = true;
            lbAbout.BackColor = Color.Transparent;
            lbAbout.FlatStyle = FlatStyle.Flat;
            lbAbout.ForeColor = Color.Black;
            lbAbout.Location = new Point(713, 630);
            lbAbout.Name = "lbAbout";
            lbAbout.Size = new Size(69, 25);
            lbAbout.TabIndex = 2;
            lbAbout.Text = "ABOUT";
            // 
            // pictureBox1
            // 
            pictureBox1.Dock = DockStyle.Fill;
            pictureBox1.Image = Properties.Resources.ezgif_1_2b46e4d3fb;
            pictureBox1.Location = new Point(0, 0);
            pictureBox1.Name = "pictureBox1";
            pictureBox1.Size = new Size(1344, 712);
            pictureBox1.SizeMode = PictureBoxSizeMode.StretchImage;
            pictureBox1.TabIndex = 0;
            pictureBox1.TabStop = false;
            // 
            // Caro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1344, 712);
            Controls.Add(pnStartMenu);
            Controls.Add(btReady);
            Controls.Add(pnPause);
            Controls.Add(lbTimer);
            Controls.Add(btMenu);
            Controls.Add(imgTurn);
            Controls.Add(chbServer);
            Controls.Add(tbIPAdress);
            Controls.Add(btConnect);
            Controls.Add(pnTable);
            Name = "Caro";
            Text = "Caro";
            Load += Caro_Load;
            KeyDown += Caro_KeyDown;
            Resize += Caro_Resize;
            ((System.ComponentModel.ISupportInitialize)imgTurn).EndInit();
            pnPause.ResumeLayout(false);
            pnPause.PerformLayout();
            pnStartMenu.ResumeLayout(false);
            pnStartMenu.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)pictureBox1).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Addon_Round_Panel pnTable;
        private Button btConnect;
        private TextBox tbIPAdress;
        private CheckBox chbServer;
        private ImageList imageList1;
        private PictureBox imgTurn;
        private Addon_Custom_Button btMenu;
        private RichTextBox rtbLog;
        private Addon_Transparent_Panel pnPause;
        private Label label1;
        private Addon_Custom_Button btMenuLabel;
        private CustomLabel lbExit;
        private CustomLabel lbLeaveMatch;
        private CustomLabel lbMatchLog;
        private CustomLabel lbSettings;
        private CustomLabel lbOptions;
        private CustomLabel lbResume;
        private CustomLabel lbMenu;
        private CustomLabel lbRandom;
        private CustomLabel lbPause;
        private CustomLabel lbRestart;
        private CustomLabel randomPatternLabel;
        private System.Windows.Forms.Timer timer1;
        private Label lbTimer;
        private Addon_Custom_Button btReady;
        private CustomLabel customLabel1;
        private CustomLabel lbChangeTurn;
        private Panel pnStartMenu;
        private PictureBox pictureBox1;
        private CustomLabel lbSetting;
        private CustomLabel lbAbout;
        private CustomLabel lbHelp;
        private Addon_Custom_Button btLan;
        private Addon_Custom_Button btPlayMM;
    }
}
