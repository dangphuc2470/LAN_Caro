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
            btPause = new Round_Button();
            btNewGame = new Round_Button();
            button1 = new Button();
            button2 = new Button();
            rtbLog = new RichTextBox();
            panel1 = new xPanel();
            button3 = new Button();
            ((System.ComponentModel.ISupportInitialize)imgTurn).BeginInit();
            panel1.SuspendLayout();
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
            // btPause
            // 
            btPause.BackColor = Color.FromArgb(213, 227, 255);
            btPause.BackgroundColor = Color.FromArgb(213, 227, 255);
            btPause.BorderColor = Color.PaleVioletRed;
            btPause.BorderRadius = 30;
            btPause.BorderSize = 0;
            btPause.FlatAppearance.BorderSize = 0;
            btPause.FlatStyle = FlatStyle.Flat;
            btPause.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btPause.ForeColor = Color.FromArgb(0, 28, 59);
            btPause.Location = new Point(34, 683);
            btPause.Name = "btPause";
            btPause.Size = new Size(225, 60);
            btPause.TabIndex = 10;
            btPause.Text = "Pause";
            btPause.TextColor = Color.FromArgb(0, 28, 59);
            btPause.UseVisualStyleBackColor = false;
            btPause.Click += Pause_Click;
            // 
            // btNewGame
            // 
            btNewGame.BackColor = Color.FromArgb(213, 227, 255);
            btNewGame.BackgroundColor = Color.FromArgb(213, 227, 255);
            btNewGame.BorderColor = Color.PaleVioletRed;
            btNewGame.BorderRadius = 30;
            btNewGame.BorderSize = 0;
            btNewGame.FlatAppearance.BorderSize = 0;
            btNewGame.FlatStyle = FlatStyle.Flat;
            btNewGame.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            btNewGame.ForeColor = Color.FromArgb(0, 28, 59);
            btNewGame.Location = new Point(25, 589);
            btNewGame.Name = "btNewGame";
            btNewGame.Size = new Size(225, 60);
            btNewGame.TabIndex = 11;
            btNewGame.Text = "New Game";
            btNewGame.TextColor = Color.FromArgb(0, 28, 59);
            btNewGame.UseVisualStyleBackColor = false;
            btNewGame.Click += NewGame_Click;
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
            button2.Name = "btSwitch";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 0;
            button2.Text = "Switch";
            button2.UseVisualStyleBackColor = true;
            button2.Click += SwitchPlayer_Click;
            // 
            // rtbLog
            // 
            rtbLog.BorderStyle = BorderStyle.None;
            rtbLog.Location = new Point(25, 32);
            rtbLog.Name = "rtbLog";
            rtbLog.Size = new Size(221, 256);
            rtbLog.TabIndex = 13;
            rtbLog.Text = "";
            rtbLog.TextChanged += richTextBox1_TextChanged;
            // 
            // panel1
            // 
            panel1.Controls.Add(button3);
            panel1.Location = new Point(0, 0);
            panel1.Name = "panel1";
            panel1.Size = new Size(12, 15);
            panel1.TabIndex = 14;
            panel1.Visible = false;
            // 
            // button3
            // 
            button3.Location = new Point(5, 41);
            button3.Name = "button3";
            button3.Size = new Size(27, 34);
            button3.TabIndex = 0;
            button3.Text = "button3";
            button3.UseVisualStyleBackColor = true;
            // 
            // Caro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1312, 770);
            Controls.Add(panel1);
            Controls.Add(rtbLog);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btNewGame);
            Controls.Add(btPause);
            Controls.Add(imgTurn);
            Controls.Add(chbServer);
            Controls.Add(tbIPAdress);
            Controls.Add(btConnect);
            Controls.Add(pnTable);
            Name = "Caro";
            Text = "Caro";
            Load += Caro_Load;
            ((System.ComponentModel.ISupportInitialize)imgTurn).EndInit();
            panel1.ResumeLayout(false);
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
        private Lab_3.Addon_Custom_Button btPause;
        private Lab_3.Addon_Custom_Button btNewGame;
        private Button button1;
        private Button button2;
        private RichTextBox rtbLog;
        private xPanel pnPause;
        private Label label1;
    }
}