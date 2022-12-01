namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;

public class GainLifePointsTest
{
    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new GainLifePoints();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(PlayerAction<GainLifePoints>)));
    }

    [Fact]
    public void ItShouldUpdateTheLifePointsOfThePlayer()
    {
        PlayerPayload player = new PlayerPayload("1", "Jose", new Monster("Gigazaur", 10, 1));
        List<string> oneHeart = new List<string>() { "one", "two", "heart", "one", "two", "energy" };
        var instance = new GainLifePoints();

        Assert.Equal(1, player.MyMonster?.LifePoints);
        instance.Execute(oneHeart, player);
        Assert.Equal(2, player.MyMonster?.LifePoints);

        List<string> threeHearts = new List<string>() { "heart", "energy", "three", "heart", "two", "heart" };
        instance.Execute(threeHearts, player);
        Assert.Equal(5, player.MyMonster?.LifePoints);

        List<string> fiveHearts = new List<string>() { "energy", "heart", "heart", "heart", "heart", "heart" };
        instance.Execute(fiveHearts, player);
        Assert.Equal(10, player.MyMonster?.LifePoints);
    }

    [Fact]
    public void UpdateLimitShouldBeTen()
    {
        PlayerPayload player = new PlayerPayload("1", "Jose", new Monster("Gigazaur", 10, 8));
        List<string> fourHearts = new List<string>() { "one", "heart", "heart", "heart", "heart", "energy" };
        var instance = new GainLifePoints();

        Assert.Equal(8, player.MyMonster?.LifePoints);
        instance.Execute(fourHearts, player);
        Assert.Equal(10, player.MyMonster?.LifePoints);
    }
}
