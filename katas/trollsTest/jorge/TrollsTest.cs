namespace Trolls.Test.Jorge{
    using Trolls.Jorge;
public class TrollsTest {

    [Fact]
    public void ItShouldntHaveVowels() {
        Assert.True("Ths wbst s fr lsrs LL!" == new TrollsText().Troll("This website is for losers LOL!"));
        Assert.True("Wht r y,  cmmnst?" == new TrollsText().Troll("What are you, a communist?"));
        Assert.True("N ffns bt,\nYr wrtng s mng th wrst 'v vr rd" == new TrollsText().Troll("No offense but,\nYour writing is among the worst I've ever read"));
    }

}
}

