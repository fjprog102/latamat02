namespace Analyzers.Joaquin;

using System.Linq;
using PokerHands.Joaquin;

public class IsTwoPairsAnalyzer : HandAnalyzer
{
    public override bool Match(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(character => character.Count() == 2).Count() == 2;
    }

    public override int GetRank()
    {
        return 2;
    }
}
