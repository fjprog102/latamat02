namespace Card.Test.Joaquin;

using PokerHand.Joaquin;

public class CardTest
{
    Deck Deck = new Deck();

    char[] values = { 'A', '9', '4', 'J' };
    char[] suits = { 'C', 'D', 'H', 'S' };
    [Fact]
    public void ItShouldReturnAValidSuit()
    {
        for (int i = 0; i < values.Length; i++)
        {
            Card card = new Card(values[i], suits[i]);
            Assert.Contains(card.suit, card.Deck.suits);
        }
    }

    [Fact]
    public void ItShouldReturnAValidCardValue()
    {
        for (int i = 0; i < values.Length; i++)
        {
            Card card = new Card(values[i], suits[i]);
            Assert.Contains(card.value, card.Deck.cardValues);
        }
    }

    [Fact]
    public void ItShouldBeAValidCard()
    {
        for (int i = 0; i < values.Length; i++)
        {
            Card card = new Card(values[i], suits[i]);
            string cardValue = card.CardToString();
            Assert.NotNull(card);
            Assert.Contains(cardValue, Deck.cards);
        }
    }

    [Fact]
    public void ItShouldHaveTheCorrectWeight()
    {
        for (int i = 0; i < values.Length; i++)
        {
            Card card = new Card(values[i], suits[i]);
            Assert.InRange(card.weight, 0, 12);
            Assert.Equal(Deck.valuesRanking[values[i]], card.weight);
        }
    }
}