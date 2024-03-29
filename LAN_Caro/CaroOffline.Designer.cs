﻿namespace LAN_Caro
{
    partial class CaroOffline
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
            pnTable = new Addon_Round_Panel();
            btHost = new Addon_Custom_Button();
            btExit = new Button();
            SuspendLayout();
            // 
            // pnTable
            // 
            pnTable.AutoScroll = true;
            pnTable.BackColor = Color.Black;
            pnTable.BackgroundImageLayout = ImageLayout.Stretch;
            pnTable.CornerRadius = 25;
            pnTable.Location = new Point(30, 134);
            pnTable.Margin = new Padding(2);
            pnTable.Name = "pnTable";
            pnTable.Size = new Size(1440, 640);
            pnTable.TabIndex = 1;
            // 
            // btHost
            // 
            btHost.BackColor = Color.Transparent;
            btHost.BackgroundColor = Color.Transparent;
            btHost.BackgroundImage = Properties.Resources.Picsart_23_06_12_21_54_09_715;
            btHost.BackgroundImageLayout = ImageLayout.Stretch;
            btHost.BorderColor = Color.White;
            btHost.BorderRadius = 4;
            btHost.BorderSize = 1;
            btHost.FlatAppearance.BorderSize = 0;
            btHost.FlatStyle = FlatStyle.Flat;
            btHost.Font = new Font("Impact", 25F, FontStyle.Regular, GraphicsUnit.Point);
            btHost.ForeColor = Color.White;
            btHost.Location = new Point(0, 0);
            btHost.Margin = new Padding(2);
            btHost.Name = "btHost";
            btHost.Size = new Size(355, 102);
            btHost.TabIndex = 29;
            btHost.Text = "RESTART";
            btHost.TextColor = Color.White;
            btHost.UseVisualStyleBackColor = false;
            btHost.Click += btHost_Click;
            // 
            // btExit
            // 
            btExit.Location = new Point(361, 0);
            btExit.Margin = new Padding(4);
            btExit.Name = "btExit";
            btExit.Size = new Size(118, 102);
            btExit.TabIndex = 30;
            btExit.Text = "QUIT";
            btExit.UseVisualStyleBackColor = true;
            btExit.Click += btExit_Click;
            // 
            // CaroOffline
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Picsart_23_06_07_08_41_09_453;
            BackgroundImageLayout = ImageLayout.Stretch;
            ClientSize = new Size(1480, 788);
            Controls.Add(btExit);
            Controls.Add(btHost);
            Controls.Add(pnTable);
            Margin = new Padding(2);
            Name = "CaroOffline";
            Text = "CaroOffline";
            Load += CaroOffline_Load;
            ResumeLayout(false);
        }

        #endregion

        private Addon_Round_Panel pnTable;
        private Addon_Custom_Button btHost;
        private Button btExit;
    }
}