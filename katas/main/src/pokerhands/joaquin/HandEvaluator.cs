namespace PokerHand.Joaquin;

public class HandEvaluator
{
    private readonly List<HandAnalyzer> analyzers = new List<HandAnalyzer>()
    {
        new IsStraightFlushAnalyzer(),
        new IsFourOfAKindAnalyzer(),
        new IsFullHouseAnalyzer(),
        new IsFlushAnalyzer(),
        new IsStraightAnalyzer(),
        new IsThreeOfAKindAnalyzer(),
        new IsTwoPairsAnalyzer(),
        new IsPairAnalyzer(),
    };

    public int Evaluate(Hand hand)
    {
        foreach (HandAnalyzer analyzer in analyzers)
        {
            if (analyzer.Match(hand))
            {
                return analyzer.GetRank();
            }
        }

        return 0;
    }
}

