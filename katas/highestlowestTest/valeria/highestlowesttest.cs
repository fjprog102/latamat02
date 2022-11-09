using HighestLowestKata.Valeria;
namespace HighestLowestKata.Test.Valeria
{
    public class HighestLowestTest
    {
        [Fact]
        void ItShouldGiveMeTheHighestAndLowestValueOfAString()
        {
            Assert.Equal("5 1", new HighestLowest().GetHighAndLow("1 2 3 4 5"));
            Assert.Equal("5 -3", new HighestLowest().GetHighAndLow("1 2 -3 4 5"));
            Assert.Equal("9 -5", new HighestLowest().GetHighAndLow("1 9 3 4 -5"));
            Assert.Equal("123 -654", new HighestLowest().GetHighAndLow("12 -26 123 -654"));
        }
    }
    
}