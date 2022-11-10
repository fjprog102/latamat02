using VowelCount.Joaquin;

namespace VowelCount.Test.Joaquin
{
    public class VowelCountTest
    {
        [Fact]
        public void ItShouldReturnTheAmountOfVowels()
        {
            Assert.Equal(5, new VowelCountClass().VowelCount("aeiou"));
            Assert.Equal(1, new VowelCountClass().VowelCount("AEIOUa"));
            Assert.Equal(9, new VowelCountClass().VowelCount("Hello my name is Joaquin!"));
            Assert.Equal(0, new VowelCountClass().VowelCount("123456789"));
            Assert.Equal(7, new VowelCountClass().VowelCount("My telephone number is 11330012"));
        }

        [Fact]
        public void ItShouldReturnAnInteger()
        {
            Assert.True(new VowelCountClass().VowelCount("aeiou").GetType().Equals(typeof(int)));
        }

        [Fact]
        public void ItShouldNotBeNegative()
        {
            Assert.InRange(new VowelCountClass().VowelCount("aeiou"), 0, 99999999);
            Assert.InRange(new VowelCountClass().VowelCount("<<   >>> ;; //"), 0, 99999999);
            Assert.InRange(
                new VowelCountClass().VowelCount("My phone number is 11330012"),
                0,
                99999999
            );
        }
    }
}
