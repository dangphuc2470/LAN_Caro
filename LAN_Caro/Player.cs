using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN_Caro
{
    public class Player
    {
        private string name;
        public string Name { get => name; set => name = value; }
        private Image image;
        public Image Image { get => image; set => image = value; }

        public Player(string name, Image image) 
        {
            this.Name = name;
            this.Image = image;
        }



    }
}
