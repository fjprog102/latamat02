namespace PokerHand.Joaquin;

using System.Linq;

public class IsFullHouseAnalyzer : HandAnalyzer
{
    private readonly IsPairAnalyzer PairAnalyzer = new IsPairAnalyzer();
    private readonly IsThreeOfAKindAnalyzer ThreeOfAKindAnalyzer = new IsThreeOfAKindAnalyzer();

    public override bool Match(Hand hand)
    {
        return PairAnalyzer.Match(hand) && ThreeOfAKindAnalyzer.Match(hand);
    }

    public override int GetRank()
    {
        return 6;
    }
}
