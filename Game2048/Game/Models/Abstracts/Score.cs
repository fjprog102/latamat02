namespace Models;

public abstract class Score
{
    public int Value { get; set; }
    public abstract int UpdateScore(Grid grid);
}
