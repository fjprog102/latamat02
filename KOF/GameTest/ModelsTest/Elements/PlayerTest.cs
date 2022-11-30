using KOT.Models;
using KOT.Models.Abstracts;

namespace KOT.Models.Test;

public class PlayerTest
{
    private readonly Player player1 = new Player("Pablo", new Monster("monster1", 10, 10));

    [Fact]
    public void ShouldReturnPropertyIdAsString()
    {
        Assert.True(player1.IdAttr?.Length > 0);
        Assert.IsType<string>(player1.IdAttr);
    }

    [Fact]
    public void ShouldReturnPropertyNameAsString()
    {
        Assert.Equal("Pablo", player1.NameAttr);
    }

    [Fact]
    public void ShouldReturnMonsterAsObjectWhenMonsterIsDeclared()
    {
        Assert.False(object.ReferenceEquals(null, player1.MonsterAttr));
    }

    [Fact]
    public void ShouldReturnMonsterAsNullWhenMonsterIsNotDeclared()
    {
        Player player2 = new Player("Player2", null);
        Assert.True(object.ReferenceEquals(null, player2.MonsterAttr));
    }
}
