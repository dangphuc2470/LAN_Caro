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
            btNewGamea = new Addon_Custom_Button();
            button1 = new Button();
            button2 = new Button();
            rtbLog = new RichTextBox();
            pnPause = new xPanel();
            btMenuLabel = new Addon_Custom_Button();
            btResume = new Addon_Custom_Button();
            btExitGame = new Addon_Custom_Button();
            btLeaveMatch = new Addon_Custom_Button();
            btSettings = new Addon_Custom_Button();
            btMatchLog = new Addon_Custom_Button();
            btPauseGame = new Addon_Custom_Button();
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
            btMenu.BorderRadius = 30;
            btMenu.BorderSize = 0;
            btMenu.FlatAppearance.BorderSize = 0;
            btMenu.FlatStyle = FlatStyle.Flat;
            btMenu.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btMenu.ForeColor = Color.FromArgb(0, 28, 59);
            btMenu.Location = new Point(31, 683);
            btMenu.Name = "btMenu";
            btMenu.Size = new Size(225, 60);
            btMenu.TabIndex = 10;
            btMenu.Text = "Pause";
            btMenu.TextColor = Color.FromArgb(0, 28, 59);
            btMenu.UseVisualStyleBackColor = false;
            btMenu.Click += Menu_Click;
            // 
            // btNewGamea
            // 
            btNewGamea.BackColor = Color.FromArgb(213, 227, 255);
            btNewGamea.BackgroundColor = Color.FromArgb(213, 227, 255);
            btNewGamea.BorderColor = Color.PaleVioletRed;
            btNewGamea.BorderRadius = 30;
            btNewGamea.BorderSize = 0;
            btNewGamea.FlatAppearance.BorderSize = 0;
            btNewGamea.FlatStyle = FlatStyle.Flat;
            btNewGamea.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btNewGamea.ForeColor = Color.FromArgb(0, 28, 59);
            btNewGamea.Location = new Point(25, 589);
            btNewGamea.Name = "btNewGamea";
            btNewGamea.Size = new Size(225, 60);
            btNewGamea.TabIndex = 11;
            btNewGamea.Text = "New Game";
            btNewGamea.TextColor = Color.FromArgb(0, 28, 59);
            btNewGamea.UseVisualStyleBackColor = false;
            btNewGamea.Click += NewGame_Click;
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
            rtbLog.Location = new Point(337, 95);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(760, 569);
            rtbLog.TabIndex = 13;
            rtbLog.Text = "";
            rtbLog.Visible = false;
            rtbLog.TextChanged += richTextBox1_TextChanged;
            // 
            // pnPause
            // 
            pnPause.Controls.Add(btMenuLabel);
            pnPause.Controls.Add(btResume);
            pnPause.Controls.Add(rtbLog);
            pnPause.Controls.Add(btExitGame);
            pnPause.Controls.Add(btLeaveMatch);
            pnPause.Controls.Add(btSettings);
            pnPause.Controls.Add(btMatchLog);
            pnPause.Controls.Add(btPauseGame);
            pnPause.Dock = DockStyle.Fill;
            pnPause.Location = new Point(0, 0);
            pnPause.Name = "pnPause";
            pnPause.Size = new Size(1312, 770);
            pnPause.TabIndex = 14;
            pnPause.Tag = "0";
            pnPause.Visible = false;
            // 
            // btMenuLabel
            // 
            btMenuLabel.BackColor = Color.Transparent;
            btMenuLabel.BackgroundColor = Color.Transparent;
            btMenuLabel.BorderColor = Color.PaleVioletRed;
            btMenuLabel.BorderRadius = 0;
            btMenuLabel.BorderSize = 0;
            btMenuLabel.FlatAppearance.BorderSize = 0;
            btMenuLabel.FlatStyle = FlatStyle.Flat;
            btMenuLabel.ForeColor = Color.White;
            btMenuLabel.Location = new Point(34, 95);
            btMenuLabel.Name = "btMenuLabel";
            btMenuLabel.RightToLeft = RightToLeft.No;
            btMenuLabel.Size = new Size(225, 86);
            btMenuLabel.TabIndex = 16;
            btMenuLabel.Text = "MENU";
            btMenuLabel.TextAlign = ContentAlignment.MiddleLeft;
            btMenuLabel.TextColor = Color.White;
            btMenuLabel.UseVisualStyleBackColor = false;
            btMenuLabel.Click += btMenu_Click;
            btMenuLabel.Leave += PauseButton_MouseLeave;
            btMenuLabel.MouseClick += btMenu_MouseClick;
            btMenuLabel.MouseDown += btMenu_MouseClick;
            btMenuLabel.MouseEnter += MenuButton_MouseEnter;
            btMenuLabel.MouseLeave += MenuButton_MouseLeave;
            btMenuLabel.MouseUp += btMenu_MouseClick;
            // 
            // btResume
            // 
            btResume.BackColor = Color.Transparent;
            btResume.BackgroundColor = Color.Transparent;
            btResume.BorderColor = Color.PaleVioletRed;
            btResume.BorderRadius = 0;
            btResume.BorderSize = 0;
            btResume.FlatAppearance.BorderSize = 0;
            btResume.FlatStyle = FlatStyle.Flat;
            btResume.ForeColor = Color.White;
            btResume.Location = new Point(43, 215);
            btResume.Name = "btResume";
            btResume.RightToLeft = RightToLeft.No;
            btResume.Size = new Size(225, 60);
            btResume.TabIndex = 14;
            btResume.Text = "RESUME";
            btResume.TextAlign = ContentAlignment.MiddleLeft;
            btResume.TextColor = Color.White;
            btResume.UseVisualStyleBackColor = false;
            btResume.Click += btResume_Click;
            btResume.MouseEnter += PauseButton_MouseEnter;
            btResume.MouseLeave += PauseButton_MouseLeave;
            // 
            // btExitGame
            // 
            btExitGame.BackColor = Color.Transparent;
            btExitGame.BackgroundColor = Color.Transparent;
            btExitGame.BorderColor = Color.PaleVioletRed;
            btExitGame.BorderRadius = 0;
            btExitGame.BorderSize = 0;
            btExitGame.FlatAppearance.BorderSize = 0;
            btExitGame.FlatStyle = FlatStyle.Flat;
            btExitGame.ForeColor = Color.White;
            btExitGame.Location = new Point(43, 540);
            btExitGame.Name = "btExitGame";
            btExitGame.Size = new Size(298, 60);
            btExitGame.TabIndex = 4;
            btExitGame.Text = "EXIT TO DESKTOP";
            btExitGame.TextAlign = ContentAlignment.MiddleLeft;
            btExitGame.TextColor = Color.White;
            btExitGame.UseVisualStyleBackColor = false;
            btExitGame.MouseEnter += PauseButton_MouseEnter;
            btExitGame.MouseLeave += PauseButton_MouseLeave;
            // 
            // btLeaveMatch
            // 
            btLeaveMatch.BackColor = Color.Transparent;
            btLeaveMatch.BackgroundColor = Color.Transparent;
            btLeaveMatch.BorderColor = Color.PaleVioletRed;
            btLeaveMatch.BorderRadius = 0;
            btLeaveMatch.BorderSize = 0;
            btLeaveMatch.FlatAppearance.BorderSize = 0;
            btLeaveMatch.FlatStyle = FlatStyle.Flat;
            btLeaveMatch.ForeColor = Color.White;
            btLeaveMatch.Location = new Point(43, 475);
            btLeaveMatch.Name = "btLeaveMatch";
            btLeaveMatch.Size = new Size(225, 60);
            btLeaveMatch.TabIndex = 3;
            btLeaveMatch.Text = "LEAVE MATCH";
            btLeaveMatch.TextAlign = ContentAlignment.MiddleLeft;
            btLeaveMatch.TextColor = Color.White;
            btLeaveMatch.UseVisualStyleBackColor = false;
            btLeaveMatch.MouseEnter += PauseButton_MouseEnter;
            btLeaveMatch.MouseLeave += PauseButton_MouseLeave;
            // 
            // btSettings
            // 
            btSettings.BackColor = Color.Transparent;
            btSettings.BackgroundColor = Color.Transparent;
            btSettings.BorderColor = Color.PaleVioletRed;
            btSettings.BorderRadius = 0;
            btSettings.BorderSize = 0;
            btSettings.FlatAppearance.BorderSize = 0;
            btSettings.FlatStyle = FlatStyle.Flat;
            btSettings.ForeColor = Color.White;
            btSettings.Location = new Point(43, 345);
            btSettings.Name = "btSettings";
            btSettings.Size = new Size(225, 60);
            btSettings.TabIndex = 2;
            btSettings.Text = "SETTINGS";
            btSettings.TextAlign = ContentAlignment.MiddleLeft;
            btSettings.TextColor = Color.White;
            btSettings.UseVisualStyleBackColor = false;
            btSettings.MouseEnter += PauseButton_MouseEnter;
            btSettings.MouseLeave += PauseButton_MouseLeave;
            // 
            // btMatchLog
            // 
            btMatchLog.BackColor = Color.Transparent;
            btMatchLog.BackgroundColor = Color.Transparent;
            btMatchLog.BorderColor = Color.PaleVioletRed;
            btMatchLog.BorderRadius = 0;
            btMatchLog.BorderSize = 0;
            btMatchLog.FlatAppearance.BorderSize = 0;
            btMatchLog.FlatStyle = FlatStyle.Flat;
            btMatchLog.ForeColor = Color.White;
            btMatchLog.Location = new Point(43, 410);
            btMatchLog.Name = "btMatchLog";
            btMatchLog.Size = new Size(225, 60);
            btMatchLog.TabIndex = 1;
            btMatchLog.Text = "MATCH LOG";
            btMatchLog.TextAlign = ContentAlignment.MiddleLeft;
            btMatchLog.TextColor = Color.White;
            btMatchLog.UseVisualStyleBackColor = false;
            btMatchLog.Click += btMatchLog_Click;
            btMatchLog.MouseEnter += PauseButton_MouseEnter;
            btMatchLog.MouseLeave += PauseButton_MouseLeave;
            // 
            // btPauseGame
            // 
            btPauseGame.BackColor = Color.Transparent;
            btPauseGame.BackgroundColor = Color.Transparent;
            btPauseGame.BorderColor = Color.PaleVioletRed;
            btPauseGame.BorderRadius = 0;
            btPauseGame.BorderSize = 0;
            btPauseGame.FlatAppearance.BorderSize = 0;
            btPauseGame.FlatStyle = FlatStyle.Flat;
            btPauseGame.ForeColor = Color.White;
            btPauseGame.Location = new Point(43, 280);
            btPauseGame.Name = "btPauseGame";
            btPauseGame.RightToLeft = RightToLeft.No;
            btPauseGame.Size = new Size(225, 60);
            btPauseGame.TabIndex = 0;
            btPauseGame.Text = "PAUSE GAME";
            btPauseGame.TextAlign = ContentAlignment.MiddleLeft;
            btPauseGame.TextColor = Color.White;
            btPauseGame.UseVisualStyleBackColor = false;
            btPauseGame.Click += btPause_Click;
            btPauseGame.MouseEnter += PauseButton_MouseEnter;
            btPauseGame.MouseLeave += PauseButton_MouseLeave;
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
            Controls.Add(btNewGamea);
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
        private Addon_Custom_Button btNewGamea;
        private Button button1;
        private Button button2;
        private RichTextBox rtbLog;
        private xPanel pnPause;
        private Label label1;
        private Addon_Custom_Button btPauseGame;
        private Addon_Custom_Button btMatchLog;
        private Addon_Custom_Button btSettings;
        private Addon_Custom_Button btExitGame;
        private Addon_Custom_Button btLeaveMatch;
        private Addon_Custom_Button btResume;
        private Addon_Custom_Button btMenuLabel;
    }
}
