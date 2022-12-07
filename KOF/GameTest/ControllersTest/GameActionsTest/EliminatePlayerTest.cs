namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class EliminatePlayerTest
{

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new EliminatePlayer();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<EliminatePlayer>)));
    }

    [Fact]
    public void ItShouldRemovePlayersFromBoardPlace()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 0));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 0));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Joaquin", new Monster("Gigazaur", 10, 0));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name, players);
        var instance = new EliminatePlayer();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerThree, game.Board!.OutsideTokyo, game.Board.TokyoCity);

        instance.RemovePlayer(game.Board.OutsideTokyo, game.Players!);
        instance.RemovePlayer(game.Board.TokyoBay!, game.Players!);
        instance.RemovePlayer(game.Board.TokyoCity, game.Players!);

        Assert.DoesNotContain(playerOne, game.Board.OutsideTokyo);
        Assert.DoesNotContain(playerOne, game.Board.TokyoBay);
        Assert.DoesNotContain(playerOne, game.Board.TokyoCity);
        Assert.DoesNotContain(playerOne, game.Players);
        Assert.DoesNotContain(playerThree, game.Board.OutsideTokyo);
        Assert.DoesNotContain(playerThree, game.Board.TokyoBay);
        Assert.DoesNotContain(playerThree, game.Board.TokyoCity);
        Assert.DoesNotContain(expected: playerThree, game.Players);
        Assert.DoesNotContain(playerFive, game.Board.OutsideTokyo);
        Assert.DoesNotContain(playerFive, game.Board.TokyoBay);
        Assert.DoesNotContain(playerFive, game.Board.TokyoCity);
        Assert.DoesNotContain(playerFive, game.Players);
    }

    [Fact]
    public void ItShouldMovePlayersToTokyoBayToTokyoCity()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 0));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name, players);
        var instance = new EliminatePlayer();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerThree, game.Board!.OutsideTokyo, game.Board.TokyoCity);

        instance.RemovePlayer(game.Board.TokyoCity, game.Players!);

        Assert.DoesNotContain(playerThree, game.Board.OutsideTokyo);
        Assert.DoesNotContain(playerThree, game.Board.TokyoBay);
        Assert.DoesNotContain(playerThree, game.Board.TokyoCity);
        Assert.DoesNotContain(playerThree, game.Players);

        Assert.Single(game.Board.TokyoBay!);
        Assert.Equal(playerOne, game.Board.TokyoBay!.First());
        instance.MovePlayersFromTokyoBayToTokyoCity(game);
        Assert.Empty(game.Board.TokyoBay!);
        Assert.Contains(playerOne, game.Board.TokyoCity);
    }

    [Fact]
    public void ItShouldRemovePlayersFromGameAndNullTokyoBay()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 0));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 0));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 0));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name, players);
        var instance = new EliminatePlayer();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerTwo, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerThree, game.Board!.OutsideTokyo, game.Board.TokyoCity);

        instance.Execute(null!, game);

        Assert.Null(game.Board.TokyoBay);
        Assert.DoesNotContain(playerOne, game.Board.OutsideTokyo);
        Assert.DoesNotContain(playerOne, game.Board.TokyoCity);
        Assert.DoesNotContain(playerOne, game.Players!);
        Assert.DoesNotContain(playerThree, game.Board.OutsideTokyo);
        Assert.DoesNotContain(playerThree, game.Board.TokyoCity);
        Assert.DoesNotContain(playerThree, game.Players!);
        Assert.DoesNotContain(playerFive, game.Board.OutsideTokyo);
        Assert.DoesNotContain(playerFive, game.Board.TokyoCity);
        Assert.DoesNotContain(playerFive, game.Players!);
        Assert.Contains(playerTwo, game.Board.TokyoCity);
    }
}
