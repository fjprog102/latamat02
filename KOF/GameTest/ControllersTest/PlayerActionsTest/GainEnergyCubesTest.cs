namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;

public class GainEnergyCubeTest
{
    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new GainEnergyCube();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(PlayerAction<GainEnergyCube>)));
    }

    [Fact]
    public void ItShouldUpdateTheEnergyCubesOfThePlayer()
    {
        PlayerPayload player = new PlayerPayload("1", "Jose", new Monster("Gigazaur", 10, 10));
        List<string> oneEnergy = new List<string>() { "one", "two", "heart", "one", "two", "energy" };
        var instance = new GainEnergyCube();

        Assert.Equal(0, player.EnergyCubes);
        instance.Execute(oneEnergy, player);
        Assert.Equal(1, player.EnergyCubes);

        List<string> threeEnergy = new List<string>() { "energy", "energy", "three", "smash", "two", "energy" };
        instance.Execute(threeEnergy, player);
        Assert.Equal(4, player.EnergyCubes);

        List<string> sixEnergy = new List<string>() { "energy", "energy", "energy", "energy", "energy", "energy" };
        instance.Execute(sixEnergy, player);
        Assert.Equal(10, player.EnergyCubes);
    }
}
