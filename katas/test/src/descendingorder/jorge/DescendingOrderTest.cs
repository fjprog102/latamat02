namespace DescendingOrder.Test.Jorge{
    using DescendingOrder.Jorge;
public class DescendingOrderTest {

    [Fact]
    public void HiguestPosibble() {
        Assert.True(987654 == new DescendingOrder().Number(578496));
        Assert.True(54421 == new DescendingOrder().Number(42145));
        Assert.True(654321 == new DescendingOrder().Number(145263));
         Assert.True(987654321 == new DescendingOrder().Number(123456789));
    }

}
}

