using Trolls.Joaquin;

namespace Trolls.Test.Joaquin {
    public class TrollsTest {

        [Fact]
        public void ItShouldRemoveVowels() {
            Assert.Equal("Ths wbst s fr lsrs LL!", new TrollsText().removeVowels("This website is for losers LOL!"));
            Assert.Equal("WRST PP VR!!!", new TrollsText().removeVowels("WORST APP EVER!!!"));
            Assert.Equal(" mnky cld d t bttr...", new TrollsText().removeVowels("A monkey could do it better..."));
        }

    }

}