namespace PokerHand.Joaquin;

using System.Linq;

public class IsThreeOfAKindAnalyzer : HandAnalyzer
{
    public override bool Match(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(v => v.Count() == 3).Any();
    }

    public override int GetRank()
    {
        return 3;
    }
}