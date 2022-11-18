namespace Models;

public class Score2048 : Score
{
    public new int Value;

    public override void UpdateScore(int points)
    {
        Value = points;
        if (Value < 0)
        {
            Value = 0;
        }
    }

    public Score2048()
    {
        Value = 0;
    }
}
