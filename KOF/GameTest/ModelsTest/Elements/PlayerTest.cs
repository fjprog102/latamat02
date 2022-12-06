using KOT.Models.Processor;

namespace KOT.Models.Test;

public class PlayerTest
{
    private readonly Player player1 = new Player(
        "Pablo",
        new Monster("monster1", 10, 10),
        14,
        new List<CardDetails>()
        {
            new CardDetails(new PowerCard("Energize", 8, 1), new Effect(energyPoints: 9))
        }
    );

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
    public void ShouldReturnPowerCardsAsListOfCardDetails()
    {
        Assert.IsType<List<CardDetails>>(player1.PowerCards);
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
