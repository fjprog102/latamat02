namespace PokerHand.Joaquin;

using System.Linq;

public class IsStraightAnalyzer : HandAnalyzer
{
    public override bool Match(Hand hand)
    {
        var orderedHand = hand.Cards.OrderByDescending(card => card.weight).ToArray();

        for (int index = 0; index < orderedHand.Length - 1; index++)
        {
            if (orderedHand[index].weight - 1 != orderedHand[index + 1].weight) return false;
        }

        return true;
    }

    public override int GetRank()
    {
        return 4;
    }
}