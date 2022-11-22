namespace Models.Abstracts;

public abstract class Dice
{
    public List<string> Faces = new List<string>();
    public string[]? Symbols { get; set; }
}
