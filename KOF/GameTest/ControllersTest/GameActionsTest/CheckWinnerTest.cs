namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class CheckWinnerrTest
{

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new CheckWinner();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<CheckWinner>)));
    }

    [Fact]
    public void ItShouldReturnTheWinnersName()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 20, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name, players, "");
        var instance = new CheckWinner();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerThree, game.Board!.OutsideTokyo, game.Board.TokyoCity);

        Assert.Equal("", instance.CheckWinnerInBoardPlace(game.Board.OutsideTokyo));
        Assert.Equal("Adriel", instance.CheckWinnerInBoardPlace(game.Board.TokyoCity));
        Assert.Equal("", instance.CheckWinnerInBoardPlace(game.Board.TokyoBay!));
    }

    [Fact]
    public void PlayerOneShouldWinTheGame()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 23, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name, players, "");
        var instance = new CheckWinner();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoCity);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerThree, game.Board!.OutsideTokyo, game.Board.TokyoBay);

        instance.Execute(null!, game);
        Assert.Equal(playerOne.Name, game.Winner);
    }
}
