namespace PokerHand.Joaquin;

using System.Linq;

public class IsFourOfAKindAnalyzer : HandAnalyzer
{
    public override bool Match(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(character => character.Count() == 4).Any();
    }

    public override int GetRank()
    {
        return 7;
    }
}
