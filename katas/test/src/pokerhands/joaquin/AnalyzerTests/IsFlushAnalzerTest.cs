namespace HandEvaluator.Test.Joaquin;

using PokerHand.Joaquin;

public class IsFlushAnalyzerTest
{
    [Fact]
    public void ItShouldBeFlush()
    {
        Hand spades = new Hand("4S 2S KS TS 7S");
        Hand clubs = new Hand("3C TC 7C QC KC");
        Hand diamonds = new Hand("AD 2D 6D 4D 3D");
        Hand hearts = new Hand("KH 9H 3H TH 4H");
        IsFlushAnalyzer evaluator = new IsFlushAnalyzer();
        Assert.True(evaluator.Match(spades));
        Assert.True(evaluator.Match(clubs));
        Assert.True(evaluator.Match(diamonds));
        Assert.True(evaluator.Match(hearts));
    }
}
