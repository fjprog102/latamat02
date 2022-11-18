namespace Models;

public class TileColors
{
    private static readonly Random random = new Random();
    private static readonly Dictionary<int, System.Drawing.Color> colors = new Dictionary<int, System.Drawing.Color>();

    public string GetBackgroundColor(int value)
    {
        if (!colors.ContainsKey(value))
        {
            colors.Add(value, System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
        }

        System.Drawing.Color color = colors[value];
        return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
    }

    public string GetNumberColor(int value)
    {
        System.Drawing.Color backgroundcolor = colors[value];
        int hueTotals = backgroundcolor.R + backgroundcolor.B + backgroundcolor.G;
        return hueTotals > (255 * 3 / 2) ? "#000" : "#fff";
    }
}
