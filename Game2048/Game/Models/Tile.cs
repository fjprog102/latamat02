namespace Models;

public class Tile : GridElement
{
    private readonly TileColors _tileColors = new TileColors();

    public Tile(int value)
    {
        if (value % 2 != 0)
        {
            throw new ArgumentException("Tile value must be a multiple of two");
        }

        Value = value;
        BackgroundColor = _tileColors.GetBackgroundColor(value);
        NumberColor = _tileColors.GetNumberColor(value);
    }

    // public void IncreaseValue()
    // {
    //     Value = Value * 2;
    // }
}
