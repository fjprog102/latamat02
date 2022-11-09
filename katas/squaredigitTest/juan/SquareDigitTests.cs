using SquareDigit.Juan;

public class SquareDigitDataClass : TheoryData<String, String>
{
    public SquareDigitDataClass()
    {
        Add("9119", "811181");
        Add("1", "1");
        Add("123", "149");
    }
}

public class SquareDigitTestJuan
{
    [Theory]
    [ClassData(typeof(SquareDigitDataClass))]
    public void test_square_digits_kata(String input, String expected)
    {
        Assert.Equal(expected, SquareDigitJuan.square_digit(input));
    }
}
