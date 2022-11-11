namespace PokerHands.HandsRanker.Test.Adriel;

using Enums.Adriel;
using Hands.Adriel;
using HandsRanker.Adriel;

public class HandRankerTest
{
    [Fact]
    private void ShouldHaveAPropertyOfTypeHand()
    {
        HandRanker hr = new HandRanker(new Hand("As 2s 3s 4s 5s"));
        Assert.IsType<Hand>(hr.Hand);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankHighCard()
    {
        HandRanker hr = new HandRanker(new Hand("tc 4d 8s Kh Qd"));
        Assert.Equal(Ranking.HighCard, hr.Ranking);

        HandRanker hr2 = new HandRanker(new Hand("2d 3d 4s 5h Ks"));
        Assert.Equal(Ranking.HighCard, hr2.Ranking);

        HandRanker hr3 = new HandRanker(new Hand("As 4s 8d 2h Js"));
        Assert.Equal(Ranking.HighCard, hr3.Ranking);

        HandRanker hr4 = new HandRanker(new Hand("6d 5h 3s 9d Qh"));
        Assert.Equal(Ranking.HighCard, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankPair()
    {
        HandRanker hr = new HandRanker(new Hand("tc td 8s Kh Qd"));
        Assert.Equal(Ranking.Pair, hr.Ranking);

        HandRanker hr2 = new HandRanker(new Hand("2d 3d 4s 5h 4s"));
        Assert.Equal(Ranking.Pair, hr2.Ranking);

        HandRanker hr3 = new HandRanker(new Hand("As 4s 8d Ah Js"));
        Assert.Equal(Ranking.Pair, hr3.Ranking);

        HandRanker hr4 = new HandRanker(new Hand("6d 5h 9s 9d Qh"));
        Assert.Equal(Ranking.Pair, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankTwoPairs()
    {
        HandRanker hr = new HandRanker(new Hand("tc td 8s Kh 8d"));
        Assert.Equal(Ranking.TwoPairs, hr.Ranking);

        HandRanker hr2 = new HandRanker(new Hand("2d 2d 4s 5h 4s"));
        Assert.Equal(Ranking.TwoPairs, hr2.Ranking);

        HandRanker hr3 = new HandRanker(new Hand("As Js 8d Ah Js"));
        Assert.Equal(Ranking.TwoPairs, hr3.Ranking);

        HandRanker hr4 = new HandRanker(new Hand("6d Qh 9s 9d Qh"));
        Assert.Equal(Ranking.TwoPairs, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankThreeOfAKind()
    {
        HandRanker hr = new HandRanker(new Hand("tc td ts Kh 8d"));
        Assert.Equal(Ranking.ThreeOfAKind, hr.Ranking);

        HandRanker hr2 = new HandRanker(new Hand("2d 2d 4s 5h 2s"));
        Assert.Equal(Ranking.ThreeOfAKind, hr2.Ranking);

        HandRanker hr3 = new HandRanker(new Hand("As Js 8d Ah Ac"));
        Assert.Equal(Ranking.ThreeOfAKind, hr3.Ranking);

        HandRanker hr4 = new HandRanker(new Hand("9h 2d 9s 9d Qh"));
        Assert.Equal(Ranking.ThreeOfAKind, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankStraight()
    {
        HandRanker hr = new HandRanker(new Hand("9c 6d 7s 0h 8d"));
        Assert.Equal(Ranking.Straight, hr.Ranking);

        HandRanker hr2 = new HandRanker(new Hand("2d 3d 4s 5h As"));
        Assert.Equal(Ranking.Straight, hr2.Ranking);

        HandRanker hr3 = new HandRanker(new Hand("As Js Qd Kh Tc"));
        Assert.Equal(Ranking.Straight, hr3.Ranking);

        HandRanker hr4 = new HandRanker(new Hand("9h 8d 6s 7d 5h"));
        Assert.Equal(Ranking.Straight, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankFlush()
    {
        HandRanker hr = new HandRanker(new Hand("9c 6c Kc 2c 8c"));
        Assert.Equal(Ranking.Flush, hr.Ranking);

        HandRanker hr2 = new HandRanker(new Hand("2d 3d 4d 7d Ad"));
        Assert.Equal(Ranking.Flush, hr2.Ranking);

        HandRanker hr3 = new HandRanker(new Hand("As Js Qs 6s 2s"));
        Assert.Equal(Ranking.Flush, hr3.Ranking);

        HandRanker hr4 = new HandRanker(new Hand("9h 8h 6h 0h Kh"));
        Assert.Equal(Ranking.Flush, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankFullHouse()
    {
        HandRanker hr = new HandRanker(new Hand("9c 9s 9d 2c 2d"));
        Assert.Equal(Ranking.FullHouse, hr.Ranking);

        HandRanker hr2 = new HandRanker(new Hand("2d 3d 2h 3s 3c"));
        Assert.Equal(Ranking.FullHouse, hr2.Ranking);

        HandRanker hr3 = new HandRanker(new Hand("As Ad Qs Qd Qc"));
        Assert.Equal(Ranking.FullHouse, hr3.Ranking);

        HandRanker hr4 = new HandRanker(new Hand("9h 8h 9d 8s 8c"));
        Assert.Equal(Ranking.FullHouse, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankFourOfAKind()
    {
        HandRanker hr = new HandRanker(new Hand("9c 9s 9d 9h 2d"));
        Assert.Equal(Ranking.FourOfAKind, hr.Ranking);

        HandRanker hr2 = new HandRanker(new Hand("2d 2c 2h 2s 3c"));
        Assert.Equal(Ranking.FourOfAKind, hr2.Ranking);

        HandRanker hr3 = new HandRanker(new Hand("As Ad Ac Ah Qc"));
        Assert.Equal(Ranking.FourOfAKind, hr3.Ranking);

        HandRanker hr4 = new HandRanker(new Hand("9h 9s 9d 9c 8c"));
        Assert.Equal(Ranking.FourOfAKind, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankStraightFlush()
    {
        HandRanker hr = new HandRanker(new Hand("9c 6c 7c 0c 8c"));
        Assert.Equal(Ranking.StraightFlush, hr.Ranking);

        HandRanker hr2 = new HandRanker(new Hand("2d 3d 4d 5d Ad"));
        Assert.Equal(Ranking.StraightFlush, hr2.Ranking);

        HandRanker hr3 = new HandRanker(new Hand("As Js Qs Ks Ts"));
        Assert.Equal(Ranking.StraightFlush, hr3.Ranking);

        HandRanker hr4 = new HandRanker(new Hand("9h 8h 6h 7h 5h"));
        Assert.Equal(Ranking.StraightFlush, hr4.Ranking);
    }
}