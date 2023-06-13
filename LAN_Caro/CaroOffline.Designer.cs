namespace LAN_Caro
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
            SuspendLayout();
            // 
            // pnTable
            // 
            pnTable.AutoScroll = true;
            pnTable.BackColor = Color.Transparent;
            pnTable.BackgroundImageLayout = ImageLayout.Stretch;
            pnTable.CornerRadius = 25;
            pnTable.Location = new Point(161, 67);
            pnTable.Name = "pnTable";
            pnTable.Size = new Size(960, 680);
            pnTable.TabIndex = 1;
            // 
            // CaroOffline
            // 
            AutoScaleDimensions = new SizeF(10F, 25F);
            AutoScaleMode = AutoScaleMode.Font;
            BackgroundImage = Properties.Resources.Picsart_23_06_07_08_41_09_453;
            ClientSize = new Size(1480, 788);
            Controls.Add(pnTable);
            Name = "CaroOffline";
            Text = "CaroOffline";
            Load += CaroOffline_Load;
            ResumeLayout(false);
        }

        #endregion

        private Addon_Round_Panel pnTable;
    }
}