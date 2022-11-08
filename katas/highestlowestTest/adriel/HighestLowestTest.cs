namespace HighestLowest.Test.Adriel;

using HighestLowest.Adriel;

public class HighestLowestTest {
    [Fact]
    void ItShouldReturnTheHighestAndLowestNumbersOnAString() {
        Assert.Equal("5 1", new HighestAndLowest().getHighestAndLowest("1 2 3 4 5"));
    }
}