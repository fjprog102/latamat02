namespace Models;

public abstract class Score
{
    public int Value { get; set; }
    public abstract void UpdateScore(int points);
}
