namespace DescendingOrder.Test.Adriel;

using DescendingOrder.Adriel;

public class DescendingOrderTest
{
    [Fact]
    private void ShouldReturnNumberInDescendingOrder()
    {
        Assert.Equal(321, new DescendingOrder().getDescendingOrder(123));
        Assert.Equal(654321, new DescendingOrder().getDescendingOrder(123456));
        Assert.Equal(987654, new DescendingOrder().getDescendingOrder(469785));
        Assert.Equal(887655443, new DescendingOrder().getDescendingOrder(436887455));
        Assert.Equal(999884433, new DescendingOrder().getDescendingOrder(334488999));
    }
}
