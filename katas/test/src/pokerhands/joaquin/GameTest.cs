namespace Player.Test.Joaquin;

using PokerHand.Joaquin;

public class GameTest
{
    [Fact]
    public void ItShouldCreateAGameWithTwoPlayersAndHands()
    {
        Hand firstPlayerHand = new Hand("AS JC 4C 7H 2D");
        Hand secondPlayerHand = new Hand("8H 4S TD 9C 7S");
        Game NewGame = new Game("Black", firstPlayerHand, "White", secondPlayerHand);
        Assert.Equal("Black", NewGame.firstPlayer);
        Assert.Equal("White", NewGame.secondPlayer);
    }
}