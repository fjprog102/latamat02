namespace Card.Test.Joaquin;

using PokerHand.Joaquin;

public class CardTest 
{

    [Fact]
    public void ItShouldReturnThePossiblesSuitsOfACard()
    {
       Card card = new Card();
       Assert.Equal(4, card.suits.Length);
       Assert.Equal('C', card.suits[0]);
       Assert.Equal('D', card.suits[1]);
       Assert.Equal('H', card.suits[2]);
       Assert.Equal('S', card.suits[3]);
    }

    [Fact]
    public void ItShouldReturnThePossibleValuesOfACard()
    {
       Card card = new Card();
       Assert.Equal(13, card.cardValues.Length);
       Assert.Equal('2', card.cardValues[0]);
       Assert.Equal('3', card.cardValues[1]);
       Assert.Equal('4', card.cardValues[2]);
       Assert.Equal('5', card.cardValues[3]);
       Assert.Equal('6', card.cardValues[4]);
       Assert.Equal('7', card.cardValues[5]);
       Assert.Equal('8', card.cardValues[6]);
       Assert.Equal('9', card.cardValues[7]);
       Assert.Equal('T', card.cardValues[8]);
       Assert.Equal('J', card.cardValues[9]);
       Assert.Equal('Q', card.cardValues[10]);
       Assert.Equal('K', card.cardValues[11]);
       Assert.Equal('A', card.cardValues[12]);
    }

    [Fact]
    public void ItShouldHaveAValidValue()
    {
        Card card = new Card();
        Assert.NotNull(card.value);
        card.suits.Contains(card.value[0]);
        card.cardValues.Contains(card.value[1]);
    }
}