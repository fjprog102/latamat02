namespace ModelsTests;

using Controllers;
using Models;

public class Game2048Test
{
    private readonly Game2048 game = new Game2048();

    [Fact]
    public void ItShouldInitializeAGameWithA4x4SquareGrid()
    {
        Assert.Equal(4, game.grid.Columns);
        Assert.Equal(4, game.grid.Rows);
    }

    [Fact]
    public void ItShouldInitializeAGameWithScoresAt0()
    {
        Assert.Equal(0, game.BestScore);
        Assert.Equal(0, game.score.Value);
    }

    [Fact]
    public void ItShouldInitializeAGameWithTwoRandomTiles()
    {
        int count = 0;

        for (int index = 0; index < game.grid.Cells.GetLength(0); index++)
        {
            for (int j = 0; j < game.grid.Cells.GetLength(1); j++)
            {
                if (game.grid.Cells[index, j] is Tile)
                {
                    count++;
                }
            }
        }

        Assert.Equal(2, count);
    }

    [Fact]
    public void ItShouldUpdateBestScoreWhenGameIsRestarted()
    {
        Game2048 newGame = new Game2048();
        newGame.grid.GenerateRandomTile();
        newGame.grid.GenerateRandomTile();
        newGame.grid.GenerateRandomTile();
        newGame.grid.GenerateRandomTile();
        newGame.score.UpdateScore(newGame.grid);

        int bestScore = newGame.score.Value;
        newGame.Restart();
        Assert.Equal(bestScore, newGame.BestScore);
    }
}
