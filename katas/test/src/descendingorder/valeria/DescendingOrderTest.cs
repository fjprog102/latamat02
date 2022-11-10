using DescendingOrder.Valeria;
namespace DescendingOrder.Test.Valeria;
public class DescendingOrderTest
{
    [Fact]
    public void ItShouldGiveMeTheHighestNumber()
    {
        Assert.Equal("54421", new DescendingOrderClass().GetTheHighestValue(42145));
        Assert.Equal("654321", new DescendingOrderClass().GetTheHighestValue(145263));
        Assert.Equal("987654321", new DescendingOrderClass().GetTheHighestValue(123456789));
        Assert.Equal("654321", new DescendingOrderClass().GetTheHighestValue(531264));
        Assert.Equal("6542", new DescendingOrderClass().GetTheHighestValue(5246));
    }

    [Fact]
    public void ItShouldGiveMeTheErrorMessage()
    {
        Assert.Equal("your input must be a non-negative integer", new DescendingOrderClass().GetTheHighestValue(-1354));
        Assert.Equal("your input must be a non-negative integer", new DescendingOrderClass().GetTheHighestValue(-9874));
    }

}
