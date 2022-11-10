using VowelCount.Juan;

public class VowelCountDataClass : TheoryData<string, int>
{
    public VowelCountDataClass()
    {
        Add("this is a test", 4);
        Add("aeiou", 5);
        Add("ntpfr", 0);
        Add("", 0);
    }
}

public class VowelCountTestJuan
{
    [Theory]
    [ClassData(typeof(VowelCountDataClass))]
    public void test_count_vowels_kata(string input, int expected)
    {
        Assert.Equal(expected, VowelCountJuan.count_vowels(input));
    }
}
