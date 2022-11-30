using KOT.Models;
using KOT.Models.Abstracts;

public class PowerCardTests
{
    [Fact]
    public void TestPowerCardConstructor()
    {
        var card = new PowerCard("name", 1, 0);
        Assert.True(card.GetType().IsSubclassOf(typeof(AbstractCard)));
        Assert.True(card.Name.GetType() == typeof(string));
        Assert.True(card.Cost.GetType() == typeof(int));
        Assert.True(card.Type.GetType() == typeof(AbstractCard.CardTypes));
        Assert.True(card.Id! == null);
    }
}
