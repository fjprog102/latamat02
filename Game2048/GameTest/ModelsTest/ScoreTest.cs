namespace ModelsTests;

using Models;

public class ScoreTest
{
    private readonly Score score = new Score();

    [Fact]
    public void ItShouldInitiliazeScoreWithValueZero()
    {
        Assert.Equal(0, score.Value);
    }

    [Fact]
    public void ItShouldSumPointsToTheScore()
    {
        Assert.Equal(0, score.Value);
        score.AddScore(16);
        Assert.Equal(16, score.Value);
        score.AddScore(24);
        Assert.Equal(40, score.Value);
        score.AddScore(256);
        Assert.Equal(296, score.Value);
    }

    [Fact]
    public void ItShouldRestPointsToTheScore()
    {
        Assert.Equal(0, score.Value);
        score.AddScore(256);
        Assert.Equal(256, score.Value);
        score.AddScore(-124);
        Assert.Equal(132, score.Value);
        score.AddScore(-132);
        Assert.Equal(0, score.Value);
    }

    [Fact]
    public void ItShouldReturnValueToZeroWhenIsNegative()
    {
        Assert.Equal(0, score.Value);
        score.AddScore(-10);
        Assert.Equal(0, score.Value);
        score.AddScore(-124);
        Assert.Equal(0, score.Value);
    }
}
