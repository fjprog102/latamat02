namespace PokerHands.Joaquin;

public class HandTest
{
    private readonly List<string> Cards = new List<string>()
    {
        {"AS 7H 8D JS QH"},
        {"3C 3S JS 3H JH"},
        {"7D 4D 6D 3D 5D"},
        {"JS TD QH 2S 4C"},
        {"5S AH 2C QS 4C"},
    };

    [Fact]
    public void ItShouldCreateAHandOfPoker()
    {
        foreach (string card in Cards)
        {
            Hand hand = new Hand(card);
            Assert.Equal(5, hand.Cards.Count);
        }
    }

    [Fact]
    public void ItShouldHaveValidValues()
    {
        Deck deck = new Deck();

        foreach (string card in Cards)
        {
            Hand hand = new Hand("AS 7H 8D JS QH");
            foreach (var cards in hand.Cards)
            {
                Assert.Contains(cards.CardToString(), deck.cards);
            }
        }
    }

    [Fact]
    public void ItShouldReceiveAValidInput()
    {
        Assert.Throws<ArgumentException>(() => new Hand(""));
        Assert.Throws<ArgumentException>(() => new Hand("AS JQ"));
        Assert.Throws<ArgumentException>(() => new Hand("8S 4H AH JQ"));
        Assert.Throws<ArgumentException>(() => new Hand("24342389473"));
        Assert.Throws<ArgumentException>(() => new Hand("JSJSJSJ131313"));
    }
}
