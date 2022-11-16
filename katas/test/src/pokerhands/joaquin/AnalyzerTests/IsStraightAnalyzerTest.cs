namespace HandEvaluator.Test.Joaquin;

using PokerHand.Joaquin;

public class IsStraightAnalyzerTest
{
    [Fact]
    public void ItShouldBeStraight()
    {
        Hand straight = new Hand("4S 6D 5H 8S 7S");
        IsStraightAnalyzer evaluator = new IsStraightAnalyzer();
        Assert.True(evaluator.Match(straight));
    }
}