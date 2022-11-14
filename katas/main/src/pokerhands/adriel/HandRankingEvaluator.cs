namespace PokerHands.HandsRankingEvaluator.Adriel;

using Enums.Adriel;
using Hands.Adriel;

public class HandRankingEvaluator
{
    public static Ranking Evaluate(Hand hand)
    {
        if (isStraightFlush(hand)) return Ranking.StraightFlush;
        else if (IsFourOfAKind(hand)) return Ranking.FourOfAKind;
        else if (IsFullHouse(hand)) return Ranking.FullHouse;
        else if (IsFlush(hand)) return Ranking.Flush;
        else if (IsStraight(hand)) return Ranking.Straight;
        else if (IsThreeOfAKind(hand)) return Ranking.ThreeOfAKind;
        else if (IsTwoPairs(hand)) return Ranking.TwoPairs;
        else if (IsPair(hand)) return Ranking.Pair;
        return Ranking.HighCard;
    }

    private static bool IsPair(Hand hand)
    {
        return hand.Cards.GroupBy(c => c.Value).Where(g => g.Count() == 2).Count() == 1;
    }

    private static bool IsTwoPairs(Hand hand)
    {
        return hand.Cards.GroupBy(c => c.Value).Where(g => g.Count() == 2).Count() == 2;
    }

    private static bool IsThreeOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(c => c.Value).Where(g => g.Count() == 3).Any();
    }

    private static bool IsFourOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(c => c.Value).Where(g => g.Count() == 4).Any();
    }

    private static bool IsStraight(Hand hand)
    {
        if (IsAceLowStraight(hand)) return true;

        var sortedHand = hand.Cards.OrderBy(h => h.Value).ToArray();
        int firstCardOfStraight = (int)sortedHand.First().Value;

        for (int i = 1; i < sortedHand.Length; i++)
        {
            if ((int)sortedHand[i].Value != firstCardOfStraight + i) return false;
        }

        return true;
    }

    private static bool IsAceLowStraight(Hand hand)
    {
        return hand.Contains(Value.Ace) && hand.Contains(Value.Two) && hand.Contains(Value.Three) &&
            hand.Contains(Value.Four) && hand.Contains(Value.Five);
    }


    private static bool IsFlush(Hand hand)
    {
        return hand.Cards.GroupBy(h => h.Suit).Count() == 1;
    }

    private static bool IsFullHouse(Hand hand)
    {
        return IsPair(hand) && IsThreeOfAKind(hand);
    }

    private static bool isStraightFlush(Hand hand)
    {
        return IsStraight(hand) && IsFlush(hand);
    }
}
