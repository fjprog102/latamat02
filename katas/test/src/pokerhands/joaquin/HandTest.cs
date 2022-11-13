namespace Hand.Test.Joaquin;

using PokerHand.Joaquin;


public class HandTest 
{

    [Fact]
    public void ItShouldCreateAHandOfPoker()
    {
       Hand hand = new Hand();
       Assert.Equal(5, hand.cards.Length);
    }

    [Fact]
    public void ItShouldHaveValidValues()
    {
        Deck deck = new Deck();
        Hand hand = new Hand();

        foreach (string card in hand.cards)
        {
            Assert.Contains(card, deck.cards);
        }
    }

    [Fact]
    public void CardShouldNotBeRepeatedInAHand()
    {
        Hand hand = new Hand();

        for (int i = 0; i < hand.cards.Length; i++)
        {
            int index = i;
            while (index < hand.cards.Length - 1)
            {
                index += 1;
                Assert.NotEqual(hand.cards[index], hand.cards[i]);
            }
        }
    }
}