namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;

public class BuyPowerCardTest
{

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new BuyPowerCard();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<BuyPowerCard>)));
    }
}
