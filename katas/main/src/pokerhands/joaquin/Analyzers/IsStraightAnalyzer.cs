namespace PokerHand.Joaquin;

using System.Linq;

public class IsStraightAnalyzer : HandAnalyzer
{
    public override bool Match(Hand hand)
    {
        var orderedHand = hand.Cards.OrderByDescending(card => card.weight).ToArray();

        for (int i = 0; i < orderedHand.Length - 1; i++)
        {
            if (orderedHand[i].weight - 1 != orderedHand[i + 1].weight) return false;
        }

        return true;
    }

    public override int GetRank()
    {
        return 4;
    }
}