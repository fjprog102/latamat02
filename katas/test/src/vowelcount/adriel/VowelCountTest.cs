namespace VowelCount.Test.Adriel;

using VowelCount.Adriel;

public class VowelCounterTest
{
    [Fact]
    public void ItShouldReturnTheQuantityOfVowelsInGivenString()
    {
        Assert.Equal(9, new VowelCounter().VowelCount("This is a test for the function"));
        Assert.Equal(5, new VowelCounter().VowelCount("abcdefghijklmnopqrstuvwxyz"));
        Assert.Equal(10, new VowelCounter().VowelCount("Another test to count the vowels"));
    }
}
