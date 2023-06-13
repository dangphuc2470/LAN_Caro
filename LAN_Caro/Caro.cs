using System.Drawing;
using System.Drawing.Text;
using System.Net.NetworkInformation;
using System.Windows.Forms;

namespace LAN_Caro
{
    public partial class Caro : Form
    {

        public Table tableManager;
        Player_OBJ ServerOrClient;
        ToolTip toolTip1;
        public int remainingTimeInSeconds;
        bool isPause = false;
        public Caro()
        {
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            remainingTimeInSeconds = 60;
            KeyPreview = true;
            toolTip1 = new ToolTip();
        }
        private void Caro_Load(object sender, EventArgs e)
        {
            #region Format Font
            lbTimer.Text = SecondToMinute(remainingTimeInSeconds.ToString());
            lbTimer.Parent = ptbBackgroundTimer;
            lblllMinSecond.Parent = ptbBackgroundTimer;
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

            lbTimer.UseCustomFont("DS-DIGII.TTF", 35, FontStyle.Bold);
            lblllMinSecond.UseCustomFont("UI.ttf", 10, FontStyle.Bold);
            #endregion
            tableManager = new Table(pnTable, rtbLog, imgTurn, tbIPAdress, timer1, lbTimer, btReady,
                remainingTimeInSeconds, timer, this, lbNameClient, lbNameServer, ptbPlay, lbResume);


            tableManager.tableButtonClickedSend += TableManager_ButtonClickedSend;
            tableManager.DrawTable();
        }

        private void timer_Tick(object sender, EventArgs e)
        {
            if (isPause) return;
            tableManager.remainingTimeInSeconds--;
            lbTimer.Text = SecondToMinute(tableManager.remainingTimeInSeconds.ToString());

            if (remainingTimeInSeconds == 0)
            {
                timer.Enabled = false;
                MessageBox.Show("Đếm ngược đã kết thúc!");
            }
        }


        private void TableManager_ButtonClickedSend(object sender, string text)
        {
            ServerOrClient.messageSend(text);
            tableManager.SwitchPlayer();
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
            {
                Resume();
            }
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


        public void lbLeaveMatch_Click(object sender, EventArgs e)
        {
            this.Close();
            ServerOrClient.messageSend("Leave");
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
            tableManager.Restart(60);
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
            isPause = true;
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

                lbTimer.UseCustomFont("DS-DIGII.TTF", 35, FontStyle.Bold);
                lblllMinSecond.UseCustomFont("UI.ttf", 10, FontStyle.Bold);

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
                lbTimer.BackColor = Color.Transparent;
                lbTimer.UseDefaultFont();
                lblllMinSecond.UseDefaultFont();
            }

            if (isPause) //Tiếp tục timer mỗi khi panel pause bị ẩn
            {
                isPause = false;
                ServerOrClient.messageSend("Resume");
            }

            if (btReady.Tag.ToString() == "0")
                btReady.Visible = !pnPause2.Visible;
            ptbBackgroundTimer.Visible = !pnPause2.Visible;
            pnIPAddress.Visible = !pnPause2.Visible;


        }

        public static string SecondToMinute(string second)
        {
            int minute = int.Parse(second) / 60;
            int second_ = int.Parse(second) % 60;
            string second__ = (second_ == 0) ? "00" : second;
            return minute + ":" + second__;
        }

        private void btHost_Click(object sender, EventArgs e)
        {
            try
            {
                ServerOrClient = new Server_OBJ(tableManager);

                tableManager.setPlayer(0);
                btReady.Text = "PLAY";
                btClient.Visible = false;
                lblllChooseRole.Visible = false;
                btHost.Enabled = false;
                labelShowOrInput.Text = "Show this IP address to the client";
                // Lấy thông tin mạng của máy tính
                string ipv4Address = "";
                foreach (NetworkInterface ni in NetworkInterface.GetAllNetworkInterfaces())
                {
                    if (ni.OperationalStatus == OperationalStatus.Up && ni.NetworkInterfaceType != NetworkInterfaceType.Loopback)
                    {
                        foreach (UnicastIPAddressInformation ip in ni.GetIPProperties().UnicastAddresses)
                        {
                            if (ip.Address.AddressFamily == System.Net.Sockets.AddressFamily.InterNetwork)
                            {
                                cbbIP.Items.Add(ip.Address.ToString() + " " + ni.Name.ToString());
                                tbIPAdress.Text = ip.Address.ToString();
                            }
                        }
                    }
                    if (!string.IsNullOrEmpty(ipv4Address))
                    {
                        break;
                    }
                }

                tableManager.PlayerList[0].Name = lbNameServer.Text;
            }
            catch
            {
                MessageBox.Show("Server already running, please join as client instead or restart the game if you fell something was wrong!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void btClient_Click(object sender, EventArgs e)
        {
            if (tbIPAdress.Text == "")
            {
                tbIPAdress.Focus();
                return;
            }
            try
            {
                ServerOrClient = new Client_OBJ(tableManager, tbIPAdress.Text);
                btReady.Tag = 1;
                btReady.ForeColor = Color.White;
                btHost.Visible = false;
                lblllChooseRole.Visible = false;
                btClient.Enabled = false;
                MovePanelWithAnimation(btClient, btHost);
                btClient.Location = btHost.Location;
                tableManager.PlayerList[1].Name = lbNameClient.Text;

            }
            catch
            {
                tbIPAdress.Focus();
                MessageBox.Show("Server does not started yet or maybe you entered wrong IP address!", "Error", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }


        private void MovePanelWithAnimation(Addon_Custom_Button pnMove, Addon_Custom_Button pnLocation)
        {
            Task.Run(() =>
            {
                int y = pnMove.Location.Y;
                while (y <= pnLocation.Location.Y)
                {
                    pnMove.Invoke(new Action(() =>
                    {
                        pnMove.Location = new Point(pnLocation.Location.X, y + 1);
                    }));
                    y = pnMove.Location.Y + 1;
                    if (y > 670)
                        Thread.Sleep(15);
                    else
                        Thread.Sleep(1);

                }
            });
        }

        private void cbbIP_SelectionChangeCommitted(object sender, EventArgs e)
        {
            tbIPAdress.Text = cbbIP.SelectedItem.ToString().Substring(0, cbbIP.SelectedItem.ToString().IndexOf(" "));
        }
    }
}