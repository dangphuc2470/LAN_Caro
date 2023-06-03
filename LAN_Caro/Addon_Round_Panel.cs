using System.Drawing;
using System.Drawing.Drawing2D;
using System.Windows.Forms;

namespace LAN_Caro
{
    public class Addon_Round_Panel : Panel
    {
        private int _cornerRadius = 25;

        public int CornerRadius
        {
            get { return _cornerRadius; }
            set { _cornerRadius = value; Invalidate(); }
        }

        protected override void OnPaint(PaintEventArgs e)
        {
            base.OnPaint(e);

            GraphicsPath path = new GraphicsPath();
            RectangleF rect = new RectangleF(0, 0, Width, Height);
            path.AddRoundRect(rect, _cornerRadius);

            Region = new Region(path);
            e.Graphics.SmoothingMode = SmoothingMode.AntiAlias;
            e.Graphics.InterpolationMode = InterpolationMode.HighQualityBicubic;
            e.Graphics.FillPath(new SolidBrush(BackColor), path);
        }
    }

    public static class GraphicsPathExtensions
    {
        public static void AddRoundRect(this GraphicsPath path, RectangleF rect, float radius)
        {
            float diameter = radius * 2;
            SizeF size = new SizeF(diameter, diameter);
            RectangleF arc = new RectangleF(rect.Location, size);

            path.Reset();
            path.AddArc(arc, 180, 90);
            arc.X = rect.Right - diameter;
            path.AddArc(arc, 270, 90);
            arc.Y = rect.Bottom - diameter;
            path.AddArc(arc, 0, 90);
            arc.X = rect.Left;
            path.AddArc(arc, 90, 90);
            path.CloseFigure();
        }
    }
}