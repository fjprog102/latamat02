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
    public void ItShouldChangeTheScore()
    {
        Assert.Equal(0, score.Value);
        score.UpdateScore(16);
        Assert.Equal(16, score.Value);
        score.UpdateScore(24);
        Assert.Equal(24, score.Value);
        score.UpdateScore(256);
        Assert.Equal(256, score.Value);
    }

    [Fact]
    public void ItShouldReturnValueToZeroWhenIsNegative()
    {
        Assert.Equal(0, score.Value);
        score.UpdateScore(-10);
        Assert.Equal(0, score.Value);
        score.UpdateScore(-124);
        Assert.Equal(0, score.Value);
    }
}
