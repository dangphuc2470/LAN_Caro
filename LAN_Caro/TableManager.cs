using Lab_3;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN_Caro
{
    public class TableManager
    {
        private Addon_Round_Panel table;
        public Addon_Round_Panel Table { get => table; set => table = value; }
        public List<Player> PlayerList { get; set; }
        private int PlayerNum;
        public TableManager(Addon_Round_Panel table)
        {
            this.Table = table;
            this.PlayerList = new List<Player>()
            {
                new Player("X", Properties.Resources.x),
                new Player("O", Properties.Resources.o)
            };
            PlayerNum = 0;
        }




        public void DrawTable()
        {
            Button oldButton = new Button() { Width = 0, Location = new Point(40, 40) };
            for (int i = 0; i < Const.TABLE_HEIGHT; i++)
            {
                for (int j = 0; j < Const.TABLE_WIDTH; j++)
                {
                    Button button = new Button()
                    {
                        Width = Const.SQUARE_SIZE,
                        Height = Const.SQUARE_SIZE,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        FlatStyle = FlatStyle.Flat,

                    };
                    button.FlatAppearance.BorderColor = Color.Silver;
                    button.Click += btn_Click;
                    Table.Controls.Add(button);
                    oldButton = button;
                }
                oldButton.Location = new Point(40, oldButton.Location.Y + Const.SQUARE_SIZE);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }

        }

        void btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            if (button.Image != null) 
                return;
            button.Image = PlayerList[PlayerNum].Sign;
            if (PlayerNum == 0)
            {
                PlayerNum = 1;
            }
            else PlayerNum = 0;
        }


    }
}
