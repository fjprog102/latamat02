using Trolls.Joaquin;

namespace Trolls.Test.Joaquin {
    public class TrollsTest {

        [Fact]
        public void ItShouldRemoveVowels() {
            Assert.Equal("Ths wbst s fr lsrs LL!", new TrollsText().removeVowels("This website is for losers LOL!"));
            Assert.Equal("WRST PP VR!!!", new TrollsText().removeVowels("WORST APP EVER!!!"));
            Assert.Equal(" mnky cld d t bttr...", new TrollsText().removeVowels("A monkey could do it better..."));
        }
        
        [Fact]
        public void ItShouldNotContainVowels()
        {
            Assert.Equal(false, new TrollsText().removeVowels("aeiou").Contains("a"));
            Assert.Equal(false, new TrollsText().removeVowels("aeiou").Contains("e"));
            Assert.Equal(false, new TrollsText().removeVowels("aeiou").Contains("i"));
            Assert.Equal(false, new TrollsText().removeVowels("aeiou").Contains("o"));
            Assert.Equal(false, new TrollsText().removeVowels("aeiou").Contains("u"));
        }

    }

}