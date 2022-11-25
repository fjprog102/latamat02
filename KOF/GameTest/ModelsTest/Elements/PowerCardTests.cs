using KOT.Models;
using KOT.Models.Abstracts;

public class PowerCardTests
{
    [Fact]
    public void TestPowerCardConstructor()
    {
        var card = new PowerCard("name", 1, 0);
        Assert.True(card.GetType().IsSubclassOf(typeof(AbstractCard)));
        Assert.True(card.NameAttr.GetType() == typeof(string));
        Assert.True(card.CostAttr.GetType() == typeof(int));
        Assert.True(card.TypeAttr.GetType() == typeof(AbstractCard.CardTypes));
    }
}
