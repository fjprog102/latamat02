using VowelCount.Joaquin;

namespace VowelCount.Test.Joaquin {
    public class VowelCountTest {

        [Fact]
        public void ItShouldReturnTheAmountOfVowels()
        {
            Assert.Equal(5, new VowelCountClass().vowelCount("aeiou"));
            Assert.Equal(1, new VowelCountClass().vowelCount("AEIOUa"));
            Assert.Equal(9, new VowelCountClass().vowelCount("Hello my name is Joaquin!"));
            Assert.Equal(0, new VowelCountClass().vowelCount("123456789"));
            Assert.Equal(7, new VowelCountClass().vowelCount("My telephone number is 11330012"));
        }

        [Fact]
        public void ItShouldReturnAnInteger(){
            Assert.True(new VowelCountClass().vowelCount("aeiou").GetType().Equals(typeof(int)));
        }

        [Fact]
        public void ItShouldNotBeNegative(){
            Assert.InRange(new VowelCountClass().vowelCount("aeiou"), 0, 99999999);
            Assert.InRange(new VowelCountClass().vowelCount("<<   >>> ;; //"), 0, 99999999);
            Assert.InRange(new VowelCountClass().vowelCount("My phone number is 11330012"), 0, 99999999);
        }

    }

}