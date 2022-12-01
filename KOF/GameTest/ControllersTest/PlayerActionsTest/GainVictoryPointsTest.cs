namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;

public class GainVictoryPointsTest
{

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new GainVictoryPoints();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(PlayerAction<GainVictoryPoints>)));
    }

    [Fact]
    public void ItShouldUpdateTheVictoryPointsOfThePlayer()
    {
        PlayerPayload player = new PlayerPayload("1", "Jose", new Monster("Gigazaur", 10, 10));
        List<string> fourTwos = new List<string>() { "one", "two", "two", "two", "smash", "two" };
        var instance = new GainVictoryPoints();

        Assert.Equal(10, player.MyMonster?.VictoryPoints);
        instance.Execute(fourTwos, player);
        Assert.Equal(13, player.MyMonster?.VictoryPoints);

        List<string> threeOnes = new List<string>() { "one", "one", "three", "smash", "two", "one" };
        instance.Execute(threeOnes, player);
        Assert.Equal(14, player.MyMonster?.VictoryPoints);

        List<string> sixThrees = new List<string>() { "three", "three", "three", "three", "three", "three" };
        instance.Execute(sixThrees, player);
        Assert.Equal(20, player.MyMonster?.VictoryPoints);
    }
}
