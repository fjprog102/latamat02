namespace Deck.Test.Joaquin;

using PokerHand.Joaquin;

public class DeckTest
{

    [Fact]
    public void ItShouldHave52Cards()
    {
        Deck deck = new Deck();
        Assert.Equal(52, deck.cards.Length);
    }

    [Fact]
    public void ItShouldHaveThirteenCardsOfEachSuit()
    {
        Deck deck = new Deck();
        int count = 0;

        foreach (char suit in deck.Suits)
        {
            foreach (string card in deck.cards)
            {
                if (suit == card[1])
                {
                    count++;
                }
            }

            Assert.Equal(13, count);
            count = 0;
        }
    }

    [Fact]
    public void ItShouldHaveFourCardsForEachValue()
    {
        Deck deck = new Deck();
        int count = 0;

        foreach (char value in deck.CardValues)
        {
            foreach (string card in deck.cards)
            {
                if (value.ToString() == card[0].ToString())
                {
                    count++;
                }
            }

            Assert.Equal(4, count);
            count = 0;
        }
    }
}
