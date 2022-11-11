namespace PokerGame.Test.Jorge
{
    using PokerGame.Jorge;

    public class Poker
    {
        [Fact]
        public void WinnerWinner()
        {
            //Should win Black with Four of a Kind
            Assert.Equal(
                "Black wins - with Four of a kind",
                new PokerGameCompetitors().BothHands("Black: 2H 2D 2S 2C KD  White: 2C 3H 4S 8C AH")
            );
            Assert.Equal(
                "White wins - with Straight Flush",
                new PokerGameCompetitors().BothHands("Black: 2H 2D 2S 2C KD  White: AH JH QH TH KH")
            );
            ////Should be tie with tiebreaker of Highcard winning White
            //Assert.Equal(
            //    "White wins.",
            //    new PokerGameCompetitors().BothHands("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH")
            //);
            ////Should win Black (Full vs Highcard)
            //Assert.Equal(
            //    "Black wins.",
            //    new PokerGameCompetitors().BothHands("Black: 2H 4S 4C 2D 4H  White: 2S 8S AS QS 3S")
            //);
            ////Should win Black because second highest card
            //Assert.Equal(
            //    "Black wins.",
            //    new PokerGameCompetitors().BothHands("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C KH")
            //);
            ////Should be tie
            //Assert.Equal(
            //    "Tie.",
            //    new PokerGameCompetitors().BothHands("Black: 2H 3D 5S 9C KD  White: 2D 3H 5C 9S KH")
            //);
        }

        [Fact]
        public void ResultByHands()
        {
            Assert.Equal(1, new PokerHand().HandToPlay("2H 5C TC 4S 6H"));
            Assert.Equal(2, new PokerHand().HandToPlay("2H 2C 3H 4S 6H"));
            Assert.Equal(2.1, new PokerHand().HandToPlay("2H 5C 2C 4S 5H"));
            Assert.Equal(3, new PokerHand().HandToPlay("2H 2D 5S 2C KD"));
            Assert.Equal(3.1, new PokerHand().HandToPlay("7H 5C 6C 3S 4H"));
            Assert.Equal(3.2, new PokerHand().HandToPlay("3C 2C KC 4C TC"));
            Assert.Equal(3.3, new PokerHand().HandToPlay("5H 5C 6C 5S 6H"));
            Assert.Equal(4, new PokerHand().HandToPlay("9H 3D 9S 9C 9D"));
            Assert.Equal(5, new PokerHand().HandToPlay("2H 5H 3H 4H 6H"));
        }
    }
}
