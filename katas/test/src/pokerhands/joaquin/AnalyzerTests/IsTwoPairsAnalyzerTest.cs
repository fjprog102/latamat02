namespace PokerHands.Joaquin;

using Analyzers.Joaquin;

public class IsTwoPairsAnalyzerTest
{
    [Fact]
    public void ItShouldBeTwoPairs()
    {
        Hand acesAndThrees = new Hand("3S AD 3H AC 7S");
        Hand queensAndSevens = new Hand("7C AH QD QC 7S");
        Hand sixesAndTwos = new Hand("2D 2C 6D 6H 4S");
        Hand tensAndFives = new Hand("5H TD 2S TH 5C");
        IsTwoPairsAnalyzer evaluator = new IsTwoPairsAnalyzer();
        Assert.True(evaluator.Match(acesAndThrees));
        Assert.True(evaluator.Match(queensAndSevens));
        Assert.True(evaluator.Match(sixesAndTwos));
        Assert.True(evaluator.Match(tensAndFives));
    }
}
