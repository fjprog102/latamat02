namespace Card.Test.Joaquin;

using PokerHand.Joaquin;

public class CardTest 
{

    [Fact]
    public void ItShouldReturnAValidSuit()
    {
       Card card = new Card();
       Assert.Contains(card.suit, card.Deck.suits);
    }

    [Fact]
    public void ItShouldReturnAValidCardValue()
    {
       Card card = new Card();
       Assert.Contains(card.value, card.Deck.cardValues);
    }

    [Fact]
    public void ItShouldBeAValidCard()
    {
        Deck Deck = new Deck();
        string card = new Card().CreateCard();
        Assert.NotNull(card);
        Assert.Contains(card, Deck.cards);
    }

    [Fact]
    public void ItShouldHaveAValidWeight()
    {
        Deck Deck = new Deck();
        Card Card = new Card();
        Assert.InRange(Card.weight, 0, 13);
    }
}