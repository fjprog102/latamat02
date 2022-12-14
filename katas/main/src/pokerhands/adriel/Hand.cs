namespace PokerHands.Hands.Adriel;

using Cards.Adriel;
using Enums.Adriel;

public class Hand
{
    public List<Card> Cards { get; }

    public Hand(string handString)
    {
        List<string> cardsStringList = handString.Split(" ").ToList();
        if (cardsStringList.Count != 5)
        {
            throw new ArgumentException("Hand must contain 5 cards");
        }

        Cards = new List<Card>();
        cardsStringList.ForEach(card => Cards.Add(new Card(card)));
    }

    public bool Contains(Value value)
    {
        return Cards.Where(c => c.Value == value).Any();
    }

    public override string ToString()
    {
        return string.Join(" ", Cards.Select(card => card.ToString()));
    }
}
