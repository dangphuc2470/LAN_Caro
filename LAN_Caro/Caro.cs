using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace LAN_Caro
{
    public partial class Caro : Form
    {

        int isServerPlayer = 0;
        TableManager tableManager;
        public Caro()
        {
            InitializeComponent();

        }

        private void button2_Click(object sender, EventArgs e)
        {
            tableManager.switchPlayer();
        }

        private void Caro_Load(object sender, EventArgs e)
        {
            tableManager = new TableManager(pnTable);
            tableManager.DrawTable(isServerPlayer);
        }
    }
}
