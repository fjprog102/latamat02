namespace PokerHands.Test.Valeria
{
    using PokerHands.Valeria;
    public class DealerTest
    {
        /*
        The dealer gives 5 random cards to Black player and gives 5
        random cards to white player.
        And the verdict is given by the dealer when both players 
        choose the best highlight games
        */
        [Fact]
        private void DealerShouldGive5RandomCards()
        {
            Dealer theDealer = new Dealer();
            List<string> hand = theDealer.GiveAHand();
            Assert.Equal(5, hand.Count);
        }
        [Fact]
        private void DealerShouldOpenTheGameGivingAHandToEachPlayer()
        {
            Dealer theDealer = new Dealer();
            string[] whiteHand = theDealer.WhitePlayer.MyHand;
            string[] blackHand = theDealer.BlackPlayer.MyHand;

            Assert.Equal(5, whiteHand.Length);
            Assert.Equal(5, blackHand.Length);
        }
        [Fact]
        private void DealerShouldCalculatePointsForEachPlayer()
        {
            Dealer theDealer = new Dealer();
            theDealer.CalculatePointsForEachPlayer();
            int blackPoints = theDealer.BlackPlayerPoints;
            int whitePoints = theDealer.WhitePlayerPoints;
            Assert.True(blackPoints > 0);
            Assert.True(whitePoints > 0);
        }
        [Fact]
        private void DealerShouldAnnounceWinner()
        {
            Dealer theDealer = new Dealer();
            theDealer.CalculatePointsForEachPlayer();
            string winner = theDealer.AnnounceWinner();
            Assert.True(winner.Length > 0);
        }
    }
}
