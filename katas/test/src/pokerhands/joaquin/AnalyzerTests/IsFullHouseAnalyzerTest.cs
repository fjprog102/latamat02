namespace HandEvaluator.Test.Joaquin;

using PokerHand.Joaquin;

public class IsFullHouseAnalyerTest
{
    [Fact]
    public void ItShouldBeFullHouse()
    {
        Hand aceOverThree = new Hand("AS 3D AH AC 3S");
        Hand fiveOverTwo = new Hand("2C 5H 5D 5C 2S");
        Hand tenOverNine = new Hand("9D TC 9C TH 9S");
        Hand sevenOverSix = new Hand("6H 6D 6S 7H 7C");
        IsFullHouseAnalyzer evaluator = new IsFullHouseAnalyzer();
        Assert.True(evaluator.Match(aceOverThree));
        Assert.True(evaluator.Match(fiveOverTwo));
        Assert.True(evaluator.Match(tenOverNine));
        Assert.True(evaluator.Match(sevenOverSix));
    }
}
