namespace  PokerHands.Test.Valeria
{
    using PokerHands.Valeria;
    public class GamePlayRulesTest
    {
        [Fact]
        private void GivenAHandItShouldReturnTheValuesInAList()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "2D", "3C", "3S", "AD"});
            Assert.Equal(new List<int>() { 2, 2, 3, 3, 11}, rules.Values);
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
            Assert.Equal("with straight flush: 11", rules.ApplyStraightFlushRule());
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
            Assert.Equal("with four of a kind: 11", rules.ApplyFourOfAKindRule());
        }
        [Fact]
        private void GivenANonFourOfAKindHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "3D", "AC", "AS", "AD"});
            Assert.Equal("None", rules.ApplyFourOfAKindRule());
        } 
        [Fact]
        private void GivenFullHouseHandItShouldReturnFullHouse()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "3D", "2C", "3S", "2D"});
            Assert.Equal("with full house: 2 over 3", rules.ApplyFullHouseRule());
        }
        [Fact]
        private void GivenANonFullHouseHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "3D", "AC", "AS", "AD"});
            Assert.Equal("None", rules.ApplyFullHouseRule());
        } 
        [Fact]
        private void GivenThreeOfAKindHandItShouldReturnThreeOfAKind()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "3D", "3C", "3S", "4D"});
            Assert.Equal("with three of a kind: 3", rules.ApplyThreeOfAKind());
        }
        [Fact]
        private void GivenANonThreeOfAKindHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "3D", "AC", "5S", "AD"});
            Assert.Equal("None", rules.ApplyThreeOfAKind());
        } 
        [Fact]
        private void GivenTwoPairsHandItShouldReturnTwoPairs()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"9H", "9D", "7C", "5S", "7D"});
            Assert.Equal("with two pairs: 9 and 7", rules.ApplyTwoPairs());
        }
        [Fact]
        private void GivenANonTwoPairsHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string [5]{"2H", "3D", "AC", "5S", "AD"});
            Assert.Equal("None", rules.ApplyTwoPairs());
        } 
    }
}
