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
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "2D", "3C", "3S", "AD"});
            Assert.Equal(new List<char>() { 'H', 'D', 'C', 'S', 'D'}, rules.Suits);
        }
         [Fact]
        private void GivenAStraighyFlushHandItShouldReturnStraighyFlush()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"AH", "AD", "AC", "AS", "AD"});
            Assert.Equal("StraighyFlush!", rules.ApplyStraightFlushRule());
        }
            [Fact]
        private void GivenANonStraighyFlushHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "AD", "AC", "AS", "AD"});
            Assert.Equal("None", rules.ApplyStraightFlushRule());
        }
        [Fact]
        private void GivenFourOfAKindHandItShouldReturnFourOfAKind()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "AD", "AC", "AS", "AD"});
            Assert.Equal("FourOfAKind", rules.ApplyFourOfAKindRule());
        }
        [Fact]
        private void GivenANonFourOfAKindHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "3D", "AC", "AS", "AD"});
            Assert.Equal("None", rules.ApplyFourOfAKindRule());
        }
        
    }
}
