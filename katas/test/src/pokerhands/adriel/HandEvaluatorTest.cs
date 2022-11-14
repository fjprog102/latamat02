namespace PokerHands.HandsEvaluator.Test.Adriel;

using Enums.Adriel;
using Hands.Adriel;
using HandsEvaluator.Adriel;

public class HandEvaluatorTest
{
    [Fact]
    private void ShouldHaveAPropertyOfTypeHand()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("As 2s 3s 4s 5s"));
        Assert.IsType<Hand>(hr.Hand);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankHighCard()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("tc 4d 8s Kh Qd"));
        Assert.Equal(Ranking.HighCard, hr.Ranking);

        HandEvaluator hr2 = new HandEvaluator(new Hand("2d 3d 4s 5h Ks"));
        Assert.Equal(Ranking.HighCard, hr2.Ranking);

        HandEvaluator hr3 = new HandEvaluator(new Hand("As 4s 8d 2h Js"));
        Assert.Equal(Ranking.HighCard, hr3.Ranking);

        HandEvaluator hr4 = new HandEvaluator(new Hand("6d 5h 3s 9d Qh"));
        Assert.Equal(Ranking.HighCard, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankPair()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("tc td 8s Kh Qd"));
        Assert.Equal(Ranking.Pair, hr.Ranking);

        HandEvaluator hr2 = new HandEvaluator(new Hand("2d 3d 4s 5h 4s"));
        Assert.Equal(Ranking.Pair, hr2.Ranking);

        HandEvaluator hr3 = new HandEvaluator(new Hand("As 4s 8d Ah Js"));
        Assert.Equal(Ranking.Pair, hr3.Ranking);

        HandEvaluator hr4 = new HandEvaluator(new Hand("6d 5h 9s 9d Qh"));
        Assert.Equal(Ranking.Pair, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankTwoPairs()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("tc td 8s Kh 8d"));
        Assert.Equal(Ranking.TwoPairs, hr.Ranking);

        HandEvaluator hr2 = new HandEvaluator(new Hand("2d 2d 4s 5h 4s"));
        Assert.Equal(Ranking.TwoPairs, hr2.Ranking);

        HandEvaluator hr3 = new HandEvaluator(new Hand("As Js 8d Ah Js"));
        Assert.Equal(Ranking.TwoPairs, hr3.Ranking);

        HandEvaluator hr4 = new HandEvaluator(new Hand("6d Qh 9s 9d Qh"));
        Assert.Equal(Ranking.TwoPairs, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankThreeOfAKind()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("tc td ts Kh 8d"));
        Assert.Equal(Ranking.ThreeOfAKind, hr.Ranking);

        HandEvaluator hr2 = new HandEvaluator(new Hand("2d 2d 4s 5h 2s"));
        Assert.Equal(Ranking.ThreeOfAKind, hr2.Ranking);

        HandEvaluator hr3 = new HandEvaluator(new Hand("As Js 8d Ah Ac"));
        Assert.Equal(Ranking.ThreeOfAKind, hr3.Ranking);

        HandEvaluator hr4 = new HandEvaluator(new Hand("9h 2d 9s 9d Qh"));
        Assert.Equal(Ranking.ThreeOfAKind, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankStraight()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("9c 6d 7s 0h 8d"));
        Assert.Equal(Ranking.Straight, hr.Ranking);

        HandEvaluator hr2 = new HandEvaluator(new Hand("2d 3d 4s 5h As"));
        Assert.Equal(Ranking.Straight, hr2.Ranking);

        HandEvaluator hr3 = new HandEvaluator(new Hand("As Js Qd Kh Tc"));
        Assert.Equal(Ranking.Straight, hr3.Ranking);

        HandEvaluator hr4 = new HandEvaluator(new Hand("9h 8d 6s 7d 5h"));
        Assert.Equal(Ranking.Straight, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankFlush()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("9c 6c Kc 2c 8c"));
        Assert.Equal(Ranking.Flush, hr.Ranking);

        HandEvaluator hr2 = new HandEvaluator(new Hand("2d 3d 4d 7d Ad"));
        Assert.Equal(Ranking.Flush, hr2.Ranking);

        HandEvaluator hr3 = new HandEvaluator(new Hand("As Js Qs 6s 2s"));
        Assert.Equal(Ranking.Flush, hr3.Ranking);

        HandEvaluator hr4 = new HandEvaluator(new Hand("9h 8h 6h 0h Kh"));
        Assert.Equal(Ranking.Flush, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankFullHouse()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("9c 9s 9d 2c 2d"));
        Assert.Equal(Ranking.FullHouse, hr.Ranking);

        HandEvaluator hr2 = new HandEvaluator(new Hand("2d 3d 2h 3s 3c"));
        Assert.Equal(Ranking.FullHouse, hr2.Ranking);

        HandEvaluator hr3 = new HandEvaluator(new Hand("As Ad Qs Qd Qc"));
        Assert.Equal(Ranking.FullHouse, hr3.Ranking);

        HandEvaluator hr4 = new HandEvaluator(new Hand("9h 8h 9d 8s 8c"));
        Assert.Equal(Ranking.FullHouse, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankFourOfAKind()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("9c 9s 9d 9h 2d"));
        Assert.Equal(Ranking.FourOfAKind, hr.Ranking);

        HandEvaluator hr2 = new HandEvaluator(new Hand("2d 2c 2h 2s 3c"));
        Assert.Equal(Ranking.FourOfAKind, hr2.Ranking);

        HandEvaluator hr3 = new HandEvaluator(new Hand("As Ad Ac Ah Qc"));
        Assert.Equal(Ranking.FourOfAKind, hr3.Ranking);

        HandEvaluator hr4 = new HandEvaluator(new Hand("9h 9s 9d 9c 8c"));
        Assert.Equal(Ranking.FourOfAKind, hr4.Ranking);
    }

    [Fact]
    private void RankingPropertyShouldCorrectlyContainTheRankStraightFlush()
    {
        HandEvaluator hr = new HandEvaluator(new Hand("9c 6c 7c 0c 8c"));
        Assert.Equal(Ranking.StraightFlush, hr.Ranking);

        HandEvaluator hr2 = new HandEvaluator(new Hand("2d 3d 4d 5d Ad"));
        Assert.Equal(Ranking.StraightFlush, hr2.Ranking);

        HandEvaluator hr3 = new HandEvaluator(new Hand("As Js Qs Ks Ts"));
        Assert.Equal(Ranking.StraightFlush, hr3.Ranking);

        HandEvaluator hr4 = new HandEvaluator(new Hand("9h 8h 6h 7h 5h"));
        Assert.Equal(Ranking.StraightFlush, hr4.Ranking);
    }
}