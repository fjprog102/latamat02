using DescentingOrder.Juan;

public class DescentingOrderDataClass : TheoryData<string, string>
{
    public DescentingOrderDataClass()
    {
        Add("42145", "54421");
        Add("145263", "654321");
        Add("123456789", "987654321");
    }
}

public class DescentingOrderTestJuan
{
    [Theory]
    [ClassData(typeof(DescentingOrderDataClass))]
    public void test_descending_order_kata(string input, string expected)
    {
        Assert.Equal(expected, DescentingOrderJuan.descenting_order(input));
    }
}
