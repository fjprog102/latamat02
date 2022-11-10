using Trolls.Juan;

public class TrollsDataClass : TheoryData<string, string>
{
    public TrollsDataClass()
    {
        Add("This website is for losers LOL!", "Ths wbst s fr lsrs LL!");
        Add("This is a test", "Ths s  tst");
        Add("Sqwfp", "Sqwfp");
        Add("", "");
        Add(" ", " ");
    }
}

public class TrollsTestJuan
{
    [Theory]
    [ClassData(typeof(TrollsDataClass))]
    public void test_trolls_kata(string input, string expected)
    {
        Assert.Equal(expected, TrollsJuan.trolls(input));
    }
}
