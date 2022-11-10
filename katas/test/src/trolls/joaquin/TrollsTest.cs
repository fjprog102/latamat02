using Trolls.Joaquin;

namespace Trolls.Test.Joaquin
{
    public class TrollsTest
    {
        [Fact]
        public void ItShouldRemoveVowels()
        {
            Assert.Equal(
                "Ths wbst s fr lsrs LL!",
                new TrollsText().RemoveVowels("This website is for losers LOL!")
            );
            Assert.Equal("WRST PP VR!!!", new TrollsText().RemoveVowels("WORST APP EVER!!!"));
            Assert.Equal(
                " mnky cld d t bttr...",
                new TrollsText().RemoveVowels("A monkey could do it better...")
            );
        }

        [Fact]
        public void ItShouldNotContainVowels()
        {
            Assert.DoesNotContain("a", new TrollsText().RemoveVowels("aeiou"));
            Assert.DoesNotContain("e", new TrollsText().RemoveVowels("aeiou"));
            Assert.DoesNotContain("i", new TrollsText().RemoveVowels("aeiou"));
            Assert.DoesNotContain("o", new TrollsText().RemoveVowels("aeiou"));
            Assert.DoesNotContain("u", new TrollsText().RemoveVowels("aeiou"));
        }
    }
}
