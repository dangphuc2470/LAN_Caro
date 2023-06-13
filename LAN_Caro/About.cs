using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Diagnostics;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAN_Caro
{
    public partial class About : Form
    {
        public About()
        {
            InitializeComponent();
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            string url = "https://github.com/dangphuc2470/LAN_Caro";
            string edgePath = @"C:\Program Files (x86)\Microsoft\Edge\Application\msedge.exe"; // Change this path to the location of your Microsoft Edge executable

            ProcessStartInfo startInfo = new ProcessStartInfo();
            startInfo.FileName = edgePath;
            startInfo.Arguments = url;
            Process.Start(startInfo);
        }
    }
}
