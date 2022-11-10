using SquareDigit.Valeria;
namespace SquareDigit.Test.Valeria
{
    public class SquareDigitTest
    {
        [Fact]
        void ItShouldReturnTheSquareOfEveryDigitOfANumber()
        {
            Assert.Equal("811181", new SquareDigitCalculator().GetTheSquareDigit("9119"));
            Assert.Equal("14", new SquareDigitCalculator().GetTheSquareDigit("12"));
            Assert.Equal("816416", new SquareDigitCalculator().GetTheSquareDigit("984"));
            Assert.Equal("8164491625", new SquareDigitCalculator().GetTheSquareDigit("98745"));
        }

        [Fact]
        void ItShouldReturnTheErrorMessage()
        {
            Assert.Equal("a valid number is required", new SquareDigitCalculator().GetTheSquareDigit("62.35"));
            Assert.Equal("a valid number is required", new SquareDigitCalculator().GetTheSquareDigit("-156"));
            Assert.Equal("a valid number is required", new SquareDigitCalculator().GetTheSquareDigit("/*-asdf"));
            Assert.Equal("a valid number is required", new SquareDigitCalculator().GetTheSquareDigit("adfg adf"));
            Assert.Equal("a valid number is required", new SquareDigitCalculator().GetTheSquareDigit(""));
            Assert.Equal("a valid number is required", new SquareDigitCalculator().GetTheSquareDigit(" "));
        }
    }

}