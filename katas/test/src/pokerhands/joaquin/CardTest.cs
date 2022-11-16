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
        for (int index = 0; index < values.Length; index++)
        {
            Card card = new Card(values[index], suits[index]);
            Assert.Contains(card.suit, card.Deck.suits);
        }
    }

    [Fact]
    public void ItShouldReturnAValidCardValue()
    {
        for (int index = 0; index < values.Length; index++)
        {
            Card card = new Card(values[index], suits[index]);
            Assert.Contains(card.value, card.Deck.cardValues);
        }
    }

    [Fact]
    public void ItShouldBeAValidCard()
    {
        for (int index = 0; index < values.Length; index++)
        {
            Card card = new Card(values[index], suits[index]);
            string cardValue = card.CardToString();
            Assert.NotNull(card);
            Assert.Contains(cardValue, Deck.cards);
        }
    }

    [Fact]
    public void ItShouldHaveTheCorrectWeight()
    {
        for (int index = 0; index < values.Length; index++)
        {
            Card card = new Card(values[index], suits[index]);
            Assert.InRange(card.weight, 0, 12);
            Assert.Equal(Deck.valuesRanking[values[index]], card.weight);
        }
    }
}