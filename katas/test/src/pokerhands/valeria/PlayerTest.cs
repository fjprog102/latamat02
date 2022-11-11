namespace PokerHands.Test.Valeria
{
    using PokerHands.Valeria;
    public class PlayerTest
    {
        [Fact]
        private void PlayerShouldShowTheCardsThatHasBeenGiven()
        {
            string []Hand= new string [5]{"2H", "2D", "3C", "3S", "AD"};
            Player BlackPlayer = new Player(Hand);
            Assert.Equal(Hand, BlackPlayer.MyHand);
        }
    }
}
