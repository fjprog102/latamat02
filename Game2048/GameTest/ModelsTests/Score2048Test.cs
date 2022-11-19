namespace ModelsTests;

using Models;

public class Score2048Test
{
    private readonly Score2048 score = new Score2048();

    [Fact]
    public void ItShouldInitiliazeScoreWithValueZero()
    {
        Assert.Equal(0, score.Value);
    }

    [Fact]
    public void ItShouldUpdateScore()
    {
        var grid = new Grid(4, 4);
        grid.InsertElement(2, 2, new Tile(2));
        Assert.Equal(2, score.UpdateScore(grid));
        grid.InsertElement(0, 2, new Tile(4));
        Assert.Equal(6, score.UpdateScore(grid));
        grid.InsertElement(1, 2, new Tile(2));
        Assert.Equal(8, score.UpdateScore(grid));
        grid.InsertElement(2, 3, new Tile(4));
        Assert.Equal(12, score.UpdateScore(grid));
        grid.InsertElement(3, 2, new Tile(2));
        Assert.Equal(14, score.UpdateScore(grid));
        grid.InsertElement(3, 0, new Tile(4));
        Assert.Equal(18, score.UpdateScore(grid));
    }
}
