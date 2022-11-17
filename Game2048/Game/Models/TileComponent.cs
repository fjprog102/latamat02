namespace Game2048.Models;

// public class Tile : GridElement
public class Tile
{
    public int Value { get; set; }
    public string BackgroundColor
    {
        get
        {
            if (Value <= 1)
            {
                return "#fff";
            }
            else if (Value <= 3)
            {
                return "#aaa";
            }
            else if (Value <= 5)
            {
                return "#aa0";
            }

            return "#a00";
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
