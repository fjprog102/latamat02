namespace PokerHands.Test.Valeria
{
    using PokerHands.Valeria;
    public class PlayerTest
    {
        [Fact]
        private void PlayerShouldShowTheCardsThatHasBeenGiven()
        {
            string []hand= new string [5]{"2H", "2D", "3C", "3S", "AD"};
            Player blackPlayer = new Player(hand);
            Assert.Equal(hand, blackPlayer.MyHand);
        }
    }
}
