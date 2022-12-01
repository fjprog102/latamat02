namespace KOT.Controllers.Test;

using KOT.Controllers;
using KOT.Models;

public class DiceAnalyzerTest
{
    private readonly DiceAnalyzer Analyzer = new DiceAnalyzer();

    [Fact]
    public void ItShouldOnlyExecuteGainLifeActionAndUpdateTheLifePoints()
    {
        PlayerPayload player = new PlayerPayload("1", "Jose", new Monster("Gigazaur", 10, 2));
        List<string> oneHeart = new List<string>() { "one", "two", "heart", "one", "two", "three" };

        Assert.Equal(10, player.MyMonster!.VictoryPoints);
        Assert.Equal(2, player.MyMonster!.LifePoints);
        Assert.Equal(0, player.EnergyCubes);
        Analyzer.ResolveDice(oneHeart, player);
        Assert.Equal(10, player.MyMonster!.VictoryPoints);
        Assert.Equal(3, player.MyMonster!.LifePoints);
        Assert.Equal(0, player.EnergyCubes);
    }

    [Fact]
    public void ItShouldOnlyExecuteGainVictoryActionAndUpdateTheVictoryPoints()
    {
        PlayerPayload player = new PlayerPayload("1", "Jose", new Monster("Gigazaur", 10, 10));
        List<string> threeOnes = new List<string>() { "one", "one", "three", "one", "two", "one" };

        Assert.Equal(10, player.MyMonster!.VictoryPoints);
        Assert.Equal(10, player.MyMonster!.LifePoints);
        Assert.Equal(0, player.EnergyCubes);
        Analyzer.ResolveDice(threeOnes, player);
        Assert.Equal(12, player.MyMonster!.VictoryPoints);
        Assert.Equal(10, player.MyMonster!.LifePoints);
        Assert.Equal(0, player.EnergyCubes);
    }

    [Fact]
    public void ItShouldOnlyExecuteGainEnergyActionAndUpdateTheEnergyCubes()
    {
        PlayerPayload player = new PlayerPayload("1", "Jose", new Monster("Gigazaur", 10, 10));
        List<string> fourEnergy = new List<string>() { "energy", "one", "energy", "one", "energy", "energy" };

        Assert.Equal(10, player.MyMonster!.VictoryPoints);
        Assert.Equal(10, player.MyMonster!.LifePoints);
        Assert.Equal(0, player.EnergyCubes);
        Analyzer.ResolveDice(fourEnergy, player);
        Assert.Equal(10, player.MyMonster!.VictoryPoints);
        Assert.Equal(10, player.MyMonster!.LifePoints);
        Assert.Equal(4, player.EnergyCubes);
    }

    [Fact]
    public void ItShouldExecuteAllActionsAndUpdateAttributes()
    {
        PlayerPayload player = new PlayerPayload("1", "Jose", new Monster("Gigazaur", 10, 9));
        List<string> allActions = new List<string>() { "two", "two", "energy", "two", "heart", "smash" };

        Assert.Equal(10, player.MyMonster!.VictoryPoints);
        Assert.Equal(9, player.MyMonster!.LifePoints);
        Assert.Equal(0, player.EnergyCubes);
        Analyzer.ResolveDice(allActions, player);
        Assert.Equal(12, player.MyMonster!.VictoryPoints);
        Assert.Equal(10, player.MyMonster!.LifePoints);
        Assert.Equal(1, player.EnergyCubes);
    }
}
