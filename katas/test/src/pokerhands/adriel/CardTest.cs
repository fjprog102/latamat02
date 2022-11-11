namespace PokerHands.Cards.Test.Adriel;

using Enums.Adriel;
using Cards.Adriel;

public class PokerHandsCardsTest
{
    [Fact]
    private void ShouldReturnAnArgumentExceptionWithInvalidCardInput()
    {
        string message = "Card must only consist of value and suit";

        var ex = Assert.Throws<ArgumentException>(() => new Card("11c"));
        Assert.Equal(message, ex.Message);

        var ex2 = Assert.Throws<ArgumentException>(() => new Card("hgF42"));
        Assert.Equal(message, ex2.Message);

        var ex3 = Assert.Throws<ArgumentException>(() => new Card("G"));
        Assert.Equal(message, ex3.Message);

        var ex4 = Assert.Throws<ArgumentException>(() => new Card(""));
        Assert.Equal(message, ex4.Message);
    }

    [Fact]
    private void ShouldReturnAnArgumentExceptionWithInvalidValueInput()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Card("1c"));
        Assert.Equal("Invalid value: '1'", ex.Message);

        var ex2 = Assert.Throws<ArgumentException>(() => new Card("zh"));
        Assert.Equal("Invalid value: 'z'", ex2.Message);

        var ex3 = Assert.Throws<ArgumentException>(() => new Card("Gs"));
        Assert.Equal("Invalid value: 'g'", ex3.Message);

        var ex4 = Assert.Throws<ArgumentException>(() => new Card("ps"));
        Assert.Equal("Invalid value: 'p'", ex4.Message);
    }

    [Fact]
    private void ShouldReturnAnArgumentExceptionWithInvalidSuitInput()
    {
        var ex = Assert.Throws<ArgumentException>(() => new Card("2g"));
        Assert.Equal("Invalid suit: 'g'", ex.Message);

        var ex2 = Assert.Throws<ArgumentException>(() => new Card("0j"));
        Assert.Equal("Invalid suit: 'j'", ex2.Message);

        var ex3 = Assert.Throws<ArgumentException>(() => new Card("t0"));
        Assert.Equal("Invalid suit: '0'", ex3.Message);

        var ex4 = Assert.Throws<ArgumentException>(() => new Card("t."));
        Assert.Equal("Invalid suit: '.'", ex4.Message);
    }

    [Fact]
    private void ShouldCorrectlyReturnACardEnumValue()
    {
        var card = new Card("0s");
        Assert.Equal(Value.Ten, card.Value);

        var card2 = new Card("tc");
        Assert.Equal(Value.Ten, card2.Value);

        var card3 = new Card("jd");
        Assert.Equal(Value.Jack, card3.Value);

        var card4 = new Card("Kh");
        Assert.Equal(Value.King, card4.Value);
    }

    [Fact]
    private void ShouldCorrectlyReturnACardEnumSuit()
    {
        var card = new Card("ts");
        Assert.Equal(Suit.Spades, card.Suit);

        var card2 = new Card("Qc");
        Assert.Equal(Suit.Clubs, card2.Suit);

        var card3 = new Card("kd");
        Assert.Equal(Suit.Diamonds, card3.Suit);

        var card4 = new Card("2h");
        Assert.Equal(Suit.Hearts, card4.Suit);
    }

    [Fact]
    private void MethodShouldCorrectlyReturnACardCreatedAsAString()
    {
        var card = new Card("2s");
        Assert.Equal("2s", card.ToString());

        var card2 = new Card("0c");
        Assert.Equal("Tc", card2.ToString());

        var card3 = new Card("qd");
        Assert.Equal("Qd", card3.ToString());

        var card4 = new Card("Jh");
        Assert.Equal("Jh", card4.ToString());
    }
}
