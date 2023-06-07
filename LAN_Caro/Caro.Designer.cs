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
            btConnect = new Button();
            tbIPAdress = new TextBox();
            chbServer = new CheckBox();
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
            lbTimer = new Label();
            timer = new System.Windows.Forms.Timer(components);
            pnPause2.SuspendLayout();
            ((System.ComponentModel.ISupportInitialize)imgTurn).BeginInit();
            pnPause1.SuspendLayout();
            SuspendLayout();
            // 
            // pnTable
            // 
            pnTable.AutoScroll = true;
            pnTable.BackColor = Color.Transparent;
            pnTable.BackgroundImageLayout = ImageLayout.Stretch;
            pnTable.CornerRadius = 25;
            pnTable.Location = new Point(453, 54);
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
            pnPause2.Location = new Point(458, 0);
            pnPause2.Name = "pnPause2";
            pnPause2.Size = new Size(1022, 788);
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
            // 
            // btShowPausePanel
            // 
            btShowPausePanel.Anchor = AnchorStyles.Bottom | AnchorStyles.Left;
            btShowPausePanel.BackColor = Color.FromArgb(213, 227, 255);
            btShowPausePanel.BackgroundColor = Color.FromArgb(213, 227, 255);
            btShowPausePanel.BorderColor = Color.PaleVioletRed;
            btShowPausePanel.BorderRadius = 20;
            btShowPausePanel.BorderSize = 0;
            btShowPausePanel.FlatAppearance.BorderSize = 0;
            btShowPausePanel.FlatStyle = FlatStyle.Flat;
            btShowPausePanel.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btShowPausePanel.ForeColor = Color.FromArgb(0, 28, 59);
            btShowPausePanel.Image = Properties.Resources.icons8_settings_24;
            btShowPausePanel.Location = new Point(9, 700);
            btShowPausePanel.Name = "btShowPausePanel";
            btShowPausePanel.Size = new Size(60, 60);
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
            lbExit.Location = new Point(54, 580);
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
            lbLeaveMatch.Location = new Point(54, 510);
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
            lbMatchLog.Location = new Point(54, 440);
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
            lbSettings.Location = new Point(54, 370);
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
            lbOptions.Location = new Point(54, 300);
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
            lbResume.Location = new Point(54, 230);
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
            lbMenu.Location = new Point(43, 120);
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
            pnPause1.Location = new Point(0, 486);
            pnPause1.Name = "pnPause1";
            pnPause1.Size = new Size(452, 302);
            pnPause1.TabIndex = 19;
            pnPause1.Visible = false;
            // 
            // lbTimer
            // 
            lbTimer.AutoSize = true;
            lbTimer.BackColor = Color.Transparent;
            lbTimer.Font = new Font("Impact", 20F, FontStyle.Bold, GraphicsUnit.Point);
            lbTimer.ForeColor = Color.Gray;
            lbTimer.Location = new Point(74, 105);
            lbTimer.Name = "lbTimer";
            lbTimer.Size = new Size(89, 48);
            lbTimer.TabIndex = 20;
            lbTimer.Text = "1:00";
            // 
            // timer
            // 
            timer.Interval = 1000;
            timer.Tick += timer_Tick;
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
            Controls.Add(pnPause2);
            Controls.Add(pnPause1);
            Controls.Add(btReady);
            Controls.Add(btShowPausePanel);
            Controls.Add(imgTurn);
            Controls.Add(chbServer);
            Controls.Add(tbIPAdress);
            Controls.Add(btConnect);
            Controls.Add(pnTable);
            DoubleBuffered = true;
            Name = "Caro";
            Text = " ";
            Load += Caro_Load;
            pnPause2.ResumeLayout(false);
            pnPause2.PerformLayout();
            ((System.ComponentModel.ISupportInitialize)imgTurn).EndInit();
            pnPause1.ResumeLayout(false);
            pnPause1.PerformLayout();
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
        private Label lbTimer;
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
    }
}
