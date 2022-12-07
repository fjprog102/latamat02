namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class GainVictoryPointsTest
{

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new GainVictoryPoints();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<GainVictoryPoints>)));
    }

    [Fact]
    public void ItShouldReturnTheVictoryLifePointsOfTheDices()
    {
        var instance = new GainVictoryPoints();

        string[] threePoints = { "one", "two", "two", "two", "smash", "two" };
        Assert.Equal(3, instance.CountVictoryPoints(threePoints));
        string[] onePoint = { "one", "one", "three", "smash", "two", "one" };
        Assert.Equal(1, instance.CountVictoryPoints(onePoint));
        string[] sixPoints = { "three", "three", "three", "three", "three", "three" };
        Assert.Equal(6, instance.CountVictoryPoints(sixPoints));
        string[] zeroPoints = { "two", "two", "smash", "smash", "heart", "energy" };
        Assert.Equal(0, instance.CountVictoryPoints(zeroPoints));
    }

    [Fact]
    public void ItShouldUpdateTheVictoryPointsOfThePlayer()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new GainVictoryPoints();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.NotNull(game.Board!.OutsideTokyo.Find(player => player.Name == game.ActivePlayerName));
        Assert.Equal(10, playerOne.MyMonster?.VictoryPoints);
        string[] fourTwos = { "one", "two", "two", "two", "smash", "two" };
        instance.Execute(fourTwos, game);
        Assert.Equal(13, playerOne.MyMonster?.VictoryPoints);

        game.BoardProcessor!.ChangePlayerBoardPlace(playerTwo, game.Board!.OutsideTokyo, game.Board.TokyoCity);
        game.ActivePlayerName = playerTwo.Name;
        Assert.NotNull(game.Board!.TokyoCity.Find(player => player.Name == game.ActivePlayerName));
        string[] threeOnes = { "one", "one", "three", "smash", "two", "one" };
        instance.Execute(threeOnes, game);
        Assert.Equal(11, playerTwo.MyMonster?.VictoryPoints);

        game.BoardProcessor!.ChangePlayerBoardPlace(playerThree, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.ActivePlayerName = playerThree.Name;
        Assert.NotNull(game.Board.TokyoBay!.Find(player => player.Name == game.ActivePlayerName));
        string[] sixThrees = { "three", "three", "three", "three", "three", "three" };
        instance.Execute(sixThrees, game);
        Assert.Equal(13, playerOne.MyMonster?.VictoryPoints);
        Assert.Equal(11, playerTwo.MyMonster?.VictoryPoints);
        Assert.Equal(16, playerThree.MyMonster?.VictoryPoints);
        Assert.Equal(10, playerFour.MyMonster?.VictoryPoints);
    }
}
