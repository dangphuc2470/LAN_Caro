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
            button1 = new Button();
            button2 = new Button();
            rtbLog = new RichTextBox();
            pnPause = new Addon_Transparent_Panel();
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
            ((System.ComponentModel.ISupportInitialize)imgTurn).BeginInit();
            pnPause.SuspendLayout();
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
            imgTurn.Size = new Size(34, 35);
            imgTurn.TabIndex = 9;
            imgTurn.TabStop = false;
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
            btMenu.Location = new Point(31, 683);
            btMenu.Name = "btMenu";
            btMenu.Size = new Size(60, 60);
            btMenu.TabIndex = 10;
            btMenu.TextColor = Color.FromArgb(0, 28, 59);
            btMenu.UseVisualStyleBackColor = false;
            btMenu.Click += Menu_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.MediumVioletRed;
            button1.Location = new Point(34, 506);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 12;
            button1.Text = "random quan co";
            button1.UseVisualStyleBackColor = false;
            button1.Click += RandomPattern_Click;
            // 
            // button2
            // 
            button2.Location = new Point(147, 400);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 0;
            button2.Text = "Switch";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SwitchPlayer_Click;
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
            pnPause.Dock = DockStyle.Fill;
            pnPause.Location = new Point(0, 0);
            pnPause.Name = "pnPause";
            pnPause.Size = new Size(1312, 770);
            pnPause.TabIndex = 14;
            pnPause.Tag = "0";
            pnPause.Visible = false;
            // 
            // lbRandom
            // 
            lbRandom.AutoSize = true;
            lbRandom.BackColor = Color.Transparent;
            lbRandom.ForeColor = Color.White;
            lbRandom.Location = new Point(320, 363);
            lbRandom.Name = "lbRandom";
            lbRandom.Size = new Size(330, 25);
            lbRandom.TabIndex = 24;
            lbRandom.Text = "RANDOM PATTERN (TESTING PURPOSE)";
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
            // Caro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1312, 770);
            Controls.Add(pnPause);
            Controls.Add(button2);
            Controls.Add(button1);
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
            ((System.ComponentModel.ISupportInitialize)imgTurn).EndInit();
            pnPause.ResumeLayout(false);
            pnPause.PerformLayout();
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
        private Button button1;
        private Button button2;
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
    }
}
