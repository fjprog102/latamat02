namespace VowelCount.Test.Valeria
{
    using VowelCount.Valeria;
    public class VowelCountTest
    {
        [Fact]
        public void ItShouldCountTheVocalsInAString()
        {
            Assert.Equal("5", new VowelCounter().CountVowels("aeiou"));
            Assert.Equal("3", new VowelCounter().CountVowels("hello world"));
            Assert.Equal("4", new VowelCounter().CountVowels("i have 3 dogs"));
            Assert.Equal("0", new VowelCounter().CountVowels("123456"));
            Assert.Equal("5", new VowelCounter().CountVowels("you look old"));
        }
        [Fact]
        public void ItShouldGiveTheErrorMessage()
        {
            Assert.Equal("The message must be in lower case", new VowelCounter().CountVowels("HeeEELp"));
            Assert.Equal("The message must be in lower case", new VowelCounter().CountVowels("VisUAl stuDIo CodE"));
            Assert.Equal("The message must be in lower case", new VowelCounter().CountVowels(".NET 6"));
            Assert.Equal("The message must be in lower case", new VowelCounter().CountVowels(",./!@#asdf123"));
        }
    }
}
