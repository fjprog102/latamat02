namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class GainEnergyCubeTest
{
    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new GainEnergyCube();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(PlayerAction<GainEnergyCube>)));
    }

    [Fact]
    public void ItShouldUpdateTheEnergyCubesOfThePlayers()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), playerOne.Name);

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        List<string> oneEnergy = new List<string>() { "one", "two", "heart", "one", "two", "energy" };
        var instance = new GainEnergyCube();

        Assert.Equal(0, playerOne.EnergyCubes);
        instance.Execute(oneEnergy, game);
        Assert.Equal(1, playerOne.EnergyCubes);
        List<string> threeEnergy = new List<string>() { "energy", "energy", "three", "smash", "two", "energy" };
        instance.Execute(threeEnergy, game);
        Assert.Equal(4, playerOne.EnergyCubes);
        List<string> sixEnergy = new List<string>() { "energy", "energy", "energy", "energy", "energy", "energy" };
        instance.Execute(sixEnergy, game);
        Assert.Equal(10, playerOne.EnergyCubes);

        game.ActiveUserName = playerTwo.Name;
        List<string> fiveEnergy = new List<string>() { "energy", "two", "energy", "energy", "energy", "energy" };
        instance.Execute(fiveEnergy, game);
        Assert.Equal(5, playerTwo.EnergyCubes);

        Assert.Equal(expected: 10, playerOne.EnergyCubes);
        Assert.Equal(0, playerThree.EnergyCubes);
        Assert.Equal(0, playerFour.EnergyCubes);
    }
}
