namespace PokerHands.Joaquin;

using Analyzers.Joaquin;

public class IsPairAnalyzerTest
{
    [Fact]
    public void ItShouldBePair()
    {
        Hand threes = new Hand("3S AD 3H 4C 7S");
        Hand queens = new Hand("7C AH QD QC KS");
        Hand twos = new Hand("2D 2C AD 6H 4S");
        Hand fives = new Hand("5H TD 2S JH 5C");
        IsPairAnalyzer evaluator = new IsPairAnalyzer();
        Assert.True(evaluator.Match(threes));
        Assert.True(evaluator.Match(queens));
        Assert.True(evaluator.Match(twos));
        Assert.True(evaluator.Match(fives));
    }
}
