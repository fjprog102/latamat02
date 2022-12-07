namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class EndTurnTest
{

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new EndTurn();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<EndTurn>)));
    }

    [Fact]
    public void ItShouldChangeTheActivePlayerToTheNext()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name, players);
        var instance = new EndTurn();

        Assert.Equal("Jose", game.ActivePlayerName);
        instance.Execute(null!, game);
        Assert.Equal("Juan", game.ActivePlayerName);
        instance.Execute(null!, game);
        Assert.Equal("Adriel", game.ActivePlayerName);
        instance.Execute(null!, game);
        Assert.Equal("Jorge", game.ActivePlayerName);
        instance.Execute(null!, game);
        Assert.Equal("Jose", game.ActivePlayerName);
        instance.Execute(null!, game);
        Assert.Equal("Juan", game.ActivePlayerName);
        instance.Execute(null!, game);
        Assert.Equal("Adriel", game.ActivePlayerName);
        instance.Execute(null!, game);
        Assert.Equal("Jorge", game.ActivePlayerName);
        instance.Execute(null!, game);
    }
}
