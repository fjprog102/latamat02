using HighestLowest.Juan;

public class HighestLowestDataClass : TheoryData<string, string>
{
    public HighestLowestDataClass()
    {
        Add("1 2 3 4 5", "5 1");
        Add("1 2 -3 4 5", "5 -3");
        Add("1 9 3 4 -5", "9 -5");
    }
}

public class HighestLowestTestJuan
{
    [Theory]
    [ClassData(typeof(HighestLowestDataClass))]
    public void test_highest_lowest_kata(string input, string expected)
    {
        Assert.Equal(expected, HighestLowestJuan.highest_lowest(input));
    }
}
