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
            lbStatus = new Label();
            imgTurn = new PictureBox();
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
            btConnect.Location = new Point(73, 379);
            btConnect.Name = "btConnect";
            btConnect.Size = new Size(112, 34);
            btConnect.TabIndex = 3;
            btConnect.Text = "Connect";
            btConnect.UseVisualStyleBackColor = true;
            btConnect.Click += btConnect_Click;
            // 
            // tbIPAdress
            // 
            tbIPAdress.Location = new Point(53, 101);
            tbIPAdress.Name = "tbIPAdress";
            tbIPAdress.Size = new Size(150, 31);
            tbIPAdress.TabIndex = 4;
            // 
            // chbServer
            // 
            chbServer.AutoSize = true;
            chbServer.Checked = true;
            chbServer.CheckState = CheckState.Checked;
            chbServer.Location = new Point(86, 432);
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
            // lbStatus
            // 
            lbStatus.AutoSize = true;
            lbStatus.Location = new Point(43, 16);
            lbStatus.Name = "lbStatus";
            lbStatus.Size = new Size(59, 25);
            lbStatus.TabIndex = 8;
            lbStatus.Text = "label1";
            // 
            // imgTurn
            // 
            imgTurn.Image = Properties.Resources.x;
            imgTurn.ImageLocation = "";
            imgTurn.InitialImage = null;
            imgTurn.Location = new Point(43, 186);
            imgTurn.Name = "imgTurn";
            imgTurn.Size = new Size(34, 35);
            imgTurn.TabIndex = 9;
            imgTurn.TabStop = false;
            // 
            // Caro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1312, 770);
            Controls.Add(imgTurn);
            Controls.Add(lbStatus);
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
        private Label lbStatus;
        private PictureBox imgTurn;
    }
}