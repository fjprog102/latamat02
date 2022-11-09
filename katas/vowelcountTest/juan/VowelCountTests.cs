using VowelCount.Juan;

public class VowelCountDataClass : TheoryData<String, Int32>
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
    public void test_count_vowels_kata(String input, Int32 expected)
    {
        Assert.Equal(expected, VowelCountJuan.count_vowels(input));
    }
}
