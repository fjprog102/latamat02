namespace Hand.Test.Joaquin;

using PokerHand.Joaquin;


public class HandTest 
{

    [Fact]
    public void ItShouldCreateAHandOfPoker()
    {
       Hand hand = new Hand();
       Assert.NotNull(hand.value);
       Assert.Equal(13, hand.value.Length);
       Assert.Equal(5, hand.amount);
    }

    [Fact]
    public void ItShouldHaveValidValues()
    {
        Card card = new Card();
        Hand hand = new Hand();
        card.suits.Contains(hand.value[1]);
        card.suits.Contains(hand.value[4]);
        card.suits.Contains(hand.value[7]);
        card.suits.Contains(hand.value[10]);
        card.suits.Contains(hand.value[13]);
        card.cardValues.Contains(hand.value[0]);
        card.cardValues.Contains(hand.value[3]);
        card.cardValues.Contains(hand.value[6]);
        card.cardValues.Contains(hand.value[9]);
        card.cardValues.Contains(hand.value[12]);
    }

    [Fact]
    public void CardShouldNotBeRepeatedInAHand()
    {
        Hand hand = new Hand();
        string[] cards = hand.value.Split(" ");

        for (int i = 0; i < cards.Length; i++)
        {
            int index = i;
            while (index < cards.Length - 1)
            {
                index += 1;
                Assert.NotEqual(cards[index], cards[i]);
            }
        }
    }
    
}