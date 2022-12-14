namespace Analyzers.Joaquin;

using System.Linq;
using PokerHands.Joaquin;

public class IsStraightFlushAnalyzer : HandAnalyzer
{
    private readonly IsFlushAnalyzer FlushAnalyzer = new IsFlushAnalyzer();
    private readonly IsStraightAnalyzer StraightAnalyzer = new IsStraightAnalyzer();

    public override bool Match(Hand hand)
    {
        return StraightAnalyzer.Match(hand) && FlushAnalyzer.Match(hand);
    }

    public override int GetRank()
    {
        return 8;
    }
}
