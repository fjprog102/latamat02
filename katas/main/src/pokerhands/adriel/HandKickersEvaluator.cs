namespace PokerHands.HandsKickersEvaluator.Adriel;

using Cards.Adriel;
using Hands.Adriel;

public class HandKickersEvaluator{
    public static Card[] Pair(Hand hand)
    {
        return hand.Cards.GroupBy(c => c.Value)
            .Where(g => g.Count() == 1)
            .Select(e => e.First())
            .OrderBy(c => c.Value)
            .ToArray();
    }

    public static Card[] TwoPairsOrFourOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(c => c.Value).Last().ToArray();
    }

    public static Card[] ThreeOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(c => c.Value)
            .Where(g => g.Count() == 1)
            .Select(e => e.First())
            .OrderBy(c => c.Value)
            .ToArray();
    }
}
