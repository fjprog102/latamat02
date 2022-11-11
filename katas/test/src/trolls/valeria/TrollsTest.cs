using Trolls.Valeria;
namespace Trolls.Test.Valeria
{
    public class TrollsTest
    {
        [Fact]
        private void ItShouldGiveMeTheMessageWithoutVowels()
        {
            Assert.Equal("Ths wbst s fr lsrs LL!", new Troll().EatVowels("This website is for losers LOL!"));
            Assert.Equal(" hv 19875213 dllrs!! $.$", new Troll().EatVowels("I have 19875213 dollars!! $.$"));
            Assert.Equal("Th Trll S GNN t M !#$^&*", new Troll().EatVowels("The TrOll IS GoNNA eAt MEEEE !#$^&*"));
            Assert.Equal("7987521654", new Troll().EatVowels("7987521654"));
            Assert.Equal("", new Troll().EatVowels("euAIEOoUaUai"));
            Assert.Equal("", new Troll().EatVowels(""));
            Assert.Equal(" ", new Troll().EatVowels(" "));
        }
    }
}
