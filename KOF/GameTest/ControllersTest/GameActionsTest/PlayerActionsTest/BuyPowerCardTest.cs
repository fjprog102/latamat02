namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class BuyPowerCardTest
{

    private readonly Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 10), 0, new List<CardDetails>());
    private readonly Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10), 0, new List<CardDetails>());
    private readonly Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10), 0, new List<CardDetails>());
    private readonly Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10), 0, new List<CardDetails>());
    private readonly Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10), 0, new List<CardDetails>());

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new BuyPowerCard();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<BuyPowerCard>)));
    }

    [Fact]
    public void ItShouldBuyTheFirstPossibleCardFromTheDeck()
    {
        var instance = new BuyPowerCard();
        PowerCardDeck deck = new PowerCardDeck();
        playerOne.EnergyCubes += 10;

        Assert.True(deck.Deck[0].powerCard.Cost < playerOne.EnergyCubes);
        Assert.Equal(5, deck.Deck[0].powerCard.Cost);
        CardDetails card = deck.Deck[0];
        Assert.Empty(playerOne.PowerCards);
        Assert.Equal(6, deck.Deck.Count());

        instance.BuyCard(playerOne, deck);
        Assert.Single(playerOne.PowerCards);
        Assert.Equal(5, deck.Deck.Count());
        Assert.Equal(card, playerOne.PowerCards![0]);
        Assert.Equal(5, playerOne.EnergyCubes);
    }

    [Fact]
    public void ItShouldBuyACardForTheActivePlayer()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        var instance = new BuyPowerCard();

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        // PLAYER ONE 
        playerOne.EnergyCubes += 10;

        Assert.True(game.Board!.OutsideTokyo.Exists(player => player.Name == game.ActivePlayerName));
        Assert.True(game.Deck!.Deck[0].powerCard.Cost <= playerOne.EnergyCubes);
        Assert.Equal(5, game.Deck.Deck[0].powerCard.Cost);
        CardDetails firstCard = game.Deck.Deck[0];
        Assert.Empty(playerOne.PowerCards);
        Assert.Equal(6, game.Deck.Deck.Count());

        instance.Execute(null!, game);
        Assert.Single(playerOne.PowerCards);
        Assert.Equal(5, game.Deck.Deck.Count());
        Assert.Equal(firstCard, playerOne.PowerCards![0]);
        Assert.Equal(5, playerOne.EnergyCubes);

        // PLAYER TWO
        game.BoardProcessor!.ChangePlayerBoardPlace(playerTwo, game.Board!.OutsideTokyo, game.Board.TokyoCity);
        game.ActivePlayerName = playerTwo.Name;
        playerTwo.EnergyCubes += 14;

        Assert.True(game.Board!.TokyoCity.Exists(player => player.Name == game.ActivePlayerName));
        Assert.True(game.Deck!.Deck[0].powerCard.Cost <= playerTwo.EnergyCubes);
        Assert.Equal(5, game.Deck.Deck[0].powerCard.Cost);
        CardDetails secondCard = game.Deck.Deck[0];
        Assert.Empty(playerTwo.PowerCards);
        Assert.Equal(5, game.Deck.Deck.Count());

        instance.Execute(null!, game);
        Assert.Single(playerTwo.PowerCards);
        Assert.Equal(4, game.Deck.Deck.Count());
        Assert.Equal(secondCard, playerTwo.PowerCards![0]);
        Assert.Equal(9, playerTwo.EnergyCubes);

        // PLAYER TWO
        game.BoardProcessor!.ChangePlayerBoardPlace(playerThree, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        game.ActivePlayerName = playerThree.Name;
        playerThree.EnergyCubes += 8;

        Assert.True(game.Board!.TokyoBay!.Exists(player => player.Name == game.ActivePlayerName));
        Assert.True(game.Deck!.Deck[0].powerCard.Cost <= playerThree.EnergyCubes);
        Assert.Equal(8, game.Deck.Deck[0].powerCard.Cost);
        CardDetails thirdCard = game.Deck.Deck[0];
        Assert.Empty(playerThree.PowerCards);
        Assert.Equal(4, game.Deck.Deck.Count());

        instance.Execute(null!, game);
        Assert.Single(playerThree.PowerCards);
        Assert.Equal(3, game.Deck.Deck.Count());
        Assert.Equal(thirdCard, playerThree.PowerCards![0]);
        Assert.Equal(0, playerThree.EnergyCubes);
    }
}
