namespace PokerHands.Joaquin;

using Analyzers.Joaquin;

public class IsThreeOfAKindAnalyzerTest
{
    [Fact]
    public void ItShouldBeThreeOfAKind()
    {
        Hand aces = new Hand("3S AD AH AC 7S");
        Hand sevens = new Hand("7C AH 7D QC 7S");
        Hand twos = new Hand("2D 2C 6D 2H 4S");
        Hand queens = new Hand("QH QD 2S TH QC");
        IsThreeOfAKindAnalyzer evaluator = new IsThreeOfAKindAnalyzer();
        Assert.True(evaluator.Match(aces));
        Assert.True(evaluator.Match(sevens));
        Assert.True(evaluator.Match(twos));
        Assert.True(evaluator.Match(queens));
    }
}
