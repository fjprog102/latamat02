namespace PokerHands.Test.Valeria
{
    using PokerHands.Valeria;
    public class GamePlayRulesTest
    {
        [Fact]
        private void GivenAHandItShouldReturnTheValuesInAList()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "2D", "3C", "10S", "AD" });
            Assert.Equal(new List<string>() { "10", "2", "2", "3", "A" }, rules.Values);
        }
        [Fact]
        private void GivenAHandItShouldReturnTheSuitsInAList()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "2D", "3C", "3S", "AD" });
            Assert.Equal(new List<char>() { 'H', 'D', 'C', 'S', 'D' }, rules.Suits);
        }
        [Fact]
        private void GivenAHandItShouldMakeADictionaryOfValuesAndTheTimesEachValueRepeats()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "2D", "3C", "3S", "AD" });
            Assert.Equal(new Dictionary<string, int>() { { "3", 2 }, { "2", 2 }, { "A", 1 } }, rules.ValuesCount);
        }
        [Fact]
        private void GivenAHandItShouldMakeADictionaryOfSuitsAndTheTimesEachSuitRepeats()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "2D", "3C", "3S", "AD" });
            Assert.Equal(new Dictionary<char, int>() { { 'D', 2 }, { 'H', 1 }, { 'C', 1 }, { 'S', 1 } }, rules.SuitsCount);
        }
        [Fact]
        private void GivenAStraighyFlushHandItShouldReturnStraighyFlush()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "AH", "2H", "3H", "4H", "5H" });
            Assert.Equal("with straight flush: H", rules.ApplyStraightFlushRule());
        }
        [Fact]
        private void GivenANonStraighyFlushHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "AD", "AC", "AS", "AD" });
            Assert.Equal("None", rules.ApplyStraightFlushRule());
        }
        [Fact]
        private void GivenFourOfAKindHandItShouldReturnFourOfAKind()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "AD", "AC", "AS", "AD" });
            Assert.Equal("with four of a kind: A", rules.ApplyFourOfAKindRule());
        }
        [Fact]
        private void GivenANonFourOfAKindHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "3D", "AC", "AS", "AD" });
            Assert.Equal("None", rules.ApplyFourOfAKindRule());
        }
        [Fact]
        private void GivenFullHouseHandItShouldReturnFullHouse()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "3D", "2C", "3S", "2D" });
            Assert.Equal("with full house: 2 over 3", rules.ApplyFullHouseRule());
        }
        [Fact]
        private void GivenANonFullHouseHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "3D", "AC", "AS", "AD" });
            Assert.Equal("None", rules.ApplyFullHouseRule());
        }
        [Fact]
        private void GivenThreeOfAKindHandItShouldReturnThreeOfAKind()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "3D", "3C", "3S", "4D" });
            Assert.Equal("with three of a kind: 3", rules.ApplyThreeOfAKindRule());
        }
        [Fact]
        private void GivenANonThreeOfAKindHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "3D", "AC", "5S", "AD" });
            Assert.Equal("None", rules.ApplyThreeOfAKindRule());
        }
        [Fact]
        private void GivenTwoPairsHandItShouldReturnTwoPairs()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "9H", "9D", "7C", "5S", "7D" });
            Assert.Equal("with two pairs: 7 and 9", rules.ApplyTwoPairsRule());
        }
        [Fact]
        private void GivenANonTwoPairsHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "3D", "AC", "5S", "AD" });
            Assert.Equal("None", rules.ApplyTwoPairsRule());
        }
        [Fact]
        private void GivenPairHandItShouldReturnPair()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "9H", "9D", "7C", "5S", "8D" });
            Assert.Equal("with pair: 9", rules.ApplyPairRule());
        }
        [Fact]
        private void GivenANonPairHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "3D", "4C", "5S", "AD" });
            Assert.Equal("None", rules.ApplyPairRule());
        }
        [Fact]
        private void GivenFlushHandItShouldReturnFlushMessage()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "9H", "8H", "7H", "5H", "2H" });
            Assert.Equal("with flush: H", rules.ApplyFlushRule());
        }
        [Fact]
        private void GivenANonFlushHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "3D", "4C", "5S", "AD" });
            Assert.Equal("None", rules.ApplyFlushRule());
        }
        private void GivenStraightHandItShouldReturnStraightMessage()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "10H", "8D", "9S", "JH", "QH" });
            Assert.Equal("with straight", rules.ApplyStraightRule());
        }
        [Fact]
        private void GivenANonStraightHandItShouldReturnNone()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "2H", "3D", "4C", "9S", "AD" });
            Assert.Equal("None", rules.ApplyStraightRule());
        }
        [Fact]
        private void GivenHighCardHandItShouldReturnHighCardMessage()
        {
            GamePlayRules rules = new GamePlayRules(new string[5] { "10H", "2D", "AS", "JH", "QH" });
            Assert.Equal("with high card: A", rules.ApplyHighCardRule());

            GamePlayRules rules1 = new GamePlayRules(new string[5] { "10H", "9D", "8S", "7H", "6H" });
            Assert.Equal("with high card: 10", rules1.ApplyHighCardRule());

            GamePlayRules rules2 = new GamePlayRules(new string[5] { "2H", "9D", "8S", "KH", "JH" });
            Assert.Equal("with high card: K", rules2.ApplyHighCardRule());

            GamePlayRules rules3 = new GamePlayRules(new string[5] { "3H", "QD", "8S", "7H", "JH" });
            Assert.Equal("with high card: Q", rules3.ApplyHighCardRule());

            GamePlayRules rules4 = new GamePlayRules(new string[5] { "2H", "7D", "5S", "3H", "4H" });
            Assert.Equal("with high card: 7", rules4.ApplyHighCardRule());
        }
    }
}
