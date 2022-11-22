namespace KOF.Models.Test;

using KOF.Models;

public class MonsterTest
{
    private readonly Monster monster = new Monster();

    [Fact]
    public void ShouldReturnPropertyNameAsString()
    {

        monster.Name = "Monster";
        Assert.Equal("Monster", monster.Name);

        monster.Name = "Patrick";
        Assert.Equal("Patrick", monster.Name);

        monster.Name = "CityKitty";
        Assert.Equal("CityKitty", monster.Name);
    }

    [Fact]
    public void ShouldReturnPropertyVictoryPointsAsInt()
    {
        monster.VictoryPoints = 10;
        Assert.Equal(10, monster.VictoryPoints);

        monster.VictoryPoints = 7;
        Assert.Equal(7, monster.VictoryPoints);

        monster.VictoryPoints = 0;
        Assert.Equal(0, monster.VictoryPoints);
    }

    [Fact]
    public void ShouldReturnPropertyLifePointsAsInt()
    {
        monster.LifePoints = 10;
        Assert.Equal(10, monster.LifePoints);

        monster.LifePoints = 0;
        Assert.Equal(0, monster.LifePoints);

        monster.LifePoints = 5;
        Assert.Equal(5, monster.LifePoints);
    }
}
