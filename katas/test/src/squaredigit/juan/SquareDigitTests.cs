using SquareDigit.Juan;

public class SquareDigitDataClass : TheoryData<string, string>
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
    public void TestSquareDigitsKata(string input, string expected)
    {
        Assert.Equal(expected, SquareDigitJuan.SquareDigit(input));
    }
}
