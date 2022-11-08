using VowelCount.Joaquin;

namespace VowelCount.Test.Joaquin {
    public class VowelCountTest {

        [Fact]
        public void ItShouldReturnTheAmountOfVowels()
        {
            Assert.Equal(5, VowelCount.vowelCount("aeiou"));
            Assert.Equal(0, VowelCount.vowelCount("AEIOU"));
            Assert.Equal(9, VowelCount.vowelCount("Hello my name is Joaquin!"));
            Assert.Equal(0, VowelCount.vowelCount("123456789"));
            Assert.Equal(0, VowelCount.vowelCount("AEIOU"));
        }

    }

}