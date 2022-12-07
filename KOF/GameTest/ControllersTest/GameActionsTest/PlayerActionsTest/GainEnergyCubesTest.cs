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
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<GainEnergyCube>)));
    }

    [Fact]
    public void ItShouldUpdateTheEnergyCubesOfThePlayers()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        string[] oneEnergy = { "one", "two", "heart", "one", "two", "energy" };
        var instance = new GainEnergyCube();

        Assert.NotNull(game.Board!.OutsideTokyo.Find(player => player.Name == game.ActivePlayerName));
        Assert.Equal(0, playerOne.EnergyCubes);
        instance.Execute(oneEnergy, game);
        Assert.Equal(1, playerOne.EnergyCubes);
        string[] threeEnergy = { "energy", "energy", "three", "smash", "two", "energy" };
        instance.Execute(threeEnergy, game);
        Assert.Equal(4, playerOne.EnergyCubes);
        string[] sixEnergy = { "energy", "energy", "energy", "energy", "energy", "energy" };
        instance.Execute(sixEnergy, game);
        Assert.Equal(10, playerOne.EnergyCubes);

        game.BoardProcessor!.ChangePlayerBoardPlace(playerTwo, game.Board!.OutsideTokyo, game.Board.TokyoCity);
        game.ActivePlayerName = playerTwo.Name;
        string[] fiveEnergy = { "energy", "two", "energy", "energy", "energy", "energy" };
        Assert.NotNull(game.Board!.TokyoCity.Find(player => player.Name == game.ActivePlayerName));
        instance.Execute(fiveEnergy, game);
        Assert.Equal(5, playerTwo.EnergyCubes);

        game.BoardProcessor!.ChangePlayerBoardPlace(playerThree, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.ActivePlayerName = playerThree.Name;
        string[] twoEnergy = { "energy", "two", "one", "three", "smash", "energy" };
        Assert.NotNull(game.Board.TokyoBay!.Find(player => player.Name == game.ActivePlayerName));
        instance.Execute(twoEnergy, game);
        Assert.Equal(2, playerThree.EnergyCubes);

        Assert.Equal(5, playerTwo.EnergyCubes);
        Assert.Equal(expected: 10, playerOne.EnergyCubes);
        Assert.Equal(0, playerFour.EnergyCubes);
    }
}
