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
        public Caro()
        {
            InitializeComponent();
            TableManager tableManager = new TableManager(pnTable);
            tableManager.DrawTable();
        }


    }
}
