namespace Models;

public class Tile : GridElement
{
    private readonly TileColors _tileColors = new TileColors();
    public new int Value { get; set; }
    public string? BackgroundColor;
    public string? NumberColor;
    public bool IsNewTile { get; set; }

    public Tile(int value)
    {
        if (value % 2 != 0)
        {
            throw new ArgumentException("Tile value must be a multiple of two");
        }

        Value = value;
        IsNewTile = true;
        BackgroundColor = _tileColors.GetBackgroundColor(value);
        NumberColor = _tileColors.GetNumberColor(value);
    }
}
