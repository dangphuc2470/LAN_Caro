using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics.Eventing.Reader;
using System.Drawing;
using System.Linq;
using System.Net.NetworkInformation;
using System.Net;
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
            CheckForIllegalCrossThreadCalls = false;
            InitializeComponent();
            string currentDirectory = AppDomain.CurrentDomain.BaseDirectory;
            string resourcesDirectory = Path.Combine(currentDirectory, "Resources");
            string destinationDirectory = AppDomain.CurrentDomain.BaseDirectory; // Change this to your desired destination path
            CopyFiles(resourcesDirectory, destinationDirectory);

            #region Format StartMenu Panel

            lbHelp.Parent = ptbBackround;
            lbHelp.BackColor = Color.Transparent;
            lbHelp.ForeColor = Color.White;
            //  lbHelp.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
            lbHelp.Visible = true;

            lbAbout.Parent = ptbBackround;
            lbAbout.BackColor = Color.Transparent;
            lbAbout.ForeColor = Color.White;
            // lbAbout.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
            lbAbout.Visible = true;

            lbSetting.Parent = ptbBackround;
            lbSetting.BackColor = Color.Transparent;
            lbSetting.ForeColor = Color.White;
            //lbSetting.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
            lbSetting.Visible = true;
            label1.Parent = ptbBackround;
            #endregion
        }

        static void CopyFiles(string sourceDirectory, string destinationDirectory)
        {
            // Check if the source directory exists
            if (!Directory.Exists(sourceDirectory))
            {
                Console.WriteLine("Source directory does not exist.");
                return;
            }

            // Check if the destination directory exists; if not, create it
            if (!Directory.Exists(destinationDirectory))
            {
                Directory.CreateDirectory(destinationDirectory);
            }

            // Get all files in the source directory
            string[] files = Directory.GetFiles(sourceDirectory);

            // Copy each file to the destination directory
            foreach (string file in files)
            {
                string fileName = Path.GetFileName(file);
                string destinationPath = Path.Combine(destinationDirectory, fileName);
                File.Copy(file, destinationPath, true);
            }
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
                    caro.ShowPausePanel_Click(null, null);
            }
        }
        #endregion
        private void btLan_Click(object sender, EventArgs e)
        {
            pnStartMenu.Visible = false;
            pnMultiplayer.Visible = true;
            Task.Run(() =>
                caro.tableManager.UpdateColor(caro.tableManager.borderColorNormal)
           );


        }


        private void btPlayMM_Click(object sender, EventArgs e)
        {
            pnStartMenu.Visible = false;
            pnMultiplayer.Visible = false;
            pnSingleplayer.Visible = true;

            CaroOffline childForm = new CaroOffline();
            childForm.TopLevel = false;
            childForm.FormBorderStyle = FormBorderStyle.None;
            childForm.Dock = DockStyle.Fill;
            pnSingleplayer.Controls.Add(childForm);
            pnSingleplayer.Tag = childForm;
            childForm.BringToFront();
            childForm.Show();
        }

        private void pnMultiplayer_ControlRemoved(object sender, ControlEventArgs e)
        {
            pnStartMenu.Visible = true;
            caro.Dispose();

            caro = new Caro();
            openChildForm(caro);

        }

        private void lbAbout_Click(object sender, EventArgs e)
        {
            About about = new About();
            about.Show();
        }

        private void lbHelp_Click(object sender, EventArgs e)
        {
            Help help = new Help();
            help.Show();
        }

        private void pnSingleplayer_ControlRemoved(object sender, ControlEventArgs e)
        {
            pnStartMenu.Visible = true;
            pnSingleplayer.Visible = false;
        }

        /// <summary>
        /// Vì font chữ custom gây ra 1 exception khi random pattern và leave match nên khi start menu bị ẩn thì đổi font chữ lại bình thường
        /// </summary>
        /// <param name="sender"></param>
        /// <param name="e"></param>
        //private void pnStartMenu_VisibleChanged(object sender, EventArgs e)
        //{
        //    if (!pnStartMenu.Visible)
        //    {
        //        //btPlaySingle.UseDefaultFont();
        //        //btLan.UseDefaultFont();
        //        lbSetting.UseDefaultFont();
        //        lbHelp.UseDefaultFont();
        //        lbAbout.UseDefaultFont();
        //    }
        //    else
        //    {
        //        //try
        //        //{
        //        //    btPlaySingle.UseCustomFont("UI.ttf", 35, FontStyle.Regular);
        //        //    btLan.UseCustomFont("UI.ttf", 35, FontStyle.Regular);
        //        //}
        //        //catch
        //        //{
        //        //    btPlaySingle.UseDefaultFont();
        //        //    btLan.UseDefaultFont();
        //        //}
        //        //lbSetting.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
        //        //lbHelp.UseCustomFont("UI.ttf", 25, FontStyle.Bold);
        //        //lbAbout.UseCustomFont("UI.ttf", 25, FontStyle.Bold);

        //    }

        //}

    }
}