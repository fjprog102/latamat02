using KOT.Models;
using KOT.Models.Abstracts;

namespace KOT.Models.Test;

public class PlayerTest
{
    private readonly Player player1 = new Player("Pablo", new Monster("monster1", 10, 10), 14, null);

    [Fact]
    public void ShouldReturnPropertyNameAsString()
    {
        Assert.Equal("Pablo", player1.Name);
    }

    [Fact]
    public void ShouldReturnMonsterAsObjectWhenMonsterIsDeclared()
    {
        Assert.False(object.ReferenceEquals(null, player1.MyMonster));
    }

    [Fact]
    public void ShouldReturnMonsterAsNullWhenMonsterIsNotDeclared()
    {
        Player player2 = new Player("Player2", null!);
        Assert.True(object.ReferenceEquals(null, player2.MyMonster));
    }
    [Fact]
    public void ShouldReturnEnergyCubesAsIntIsDeclared()
    {
        Assert.Equal(14, player1.EnergyCubes);
    }

    [Fact]
    public void ShouldReturnEnergyCubesAsZeroWhenEnergyCubesIsNotDeclared()
    {
        Player player2 = new Player("Player2", null!);
        Assert.Equal(0, player2.EnergyCubes);
    }

    [Fact]
    public void ShouldReturnPowerCardsAsListOfPowercards()
    {
        Assert.IsType<List<PowerCard>>(player1.PowerCards);
        Assert.False(object.ReferenceEquals(null, player1.PowerCards));
    }
    [Fact]
    public void ShouldReturnPowerCardsAsNull()
    {
        Player player2 = new Player("Player2", null!);
        Assert.True(object.ReferenceEquals(null, player2.PowerCards));
    }
    [Fact]
    public void ShouldReturnIdAsNull()
    {
        Assert.True(player1.Id! == null);
    }
}
