namespace PokerHands.Joaquin;

using Analyzers.Joaquin;

public class IsStraightFlushAnalyzerTest
{
    [Fact]
    public void ItShouldBeStraightFlush()
    {
        Hand spadesStraight = new Hand("4S 6S 5S 8S 7S");
        Hand clubsStraight = new Hand("AC TC JC QC KC");
        Hand diamondsStraight = new Hand("5D 2D 6D 4D 3D");
        Hand heartsStraight = new Hand("KH QH JH TH 9H");
        IsStraightAnalyzer evaluator = new IsStraightAnalyzer();
        Assert.True(evaluator.Match(spadesStraight));
        Assert.True(evaluator.Match(clubsStraight));
        Assert.True(evaluator.Match(diamondsStraight));
        Assert.True(evaluator.Match(heartsStraight));
    }
}
