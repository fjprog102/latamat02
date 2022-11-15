namespace PokerHand.Joaquin;

public class Hand
{
    public List<Card> Cards = new List<Card>();

    public Hand(string hand)
    {
        string[] cards = hand.Split(" ");
        if (cards.Length != 5)
        {
            throw new ArgumentException("Hand must contain 5 cards");
        }

        foreach (string card in cards)
        {
            Cards.Add(new Card(card[0], card[1]));
        }
        Cards.GroupBy(card => card.weight);
    }
}