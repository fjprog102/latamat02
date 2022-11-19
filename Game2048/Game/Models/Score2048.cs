namespace Models;

public class Score2048 : Score
{
    public override int UpdateScore(Grid grid)
    {
        Value = 0;
        for (int index = 0; index < grid.Cells.GetLength(0); index++)
        {
            for (int j = 0; j < grid.Cells.GetLength(1); j++)
            {
                if (grid.Cells[index, j]?.Value > 0)
                {
                    Value += grid.Cells[index, j].Value;
                }
            }
        }

        return Value;
    }

    public Score2048()
    {
        Value = 0;
    }
}
