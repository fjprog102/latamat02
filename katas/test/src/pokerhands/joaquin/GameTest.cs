namespace Player.Test.Joaquin;

using PokerHand.Joaquin;

public class GameTest
{
    [Fact]
    public void ItShouldCreateAGameWithTwoPlayersAndHands()
    {
        Player black = new Player("Black", new Hand("AS JC 4C 7H 2D"));
        Player white = new Player("White", new Hand("8H 4S TD 9C 7S"));
        Game newGame = new Game(black, white);
        Assert.Equal("Black", newGame.firstPlayer.name);
        Assert.Equal("White", newGame.secondPlayer.name);
    }

    [Fact]
    public void BlackPlayerShouldWin()
    {
        Game newGame = new Game(new Player("Black", new Hand("AS JS QS TS KS")), new Player("White", new Hand("8H 4S TD 9C 7S")));
        Assert.Equal("Black wins with straight flush.", newGame.GetWinner(newGame.firstPlayer, newGame.secondPlayer));

        Game newGameII = new Game(new Player("Black", new Hand("2H JS JC JD JH")), new Player("White", new Hand("4S 5C 7H JS 7H")));
        Assert.Equal("Black wins with four of a kind.", newGameII.GetWinner(newGameII.firstPlayer, newGameII.secondPlayer));

        Game newGameIII = new Game(new Player("Black", new Hand("AS 9S 9H AC AD")), new Player("White", new Hand("2C 3C 8C 5C QC")));
        Assert.Equal("Black wins with full house.", newGameIII.GetWinner(newGameIII.firstPlayer, newGameIII.secondPlayer));

        Game newGameIV = new Game(new Player("Black", new Hand("4S 5S 6S TS KS")), new Player("White", new Hand("2C 3H 4C 5C 6H")));
        Assert.Equal("Black wins with flush.", newGameIV.GetWinner(newGameIV.firstPlayer, newGameIV.secondPlayer));

        Game newGameV = new Game(new Player("Black", new Hand("4H 5D 7S 6C 8D")), new Player("White", new Hand("3C 2H QS QC QH")));
        Assert.Equal("Black wins with straight.", newGameV.GetWinner(newGameV.firstPlayer, newGameV.secondPlayer));

        Game newGameVI = new Game(new Player("Black", new Hand("AH 6D AS AC QD")), new Player("White", new Hand("3C 3H 7S 7C KH")));
        Assert.Equal("Black wins with three of a kind.", newGameVI.GetWinner(newGameVI.firstPlayer, newGameVI.secondPlayer));

        Game newGameVII = new Game(new Player("Black", new Hand("2H 6D QS 6C QD")), new Player("White", new Hand("2C 3H KS 8C KH")));
        Assert.Equal("Black wins with two pairs.", newGameVII.GetWinner(newGameVII.firstPlayer, newGameVII.secondPlayer));

        Game newGameVIII = new Game(new Player("Black", new Hand("2H 3D 5S 3C 8D")), new Player("White", new Hand("2C 3H 4S 8C KH")));
        Assert.Equal("Black wins with pair.", newGameVIII.GetWinner(newGameVIII.firstPlayer, newGameVIII.secondPlayer));

        Game newGameIX = new Game(new Player("Black", new Hand("2H JS 4C 8D 3H")), new Player("White", new Hand("4S 5C 7H TS 6H")));
        Assert.Equal("Black wins with high card.", newGameIX.GetWinner(newGameIX.firstPlayer, newGameIX.secondPlayer));
    }

    [Fact]
    public void WhitePlayerShouldWin()
    {
        Game newGame = new Game(firstPlayer: new Player("Black", new Hand("8H 4S TD 9C 7S")), new Player("White", new Hand("AS JS QS TS KS")));
        Assert.Equal("White wins with straight flush.", newGame.GetWinner(newGame.firstPlayer, newGame.secondPlayer));

        Game newGameII = new Game(new Player("Black", new Hand("4S 5C 7H JS 7H")), new Player("White", new Hand("2H JS JC JD JH")));
        Assert.Equal("White wins with four of a kind.", newGameII.GetWinner(newGameII.firstPlayer, newGameII.secondPlayer));

        Game newGameIII = new Game(new Player("Black", new Hand("2C 3C 8C 5C QC")), new Player("White", new Hand("AS 9S 9H AC AD")));
        Assert.Equal("White wins with full house.", newGameIII.GetWinner(newGameIII.firstPlayer, newGameIII.secondPlayer));

        Game newGameIV = new Game(new Player("Black", new Hand("2C 3H 4C 5C 6H")), new Player("White", new Hand("4S 5S 6S TS KS")));
        Assert.Equal("White wins with flush.", newGameIV.GetWinner(newGameIV.firstPlayer, newGameIV.secondPlayer));

        Game newGameV = new Game(new Player("Black", new Hand("3C 2H QS QC QH")), new Player("White", new Hand("4H 5D 6S 7C 8D")));
        Assert.Equal("White wins with straight.", newGameV.GetWinner(newGameV.firstPlayer, newGameV.secondPlayer));

        Game newGameVI = new Game(new Player("Black", new Hand("3C 3H 7S 7C KH")), new Player("White", new Hand("AH 6D AS AC QD")));
        Assert.Equal("White wins with three of a kind.", newGameVI.GetWinner(newGameVI.firstPlayer, newGameVI.secondPlayer));

        Game newGameVII = new Game(new Player("Black", new Hand("2C 3H KS 8C KH")), new Player("White", new Hand("2H 6D QS 6C QD")));
        Assert.Equal("White wins with two pairs.", newGameVII.GetWinner(newGameVII.firstPlayer, newGameVII.secondPlayer));

        Game newGameVIII = new Game(new Player("Black", new Hand("2C 3H 4S 8C KH")), new Player("White", new Hand("2H 3D 5S 3C 8D")));
        Assert.Equal("White wins with pair.", newGameVIII.GetWinner(newGameVIII.firstPlayer, newGameVIII.secondPlayer));

        Game newGameIX = new Game(new Player("Black", new Hand("4S 5C 7H TS 6H")), new Player("White", new Hand("2H JS 4C 8D 3H")));
        Assert.Equal("White wins with high card.", newGameIX.GetWinner(newGameIX.firstPlayer, newGameIX.secondPlayer));
    }

    [Fact]
    public void ItShouldBeATie()
    {
        Game newGame = new Game(firstPlayer: new Player("Black", new Hand("2H 3D 5S 9C KD")), new Player("White", new Hand("2D 3H 5C 9S KH")));
        Assert.Equal("Tie.", newGame.GetWinner(newGame.firstPlayer, newGame.secondPlayer));

        Game newGameII = new Game(new Player("Black", new Hand("AH QD 5S 9C KD")), new Player("White", new Hand("AD QH 5C 9S KH")));
        Assert.Equal("Tie.", newGameII.GetWinner(newGameII.firstPlayer, newGameII.secondPlayer));

        Game newGameIII = new Game(new Player("Black", new Hand("7D QH JC TS 7H")), new Player("White", new Hand("7S QC JH TC 7C")));
        Assert.Equal("Tie.", newGameIII.GetWinner(newGameIII.firstPlayer, newGameIII.secondPlayer));

        Game newGameIV = new Game(new Player("Black", new Hand("AD QH JC AS 7H")), new Player("White", new Hand("JS AC AH QC 7C")));
        Assert.Equal("Tie.", newGameIV.GetWinner(newGameIV.firstPlayer, newGameIV.secondPlayer));

        Game newGameVI = new Game(new Player("Black", new Hand("4H 4D 5H 5D 8C")), new Player("White", new Hand("5C 4C 4S 8S 5S")));
        Assert.Equal("Tie.", newGameVI.GetWinner(newGameVI.firstPlayer, newGameVI.secondPlayer));

        Game newGameVII = new Game(new Player("Black", new Hand("6S 7C 8D 9D TH")), new Player("White", new Hand("6H 7S 8S 9S TS")));
        Assert.Equal("Tie.", newGameVII.GetWinner(newGameVII.firstPlayer, newGameVII.secondPlayer));

        Game newGameVIII = new Game(new Player("Black", new Hand("8H 9H TH JH QH")), new Player("White", new Hand("8C 9C TC JC QC")));
        Assert.Equal("Tie.", newGameVIII.GetWinner(newGameVIII.firstPlayer, newGameVIII.secondPlayer));
    }
}
