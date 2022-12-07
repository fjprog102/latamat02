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
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<GainLifePoints>)));
    }

    [Fact]
    public void ItShouldUpdateTheLifePointsOfThePlayer()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 1));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new GainLifePoints();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        string[] oneHeart = { "one", "two", "heart", "one", "two", "energy" };
        Assert.Equal(1, playerOne.MyMonster.LifePoints);
        instance.Execute(oneHeart, game);
        Assert.Equal(2, playerOne.MyMonster.LifePoints);

        string[] threeHearts = { "heart", "energy", "three", "heart", "two", "heart" };
        instance.Execute(threeHearts, game);
        Assert.Equal(5, playerOne.MyMonster.LifePoints);

        string[] fiveHearts = { "energy", "heart", "heart", "heart", "heart", "heart" };
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
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        string[] fourHearts = { "energy", "two", "heart", "heart", "heart", "heart" };
        var instance = new GainLifePoints();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.Equal(8, playerOne.MyMonster.LifePoints);
        instance.Execute(fourHearts, game);
        Assert.Equal(10, playerOne.MyMonster.LifePoints);

        game.ActivePlayerName = playerThree.Name;
        Assert.Equal(7, playerThree.MyMonster.LifePoints);
        instance.Execute(fourHearts, game);
        Assert.Equal(10, playerThree.MyMonster.LifePoints);

        game.ActivePlayerName = playerFour.Name;
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
        Player playerFive = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        string[] fourHearts = { "energy", "two", "heart", "heart", "heart", "heart" };
        var instance = new GainLifePoints();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        Assert.NotNull(game.Board!.OutsideTokyo!.Find(player => player.Name == game.ActivePlayerName));
        game.BoardProcessor!.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoBay);

        Assert.NotNull(game.Board!.TokyoBay!.Find(player => player.Name == game.ActivePlayerName));
        Assert.Equal(8, playerOne.MyMonster.LifePoints);
        instance.Execute(fourHearts, game);
        Assert.Equal(8, playerOne.MyMonster.LifePoints);

        game.BoardProcessor!.ChangePlayerBoardPlace(playerTwo, originalPlace: game.Board!.OutsideTokyo, game.Board.TokyoCity);
        game.ActivePlayerName = playerTwo.Name;
        Assert.NotNull(game.Board!.TokyoCity.Find(player => player.Name == game.ActivePlayerName));
        instance.Execute(fourHearts, game);
        Assert.Equal(4, playerTwo.MyMonster.LifePoints);

        Assert.Equal(8, playerOne.MyMonster.LifePoints);
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        Assert.Equal(7, playerThree.MyMonster.LifePoints);
    }
}
