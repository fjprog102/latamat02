namespace HighestLowest.Test.Adriel;

using HighestLowest.Adriel;

public class HighestLowestTest
{
    [Fact]
    private void ItShouldReturnTheHighestAndLowestNumbersOnAString()
    {
        Assert.Equal("5 1", new HighestAndLowest().GetHighestAndLowest("1 2 3 4 5"));
        Assert.Equal("5 -1", new HighestAndLowest().GetHighestAndLowest("-1 2 3 4 5"));
        Assert.Equal("64 -58", new HighestAndLowest().GetHighestAndLowest("5 5 64 -58 4"));
        Assert.Equal("100 10", new HighestAndLowest().GetHighestAndLowest("100 50 10 20"));
        Assert.Equal("45 -741", new HighestAndLowest().GetHighestAndLowest("12 -54 0 45 -741"));
    }
}
