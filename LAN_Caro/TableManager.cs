using Lab_3;
using System;
using System.Collections.Generic;
using System.Formats.Asn1;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;

namespace LAN_Caro
{
    public class TableManager
    {
        public static int SQUARE_SIZE = 40;
        public static int TABLE_WIDTH = 24;
        public static int TABLE_HEIGHT = 16;
        private Addon_Round_Panel table;
        public Addon_Round_Panel Table { get => table; set => table = value; }
        public List<Player> PlayerList { get; set; }
        public List<List<Button>> buttonList = new List<List<Button>>();

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
            for (int i = 0; i < TABLE_HEIGHT; i++)
            {
                buttonList.Add(new List<Button>());
                for (int j = 0; j < TABLE_WIDTH; j++)
                {
                    Button button = new Button()
                    {
                        Width = SQUARE_SIZE,
                        Height = SQUARE_SIZE,
                        Location = new Point(oldButton.Location.X + oldButton.Width, oldButton.Location.Y),
                        FlatStyle = FlatStyle.Flat,
                        Name = i.ToString() //Name as Y

                    };
                    button.Tag = j;         //Tag as X
                    button.FlatAppearance.BorderColor = Color.Silver;
                    button.Click += btn_Click;
                    Table.Controls.Add(button);
                    buttonList[i].Add(button);
                    oldButton = button;
                }
                oldButton.Location = new Point(40, oldButton.Location.Y + SQUARE_SIZE);
                oldButton.Width = 0;
                oldButton.Height = 0;
            }

        }

        void btn_Click(object sender, EventArgs e)
        {
            Button button = sender as Button;
            int y = Int32.Parse(button.Name);
            int x = Int32.Parse(button.Tag.ToString());
            if (buttonList[y][x].Image != null)
                return;
            buttonList[y][x].Image = PlayerList[PlayerNum].Sign;




            if (countVertical(button) >=4 || countHorizontal(button) >= 4 || countMainDiag(button) >=4 || countSubDiag(button) >= 4)
                MessageBox.Show("WIN");


            if (PlayerNum == 0)
            {
                PlayerNum = 1;
            }
            else PlayerNum = 0;
        }
        public int countVertical(Button button)
        {
            int y = Int32.Parse(button.Name);
            int x = Int32.Parse(button.Tag.ToString());
            int count = 0;
            for (int i = x - 1; i >= 0; i--)
            {
                if (buttonList[y][i].Image == buttonList[y][x].Image)
                    count++;
                else
                    break;
            }

            for (int i = x + 1; i < TABLE_WIDTH; i++)
            {
                if (buttonList[y][i].Image == buttonList[y][x].Image)
                    count++;
                else
                    break;
            }
            return count;


        }
        public int countHorizontal(Button button)
        {
            int y = Int32.Parse(button.Name);
            int x = Int32.Parse(button.Tag.ToString());
            int count = 0;
            for (int i = y - 1; i >= 0; i--)
            {
                if (buttonList[i][x].Image == buttonList[y][x].Image)
                    count++;
                else
                    break;
            }
            for (int i = y + 1; i < TABLE_HEIGHT; i++)
            {
                if (buttonList[i][x].Image == buttonList[y][x].Image)
                    count++;
                else
                    break;
            }

            return count;

        }
        public int countMainDiag(Button button)
        {
            int y = Int32.Parse(button.Name);
            int x = Int32.Parse(button.Tag.ToString());
            int count = 0;
            for (int i = x - 1, j = y - 1; i >= 0 && j >= 0; i--, j--)
            {
                if (buttonList[j][i].Image == buttonList[y][x].Image)
                    count++;
                else break;
            }
            for (int i = x + 1, j = y + 1; i < TABLE_WIDTH && j < TABLE_HEIGHT; i++, j++)
            {
                if (buttonList[j][i].Image == buttonList[y][x].Image)
                    count++;
                else break;
            }
            return count;
        }

        public int countSubDiag(Button button)
        {
            int y = Int32.Parse(button.Name);
            int x = Int32.Parse(button.Tag.ToString());
            int count = 0;
            for (int i = x - 1, j = y + 1; i >= 0 && j < TABLE_HEIGHT; i--, j++)
            {
                if (buttonList[j][i].Image == buttonList[y][x].Image)
                    count++;
                else break;
            }
            for (int i = x + 1, j = y - 1; i < TABLE_WIDTH && j >= 0; i++, j--)
            {
                if (buttonList[j][i].Image == buttonList[y][x].Image)
                    count++;
                else break;
            }
            return count;
        }





    }
}

