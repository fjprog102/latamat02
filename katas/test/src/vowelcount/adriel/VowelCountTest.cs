namespace VowelCount.Test.Adriel;

using VowelCount.Adriel;

public class VowelCounterTest
{
    [Fact]
    public void ItShouldReturnTheQuantityOfVowelsInGivenString()
    {
        Assert.Equal(9, new VowelCounter().vowelCount("This is a test for the function"));
        Assert.Equal(5, new VowelCounter().vowelCount("abcdefghijklmnopqrstuvwxyz"));
        Assert.Equal(10, new VowelCounter().vowelCount("Another test to count the vowels"));
    }
}
