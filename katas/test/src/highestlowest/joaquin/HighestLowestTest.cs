using HighestLowest.Joaquin;

namespace HighestLowest.Test.Joaquin
{
    public class HighestLowestTest
    {

        [Fact]
        public void ItShouldReturnHighestAndLowestNumbers()
        {
            Assert.Equal("5 1", new HighestLowestClass().highAndLow("1 2 3 4 5"));
            Assert.Equal("5 -3", new HighestLowestClass().highAndLow("1 2 -3 4 5"));
            Assert.Equal("9 -5", new HighestLowestClass().highAndLow("1 9 3 4 -5"));
            Assert.Equal("1 1", new HighestLowestClass().highAndLow("1"));
            Assert.Equal("12345 12345", new HighestLowestClass().highAndLow("12345 12345"));
        }

        [Fact]
        public void ItShouldReturnAString()
        {
            Assert.True(new HighestLowestClass().highAndLow("12345 12345").GetType().Equals(typeof(string)));
        }
    }
}
