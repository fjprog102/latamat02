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
       Assert.Equal(13, card.values.Length);
       Assert.Equal('2', card.values[0]);
       Assert.Equal('3', card.values[1]);
       Assert.Equal('4', card.values[2]);
       Assert.Equal('5', card.values[3]);
       Assert.Equal('6', card.values[4]);
       Assert.Equal('7', card.values[5]);
       Assert.Equal('8', card.values[6]);
       Assert.Equal('9', card.values[7]);
       Assert.Equal('T', card.values[8]);
       Assert.Equal('J', card.values[9]);
       Assert.Equal('Q', card.values[10]);
       Assert.Equal('K', card.values[11]);
       Assert.Equal('A', card.values[12]);
    }

    [Fact]
    public void ItShouldReturnTheValueOfACard()
    {
        Card card = new Card();
        Assert.Equal("", card.cardValue);
        Assert.Equal("3S", card.CreateCard('3', 'S'));
        Assert.Equal("3S", card.cardValue);
    }
}