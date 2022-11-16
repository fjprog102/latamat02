namespace Analyzers.Joaquin;

using PokerHands.Joaquin;

using System.Linq;

public class IsFlushAnalyzer : HandAnalyzer
{
    public override bool Match(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.suit).Count() == 1;
    }

    public override int GetRank()
    {
        return 5;
    }
}
