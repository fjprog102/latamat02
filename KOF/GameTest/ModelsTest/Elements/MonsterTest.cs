namespace KOT.Models.Test;

using KOT.Models;

public class MonsterTest
{
    private readonly Monster monster = new Monster("Monster", 10, 10);

    [Fact]
    public void ShouldReturnPropertyIdAsString()
    {
        Assert.Equal("123", monster.IdAttr);
    }

    [Fact]
    public void ShouldReturnPropertyNameAsString()
    {
        Assert.Equal("Monster", monster.NameAttr);
    }

    [Fact]
    public void ShouldReturnPropertyVictoryPointsAsInt()
    {
        Assert.Equal(10, monster.VictoryPointsAttr);
    }

    [Fact]
    public void ShouldReturnPropertyLifePointsAsInt()
    {
        Assert.Equal(10, monster.LifePointsAttr);
    }
}
