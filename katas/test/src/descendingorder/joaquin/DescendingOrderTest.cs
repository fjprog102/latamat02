using DescendingOrder.Joaquin;

namespace DescendingOrder.Test.Joaquin
{
    public class DescendingOrderTest
    {
        [Fact]
        public void ItShouldOrderDescent()
        {
            Assert.Equal(54421, new DescendingClass().OrderDescent(42145));
            Assert.Equal(654321, new DescendingClass().OrderDescent(145263));
            Assert.Equal(987654321, new DescendingClass().OrderDescent(123456789));
        }
    }
}
