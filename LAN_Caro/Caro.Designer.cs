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
            pnTable = new Lab_3.Addon_Round_Panel();
            btConnect = new Button();
            tbIPAdress = new TextBox();
            chbServer = new CheckBox();
            imageList1 = new ImageList(components);
            imgTurn = new PictureBox();
            addon_Custom_Button1 = new Lab_3.Addon_Custom_Button();
            btNewGame = new Lab_3.Addon_Custom_Button();
            button1 = new Button();
            button2 = new Button();
            richTextBox1 = new RichTextBox();
            ((System.ComponentModel.ISupportInitialize)imgTurn).BeginInit();
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
            btConnect.Click += btConnect_Click;
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
            // addon_Custom_Button1
            // 
            addon_Custom_Button1.BackColor = Color.FromArgb(213, 227, 255);
            addon_Custom_Button1.BackgroundColor = Color.FromArgb(213, 227, 255);
            addon_Custom_Button1.BorderColor = Color.PaleVioletRed;
            addon_Custom_Button1.BorderRadius = 30;
            addon_Custom_Button1.BorderSize = 0;
            addon_Custom_Button1.FlatAppearance.BorderSize = 0;
            addon_Custom_Button1.FlatStyle = FlatStyle.Flat;
            addon_Custom_Button1.Font = new Font("Segoe UI Semibold", 12F, FontStyle.Bold, GraphicsUnit.Point);
            addon_Custom_Button1.ForeColor = Color.FromArgb(0, 28, 59);
            addon_Custom_Button1.Location = new Point(34, 683);
            addon_Custom_Button1.Name = "addon_Custom_Button1";
            addon_Custom_Button1.Size = new Size(225, 60);
            addon_Custom_Button1.TabIndex = 10;
            addon_Custom_Button1.Text = "Ready";
            addon_Custom_Button1.TextColor = Color.FromArgb(0, 28, 59);
            addon_Custom_Button1.UseVisualStyleBackColor = false;
            addon_Custom_Button1.Click += addon_Custom_Button1_Click;
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
            btNewGame.Click += btNewGame_Click;
            // 
            // button1
            // 
            button1.BackColor = Color.LightGreen;
            button1.Location = new Point(102, 507);
            button1.Name = "button1";
            button1.Size = new Size(112, 34);
            button1.TabIndex = 12;
            button1.Text = "random quan co";
            button1.UseVisualStyleBackColor = false;
            button1.Click += button1_Click;
            // 
            // button2
            // 
            button2.Location = new Point(147, 400);
            button2.Name = "button2";
            button2.Size = new Size(112, 34);
            button2.TabIndex = 0;
            button2.Text = "Switch";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
            // 
            // richTextBox1
            // 
            richTextBox1.Location = new Point(29, 32);
            richTextBox1.Name = "richTextBox1";
            richTextBox1.Size = new Size(221, 256);
            richTextBox1.TabIndex = 13;
            richTextBox1.Text = "";
            richTextBox1.TextChanged += richTextBox1_TextChanged;
            // 
            // Caro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1312, 770);
            Controls.Add(richTextBox1);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(btNewGame);
            Controls.Add(addon_Custom_Button1);
            Controls.Add(imgTurn);
            Controls.Add(chbServer);
            Controls.Add(tbIPAdress);
            Controls.Add(btConnect);
            Controls.Add(pnTable);
            Name = "Caro";
            Text = "Caro";
            Load += Caro_Load;
            ((System.ComponentModel.ISupportInitialize)imgTurn).EndInit();
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Lab_3.Addon_Round_Panel pnTable;
        private Button btConnect;
        private TextBox tbIPAdress;
        private CheckBox chbServer;
        private ImageList imageList1;
        private PictureBox imgTurn;
        private Lab_3.Addon_Custom_Button addon_Custom_Button1;
        private Lab_3.Addon_Custom_Button btNewGame;
        private Button button1;
        private Button button2;
        private RichTextBox richTextBox1;
    }
}