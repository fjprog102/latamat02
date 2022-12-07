namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class EnterTokyoTest
{
    private readonly Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
    private readonly Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
    private readonly Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
    private readonly Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
    private readonly Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10));

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new EnterTokyo();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<EnterTokyo>)));
    }

    [Fact]
    public void ItShouldNotEnterTokyoAndChangePointsIfDicesDoesntHaveASmashFace()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new EnterTokyo();
        string[] rolledDices = { "energy", "energy", "one", "one", "one", "heart" };

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.True(game.Board!.OutsideTokyo.Exists(player => player.Name == game.ActivePlayerName));
        Assert.Equal(10, playerOne.MyMonster.VictoryPoints);
        Assert.Empty(game.Board!.TokyoCity);
        instance.Execute(rolledDices, game);
        Assert.True(game.Board!.OutsideTokyo.Exists(player => player.Name == game.ActivePlayerName));
        Assert.Equal(10, playerOne.MyMonster.VictoryPoints);
        Assert.Empty(game.Board!.TokyoCity);
    }

    [Fact]
    public void PlayerShouldEnterTokyoCityIfItIsEmptyAndShouldGainOneVictoryPoint()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new EnterTokyo();
        string[] rolledDices = { "smash", "energy", "one", "one", "one", "heart" };

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.True(game.Board!.OutsideTokyo.Exists(player => player.Name == game.ActivePlayerName));
        Assert.Equal(10, playerOne.MyMonster.VictoryPoints);
        Assert.Empty(game.Board!.TokyoCity);
        instance.Execute(rolledDices, game);
        Assert.False(game.Board!.OutsideTokyo.Exists(player => player.Name == game.ActivePlayerName));
        Assert.True(game.Board!.TokyoCity.Exists(player => player.Name == game.ActivePlayerName));
        Assert.Equal(11, playerOne.MyMonster.VictoryPoints);
    }

    [Fact]
    public void PlayerShouldEnterTokyoBayIfItIsEmptyAndShouldGainOneVictoryPoint()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new EnterTokyo();
        string[] rolledDices = { "smash", "energy", "one", "one", "one", "heart" };

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor!.ChangePlayerBoardPlace(playerTwo, game.Board!.OutsideTokyo, game.Board.TokyoCity);

        Assert.True(game.Board!.OutsideTokyo.Exists(player => player.Name == game.ActivePlayerName));
        Assert.Equal(10, playerOne.MyMonster.VictoryPoints);
        Assert.Empty(game.Board!.TokyoBay);
        instance.Execute(rolledDices, game);
        Assert.False(game.Board!.OutsideTokyo.Exists(player => player.Name == game.ActivePlayerName));
        Assert.True(game.Board!.TokyoBay!.Exists(player => player.Name == game.ActivePlayerName));
        Assert.Equal(11, playerOne.MyMonster.VictoryPoints);
    }
}
