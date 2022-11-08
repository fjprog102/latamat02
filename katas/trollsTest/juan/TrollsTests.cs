using Trolls.Juan;

public class TrollsDataClass : TheoryData<String, String>
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
    public void test_trolls_kata(String input, String expected)
    {
        Assert.Equal(expected, TrollsJuan.trolls(input));
    }
}
