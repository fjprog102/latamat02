namespace PokerHands.Cards.Test.Adriel;

using Enums.Adriel;
using Cards.Adriel;

public class CardTest
{
    [Fact]
    private void ShouldReturnAnArgumentExceptionForInvalidCardInput()
    {
        string message = "Card must only consist of value and suit";

        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Card("11c"));
        Assert.Equal(message, ex.Message);

        ArgumentException ex2 = Assert.Throws<ArgumentException>(() => new Card("hgF42"));
        Assert.Equal(message, ex2.Message);

        ArgumentException ex3 = Assert.Throws<ArgumentException>(() => new Card("G"));
        Assert.Equal(message, ex3.Message);

        ArgumentException ex4 = Assert.Throws<ArgumentException>(() => new Card(""));
        Assert.Equal(message, ex4.Message);
    }

    [Fact]
    private void ShouldReturnAnArgumentExceptionForInvalidValueInput()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Card("1c"));
        Assert.Equal("Invalid value: '1'", ex.Message);

        ArgumentException ex2 = Assert.Throws<ArgumentException>(() => new Card("zh"));
        Assert.Equal("Invalid value: 'z'", ex2.Message);

        ArgumentException ex3 = Assert.Throws<ArgumentException>(() => new Card("Gs"));
        Assert.Equal("Invalid value: 'g'", ex3.Message);

        ArgumentException ex4 = Assert.Throws<ArgumentException>(() => new Card("ps"));
        Assert.Equal("Invalid value: 'p'", ex4.Message);
    }

    [Fact]
    private void ShouldReturnAnArgumentExceptionForInvalidSuitInput()
    {
        ArgumentException ex = Assert.Throws<ArgumentException>(() => new Card("2g"));
        Assert.Equal("Invalid suit: 'g'", ex.Message);

        ArgumentException ex2 = Assert.Throws<ArgumentException>(() => new Card("0j"));
        Assert.Equal("Invalid suit: 'j'", ex2.Message);

        ArgumentException ex3 = Assert.Throws<ArgumentException>(() => new Card("t0"));
        Assert.Equal("Invalid suit: '0'", ex3.Message);

        ArgumentException ex4 = Assert.Throws<ArgumentException>(() => new Card("t."));
        Assert.Equal("Invalid suit: '.'", ex4.Message);
    }

    [Fact]
    private void ShouldCorrectlyReturnACardEnumValue()
    {
        Card card = new Card("0s");
        Assert.Equal(Value.Ten, card.Value);

        Card card2 = new Card("tc");
        Assert.Equal(Value.Ten, card2.Value);

        Card card3 = new Card("jd");
        Assert.Equal(Value.Jack, card3.Value);

        Card card4 = new Card("Kh");
        Assert.Equal(Value.King, card4.Value);
    }

    [Fact]
    private void ShouldCorrectlyReturnACardEnumSuit()
    {
        Card card = new Card("ts");
        Assert.Equal(Suit.Spades, card.Suit);

        Card card2 = new Card("Qc");
        Assert.Equal(Suit.Clubs, card2.Suit);

        Card card3 = new Card("kd");
        Assert.Equal(Suit.Diamonds, card3.Suit);

        Card card4 = new Card("2h");
        Assert.Equal(Suit.Hearts, card4.Suit);
    }

    //Returns 1 if card1 has higher value
    //Returns -1 if card2 has higher value
    //Returns 0 if both cards have the same value
    [Fact]
    private void MethodShouldCorrectlyReturnTheCardWithMostValue()
    {
        Card card = new Card("4s");
        Card card2 = new Card("8s");
        Assert.Equal(-1, card.compareTo(card2));

        Card card3 = new Card("Jd");
        Card card4 = new Card("2s");
        Assert.Equal(1, card3.compareTo(card4));

        Card card5 = new Card("7s");
        Card card6 = new Card("7d");
        Assert.Equal(0, card5.compareTo(card6));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnACardCreatedAsAString()
    {
        Card card = new Card("2s");
        Assert.Equal("2s", card.ToString());

        Card card2 = new Card("0c");
        Assert.Equal("Tc", card2.ToString());

        Card card3 = new Card("qd");
        Assert.Equal("Qd", card3.ToString());

        Card card4 = new Card("Jh");
        Assert.Equal("Jh", card4.ToString());
    }
}
