namespace PokerHands.Test.Valeria
{
    using PokerHands.Valeria;
    public class GamePlayRulesTest
    {
        [Fact]
        private void GivenAHandItShouldReturnTheValuesInAList()
        {
            string []Hand= new string [5]{"2H", "2D", "3C", "3S", "AD"};
            GamePlayRules Rules = new GamePlayRules();
            Assert.Equal(new List<int>() { 2, 2, 3, 3, 11}, Rules.GetValues(Hand));
        }
        [Fact]
        private void GivenAHandItShouldReturnTheSuitsInAList()
        {
            string []Hand= new string [5]{"2H", "2D", "3C", "3S", "AD"};
            GamePlayRules Rules = new GamePlayRules();
            Assert.Equal(new List<char>() { 'H', 'D', 'C', 'S', 'D'}, Rules.GetSuits(Hand));
        }
         [Fact]
        private void GivenAStraighyFlushHandItShouldReturnStraighyFlush()
        {
            string []Hand= new string [5]{"AH", "AD", "AC", "AS", "AD"};
            GamePlayRules Rules = new GamePlayRules();
            Rules.GetValues(Hand);
            Assert.Equal("StraighyFlush!", Rules.ApplyStraightFlushRule());
        }
            [Fact]
        private void GivenANonStraighyFlushHandItShouldReturnNone()
        {
            string []Hand= new string [5]{"2H", "AD", "AC", "AS", "AD"};
            GamePlayRules Rules = new GamePlayRules();
            Rules.GetValues(Hand);
            Assert.Equal("None", Rules.ApplyStraightFlushRule());
        }
        [Fact]
        private void GivenFourOfAKindHandItShouldReturnFourOfAKind()
        {
            string []Hand= new string [5]{"2H", "AD", "AC", "AS", "AD"};
            GamePlayRules Rules = new GamePlayRules();
            Rules.GetValues(Hand);
            Assert.Equal("FourOfAKind", Rules.ApplyFourOfAKindRule());
        }
        
    }
}
