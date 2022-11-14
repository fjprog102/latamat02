namespace HandRanking.Test.Joaquin;

using PokerHand.Joaquin;

public class HandRankingTest
{
    HandRanking ranking = new HandRanking();
    Hand straightFlush = new Hand("4S 6S 5S 8S 7S"); 
    Hand fourOfAKind = new Hand("AS AD AH AC 7S");
    Hand fullHouse = new Hand("6H 6D 6S 7H 7C");
    Hand flush = new Hand("3C TC 7C QC KC");
    Hand straight = new Hand("4S 6D 5H 8S 7S");
    Hand threeOfAKind = new Hand("2D 2C 6D 2H 4S");
    Hand twoPairs = new Hand("2D 2C 6D 6H 4S");
    Hand pair = new Hand("7C AH QD QC KS");
    Hand highCard = new Hand("7C AH QD 4C KS");

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

        // bool CheckOrder(int[] ranking)
        // {
        //     bool isOrdered = true;
        //     for(int i = 0; i < ranking.Length - 1; i++)
        //     {
        //         if(ranking[i] < ranking[i + 1]) 
        //         return isOrdered = false;
        //     }
        //     return isOrdered;
        // }

        ranking.OrderHandByCardWeight(straightFlush);
        Assert.True(ranking.CheckOrder(ranking.orderedHand));
        ranking.OrderHandByCardWeight(fourOfAKind);
        Assert.True(ranking.CheckOrder(ranking.orderedHand));
        ranking.OrderHandByCardWeight(fullHouse);
        Assert.True(ranking.CheckOrder(ranking.orderedHand));
        ranking.OrderHandByCardWeight(flush);
        Assert.True(ranking.CheckOrder(ranking.orderedHand));
        ranking.OrderHandByCardWeight(straight);
        Assert.True(ranking.CheckOrder(ranking.orderedHand));
        ranking.OrderHandByCardWeight(threeOfAKind);
        Assert.True(ranking.CheckOrder(ranking.orderedHand));
        ranking.OrderHandByCardWeight(twoPairs);
        Assert.True(ranking.CheckOrder(ranking.orderedHand));
        ranking.OrderHandByCardWeight(pair);
        Assert.True(ranking.CheckOrder(ranking.orderedHand));
        ranking.OrderHandByCardWeight(highCard);
    }
}