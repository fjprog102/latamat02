namespace Analyzers.Joaquin;

using System.Linq;
using PokerHands.Joaquin;

public class IsThreeOfAKindAnalyzer : HandAnalyzer
{
    public override bool Match(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(character => character.Count() == 3).Any();
    }

    public override int GetRank()
    {
        return 3;
    }
}
