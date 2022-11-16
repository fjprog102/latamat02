namespace PokerHands.HandsMainEvaluator.Adriel;

using Cards.Adriel;
using Hands.Adriel;

public class HandMainEvaluator
{
    public static Card[] Pair(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.Value).Where(group => group.Count() == 2).First().ToArray();
    }

    public static Card[] TwoPairs(Hand hand)
    {
        var twoPairsGroup = hand.Cards.GroupBy(card => card.Value).Where(group => group.Count() == 2);
        return twoPairsGroup.First().Concat(twoPairsGroup.Last()).ToArray();
    }

    public static Card[] ThreeOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.Value).Where(group => group.Count() == 3).First().ToArray();
    }

    public static Card[] FourOfAKind(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.Value).Where(group => group.Count() == 4).First().ToArray();
    }

    private static bool AceLowStraightOrAceLowStraightFlush(List<Card> handList)
    {
        var newList = handList.Select(each => each.ToString()[0]);
        return newList.Contains('A') && newList.Contains('2') && newList.Contains('3') &&
            newList.Contains('4') && newList.Contains('5');
    }

    public static Card[] OtherRankings(Hand hand)
    {
        var handList = hand.Cards.OrderBy(card => card.Value).ToList();

        if (AceLowStraightOrAceLowStraightFlush(handList))
        {
            handList.Insert(0, handList[4]);
            handList.RemoveAt(5);
        }

        return handList.ToArray();
    }
}
