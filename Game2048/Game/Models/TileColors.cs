namespace Models;

public class TileColors
{
    private static readonly Random random = new Random();
    private static readonly Dictionary<int, System.Drawing.Color> colors = new Dictionary<int, System.Drawing.Color>();

    public string GetBackgroundColor(int value)
    {
        if (value.Equals(null))
        {
            return "#fff";
        }
        else if (!colors.ContainsKey(value))
        {
            colors.Add(value, System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
        }

        System.Drawing.Color color;
        colors.TryGetValue(value, out color);
        return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    }

    public string GetNumberColor(int value)
    {
        if (value.Equals(null))
        {
            return "#000";
        }

        System.Drawing.Color backgroundcolor;
        colors.TryGetValue(value, out backgroundcolor);
        int hueTotals = backgroundcolor.R + backgroundcolor.B + backgroundcolor.G;
        return hueTotals > (255 * 3 / 2) ? "#000" : "#fff";
    }
}
