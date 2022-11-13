namespace Card.Test.Joaquin;

using PokerHand.Joaquin;

public class CardTest 
{

    [Fact]
    public void ItShouldReturnAValidSuit()
    {
       Card card = new Card();
       card.CreateCard();
       Assert.Contains(card.value[1], card.Deck.suits);
    }

    [Fact]
    public void ItShouldReturnAValidCardValue()
    {
       Card card = new Card();
       card.CreateCard();
       Assert.Contains(card.value[0], card.Deck.cardValues);
    }

    [Fact]
    public void ItShouldHaveAValidValue()
    {
        Card card = new Card();
        card.CreateCard();
        Assert.NotNull(card.value);
        Assert.Contains(card.value, card.Deck.cards);
    }
}