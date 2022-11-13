namespace HandRanking.Test.Joaquin;

using PokerHand.Joaquin;

public class HandRankingTest 
{

    [Fact]
    public void ItShouldBeStraightFlush()
    {  
        string[] spadesStraight = {"4S", "6S", "5S", "8S", "7S"};
        string[] clubsStraight = {"AC", "TC", "JC", "QC", "KC"};
        string[] diamondsStraight = {"5D", "2D", "6D", "4D", "3D"};
        string[] heartsStraight = {"KH", "QH", "JH", "TH", "9H"};
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsStraightFlush(spadesStraight));
        Assert.True(ranking.IsStraightFlush(clubsStraight));
        Assert.True(ranking.IsStraightFlush(diamondsStraight));
        Assert.True(ranking.IsStraightFlush(heartsStraight));
    }

    [Fact]
    public void ItShouldBeFourOfAKind()
    {  
        string[] aces = {"AS", "AD", "AH", "AC", "7S"};
        string[] sevens = {"7C", "7H", "7D", "QC", "7S"};
        string[] twos = {"2D", "2C", "6D", "2H", "2S"};
        string[] queens = {"QH", "QD", "QS", "TH", "QC"};
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsFourOfAKind(aces));
        Assert.True(ranking.IsFourOfAKind(sevens));
        Assert.True(ranking.IsFourOfAKind(twos));
        Assert.True(ranking.IsFourOfAKind(queens));
    }

    [Fact]
    public void ItShouldBeFullHouse()
    {  
        string[] aceOverThree = {"AS", "3D", "AH", "AC", "3S"};
        string[] fiveOverTwo = {"2C", "5H", "5D", "5C", "2S"};
        string[] tenOverNine = {"9D", "TC", "9C", "TH", "9S"};
        string[] sevenOverSix = {"6H", "6D", "6S", "7H", "7C"};
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsFullHouse(aceOverThree));
        Assert.True(ranking.IsFullHouse(fiveOverTwo));
        Assert.True(ranking.IsFullHouse(tenOverNine));
        Assert.True(ranking.IsFullHouse(sevenOverSix));
    }

    [Fact]
    public void ItShouldBeFlush()
    {  
        string[] spades = {"4S", "2S", "KS", "TS", "7S"};
        string[] clubs = {"3C", "TC", "7C", "QC", "KC"};
        string[] diamonds = {"AD", "2D", "6D", "4D", "3D"};
        string[] hearts = {"KH", "9H", "3H", "TH", "4H"};
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsFlush(spades));
        Assert.True(ranking.IsFlush(clubs));
        Assert.True(ranking.IsFlush(diamonds));
        Assert.True(ranking.IsFlush(hearts));
    }

    [Fact]
    public void ItShouldBeStraight()
    {  
        string[] straight = {"4S", "6D", "5H", "8S", "7S"};
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsStraight(straight));
    }

    [Fact]
    public void ItShouldBeThreeOfAKind()
    {  
        string[] aces = {"AS", "AD", "AH", "AC", "7S"};
        string[] sevens = {"7C", "7H", "7D", "QC", "7S"};
        string[] twos = {"2D", "2C", "6D", "2H", "2S"};
        string[] queens = {"QH", "QD", "QS", "TH", "QC"};
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsFourOfAKind(aces));
        Assert.True(ranking.IsFourOfAKind(sevens));
        Assert.True(ranking.IsFourOfAKind(twos));
        Assert.True(ranking.IsFourOfAKind(queens));
    }
}