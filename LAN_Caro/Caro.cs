using System.Drawing;
using System.Drawing.Text;
using System.Windows.Forms;

namespace LAN_Caro
{
    public partial class Caro : Form
    {

        public Table tableManager;
        Player_OBJ ServerOrClient;
        ToolTip toolTip1;
        public int remainingTimeInSeconds;  // Thời gian ban đầu là 60 giây
        public Caro()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            remainingTimeInSeconds = 60;
            KeyPreview = true;
            toolTip1 = new ToolTip();
            lbTimer.Text = SecondToMinute(remainingTimeInSeconds.ToString());
            #region Format Pause Panel font
            foreach (CustomLabel label in pnPause1.Controls.OfType<CustomLabel>())
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

            foreach (CustomLabel label in pnPause2.Controls.OfType<CustomLabel>())
            {
                if (label.Name == "lbTesting2" || label.Name == "lbTesting1")
                    continue;
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
            tableManager = new Table(pnTable, rtbLog, imgTurn, tbIPAdress, timer1, lbTimer, btReady, remainingTimeInSeconds, timer);
            tableManager.tableButtonClickedSend += TableManager_ButtonClickedSend;
            tableManager.DrawTable();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            tableManager.remainingTimeInSeconds--;
            lbTimer.Text = SecondToMinute(tableManager.remainingTimeInSeconds.ToString());

            if (remainingTimeInSeconds == 0)
            {
                timer.Enabled = false;
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

        public void ShowPausePanel_Click(object sender, EventArgs e)
        {
            if (pnPause2.Tag.ToString() == "0" && tableManager.button_IsLoading == false)
            {
                tableManager.DarkColor();
                pnPause2.Dock = DockStyle.Right;
                pnPause1.Dock = DockStyle.Left;
                pnPause2.Size = new Size(1022, 788);
                pnPause1.Size = new Size(458, 788);
                pnPause2.Visible = true;
                pnPause2.Tag = "1";
                ResetColor(lbResume);
            }
            else
                Resume();
        }

        private void richTextBox1_TextChanged(object sender, EventArgs e)
        {
            rtbLog.SelectionStart = rtbLog.Text.Length;
            rtbLog.ScrollToCaret();
        }


        #region Pause Panel
        public void LoadButtonColor()
        {
            //tableManager.ResetColor();
            //Task.Run(() =>
            //{
            //    //tableManager.UpdateColor(tableManager.borderColorNormal);
            //}
            //);
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
            pnPause2.Visible = false;
            pnPause2.Tag = "0";
            ResetVisible();
            tableManager.ResetColor();

        }

        private void lbOptions_Click(object sender, EventArgs e)
        {
            ResetColor(lbOptions);
            ResetVisible();
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
            this.Close();
        }

        private void lbExit_Click(object sender, EventArgs e)
        {
            this.Close();
        }

        /// <summary>
        /// Reset tag và màu cho các label
        /// </summary>
        /// 
        private void ResetColor(CustomLabel thisLabel = null)
        {
            foreach (CustomLabel label in pnPause1.Controls.OfType<CustomLabel>())
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
            lbChangeTurn.Visible = false;
            tableManager.DarkColor();

        }


        #endregion

        private void lbRestart_Click(object sender, EventArgs e)
        {
            Resume();
            tableManager.Restart();
            remainingTimeInSeconds = 60;
            try
            {
                ServerOrClient.messageSend("Restart_" + remainingTimeInSeconds);
            }
            catch
            {
                MessageBox.Show("Could not send command to opponient, check your connection and try again!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
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
            lbChangeTurn.Visible = lbRestart.Visible;
        }

        private void lbChangeTurn_Click(object sender, EventArgs e)
        {
            tableManager.SwitchPlayer();
            ServerOrClient.messageSend("Switch");
            Resume();
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
            pnPause1.Visible = pnPause2.Visible;
            if (!pnPause2.Visible)
            {
                foreach (CustomLabel label in pnPause1.Controls.OfType<CustomLabel>())
                {

                    label.UseDefaultFont();
                }
                //                lbTimer.BackColor = Color.FromArgb(75, 75, 75);
            }
            else
            {
                foreach (CustomLabel label in pnPause1.Controls.OfType<CustomLabel>())
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

                foreach (CustomLabel label in pnPause2.Controls.OfType<CustomLabel>())
                {
                    if (label.Name == "lbTesting2" || label.Name == "lbTesting1")
                        continue;
                    label.MouseEnter += PauseLabel_MouseEnter;
                    label.MouseLeave += PauseLabel_MouseLeave;
                    label.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
                    label.ForeColor = Color.Silver;
                    label.Tag = "0";
                }
                //lbTimer.BackColor = Color.Transparent;
            }

            if (btReady.Tag.ToString() == "0")
                btReady.Visible = !pnPause2.Visible;
        }

        private static string SecondToMinute(string second)
        {
            int minute = int.Parse(second) / 60;
            int second_ = int.Parse(second) % 60;
            string second__ = (second_ == 0) ? "00" : second;
            return minute + ":" + second__;
        }
 
    }
}