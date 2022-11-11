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
    }
}
