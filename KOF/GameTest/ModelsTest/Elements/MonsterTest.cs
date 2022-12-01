namespace KOT.Models.Test;

using KOT.Models;

public class MonsterTest
{
    private readonly Monster monster = new Monster("Monster", 10, 10);

    [Fact]
    public void ShouldReturnPropertyIdAsNull()
    {
        Assert.True(monster.Id == null);
    }

    [Fact]
    public void ShouldReturnPropertyNameAsString()
    {
        Assert.Equal("Monster", monster.Name);
    }

    [Fact]
    public void ShouldReturnPropertyVictoryPointsAsInt()
    {
        Assert.Equal(10, monster.VictoryPoints);
    }

    [Fact]
    public void ShouldReturnPropertyLifePointsAsInt()
    {
        Assert.Equal(10, monster.LifePoints);
    }
}
