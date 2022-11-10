namespace Trolls.Test.Adriel;

using Trolls.Adriel;

public class TrollsTest {
    [Fact]
    public void ItShoutEraseEveryVowelOfGivenString() {
        Assert.Equal("Ths wbst s fr lsrs LL!", new TrollTrolls().trollTheTrolls("This website is for losers LOL!"));
        Assert.Equal("Ths vd s hrrbl!", new TrollTrolls().trollTheTrolls("This video is horrible!"));
        Assert.Equal("Ddn't lk ths t ll!", new TrollTrolls().trollTheTrolls("Didn't like this at all!"));
    }
}