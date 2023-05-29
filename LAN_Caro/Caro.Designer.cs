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
            button1 = new Button();
            button2 = new Button();
            btConnect = new Button();
            tbIPAdress = new TextBox();
            chbServer = new CheckBox();
            tbData = new TextBox();
            btSend = new Button();
            imageList1 = new ImageList(components);
            lbStatus = new Label();
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
            // button1
            // 
            button1.FlatStyle = FlatStyle.Flat;
            button1.ForeColor = SystemColors.ActiveCaptionText;
            button1.Image = Properties.Resources.o;
            button1.Location = new Point(28, 260);
            button1.Name = "button1";
            button1.Size = new Size(40, 40);
            button1.TabIndex = 1;
            button1.UseVisualStyleBackColor = true;
            // 
            // button2
            // 
            button2.Location = new Point(86, 310);
            button2.Name = "button2";
            button2.Size = new Size(152, 34);
            button2.TabIndex = 2;
            button2.Text = "Switch player";
            button2.UseVisualStyleBackColor = true;
            button2.Click += button2_Click;
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
            // 
            // tbData
            // 
            tbData.Location = new Point(53, 528);
            tbData.Name = "tbData";
            tbData.Size = new Size(150, 31);
            tbData.TabIndex = 6;
            // 
            // btSend
            // 
            btSend.Location = new Point(91, 585);
            btSend.Name = "btSend";
            btSend.Size = new Size(112, 34);
            btSend.TabIndex = 7;
            btSend.Text = "Send";
            btSend.UseVisualStyleBackColor = true;
            btSend.Click += btSend_Click;
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
            // Caro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1312, 770);
            Controls.Add(lbStatus);
            Controls.Add(btSend);
            Controls.Add(tbData);
            Controls.Add(chbServer);
            Controls.Add(tbIPAdress);
            Controls.Add(btConnect);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pnTable);
            Name = "Caro";
            Text = "Caro";
            Load += Caro_Load;
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Lab_3.Addon_Round_Panel pnTable;
        private Button button1;
        private Button button2;
        private Button btConnect;
        private TextBox tbIPAdress;
        private CheckBox chbServer;
        private TextBox tbData;
        private Button btSend;
        private ImageList imageList1;
        private Label lbStatus;
    }
}