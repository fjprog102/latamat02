namespace PokerGame.Test.Jorge
{
    using PokerGame.Hands.Jorge;

    public class Poker
    {
        [Fact]
        public void WinnerWinner()
        {
            Assert.Equal(
                "Black wins - with FourOfAKind of 2",
                new GameBlackAndWhite().BothHands("Black: 2H 2D 2S 2C KD  White: 2C 3H 4S 8C AH")
            );
            Assert.Equal(
                "White wins - with StraightFlush of A",
                new GameBlackAndWhite().BothHands("Black: 2H 2D 2S 2C KD  White: AH JH QH TH KH")
            );
            Assert.Equal(
                "White wins - with Highcard and High Card of A",
                new GameBlackAndWhite().BothHands("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH")
            );
            Assert.Equal(
                "Black wins - with FullHouse of 4",
                new GameBlackAndWhite().BothHands("Black: 2H 4S 4C 2D 4H  White: 2S 8S AS QS 3S")
            );
        }

        [Fact]
        public void ShouldBeHighCard()
        {
            Assert.Equal("1", new Hand().HandStringToList("2H 5C TC 4S 6H")[0]);
            Assert.Equal("1", new Hand().HandStringToList("TH AC 7H 4S 6H")[0]);
            Assert.Equal("1", new Hand().HandStringToList("AH QC KC JS 3H")[0]);
        }

        [Fact]
        public void ShouldBePair()
        {
            Assert.Equal("2", new Hand().HandStringToList("2H 5C TC 4S TH")[0]);
            Assert.Equal("2", new Hand().HandStringToList("2H 2C 3H 4S 6H")[0]);
            Assert.Equal("2", new Hand().HandStringToList("9H 7C 3H 9S 6H")[0]);
        }

        [Fact]
        public void ShouldBeTwoPais()
        {
            Assert.Equal("3", new Hand().HandStringToList("7H 5C TC 7S 5H")[0]);
            Assert.Equal("3", new Hand().HandStringToList("2H 2C 3H 3S 6H")[0]);
            Assert.Equal("3", new Hand().HandStringToList("QH QC AC 4S AH")[0]);
        }

        [Fact]
        public void ShouldBeThreeOfAKind()
        {
            Assert.Equal("4", new Hand().HandStringToList("TH 5C TC TS 9H")[0]);
            Assert.Equal("4", new Hand().HandStringToList("2H 2C 3H JS 2H")[0]);
            Assert.Equal("4", new Hand().HandStringToList("QH QC QS 4S AH")[0]);
        }

        [Fact]
        public void ShouldBeStraight()
        {
            Assert.Equal("5", new Hand().HandStringToList("7S 4H 5S 8S 6H")[0]);
            Assert.Equal("5", new Hand().HandStringToList("2C 3C 4C 5C 6S")[0]);
            Assert.Equal("5", new Hand().HandStringToList("JS QC AS KH TS")[0]);
        }

        [Fact]
        public void ShouldBeFlush()
        {
            Assert.Equal("6", new Hand().HandStringToList("TH QH 5H 4H 9H")[0]);
            Assert.Equal("6", new Hand().HandStringToList("2C 3C 4C JC QC")[0]);
            Assert.Equal("6", new Hand().HandStringToList("4S TS 7S 2S AS")[0]);
        }

        [Fact]
        public void ShouldBeFullHouse()
        {
            Assert.Equal("7", new Hand().HandStringToList("TH 5C TC TS 5H")[0]);
            Assert.Equal("7", new Hand().HandStringToList("2H 2C 3H 3S 2H")[0]);
            Assert.Equal("7", new Hand().HandStringToList("QH QC QS AS AH")[0]);
        }

        [Fact]
        public void ShouldBeFourOfAKind()
        {
            Assert.Equal("8", new Hand().HandStringToList("TH 5C TC TS TD")[0]);
            Assert.Equal("8", new Hand().HandStringToList("2H 2C 3H 2D 2S")[0]);
            Assert.Equal("8", new Hand().HandStringToList("QH QC QS 4S QD")[0]);
        }

        [Fact]
        public void ShouldBeStraightFlush()
        {
            Assert.Equal("9", new Hand().HandStringToList("TH QH KH AH JH")[0]);
            Assert.Equal("9", new Hand().HandStringToList("2C 3C 4C 5C 6C")[0]);
            Assert.Equal("9", new Hand().HandStringToList("4S 5S 7S 6S 8S")[0]);
        }
    }
}
