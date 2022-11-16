namespace PokerHands.HandsKickersEvaluator.Adriel;

using Cards.Adriel;
using Hands.Adriel;

public class HandKickersEvaluator
{
    public static Card[] Pair(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.Value)
            .Where(group => group.Count() == 1)
            .Select(each => each.First())
            .OrderBy(card => card.Value)
            .ToArray();
    }

    public static Card[] TwoPairsOrFourOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.Value).Last().ToArray();
    }

    public static Card[] ThreeOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.Value)
            .Where(group => group.Count() == 1)
            .Select(each => each.First())
            .OrderBy(card => card.Value)
            .ToArray();
    }
}
