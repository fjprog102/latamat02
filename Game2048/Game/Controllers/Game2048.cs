namespace Controllers;

using Models;

public class Game2048
{
    public Grid grid;

    public Score score;

    public int BestScore { get; set; } = 0;

    public Game2048()
    {
        grid = new Grid(4, 4);
        score = new Score2048();
        grid.GenerateRandomTile();
        grid.GenerateRandomTile();
    }

    public void Restart()
    {
        TileColors.Colors.Clear();
        UpdateBestScore();
        grid = new Grid(4, 4);
        score = new Score2048();
        grid.GenerateRandomTile();
        grid.GenerateRandomTile();
    }

    public void UpdateBestScore()
    {
        if (score.Value > BestScore)
        {
            BestScore = score.Value;
        }
    }
}

