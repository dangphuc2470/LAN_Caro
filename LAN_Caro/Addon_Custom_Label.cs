using System.Drawing.Text;

namespace LAN_Caro;
public class CustomLabel : Label
{
    public CustomLabel()
    {
        BackColor = Color.Transparent;
        ForeColor = Color.White;
    }

    public void UseCustomFont(string name, int size, FontStyle fontStyle)
    {
        PrivateFontCollection modernFont = new PrivateFontCollection();

        modernFont.AddFontFile(name);

        Font = new Font(modernFont.Families[0], size, fontStyle);
    }

    public void UseDefaultFont()
    {
        Font = new Font("Segoe UI", 9, FontStyle.Regular);
    }
}