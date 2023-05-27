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
            pnTable = new Lab_3.Addon_Round_Panel();
            button1 = new Button();
            button2 = new Button();
            btConnect = new Button();
            tbIPAdress = new TextBox();
            rdButton = new Button();
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
            button1.Location = new Point(90, 208);
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
            // rdButton
            // 
            rdButton.Location = new Point(76, 465);
            rdButton.Name = "rdButton";
            rdButton.Size = new Size(112, 34);
            rdButton.TabIndex = 5;
            rdButton.Text = "Ready";
            rdButton.UseVisualStyleBackColor = true;
            rdButton.Click += rdButton_Click;
            // 
            // Caro
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackColor = Color.FromArgb(247, 249, 252);
            ClientSize = new Size(1312, 770);
            Controls.Add(rdButton);
            Controls.Add(tbIPAdress);
            Controls.Add(btConnect);
            Controls.Add(button2);
            Controls.Add(button1);
            Controls.Add(pnTable);
            Name = "Caro";
            Text = "Caro";
            ResumeLayout(false);
            PerformLayout();
        }

        #endregion

        private Lab_3.Addon_Round_Panel pnTable;
        private Button button1;
        private Button button2;
        private Button btConnect;
        private TextBox tbIPAdress;
        private Button rdButton;
    }
}