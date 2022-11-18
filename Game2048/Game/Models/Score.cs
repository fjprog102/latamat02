namespace Models;

public class Score
{
    public int Value = 0;

    public void AddScore(int points)
    {
        Value += points;
        if (Value < 0)
        {
            Value = 0;
        }
    }
}
