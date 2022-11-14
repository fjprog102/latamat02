namespace HandRanking.Test.Joaquin;

using PokerHand.Joaquin;

public class HandRankingTest
{

    [Fact]
    public void ItShouldBeStraightFlush()
    {
        Hand spadesStraight = new Hand("4S 6S 5S 8S 7S");
        Hand clubsStraight = new Hand("AC TC JC QC KC");
        Hand diamondsStraight = new Hand("5D 2D 6D 4D 3D");
        Hand heartsStraight = new Hand("KH QH JH TH 9H");
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsStraightFlush(spadesStraight));
        Assert.True(ranking.IsStraightFlush(clubsStraight));
        Assert.True(ranking.IsStraightFlush(diamondsStraight));
        Assert.True(ranking.IsStraightFlush(heartsStraight));
    }

    [Fact]
    public void ItShouldBeFourOfAKind()
    {
        Hand aces = new Hand("AS AD AH AC 7S");
        Hand sevens = new Hand("7C 7H 7D QC 7S");
        Hand twos = new Hand("2D 2C 6D 2H 2S");
        Hand queens = new Hand("QH QD QS TH QC");
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsFourOfAKind(aces));
        Assert.True(ranking.IsFourOfAKind(sevens));
        Assert.True(ranking.IsFourOfAKind(twos));
        Assert.True(ranking.IsFourOfAKind(queens));
    }

    [Fact]
    public void ItShouldBeFullHouse()
    {
        Hand aceOverThree = new Hand("AS 3D AH AC 3S");
        Hand fiveOverTwo = new Hand("2C 5H 5D 5C 2S");
        Hand tenOverNine = new Hand("9D TC 9C TH 9S");
        Hand sevenOverSix = new Hand("6H 6D 6S 7H 7C");
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsFullHouse(aceOverThree));
        Assert.True(ranking.IsFullHouse(fiveOverTwo));
        Assert.True(ranking.IsFullHouse(tenOverNine));
        Assert.True(ranking.IsFullHouse(sevenOverSix));
    }

    [Fact]
    public void ItShouldBeFlush()
    {
        Hand spades = new Hand("4S 2S KS TS 7S");
        Hand clubs = new Hand("3C TC 7C QC KC");
        Hand diamonds = new Hand("AD 2D 6D 4D 3D");
        Hand hearts = new Hand("KH 9H 3H TH 4H");
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsFlush(spades));
        Assert.True(ranking.IsFlush(clubs));
        Assert.True(ranking.IsFlush(diamonds));
        Assert.True(ranking.IsFlush(hearts));
    }

    [Fact]
    public void ItShouldBeStraight()
    {
        Hand straight = new Hand("4S 6D 5H 8S 7S");
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsStraight(straight));
    }

    [Fact]
    public void ItShouldBeThreeOfAKind()
    {
        Hand aces = new Hand("3S AD AH AC 7S");
        Hand sevens = new Hand("7C AH 7D QC 7S");
        Hand twos = new Hand("2D 2C 6D 2H 4S");
        Hand queens = new Hand("QH QD 2S TH QC");
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsThreeOfAKind(aces));
        Assert.True(ranking.IsThreeOfAKind(sevens));
        Assert.True(ranking.IsThreeOfAKind(twos));
        Assert.True(ranking.IsThreeOfAKind(queens));
    }

    [Fact]
    public void ItShouldBeTwoPairs()
    {
        Hand acesAndThrees = new Hand("3S AD 3H AC 7S");
        Hand queensAndSevens = new Hand("7C AH QD QC 7S");
        Hand sixesAndTwos = new Hand("2D 2C 6D 6H 4S");
        Hand tensAndFives = new Hand("5H TD 2S TH 5C");
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsTwoPairs(acesAndThrees));
        Assert.True(ranking.IsTwoPairs(queensAndSevens));
        Assert.True(ranking.IsTwoPairs(sixesAndTwos));
        Assert.True(ranking.IsTwoPairs(tensAndFives));
    }

    [Fact]
    public void ItShouldBePair()
    {
        Hand threes = new Hand("3S AD 3H 4C 7S");
        Hand queens = new Hand("7C AH QD QC KS");
        Hand twos = new Hand("2D 2C AD 6H 4S");
        Hand fives = new Hand("5H TD 2S JH 5C");
        HandRanking ranking = new HandRanking();
        Assert.True(ranking.IsPair(threes));
        Assert.True(ranking.IsPair(queens));
        Assert.True(ranking.IsPair(twos));
        Assert.True(ranking.IsPair(fives));
    }
}