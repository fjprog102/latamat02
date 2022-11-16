namespace Analyzers.Joaquin;

using System.Linq;
using PokerHands.Joaquin;

public abstract class HandAnalyzer
{
    public abstract bool Match(Hand hand);

    public abstract int GetRank();
}
