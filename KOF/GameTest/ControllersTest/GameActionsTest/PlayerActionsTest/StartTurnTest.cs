namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class StartTurnTest
{
    private readonly Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
    private readonly Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
    private readonly Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
    private readonly Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
    private readonly Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10));

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new StartTurn();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<StartTurn>)));
    }

    [Fact]
    public void ItShouldNotUpdateVictoryPointsIfPlayerIsOutsideTokyo()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new StartTurn();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.Equal(10, playerOne.MyMonster.VictoryPoints);
        Assert.True(game.Board!.OutsideTokyo.Exists(player => player.Name == game.ActivePlayerName));
        instance.Execute(null!, game);
        Assert.Equal(10, playerOne.MyMonster.VictoryPoints);
    }

    [Fact]
    public void ItShouldUpdateVictoryPointsIfPlayerIsInTokyoBay()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new StartTurn();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoBay);

        Assert.Equal(10, playerOne.MyMonster.VictoryPoints);
        Assert.True(game.Board!.TokyoBay!.Exists(player => player.Name == game.ActivePlayerName));
        instance.Execute(null!, game);
        Assert.Equal(12, playerOne.MyMonster.VictoryPoints);
    }

    [Fact]
    public void ItShouldUpdateVictoryPointsIfPlayerIsInTokyoCity()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new StartTurn();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoCity);

        Assert.Equal(10, playerOne.MyMonster.VictoryPoints);
        Assert.True(game.Board!.TokyoCity!.Exists(player => player.Name == game.ActivePlayerName));
        instance.Execute(null!, game);
        Assert.Equal(12, playerOne.MyMonster.VictoryPoints);
    }
}
