namespace KOT.Models.Test;

using KOT.Models;

public class MonsterTest
{
    private readonly Monster monster = new Monster();

    [Fact]
    public void ShouldReturnPropertyIdAsInt()
    {
        monster.Id = 1;
        Assert.Equal(1, monster.Id);

        Monster monster2 = new Monster();
        monster2.Id = 2;
        Assert.Equal(2, monster2.Id);

        Monster monster3 = new Monster();
        monster3.Id = 3;
        Assert.Equal(3, monster3.Id);
    }

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
