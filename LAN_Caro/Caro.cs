﻿using System.Drawing;
using System.Drawing.Text;

namespace LAN_Caro
{
    public partial class Caro : Form
    {

        TableManager tableManager;
        Player_OBJ ServerOrClient;
        public Caro()
        {
            InitializeComponent();
            KeyPreview = true;
            #region Format Pause Panel font
            foreach (CustomLabel label in pnPause.Controls.OfType<CustomLabel>())
            {
                if (label.Name == "lbMenu")
                {
                    label.UseCustomFont("Arbuz.ttf", 40, FontStyle.Bold);
                    label.ForeColor = Color.White;
                    continue;
                }
                label.MouseEnter += PauseLabel_MouseEnter;
                label.MouseLeave += PauseLabel_MouseLeave;
                label.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
                label.ForeColor = Color.Silver;
                label.Tag = "0";
            }
            #endregion
        }
        private void Caro_Load(object sender, EventArgs e)
        {
            tableManager = new TableManager(pnTable, rtbLog, imgTurn, tbIPAdress);
            tableManager.tableButtonClickedSend += TableManager_ButtonClickedSend;
            tableManager.DrawTable();
            Task.Run(() =>
            {
                tableManager.UpdateColor(Color.Silver);

            });
        }

        private void Connect_Click(object sender, EventArgs e)
        {
            if (chbServer.CheckState == CheckState.Checked)
            {
                ServerOrClient = new Server_OBJ(tableManager);
                tableManager.setPlayer(0);
            }
            else
            {
                try
                { ServerOrClient = new Client_OBJ(tableManager, tbIPAdress.Text); }
                catch 
                {
                    MessageBox.Show("Server does not started yet!");
                    return;
                }
            }
        }


        private void TableManager_ButtonClickedSend(object sender, string text)
        {
            ServerOrClient.messageSend(text);
            tableManager.SwitchPlayer();
        }

        private void chbServer_CheckedChanged(object sender, EventArgs e)
        {
            tbIPAdress.Text = "127.0.0.1";
        }

        private void Menu_Click(object sender, EventArgs e)
        {

            pnPause.Dock = DockStyle.Fill;
            pnPause.Visible = true;
            tableManager.DarkColor();
        }

        private void RandomPattern_Click(object sender, EventArgs e)
        {
            tableManager.RandomPatern();
        }

        private void SwitchPlayer_Click(object sender, EventArgs e)
        {
            tableManager.SwitchPlayer();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }


        #region Pause Panel
        private void Caro_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (pnPause.Tag == "0")
                {
                    tableManager.DarkColor();
                    pnPause.Dock = DockStyle.Fill;
                    pnPause.Visible = true;
                    pnPause.Tag = "1";
                    ResetColor(lbResume);
                }
                else
                    Resume();
            }
        }

        private void PauseLabel_MouseEnter(object sender, EventArgs e)
        {
            CustomLabel label = (CustomLabel)sender;
            label.ForeColor = Color.White;
        }

        private void PauseLabel_MouseLeave(object sender, EventArgs e)
        {
            CustomLabel label = (CustomLabel)sender;
            if (label.Tag == "0")
                label.ForeColor = Color.Silver;
        }


        private void lbResume_Click(object sender, EventArgs e)
        {
            Resume();
        }

        private void Resume()
        {
            ResetColor();
            pnPause.Visible = false;
            pnPause.Tag = "0";
            ResetVisible();
            tableManager.ResetColor();

        }

        private void lbOptions_Click(object sender, EventArgs e)
        {
            ResetColor(lbOptions);
            ResetVisible();
            lbPause.Visible = true;
            lbRandom.Visible = true;
            lbRestart.Visible = true;
        }

        private void lbSettings_Click(object sender, EventArgs e)
        {
            ResetColor(lbSettings);
            ResetVisible();
        }


        private void lbMatchLog_Click(object sender, EventArgs e)
        {
            ResetVisible();
            ResetColor(lbMatchLog);
            rtbLog.Visible = true;
        }


        private void lbLeaveMatch_Click(object sender, EventArgs e)
        {
            ResetColor(lbLeaveMatch);
            ResetVisible();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            ResetColor(lbExit);
            ResetVisible();
        }

        /// <summary>
        /// Reset tag và màu cho các button
        /// </summary>
        /// 
        private void ResetColor(CustomLabel thisLabel = null)
        {
            foreach (CustomLabel label in pnPause.Controls.OfType<CustomLabel>())
            {
                if (label.Name == "lbMenu")
                    continue;
                label.ForeColor = Color.Silver;
                label.Tag = "0";
                if (thisLabel != null && thisLabel.Name != "lbResume")
                {
                    thisLabel.ForeColor = Color.White;
                    thisLabel.Tag = "1";
                }
            }
        }

        /// <summary>
        /// Ẩn tất cả tính năng trên Pause Panel
        /// </summary>
        private void ResetVisible()
        {
            rtbLog.Visible = false;
            lbPause.Visible = false;
            lbRandom.Visible = false;
            lbRestart.Visible = false;
            tableManager.DarkColor();

        }


        #endregion

        private void lbRestart_Click(object sender, EventArgs e)
        {
            Resume();
            tableManager.Restart();
            ServerOrClient.messageSend("RS");
        }

        private void lbPause_Click(object sender, EventArgs e)
        {

        }
        private void lbRandom_Click(object sender, EventArgs e)
        {
            Resume();
            tableManager.RandomPatern();
        }


    }
}