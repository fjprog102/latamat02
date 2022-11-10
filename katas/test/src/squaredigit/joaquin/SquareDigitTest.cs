using SquareDigit.Joaquin;

namespace SquareDigit.Test.Joaquin
{
    public class SquareDigitTest
    {
        [Fact]
        public void ItShouldReturnAllDigitsToSquare()
        {
            Assert.Equal(0, new SquareDigitClass().SquareDigits(0));
            Assert.Equal(1, new SquareDigitClass().SquareDigits(1));
            Assert.Equal(25, new SquareDigitClass().SquareDigits(5));
            Assert.Equal(4949, new SquareDigitClass().SquareDigits(77));
            Assert.Equal(811181, new SquareDigitClass().SquareDigits(9119));
        }

        [Fact]
        public void ItShouldReturnAnInteger()
        {
            Assert.True(new SquareDigitClass().SquareDigits(9119).GetType().Equals(typeof(int)));
        }
    }
}
