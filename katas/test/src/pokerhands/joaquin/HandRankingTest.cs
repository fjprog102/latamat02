namespace PokerHands.Joaquin;

public class HandRankingTest
{
    private readonly HandRanking ranking = new HandRanking();
    private readonly Hand straightFlush = new Hand("4S 6S 5S 8S 7S");
    private readonly Hand fourOfAKind = new Hand("AS AD AH AC 7S");
    private readonly Hand fullHouse = new Hand("6H 6D 6S 7H 7C");
    private readonly Hand flush = new Hand("3C TC 7C QC KC");
    private readonly Hand straight = new Hand("4S 6D 5H 8S 7S");
    private readonly Hand threeOfAKind = new Hand("2D 2C 6D 2H 4S");
    private readonly Hand twoPairs = new Hand("2D 2C 6D 6H 4S");
    private readonly Hand pair = new Hand("7C AH QD QC KS");
    private readonly Hand highCard = new Hand("7C AH QD 4C KS");

    [Fact]
    public void ItShouldReturnTheCorrectHandRanking()
    {
        Assert.Equal(8, ranking.GetHandRanking(straightFlush));
        Assert.Equal(7, ranking.GetHandRanking(fourOfAKind));
        Assert.Equal(6, ranking.GetHandRanking(fullHouse));
        Assert.Equal(5, ranking.GetHandRanking(flush));
        Assert.Equal(4, ranking.GetHandRanking(straight));
        Assert.Equal(3, ranking.GetHandRanking(threeOfAKind));
        Assert.Equal(2, ranking.GetHandRanking(twoPairs));
        Assert.Equal(1, ranking.GetHandRanking(pair));
        Assert.Equal(0, ranking.GetHandRanking(highCard));
    }

    [Fact]
    public void ItShouldReturnTheCorrectRankingType()
    {
        Assert.Equal("straight flush", ranking.GetRankingType(8));
        Assert.Equal("four of a kind", ranking.GetRankingType(7));
        Assert.Equal("full house", ranking.GetRankingType(6));
        Assert.Equal("flush", ranking.GetRankingType(5));
        Assert.Equal("straight", ranking.GetRankingType(4));
        Assert.Equal("three of a kind", ranking.GetRankingType(3));
        Assert.Equal("two pairs", ranking.GetRankingType(2));
        Assert.Equal("pair", ranking.GetRankingType(1));
        Assert.Equal("high card", ranking.GetRankingType(0));
    }

    [Fact]
    public void ItShouldOrderHandByCardValue()
    {
        Assert.True(ranking.CheckOrder(ranking.OrderHandByCardWeight(straightFlush)));
        Assert.True(ranking.CheckOrder(ranking.OrderHandByCardWeight(fourOfAKind)));
        Assert.True(ranking.CheckOrder(ranking.OrderHandByCardWeight(fullHouse)));
        Assert.True(ranking.CheckOrder(ranking.OrderHandByCardWeight(flush)));
        Assert.True(ranking.CheckOrder(ranking.OrderHandByCardWeight(straight)));
        Assert.True(ranking.CheckOrder(ranking.OrderHandByCardWeight(threeOfAKind)));
        Assert.True(ranking.CheckOrder(ranking.OrderHandByCardWeight(twoPairs)));
        Assert.True(ranking.CheckOrder(ranking.OrderHandByCardWeight(pair)));
    }
}
