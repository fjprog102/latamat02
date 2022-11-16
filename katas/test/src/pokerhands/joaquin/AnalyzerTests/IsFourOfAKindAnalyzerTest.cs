namespace HandEvaluator.Test.Joaquin;

using PokerHand.Joaquin;

public class IsFourOfAKindAnalyzerTest
{
    [Fact]
    public void ItShouldBeFourOfAKind()
    {
        Hand aces = new Hand("AS AD AH AC 7S");
        Hand sevens = new Hand("7C 7H 7D QC 7S");
        Hand twos = new Hand("2D 2C 6D 2H 2S");
        Hand queens = new Hand("QH QD QS TH QC");
        IsFourOfAKindAnalyzer evaluator = new IsFourOfAKindAnalyzer();
        Assert.True(evaluator.Match(aces));
        Assert.True(evaluator.Match(sevens));
        Assert.True(evaluator.Match(twos));
        Assert.True(evaluator.Match(queens));
    }
}
