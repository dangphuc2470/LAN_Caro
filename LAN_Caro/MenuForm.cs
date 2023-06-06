using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Reflection.Emit;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAN_Caro
{
    public partial class MenuForm : Form
    {
        private Form activeForm = null;
        public int resizeCount = 0;
        Caro caro;
        private void openChildForm(Form childForm)
        {
            if (activeForm != null) activeForm.Close();
            activeForm = childForm;
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnMultiplayer.Controls.Add(childForm);
            pnMultiplayer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();

        }

        public MenuForm()
        {
            InitializeComponent();
            #region test
            //pnStartMenu.Visible = false;
            //pnMultiplayer.Visible = true;
            #endregion
            #region Format StartMenu Panel
            btPlaySingle.UseCustomFont("UI.ttf", 35, FontStyle.Regular);
            btLan.UseCustomFont("UI.ttf", 35, FontStyle.Regular);


            lbHelp.Parent = ptbBackround;
            lbHelp.BackColor = Color.Transparent;
            lbHelp.ForeColor = Color.White;
            lbHelp.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
            lbHelp.Visible = true;

            lbAbout.Parent = ptbBackround;
            lbAbout.BackColor = Color.Transparent;
            lbAbout.ForeColor = Color.White;
            lbAbout.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
            lbAbout.Visible = true;

            lbSetting.Parent = ptbBackround;
            lbSetting.BackColor = Color.Transparent;
            lbSetting.ForeColor = Color.White;
            lbSetting.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
            lbSetting.Visible = true;
            #endregion
        }

        #region MenuForm Event
        private void MenuForm_SizeChanged(object sender, EventArgs e)
        {

            int width = this.Width;
            int height = this.Height;
            int targetHeight = (int)(width * 9.0 / 16.0);

            if (height != targetHeight)
            {
                this.SetBounds(this.Bounds.X, this.Bounds.Y, width, targetHeight);
            }

        }

        /// <summary>
        /// Chuyển backround thành ảnh tĩnh khi người dùng di chuyển form để tối ưu hiệu năng
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void MenuForm_Move(object sender, EventArgs e)
        {
            if (resizeCount == 0) //Khi khởi tạo thì form sẽ kích hoạt sự kiện này một lần, nên cần phải bỏ qua
            {
                caro = new Caro();
                openChildForm(caro); ///Vì khi khởi tạo thì sự kiện này sẽ kích hoạt 1 lần nên ta tân dụng nó để load game trước trong nền
                resizeCount++;
                return;
            }
            else if (resizeCount == 1)
            {
                ptbBackround.Image = Properties.Resources.Backgroud;
                resizeCount++;
            }
        }

        private void MenuForm_KeyDown(object sender, KeyEventArgs e)
        {
            if (e.KeyCode == Keys.Escape)
            {
                if (pnMultiplayer.Visible)
                    caro.ShowPausePanel();
            }
        }
        #endregion
        private void btLan_Click(object sender, EventArgs e)
        {
            pnStartMenu.Visible = false;
            pnMultiplayer.Visible = true;
            caro.LoadButtonColor();

        }


        private void btPlayMM_Click(object sender, EventArgs e)
        {
        }

        private void pnMultiplayer_ControlRemoved(object sender, ControlEventArgs e)
        {
            pnStartMenu.Visible = true;
            caro.Dispose();
            caro = new Caro();
            openChildForm(caro);
        }


        /// <summary>
        /// Vì font chữ custom gây ra 1 exception khi random pattern và leave match nên khi start menu bị ẩn thì đổi font chữ lại bình thường
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        private void pnStartMenu_VisibleChanged(object sender, EventArgs e)
        {
            if (!pnStartMenu.Visible)
            {
                btPlaySingle.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                btLan.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lbSetting.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lbHelp.Font = new Font("Segoe UI", 9, FontStyle.Regular);
                lbAbout.Font = new Font("Segoe UI", 9, FontStyle.Regular);
            }
            else
            {

                btPlaySingle.UseCustomFont("UI.ttf", 35, FontStyle.Regular);
                btLan.UseCustomFont("UI.ttf", 35, FontStyle.Regular);

                lbSetting.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
                lbHelp.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
                lbAbout.UseCustomFont("UI.ttf", 25, FontStyle.Bold);

            }

        }
    }
}