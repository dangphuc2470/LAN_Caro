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
            pnPause2 = new Addon_Transparent_Panel();
            lbChangeTurn = new CustomLabel();
            lbRandom = new CustomLabel();
            lbPause = new CustomLabel();
            lbRestart = new CustomLabel();
            rtbLog = new RichTextBox();
            tbIPAdress = new TextBox();
            imageList1 = new ImageList(components);
            imgTurn = new PictureBox();
            btShowPausePanel = new Addon_Custom_Button();
            lbExit = new CustomLabel();
            lbLeaveMatch = new CustomLabel();
            lbMatchLog = new CustomLabel();
            lbSettings = new CustomLabel();
            lbOptions = new CustomLabel();
            lbResume = new CustomLabel();
            lbMenu = new CustomLabel();
            btReady = new Addon_Custom_Button();
            pnPause1 = new Panel();
            timer = new System.Windows.Forms.Timer(components);
            ptbBackgroundTimer = new PictureBox();
            lbTimer = new CustomLabel();
            lblllMinSecond = new CustomLabel();
            btHost = new Addon_Custom_Button();
            btClient = new Addon_Custom_Button();
            lblllChooseRole = new Label();
            pnIPAddress = new Panel();
            labelShowOrInput = new Label();
            panel3 = new Panel();
            cbbIP = new CustomComboBox();
            pnPause2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgTurn).BeginInit();
            pnPause1.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBackgroundTimer).BeginInit();
            pnIPAddress.SuspendLayout();
            SuspendLayout();
            // 
            // pnTable
            // 
            pnTable.AutoScroll = true;
            pnTable.BackColor = Color.Transparent;
            pnTable.BackgroundImageLayout = ImageLayout.Stretch;
            pnTable.CornerRadius = 25;
            pnTable.Location = new Point(458, 86);
            pnTable.Name = "pnTable";
            pnTable.Size = new Size(960, 680);
            pnTable.TabIndex = 0;
            // 
            // pnPause2
            // 
            pnPause2.Controls.Add(lbChangeTurn);
            pnPause2.Controls.Add(lbRandom);
            pnPause2.Controls.Add(lbPause);
            pnPause2.Controls.Add(lbRestart);
            pnPause2.Controls.Add(rtbLog);
            pnPause2.Dock = DockStyle.Right;
            pnPause2.Location = new Point(1169, 0);
            pnPause2.Name = "pnPause2";
            pnPause2.Size = new Size(311, 788);
            pnPause2.TabIndex = 14;
            pnPause2.Tag = "0";
            pnPause2.Visible = false;
            pnPause2.VisibleChanged += pnPause_VisibleChanged;
            // 
            // lbChangeTurn
            // 
            lbChangeTurn.AutoSize = true;
            lbChangeTurn.BackColor = Color.Transparent;
            lbChangeTurn.ForeColor = Color.White;
            lbChangeTurn.Location = new Point(30, 440);
            lbChangeTurn.Name = "lbChangeTurn";
            lbChangeTurn.Size = new Size(219, 25);
            lbChangeTurn.TabIndex = 26;
            lbChangeTurn.Text = "CHANGE TURN (FOR DEV)";
            lbChangeTurn.Visible = false;
            lbChangeTurn.Click += lbChangeTurn_Click;
            // 
            // lbRandom
            // 
            lbRandom.AutoSize = true;
            lbRandom.BackColor = Color.Transparent;
            lbRandom.ForeColor = Color.White;
            lbRandom.Location = new Point(30, 373);
            lbRandom.Name = "lbRandom";
            lbRandom.Size = new Size(254, 25);
            lbRandom.TabIndex = 24;
            lbRandom.Text = "RANDOM PATTERN (FOR DEV)";
            lbRandom.Visible = false;
            lbRandom.Click += lbRandom_Click;
            // 
            // lbPause
            // 
            lbPause.AutoSize = true;
            lbPause.BackColor = Color.Transparent;
            lbPause.ForeColor = Color.White;
            lbPause.Location = new Point(30, 300);
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
            lbRestart.Location = new Point(30, 230);
            lbRestart.Name = "lbRestart";
            lbRestart.Size = new Size(81, 25);
            lbRestart.TabIndex = 22;
            lbRestart.Text = "RESTART";
            lbRestart.Visible = false;
            lbRestart.VisibleChanged += lbRestart_VisibleChanged;
            lbRestart.Click += lbRestart_Click;
            // 
            // rtbLog
            // 
            rtbLog.BackColor = Color.FromArgb(70, 71, 74);
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Font = new Font("Segoe UI", 12F, FontStyle.Regular, GraphicsUnit.Point);
            rtbLog.ForeColor = Color.Transparent;
            rtbLog.Location = new Point(-2, 54);
            rtbLog.Name = "rtbLog";
            rtbLog.ReadOnly = true;
            rtbLog.Size = new Size(960, 680);
            rtbLog.TabIndex = 13;
            rtbLog.Text = "";
            rtbLog.Visible = false;
            rtbLog.TextChanged += richTextBox1_TextChanged;
            // 
            // tbIPAdress
            // 
            tbIPAdress.AutoCompleteCustomSource.AddRange(new string[] { "127.0.0.1" });
            tbIPAdress.BackColor = Color.FromArgb(45, 51, 73);
            tbIPAdress.BorderStyle = BorderStyle.None;
            tbIPAdress.Font = new Font("Impact", 14F, FontStyle.Bold, GraphicsUnit.Point);
            tbIPAdress.ForeColor = Color.White;
            tbIPAdress.Location = new Point(34, 83);
            tbIPAdress.Name = "tbIPAdress";
            tbIPAdress.Size = new Size(230, 35);
            tbIPAdress.TabIndex = 4;
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
            imgTurn.Location = new Point(328, 343);
            imgTurn.Name = "imgTurn";
            imgTurn.Size = new Size(69, 55);
            imgTurn.SizeMode = PictureBoxSizeMode.Zoom;
            imgTurn.TabIndex = 9;
            imgTurn.TabStop = false;
            // 
            // btShowPausePanel
            // 
            btShowPausePanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btShowPausePanel.BackColor = Color.Transparent;
            btShowPausePanel.BackgroundColor = Color.Transparent;
            btShowPausePanel.BackgroundImageLayout = ImageLayout.Stretch;
            btShowPausePanel.BorderColor = Color.PaleVioletRed;
            btShowPausePanel.BorderRadius = 0;
            btShowPausePanel.BorderSize = 0;
            btShowPausePanel.FlatAppearance.BorderSize = 0;
            btShowPausePanel.FlatStyle = FlatStyle.Flat;
            btShowPausePanel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btShowPausePanel.ForeColor = Color.FromArgb(0, 28, 59);
            btShowPausePanel.Image = Properties.Resources.icons8_settings_24;
            btShowPausePanel.Location = new Point(-8, 126);
            btShowPausePanel.Name = "btShowPausePanel";
            btShowPausePanel.Size = new Size(83, 73);
            btShowPausePanel.TabIndex = 5;
            btShowPausePanel.TextColor = Color.FromArgb(0, 28, 59);
            btShowPausePanel.UseVisualStyleBackColor = false;
            btShowPausePanel.Click += ShowPausePanel_Click;
            // 
            // lbExit
            // 
            lbExit.AutoSize = true;
            lbExit.BackColor = Color.Transparent;
            lbExit.ForeColor = Color.White;
            lbExit.Location = new Point(105, 588);
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
            lbLeaveMatch.Location = new Point(105, 518);
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
            lbMatchLog.Location = new Point(105, 448);
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
            lbSettings.Location = new Point(105, 378);
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
            lbOptions.Location = new Point(105, 308);
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
            lbResume.Location = new Point(105, 238);
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
            lbMenu.Location = new Point(94, 128);
            lbMenu.Name = "lbMenu";
            lbMenu.Size = new Size(62, 25);
            lbMenu.TabIndex = 15;
            lbMenu.Text = "MENU";
            // 
            // btReady
            // 
            btReady.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btReady.BackColor = Color.FromArgb(213, 227, 255);
            btReady.BackgroundColor = Color.FromArgb(213, 227, 255);
            btReady.BackgroundImage = Properties.Resources.Picsart_23_06_13_09_08_41_819;
            btReady.BackgroundImageLayout = ImageLayout.Stretch;
            btReady.BorderColor = Color.White;
            btReady.BorderRadius = 4;
            btReady.BorderSize = 1;
            btReady.FlatAppearance.BorderSize = 0;
            btReady.FlatStyle = FlatStyle.Flat;
            btReady.Font = new Font("Impact", 25F, FontStyle.Regular, GraphicsUnit.Point);
            btReady.ForeColor = Color.Silver;
            btReady.Location = new Point(12, 598);
            btReady.Name = "btReady";
            btReady.Size = new Size(329, 86);
            btReady.TabIndex = 17;
            btReady.Tag = 0;
            btReady.Text = "READY";
            btReady.TextColor = Color.Silver;
            btReady.UseVisualStyleBackColor = false;
            btReady.Click += btReady_Click;
            btReady.MouseHover += btReady_MouseHover;
            // 
            // pnPause1
            // 
            pnPause1.BackColor = Color.FromArgb(180, 0, 0, 0);
            pnPause1.Controls.Add(lbMenu);
            pnPause1.Controls.Add(lbResume);
            pnPause1.Controls.Add(lbOptions);
            pnPause1.Controls.Add(lbSettings);
            pnPause1.Controls.Add(lbMatchLog);
            pnPause1.Controls.Add(lbLeaveMatch);
            pnPause1.Controls.Add(lbExit);
            pnPause1.Location = new Point(0, 778);
            pnPause1.Name = "pnPause1";
            pnPause1.Size = new Size(452, 10);
            pnPause1.TabIndex = 19;
            pnPause1.Visible = false;
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
            // 
            // ptbBackgroundTimer
            // 
            ptbBackgroundTimer.BackColor = Color.Transparent;
            ptbBackgroundTimer.BackgroundImageLayout = ImageLayout.Zoom;
            ptbBackgroundTimer.Image = Properties.Resources.Picsart_23_06_12_21_54_09_715;
            ptbBackgroundTimer.Location = new Point(0, 0);
            ptbBackgroundTimer.Name = "ptbBackgroundTimer";
            ptbBackgroundTimer.Size = new Size(378, 125);
            ptbBackgroundTimer.SizeMode = PictureBoxSizeMode.StretchImage;
            ptbBackgroundTimer.TabIndex = 25;
            ptbBackgroundTimer.TabStop = false;
            // 
            // lbTimer
            // 
            lbTimer.AutoSize = true;
            lbTimer.BackColor = Color.Transparent;
            lbTimer.ForeColor = Color.FromArgb(253, 247, 250);
            lbTimer.Location = new Point(136, 17);
            lbTimer.Name = "lbTimer";
            lbTimer.Size = new Size(46, 25);
            lbTimer.TabIndex = 26;
            lbTimer.Text = "1:00";
            // 
            // lblllMinSecond
            // 
            lblllMinSecond.AutoSize = true;
            lblllMinSecond.BackColor = Color.Transparent;
            lblllMinSecond.ForeColor = Color.FromArgb(253, 247, 250);
            lblllMinSecond.Location = new Point(135, 86);
            lblllMinSecond.Name = "lblllMinSecond";
            lblllMinSecond.Size = new Size(131, 25);
            lblllMinSecond.TabIndex = 27;
            lblllMinSecond.Text = "MIN           SEC";
            // 
            // btHost
            // 
            btHost.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btHost.BackColor = Color.MediumSlateBlue;
            btHost.BackgroundColor = Color.MediumSlateBlue;
            btHost.BackgroundImage = Properties.Resources.Picsart_23_06_12_22_28_22_579;
            btHost.BackgroundImageLayout = ImageLayout.Stretch;
            btHost.BorderColor = Color.White;
            btHost.BorderRadius = 4;
            btHost.BorderSize = 1;
            btHost.FlatAppearance.BorderSize = 0;
            btHost.FlatStyle = FlatStyle.Flat;
            btHost.Font = new Font("Impact", 25F, FontStyle.Regular, GraphicsUnit.Point);
            btHost.ForeColor = Color.White;
            btHost.Location = new Point(12, 690);
            btHost.Name = "btHost";
            btHost.Size = new Size(329, 86);
            btHost.TabIndex = 28;
            btHost.Text = "HOST";
            btHost.TextColor = Color.White;
            btHost.UseVisualStyleBackColor = false;
            btHost.Click += btHost_Click;
            // 
            // btClient
            // 
            btClient.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btClient.BackColor = Color.MediumSlateBlue;
            btClient.BackgroundColor = Color.MediumSlateBlue;
            btClient.BackgroundImage = Properties.Resources.Picsart_23_06_12_22_28_37_117;
            btClient.BackgroundImageLayout = ImageLayout.Stretch;
            btClient.BorderColor = Color.White;
            btClient.BorderRadius = 4;
            btClient.BorderSize = 1;
            btClient.FlatAppearance.BorderSize = 0;
            btClient.FlatStyle = FlatStyle.Flat;
            btClient.Font = new Font("Impact", 25F, FontStyle.Regular, GraphicsUnit.Point);
            btClient.ForeColor = Color.White;
            btClient.Location = new Point(12, 598);
            btClient.Name = "btClient";
            btClient.Size = new Size(329, 86);
            btClient.TabIndex = 29;
            btClient.Text = "CLIENT";
            btClient.TextColor = Color.White;
            btClient.UseVisualStyleBackColor = false;
            btClient.Click += btClient_Click;
            // 
            // lblllChooseRole
            // 
            lblllChooseRole.AutoSize = true;
            lblllChooseRole.BackColor = Color.Transparent;
            lblllChooseRole.Font = new Font("Impact", 15F, FontStyle.Regular, GraphicsUnit.Point);
            lblllChooseRole.ForeColor = Color.Black;
            lblllChooseRole.Location = new Point(12, 546);
            lblllChooseRole.Name = "lblllChooseRole";
            lblllChooseRole.Size = new Size(244, 37);
            lblllChooseRole.TabIndex = 30;
            lblllChooseRole.Text = "CHOOSE YOUR ROLE:";
            // 
            // pnIPAddress
            // 
            pnIPAddress.BackColor = Color.Transparent;
            pnIPAddress.BackgroundImage = Properties.Resources.Picsart_23_06_13_07_51_33_967;
            pnIPAddress.BackgroundImageLayout = ImageLayout.Stretch;
            pnIPAddress.Controls.Add(labelShowOrInput);
            pnIPAddress.Controls.Add(panel3);
            pnIPAddress.Controls.Add(tbIPAdress);
            pnIPAddress.Controls.Add(cbbIP);
            pnIPAddress.Location = new Point(350, -76);
            pnIPAddress.Name = "pnIPAddress";
            pnIPAddress.Size = new Size(340, 150);
            pnIPAddress.TabIndex = 31;
            // 
            // labelShowOrInput
            // 
            labelShowOrInput.AutoSize = true;
            labelShowOrInput.Font = new Font("Impact", 7F, FontStyle.Italic, GraphicsUnit.Point);
            labelShowOrInput.ForeColor = Color.White;
            labelShowOrInput.Location = new Point(11, 127);
            labelShowOrInput.Name = "labelShowOrInput";
            labelShowOrInput.Size = new Size(139, 18);
            labelShowOrInput.TabIndex = 6;
            labelShowOrInput.Text = "Enter server IP address";
            // 
            // panel3
            // 
            panel3.BackColor = Color.Silver;
            panel3.Location = new Point(34, 120);
            panel3.Name = "panel3";
            panel3.Size = new Size(230, 1);
            panel3.TabIndex = 5;
            // 
            // cbbIP
            // 
            cbbIP.BackColor = Color.FromArgb(45, 51, 73);
            cbbIP.FlatStyle = FlatStyle.Flat;
            cbbIP.ForeColor = Color.White;
            cbbIP.FormattingEnabled = true;
            cbbIP.Location = new Point(34, 85);
            cbbIP.Name = "cbbIP";
            cbbIP.Size = new Size(258, 33);
            cbbIP.TabIndex = 0;
            cbbIP.SelectionChangeCommitted += cbbIP_SelectionChangeCommitted;
            // 
            // Caro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            BackgroundImage = Properties.Resources.Picsart_23_06_07_08_41_09_453;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1480, 788);
            Controls.Add(lbTimer);
            Controls.Add(lblllMinSecond);
            Controls.Add(pnPause2);
            Controls.Add(pnPause1);
            Controls.Add(btShowPausePanel);
            Controls.Add(imgTurn);
            Controls.Add(pnTable);
            Controls.Add(btHost);
            Controls.Add(btClient);
            Controls.Add(lblllChooseRole);
            Controls.Add(pnIPAddress);
            Controls.Add(ptbBackgroundTimer);
            Controls.Add(btReady);
            DoubleBuffered = true;
            Name = "Caro";
            Text = " ";
            Load += Caro_Load;
            pnPause2.ResumeLayout(false);
            pnPause2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgTurn).EndInit();
            pnPause1.ResumeLayout(false);
            pnPause1.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)ptbBackgroundTimer).EndInit();
            pnIPAddress.ResumeLayout(false);
            pnIPAddress.PerformLayout();
            ResumeLayout(false);
            PerformLayout();
        }


        #endregion

        private Addon_Round_Panel pnTable;
        private TextBox tbIPAdress;
        private ImageList imageList1;
        private PictureBox imgTurn;
        private Addon_Custom_Button btShowPausePanel;
        private RichTextBox rtbLog;
        private Addon_Transparent_Panel pnPause2;
        private Addon_Custom_Button btShowPausePanelLabel;
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
        private System.Windows.Forms.Timer timer1;
        private Addon_Custom_Button btReady;
        private CustomLabel lbChangeTurn;
        private Panel panel1;
        private CustomLabel customLabel1;
        private CustomLabel customLabel7;
        private CustomLabel customLabel2;
        private CustomLabel customLabel6;
        private CustomLabel customLabel3;
        private CustomLabel customLabel5;
        private CustomLabel customLabel4;
        private Panel pnPause1;
        private Label lbTimer2;
        private System.Windows.Forms.Timer timer;
        private PictureBox ptbBackgroundTimer;
        private CustomLabel lbTimer;
        private CustomLabel lblllMinSecond;
        private Addon_Custom_Button btHost;
        private Addon_Custom_Button btClient;
        private Label lblllChooseRole;
        private Panel pnIPAddress;
        private CustomComboBox cbbIP;
        private Panel panel3;
        private Label labelShowOrInput;
    }
}
