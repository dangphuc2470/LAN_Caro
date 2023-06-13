using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LAN_Caro
{

    public class CustomComboBox : ComboBox
    {
        public CustomComboBox()
        {
            // Thiết lập thuộc tính FlatStyle của ComboBox thành FlatStyle.Flat
            this.FlatStyle = FlatStyle.Flat;
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            // Gọi phương thức OnPaint của lớp cha để vẽ các phần tử khác của ComboBox
            base.OnPaint(e);

            // Vẽ lại nút drop-down với màu đen
            Rectangle rect = new Rectangle(ClientRectangle.Width - 18, 0, 18, ClientRectangle.Height);
            e.Graphics.FillRectangle(new SolidBrush(Color.Black), rect);
            Point[] triangle = new Point[] { new Point(rect.X + 3, rect.Height / 2 - 1), new Point(rect.X + rect.Width - 4, rect.Height / 2 - 1), new Point(rect.X + rect.Width / 2, rect.Height / 2 + 2) };
            e.Graphics.FillPolygon(new SolidBrush(Color.White), triangle);
        }
    }
}
