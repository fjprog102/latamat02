namespace Analyzers.Joaquin;

using PokerHands.Joaquin;

using System.Linq;

public abstract class HandAnalyzer
{
    public abstract bool Match(Hand hand);

    public abstract int GetRank();
}
