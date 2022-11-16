namespace PokerHands.HandsComparer.Test.Adriel;

using HandsComparer.Adriel;
using Xunit.Abstractions;

public class HandComparerTest
{
    [Fact]
    private void ShouldReturnTheNameOfPlayerOne()
    {
        var hc = new HandComparer("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH");
        Assert.Equal("Black", hc.PlayerOneName);

        var hc2 = new HandComparer("Dude: 2H 4S 4C 2D 4H  Dudette: 2S 8S AS QS 3S");
        Assert.Equal("Dude", hc2.PlayerOneName);

        var hc3 = new HandComparer("Player1: 2H 3D 5S 9C KD  Player2: 2C 3H 4S 8C KH");
        Assert.Equal("Player1", hc3.PlayerOneName);
    }

    [Fact]
    private void ShouldReturnPlayerOneSortedHandAsString()
    {
        var hc = new HandComparer("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH");
        Assert.Equal("2h 3d 5s 9c Kd", hc.PlayerOneHand.Hand.ToString());

        var hc2 = new HandComparer("Dude: 2H 4S 4C 2D 4H  Dudette: 2S 8S AS QS 3S");
        Assert.Equal("2h 2d 4s 4c 4h", hc2.PlayerOneHand.Hand.ToString());

        var hc3 = new HandComparer("Player1: 2H 3D 5S 9C KD  Player2: 2C 3H 4S 8C KH");
        Assert.Equal("2h 3d 5s 9c Kd", hc3.PlayerOneHand.Hand.ToString());
    }

    [Fact]
    private void ShouldReturnTheNameOfPlayerTwo()
    {
        var hc = new HandComparer("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH");
        Assert.Equal("White", hc.PlayerTwoName);

        var hc2 = new HandComparer("Dude: 2H 4S 4C 2D 4H  Dudette: 2S 8S AS QS 3S");
        Assert.Equal("Dudette", hc2.PlayerTwoName);

        var hc3 = new HandComparer("Player1: 2H 3D 5S 9C KD  Player2: 2C 3H 4S 8C KH");
        Assert.Equal("Player2", hc3.PlayerTwoName);
    }

    [Fact]
    private void ShouldReturnPlayerTwoSortedHandAsString()
    {
        var hc = new HandComparer("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH");
        Assert.Equal("2c 3h 4s 8c Ah", hc.PlayerTwoHand.Hand.ToString());

        var hc2 = new HandComparer("Dude: 2H 4S 4C 2D 4H  Dudette: 2S 8S AS QS 3S");
        Assert.Equal("2s 3s 8s Qs As", hc2.PlayerTwoHand.Hand.ToString());

        var hc3 = new HandComparer("Player1: 2H 3D 5S 9C KD  Player2: 2C 3H 4S 8C KH");
        Assert.Equal("2c 3h 4s 8c Kh", hc3.PlayerTwoHand.Hand.ToString());
    }

    [Fact]
    public void ShouldStartRoundAndReturnExpectedWinnerWithRankingAndCardsFormingTheRanking_HighCard()
    {
        string expected = "White wins! with High card: 2c 3h 4s 8c Ah";
        var hc = new HandComparer("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH");
        Assert.Equal(expected, hc.StartRound());

        string expected2 = "Player1 wins! with High card: 2h 3d 5s 9c Kd";
        var hc2 = new HandComparer("Player1: 2H 3D 5S 9C KD  Player2: 2C 3H 4S 8C KH");
        Assert.Equal(expected2, hc2.StartRound());
    }

    [Fact]
    public void ShouldStartRoundAndReturnExpectedWinnerWithRankingAndCardsFormingTheRanking_Pair()
    {
        string expected = "White wins! with Pair: 5h 5s";
        var hc = new HandComparer("White: 5H 3D 5S 9C KD  Black: 2C 3H 4S 2D KH");
        Assert.Equal(expected, hc.StartRound());

        string expected2 = "Player1 wins! with High card: 2h 3d 5s 9c Kd";
        var hc2 = new HandComparer("Player1: 2H 3D 5S 9C KD  Player2: 2C 3H 4S 8C KH");
        Assert.Equal(expected2, hc2.StartRound());
    }

    [Fact]
    public void ShouldStartRoundAndReturnExpectedWinnerWithRankingAndCardsFormingTheRanking_TwoPairs()
    {
        string expected = "Colleague wins! with Two pairs: Qc Qs Kh Kd";
        var hc = new HandComparer("Friend: 6H 2D 8S 3C JC  Colleague: QC KH QS 2D KD");
        Assert.Equal(expected, hc.StartRound());

        string expected2 = "Mario wins! with Two pairs: 2h 2s 4d 4c";
        var hc2 = new HandComparer("Mario: 2H 4D 2S 4C KD  Luigi: 2C 3H 3S 2d KH");
        Assert.Equal(expected2, hc2.StartRound());
    }

    [Fact]
    public void ShouldStartRoundAndReturnExpectedWinnerWithRankingAndCardsFormingTheRanking_ThreeOfAKind()
    {
        string expected = "Black wins! with Three of a kind: 5h 5d 5s";
        var hc = new HandComparer("Black: 5H 5D 5S 3C JC  White: QC KH QS 2D 5D");
        Assert.Equal(expected, hc.StartRound());

        string expected2 = "Player1 wins! with Three of a kind: 7h 7s 7d";
        var hc2 = new HandComparer("Player1: 7H 2D 7S 4C 7D  Player2: 4C 3H 8S 4D 4H");
        Assert.Equal(expected2, hc2.StartRound());
    }

    [Fact]
    public void ShouldStartRoundAndReturnExpectedWinnerWithRankingAndCardsFormingTheRanking_Straight()
    {
        string expected = "Kyle wins! with Straight: 3s 4c 5h 6d 7c";
        var hc = new HandComparer("Kyle: 5H 6D 3S 4C 7C  Cartman: 2C 4H 3S 5D 6D");
        Assert.Equal(expected, hc.StartRound());

        string expected2 = "Stan wins! with Straight: 9h Th Js Qd Kc";
        var hc2 = new HandComparer("Kenny: 5H 3D 4S 2C AD  Stan: KC 0H JS QD 9H");
        Assert.Equal(expected2, hc2.StartRound());
    }

    [Fact]
    public void ShouldStartRoundAndReturnExpectedWinnerWithRankingAndCardsFormingTheRanking_Flush()
    {
        string expected = "You wins! with Flush: 3d 4d 6d Jd Qd";
        var hc = new HandComparer("Me: 2H 3H 6H 0H JH  You: QD 4D 3D 6D JD");
        Assert.Equal(expected, hc.StartRound());

        string expected2 = "Her wins! with Flush: 2c 6c 9c Tc Kc";
        var hc2 = new HandComparer("He: 5H 3D 4S 2C AD  Her: KC 0C 6C 2C 9C");
        Assert.Equal(expected2, hc2.StartRound());
    }

    [Fact]
    public void ShouldStartRoundAndReturnExpectedWinnerWithRankingAndCardsFormingTheRanking_FullHouse()
    {
        string expected = "Dude wins! with Full house: 4 over 2";
        var hc = new HandComparer("Dude: 2H 4S 4C 2D 4H  Dudette: 2S 8S AS QS 3S");
        Assert.Equal(expected, hc.StartRound());

        string expected2 = "Blue wins! with Full house: J over 8";
        var hc2 = new HandComparer("Green: JH 7D JS JC 7S  Blue: JH 8D JS JC 8S");
        Assert.Equal(expected2, hc2.StartRound());
    }

    [Fact]
    public void ShouldStartRoundAndReturnExpectedWinnerWithRankingAndCardsFormingTheRanking_FourOfAKind()
    {
        string expected = "Dudette wins! with Four of a kind: 3d 3h 3c 3s";
        var hc = new HandComparer("Dude: 2H 2S 2C 2D 4H  Dudette: 3D 3H AS 3C 3S");
        Assert.Equal(expected, hc.StartRound());

        string expected2 = "Green wins! with Four of a kind: Jh Js Jc Jd";
        var hc2 = new HandComparer("Green: JH 7D JS JC JD  Blue: 8H 8D JS 8C 8S");
        Assert.Equal(expected2, hc2.StartRound());
    }

    [Fact]
    public void ShouldStartRoundAndReturnExpectedWinnerWithRankingAndCardsFormingTheRanking_StraightFlush()
    {
        string expected = "Rick wins! with Straight flush: 9s Ts Js Qs Ks";
        var hc = new HandComparer("Morty: 2H AH 4H 3H 5H  Rick: KS QS JS 0S 9S");
        Assert.Equal(expected, hc.StartRound());

        string expected2 = "Beth wins! with Straight flush: 4d 5d 6d 7d 8d";
        var hc2 = new HandComparer("Jerry: 2H 4H 3H 5H 6H  Beth: 4D 5D 6D 7D 8D");
        Assert.Equal(expected2, hc2.StartRound());
    }
}
