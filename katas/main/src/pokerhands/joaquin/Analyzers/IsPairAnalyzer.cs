namespace PokerHand.Joaquin;

using System.Linq;

public class IsPairAnalyzer : HandAnalyzer
{
    public override bool Match(Hand hand)
    {
        return hand.Cards.GroupBy(card => card.value).Where(v => v.Count() == 2).Count() == 1;
    }

    public override int GetRank()
    {
        return 1;
    }
}