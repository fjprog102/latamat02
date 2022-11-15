namespace PokerHands.Test.Valeria
{
    using PokerHands.Valeria;
    public class PlayerTest
    {
        [Fact]
        private void PlayerShouldShowTheCardsThatHasBeenGiven()
        {
            string[] hand = new string[5] { "2H", "2D", "3C", "3S", "AD" };
            Player blackPlayer = new Player(hand);
            Assert.Equal(hand, blackPlayer.MyHand);
        }
        [Fact]
        private void PlayerShouldPlayTheBestStrategyPossible()
        {
            Player blackPlayer = new Player(new string[] { "KH", "KD", "KS", "KH", "JH" });
            Assert.Equal("with four of a kind: K", blackPlayer.MyBestPlay);

            Player whitePlayer = new Player(new string[] { "KH", "AD", "10S", "KH", "JH" });
            Assert.Equal("with pair: K", whitePlayer.MyBestPlay);
            
            Player greenPlayer = new Player(new string[] { "KH", "AH", "10H", "QH", "JH" });
            Assert.Equal("with straight flush: H", greenPlayer.MyBestPlay);

            Player purplePlayer = new Player(new string[] { "KH", "AH", "10S", "QH", "JD" });
            Assert.Equal("with straight", purplePlayer.MyBestPlay);

            Player redPlayer = new Player(new string[] { "KH", "AH", "KS", "AS", "AD" });
            Assert.Equal("with full house: A over K", redPlayer.MyBestPlay);

            Player bluePlayer = new Player(new string[] { "AH", "AD", "10S", "AS", "JH" });
            Assert.Equal("with three of a kind: A", bluePlayer.MyBestPlay);
        }
    }
}
