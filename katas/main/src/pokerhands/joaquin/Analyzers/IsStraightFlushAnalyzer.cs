namespace PokerHand.Joaquin;

using System.Linq;

public class IsStraightFlushAnalyzer : HandAnalyzer
{
    IsFlushAnalyzer FlushAnalyzer = new IsFlushAnalyzer();
    IsStraightAnalyzer StraightAnalyzer = new IsStraightAnalyzer();

    public override bool Match(Hand hand)
    {
        return StraightAnalyzer.Match(hand) && FlushAnalyzer.Match(hand);
    }

    public override int GetRank()
    {
        return 8;
    }
}