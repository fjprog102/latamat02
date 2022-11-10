namespace SquareDigit.Test.Adriel;

using SquareDigit.Adriel;

public class SquareDigitsTest
{
    [Fact]
    public void ItShouldReturnTheSquareOfEveryDigitInString()
    {
        Assert.Equal(149, new SquareDigits().squareEveryDigit(123));
        Assert.Equal(916251, new SquareDigits().squareEveryDigit(3451));
        Assert.Equal(369412510, new SquareDigits().squareEveryDigit(6321510));
        Assert.Equal(25163649, new SquareDigits().squareEveryDigit(5467));
    }
}