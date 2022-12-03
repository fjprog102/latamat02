namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

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
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 1));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), playerOne.Name);
        var instance = new GainLifePoints();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        List<string> oneHeart = new List<string>() { "one", "two", "heart", "one", "two", "energy" };
        Assert.Equal(1, playerOne.MyMonster.LifePoints);
        instance.Execute(oneHeart, game);
        Assert.Equal(2, playerOne.MyMonster.LifePoints);

        List<string> threeHearts = new List<string>() { "heart", "energy", "three", "heart", "two", "heart" };
        instance.Execute(threeHearts, game);
        Assert.Equal(5, playerOne.MyMonster.LifePoints);

        List<string> fiveHearts = new List<string>() { "energy", "heart", "heart", "heart", "heart", "heart" };
        instance.Execute(fiveHearts, game);
        Assert.Equal(10, playerOne.MyMonster.LifePoints);
    }

    [Fact]
    public void UpdateLimitShouldBeTen()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 8));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 4));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 7));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), playerOne.Name);
        List<string> fourHearts = new List<string>() { "energy", "two", "heart", "heart", "heart", "heart" };
        var instance = new GainLifePoints();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.Equal(8, playerOne.MyMonster.LifePoints);
        instance.Execute(fourHearts, game);
        Assert.Equal(10, playerOne.MyMonster.LifePoints);

        game.ActiveUserName = playerThree.Name;
        Assert.Equal(7, playerThree.MyMonster.LifePoints);
        instance.Execute(fourHearts, game);
        Assert.Equal(10, playerThree.MyMonster.LifePoints);

        game.ActiveUserName = playerFour.Name;
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        instance.Execute(fourHearts, game);
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        Assert.Equal(10, playerOne.MyMonster.LifePoints);
        Assert.Equal(10, playerThree.MyMonster.LifePoints);
        Assert.Equal(4, playerTwo.MyMonster.LifePoints);
    }

    [Fact]
    public void ItShouldNotUpdateLifePointsIfPlayerIsNotOutsideTokyo()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 8));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 4));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 7));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), playerOne.Name);
        List<string> fourHearts = new List<string>() { "energy", "two", "heart", "heart", "heart", "heart" };
        var instance = new GainLifePoints();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoBay);

        Assert.Equal(8, playerOne.MyMonster.LifePoints);
        instance.Execute(fourHearts, game);
        Assert.Equal(8, playerOne.MyMonster.LifePoints);

        game.BoardProcessor!.ChangePlayerBoardPlace(playerOne, originalPlace: game.Board!.TokyoBay, game.Board.TokyoCity);
        instance.Execute(fourHearts, game);
        Assert.Equal(8, playerOne.MyMonster.LifePoints);
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        Assert.Equal(7, playerThree.MyMonster.LifePoints);
        Assert.Equal(4, playerTwo.MyMonster.LifePoints);
    }
}
