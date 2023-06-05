using System.Drawing;
using System.Drawing.Text;

namespace LAN_Caro
{
    public partial class Caro : Form
    {

        TableManager tableManager;
        Player_OBJ ServerOrClient;
        ToolTip toolTip1;
        public int remainingTimeInSeconds; // Thời gian ban đầu là 60 giây
        public Caro()
        {
            InitializeComponent();
            remainingTimeInSeconds = 60;
            lbTimer.ForeColor = Color.Blue;
            KeyPreview = true;
            toolTip1 = new ToolTip();
            #region Format Pause Panel font
            foreach (CustomLabel label in pnPause.Controls.OfType<CustomLabel>())
            {
                if (label.Name == "lbMenu")
                {
                    label.UseCustomFont("Arbuz.ttf", 40, FontStyle.Bold);
                    label.ForeColor = Color.White;
                    continue;
                }
                else if (label.Name == "randomPatternLabel")
                    continue;
                label.MouseEnter += PauseLabel_MouseEnter;
                label.MouseLeave += PauseLabel_MouseLeave;
                label.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
                label.ForeColor = Color.Silver;
                label.Tag = "0";
            }
            #endregion
            #region Format StartMenu Panel
            foreach (CustomLabel label in pnStartMenu.Controls.OfType<CustomLabel>())
            {
                label.Parent = pictureBox1;
                label.BackColor = Color.Transparent;
                label.ForeColor = Color.White;
                label.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
            }
            btPlayMM.UseCustomFont("UI.ttf", 35, FontStyle.Regular);
            btLan.UseCustomFont("UI.ttf", 35, FontStyle.Regular);
            lbSetting.Parent = pictureBox1;
            lbSetting.BackColor = Color.Transparent;
            lbSetting.ForeColor = Color.White;
            lbSetting.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
            //lbPlay.UseCustomFont("HeadlinerNo.45 DEMO.ttf", 45, FontStyle.Regular);
            //lbPlay.ForeColor = Color.FromArgb(234, 178, 26);
            #endregion
        }
        private void Caro_Load(object sender, EventArgs e)
        {
            lbTimer.Text = remainingTimeInSeconds.ToString();
            tableManager = new TableManager(pnTable, rtbLog, imgTurn, tbIPAdress, timer1, lbTimer, btReady, remainingTimeInSeconds);
            tableManager.tableButtonClickedSend += TableManager_ButtonClickedSend;
            tableManager.DrawTable();
        }

        private void timer1_Tick(object sender, EventArgs e)
        {
            remainingTimeInSeconds--;
            lbTimer.Text = remainingTimeInSeconds.ToString();

            if (remainingTimeInSeconds == 0)
            {
                timer1.Enabled = false;
                MessageBox.Show("Đếm ngược đã kết thúc!");
            }
        }


        private void Connect_Click(object sender, EventArgs e)
        {
            if (chbServer.CheckState == CheckState.Checked)
            {
                ServerOrClient = new Server_OBJ(tableManager);
                tableManager.setPlayer(0);
                btReady.Text = "Play";
            }
            else
            {
                try
                {
                    ServerOrClient = new Client_OBJ(tableManager, tbIPAdress.Text);
                    btReady.Tag = 1;
                    btReady.ForeColor = Color.Black;
                }
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
            randomPatternLabel.Visible = true;
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
            lbPause.Visible = false;
            //Lam lai tu dau
            pnStartMenu.Visible = true;
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
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
            remainingTimeInSeconds = 60;
            ServerOrClient.messageSend("Restart:" + remainingTimeInSeconds);
        }

        private void lbPause_Click(object sender, EventArgs e)
        {
            ServerOrClient.messageSend("Pause");
        }
        private void lbRandom_Click(object sender, EventArgs e)
        {
            Resume();
            tableManager.RandomPatern();
        }


        /// <summary>
        /// Hiển thị các label trong Options chung với Restart
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void lbRestart_VisibleChanged(object sender, EventArgs e)
        {
            lbRandom.Visible = lbRestart.Visible;
            lbPause.Visible = lbRestart.Visible;
            randomPatternLabel.Visible = lbRestart.Visible;
        }

        private void lbChangeTurn_Click(object sender, EventArgs e)
        {
            tableManager.SwitchPlayer();
        }

        /// <summary>
        /// Mượn sự kiện SizeChanged để kích hoạt timer trong UI Thread (Vì không thể kích hoạt timer trong thread khác)
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void imgTurn_SizeChanged(object sender, EventArgs e)
        {
            if (timer1.Enabled)
                timer1.Stop();
            else
                timer1.Start();
        }

        private void btReady_Click(object sender, EventArgs e)
        {
            if (btReady.Tag.ToString() == "0")
                return;
            ServerOrClient.ready();
            btReady.Tag = 1;
        }

        private void btReady_MouseHover(object sender, EventArgs e)
        {
            if (btReady.Tag.ToString() == "0")
                toolTip1.Show("The other party is not ready at the moment or there is a connection problem...", btReady);
        }

        private void pnPause_VisibleChanged(object sender, EventArgs e)
        {
            if (pnPause.Visible)
            {
                lbTimer.BackColor = Color.FromArgb(75, 75, 75);
            }
            else
            {
                lbTimer.BackColor = Color.Transparent;
            }

            if (btReady.Tag.ToString() == "0")
                btReady.Visible = !pnPause.Visible;
        }

        private void btLan_Click(object sender, EventArgs e)
        {

            Task.Run(() =>
            {
                tableManager.UpdateColor(Color.Silver);

            });
            pnStartMenu.Visible = false;
            pnPause.Visible = false;
        }

        private void Caro_Resize(object sender, EventArgs e)
        {
            int width = this.Width;
            int height = this.Height;
            int targetHeight = (int)(width * 9.0 / 16.0);

            if (height != targetHeight)
            {
                this.SetBounds(this.Bounds.X, this.Bounds.Y, width, targetHeight);
            }
        }
    }
}