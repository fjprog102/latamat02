namespace PokerHands.HandsEvaluator.Adriel;

using Cards.Adriel;
using Enums.Adriel;
using Hands.Adriel;
using HandsKickersEvaluator.Adriel;
using HandsMainEvaluator.Adriel;
using HandsRankingEvaluator.Adriel;

public class HandEvaluator
{
    public Hand Hand { get; }
    public Ranking Ranking { get; }
    public Card[] RankingCards { get; }
    public Card[] Kickers { get; }

    public HandEvaluator(Hand hand)
    {
        string tempCardsString = string.Join(" ", hand.Cards.OrderBy(c => c.Value));

        Hand = new Hand(tempCardsString);
        Ranking = HandRankingEvaluator.Evaluate(Hand);

        if (IsAceLowStraightOrAceLowStraightFlush())
        {
            Hand.Cards.Insert(0, Hand.Cards[4]);
            Hand.Cards.RemoveAt(5);
        }

        RankingCards = GetRankingCards();
        Kickers = GetKickers();
    }

    private bool IsAceLowStraightOrAceLowStraightFlush()
    {
        return (Ranking == Ranking.Straight || Ranking == Ranking.StraightFlush) &&
        (Hand.Contains(Value.Ace) && Hand.Contains(Value.Two) && Hand.Contains(Value.Three) &&
        Hand.Contains(Value.Four) && Hand.Contains(Value.Five));
    }

    private Card[] GetRankingCards()
    {
        if (Ranking == Ranking.Pair)
        {
            return HandMainEvaluator.Pair(Hand);
        }
        else if (Ranking == Ranking.TwoPairs)
        {
            return HandMainEvaluator.TwoPairs(Hand);
        }
        else if (Ranking == Ranking.ThreeOfAKind)
        {
            return HandMainEvaluator.ThreeOfAKind(Hand);
        }
        else if (Ranking == Ranking.FourOfAKind)
        {
            return HandMainEvaluator.FourOfAKind(Hand);
        }
        else
        {
            return HandMainEvaluator.OtherRankings(Hand);
        }
    }

    private Card[] GetKickers()
    {
        if (Ranking == Ranking.Pair)
        {
            return HandKickersEvaluator.Pair(Hand);
        }
        else if (Ranking == Ranking.TwoPairs)
        {
            return HandKickersEvaluator.TwoPairsOrFourOfAKind(Hand);
        }
        else if (Ranking == Ranking.ThreeOfAKind)
        {
            return HandKickersEvaluator.ThreeOfAKind(Hand);
        }
        else if (Ranking == Ranking.FourOfAKind)
        {
            return HandKickersEvaluator.TwoPairsOrFourOfAKind(Hand);
        }
        else
        {
            return new Card[0];
        }
    }
}
