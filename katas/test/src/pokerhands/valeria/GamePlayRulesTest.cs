namespace  PokerHands.Test.Valeria
{
    using PokerHands.Valeria;
    public class GamePlayRulesTest
    {
        [Fact]
        private void GivenAHandItShouldReturnTheValuesInAList()
        {
            GamePlayRules Rules = new GamePlayRules(new string [5]{"2H", "2D", "3C", "3S", "AD"});
            Assert.Equal(new List<int>() { 2, 2, 3, 3, 11}, Rules.Values);
        }
        [Fact]
        private void GivenAHandItShouldReturnTheSuitsInAList()
        {
            GamePlayRules Rules = new GamePlayRules(new string [5]{"2H", "2D", "3C", "3S", "AD"});
            Assert.Equal(new List<char>() { 'H', 'D', 'C', 'S', 'D'}, Rules.Suits);
        }
         [Fact]
        private void GivenAStraighyFlushHandItShouldReturnStraighyFlush()
        {
            GamePlayRules Rules = new GamePlayRules(new string [5]{"AH", "AD", "AC", "AS", "AD"});
            Assert.Equal("StraighyFlush!", Rules.ApplyStraightFlushRule());
        }
            [Fact]
        private void GivenANonStraighyFlushHandItShouldReturnNone()
        {
            GamePlayRules Rules = new GamePlayRules(new string [5]{"2H", "AD", "AC", "AS", "AD"});
            Assert.Equal("None", Rules.ApplyStraightFlushRule());
        }
        [Fact]
        private void GivenFourOfAKindHandItShouldReturnFourOfAKind()
        {
            GamePlayRules Rules = new GamePlayRules(new string [5]{"2H", "AD", "AC", "AS", "AD"});
            Assert.Equal("FourOfAKind", Rules.ApplyFourOfAKindRule());
        }
        [Fact]
        private void GivenANonFourOfAKindHandItShouldReturnNone()
        {
            GamePlayRules Rules = new GamePlayRules(new string [5]{"2H", "3D", "AC", "AS", "AD"});
            Assert.Equal("None", Rules.ApplyFourOfAKindRule());
        }
        
    }
}
