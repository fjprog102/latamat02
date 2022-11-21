namespace Models;

using System.Collections.Concurrent;

public class TileColors
{
    private static readonly Random random = new Random();
    public static readonly ConcurrentDictionary<int, System.Drawing.Color> colors = new ConcurrentDictionary<int, System.Drawing.Color>();

    public string GetBackgroundColor(int value)
    {
        if (!colors.ContainsKey(value))
        {
            colors.TryAdd(value, System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
        }

        System.Drawing.Color backgroundColor;
        colors.TryGetValue(value, out backgroundColor);

        return "#" + backgroundColor.R.ToString("X2") + backgroundColor.G.ToString("X2") + backgroundColor.B.ToString("X2");
    }

    public string GetNumberColor(int value)
    {
        System.Drawing.Color backgroundcolor;
        colors.TryGetValue(value, out backgroundcolor);

        int hueTotals = backgroundcolor.R + backgroundcolor.B + backgroundcolor.G;

        return hueTotals > (255 * 3 / 2) ? "#000" : "#fff";
    }
}
