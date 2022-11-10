namespace Trolls.Test.Adriel;

using Trolls.Adriel;

public class TrollsTest
{
    [Fact]
    public void ItShoutEraseEveryVowelOfGivenString()
    {
        Assert.Equal(
            "Ths wbst s fr lsrs LL!",
            new TrollTrolls().TrollTheTrolls("This website is for losers LOL!")
        );
        Assert.Equal(
            "Ths vd s hrrbl!",
            new TrollTrolls().TrollTheTrolls("This video is horrible!")
        );
        Assert.Equal(
            "Ddn't lk ths t ll!",
            new TrollTrolls().TrollTheTrolls("Didn't like this at all!")
        );
    }
}
