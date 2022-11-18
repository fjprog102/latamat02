namespace Models;

public class Tile : GridElement
{
    private static readonly Random random = new Random();
    private static readonly Dictionary<int, System.Drawing.Color> colors = new Dictionary<int, System.Drawing.Color>();
    public int? Value { get; set; }
    public string? BackgroundColor
    {
        get
        {
            if (!Value.HasValue)
            {
                return "#fff";
            }
            else if (!colors.ContainsKey(Value.Value))
            {
                colors.Add(Value.Value, System.Drawing.Color.FromArgb(random.Next(0, 256), random.Next(0, 256), random.Next(0, 256)));
            }

            System.Drawing.Color color = colors[Value.Value];
            return "#" + color.R.ToString("X2") + color.G.ToString("X2") + color.B.ToString("X2");
        }
    }

    public string? NumberColor
    {
        get
        {
            if (!Value.HasValue)
            {
                return "#fff";
            }

            System.Drawing.Color backgroundcolor = colors[Value.Value];
            int hueTotals = backgroundcolor.R + backgroundcolor.B + backgroundcolor.G;
            return hueTotals > (255 * 3 / 2) ? "#000" : "#fff";
        }
    }

    public Tile(int value)
    {
        if (value % 2 != 0)
        {
            throw new ArgumentException("Tile value must be a multiple of two");
        }

        Value = value;
    }
}
