namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class SmashMonstersTest
{

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new SmashMonsters();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<SmashMonsters>)));
    }

    [Fact]
    public void ItShouldNotSmashAnyMonster()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new SmashMonsters();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        string[] smashThree = { "smash", "smash", "two", "two", "smash", "two" };
        instance.Execute(smashThree, game);
        Assert.Equal(10, playerOne.MyMonster?.LifePoints);
        Assert.Equal(10, playerTwo.MyMonster?.LifePoints);
        Assert.Equal(10, playerThree.MyMonster?.LifePoints);
        Assert.Equal(10, playerFour.MyMonster?.LifePoints);

        game.BoardProcessor.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.BoardProcessor.ChangePlayerBoardPlace(playerTwo, game.Board!.OutsideTokyo, game.Board.TokyoCity);
        game.BoardProcessor.ChangePlayerBoardPlace(playerThree, game.Board!.OutsideTokyo, game.Board.TokyoCity);
        game.BoardProcessor.ChangePlayerBoardPlace(playerFour, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.BoardProcessor.ChangePlayerBoardPlace(playerFive, game.Board!.OutsideTokyo, game.Board.TokyoBay);

        instance.Execute(smashThree, game);
        Assert.Equal(10, playerOne.MyMonster?.LifePoints);
        Assert.Equal(10, playerTwo.MyMonster?.LifePoints);
        Assert.Equal(10, playerThree.MyMonster?.LifePoints);
        Assert.Equal(10, playerFour.MyMonster?.LifePoints);
    }

    [Fact]
    public void ItShouldSmashPlayersTwoAndFourInsideTokyo()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new SmashMonsters();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor.ChangePlayerBoardPlace(playerTwo, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.BoardProcessor.ChangePlayerBoardPlace(playerFour, game.Board.OutsideTokyo, game.Board.TokyoCity);

        string[] smashThree = { "smash", "smash", "two", "two", "smash", "two" };
        instance.Execute(smashThree, game);
        Assert.Equal(10, playerOne.MyMonster?.LifePoints);
        Assert.Equal(7, playerTwo.MyMonster?.LifePoints);
        Assert.Equal(10, playerThree.MyMonster?.LifePoints);
        Assert.Equal(7, playerFour.MyMonster?.LifePoints);
        Assert.Equal(10, playerFive.MyMonster?.LifePoints);
    }

    [Fact]
    public void ItShouldSmashPlayersPlacedOutsideTokyo()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new SmashMonsters();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoBay);

        string[] smashThree = { "smash", "smash", "two", "two", "smash", "two" };
        instance.Execute(smashThree, game);
        Assert.Equal(10, playerOne.MyMonster?.LifePoints);
        Assert.Equal(7, playerTwo.MyMonster?.LifePoints);
        Assert.Equal(7, playerThree.MyMonster?.LifePoints);
        Assert.Equal(7, playerFour.MyMonster?.LifePoints);
        Assert.Equal(7, playerFive.MyMonster?.LifePoints);
    }
}
