namespace Analyzers.Joaquin;

using System.Linq;
using PokerHands.Joaquin;

public class IsPairAnalyzer : HandAnalyzer
{
    public override bool Match(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(character => character.Count() == 2).Count() == 1;
    }

    public override int GetRank()
    {
        return 1;
    }
}
