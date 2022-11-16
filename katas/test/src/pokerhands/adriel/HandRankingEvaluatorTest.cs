namespace PokerHands.HandsRankingEvaluator.Test.Adriel;

using Enums.Adriel;
using Hands.Adriel;
using HandsRankingEvaluator.Adriel;

public class HandRankingEvaluatorTest
{
    [Fact]
    private void MethodShouldCorrectlyReturnHighCardForAHandWithHighCard()
    {
        Hand hand = new Hand("tc 4d 8s Kh Qd");
        Assert.Equal(Ranking.HighCard, HandRankingEvaluator.Evaluate(hand));

        Hand hand2 = new Hand("2d 3d 4s 5h Ks");
        Assert.Equal(Ranking.HighCard, HandRankingEvaluator.Evaluate(hand2));

        Hand hand3 = new Hand("As 4s 8d 2h Js");
        Assert.Equal(Ranking.HighCard, HandRankingEvaluator.Evaluate(hand3));

        Hand hand4 = new Hand("6d 5h 3s 9d Qh");
        Assert.Equal(Ranking.HighCard, HandRankingEvaluator.Evaluate(hand4));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnPairForAHandWithPair()
    {
        Hand hand = new Hand("tc td 8s Kh Qd");
        Assert.Equal(Ranking.Pair, HandRankingEvaluator.Evaluate(hand));

        Hand hand2 = new Hand("2d 3d 4s 5h 4s");
        Assert.Equal(Ranking.Pair, HandRankingEvaluator.Evaluate(hand2));

        Hand hand3 = new Hand("As 4s 8d Ah Js");
        Assert.Equal(Ranking.Pair, HandRankingEvaluator.Evaluate(hand3));

        Hand hand4 = new Hand("6d 5h 9s 9d Qh");
        Assert.Equal(Ranking.Pair, HandRankingEvaluator.Evaluate(hand4));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnTwoPairsForAHandWithTwoPairs()
    {
        Hand hand = new Hand("tc td 8s Kh 8d");
        Assert.Equal(Ranking.TwoPairs, HandRankingEvaluator.Evaluate(hand));

        Hand hand2 = new Hand("2d 2d 4s 5h 4s");
        Assert.Equal(Ranking.TwoPairs, HandRankingEvaluator.Evaluate(hand2));

        Hand hand3 = new Hand("As Js 8d Ah Js");
        Assert.Equal(Ranking.TwoPairs, HandRankingEvaluator.Evaluate(hand3));

        Hand hand4 = new Hand("6d Qh 9s 9d Qh");
        Assert.Equal(Ranking.TwoPairs, HandRankingEvaluator.Evaluate(hand4));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnThreeOfAKindForAHandWithThreeOfAKind()
    {
        Hand hand = new Hand("tc td ts Kh 8d");
        Assert.Equal(Ranking.ThreeOfAKind, HandRankingEvaluator.Evaluate(hand));

        Hand hand2 = new Hand("2d 2d 4s 5h 2s");
        Assert.Equal(Ranking.ThreeOfAKind, HandRankingEvaluator.Evaluate(hand2));

        Hand hand3 = new Hand("As Js 8d Ah Ac");
        Assert.Equal(Ranking.ThreeOfAKind, HandRankingEvaluator.Evaluate(hand3));

        Hand hand4 = new Hand("9h 2d 9s 9d Qh");
        Assert.Equal(Ranking.ThreeOfAKind, HandRankingEvaluator.Evaluate(hand4));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnStraightForAHandWithStraight()
    {
        Hand hand = new Hand("9c 6d 7s 0h 8d");
        Assert.Equal(Ranking.Straight, HandRankingEvaluator.Evaluate(hand));

        Hand hand2 = new Hand("2d 3d 4s 5h As");
        Assert.Equal(Ranking.Straight, HandRankingEvaluator.Evaluate(hand2));

        Hand hand3 = new Hand("As Js Qd Kh Tc");
        Assert.Equal(Ranking.Straight, HandRankingEvaluator.Evaluate(hand3));

        Hand hand4 = new Hand("9h 8d 6s 7d 5h");
        Assert.Equal(Ranking.Straight, HandRankingEvaluator.Evaluate(hand4));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnFlushForAHandWithFlush()
    {
        Hand hand = new Hand("9c 6c Kc 2c 8c");
        Assert.Equal(Ranking.Flush, HandRankingEvaluator.Evaluate(hand));

        Hand hand2 = new Hand("2d 3d 4d 7d Ad");
        Assert.Equal(Ranking.Flush, HandRankingEvaluator.Evaluate(hand2));

        Hand hand3 = new Hand("As Js Qs 6s 2s");
        Assert.Equal(Ranking.Flush, HandRankingEvaluator.Evaluate(hand3));

        Hand hand4 = new Hand("9h 8h 6h 0h Kh");
        Assert.Equal(Ranking.Flush, HandRankingEvaluator.Evaluate(hand4));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnFullHouseForAHandWithFullHouse()
    {
        Hand hand = new Hand("9c 9s 9d 2c 2d");
        Assert.Equal(Ranking.FullHouse, HandRankingEvaluator.Evaluate(hand));

        Hand hand2 = new Hand("2d 3d 2h 3s 3c");
        Assert.Equal(Ranking.FullHouse, HandRankingEvaluator.Evaluate(hand2));

        Hand hand3 = new Hand("As Ad Qs Qd Qc");
        Assert.Equal(Ranking.FullHouse, HandRankingEvaluator.Evaluate(hand3));

        Hand hand4 = new Hand("9h 8h 9d 8s 8c");
        Assert.Equal(Ranking.FullHouse, HandRankingEvaluator.Evaluate(hand4));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnFourOfAKindForAHandWithFourOfAKind()
    {
        Hand hand = new Hand("9c 9s 9d 9h 2d");
        Assert.Equal(Ranking.FourOfAKind, HandRankingEvaluator.Evaluate(hand));

        Hand hand2 = new Hand("2d 2c 2h 2s 3c");
        Assert.Equal(Ranking.FourOfAKind, HandRankingEvaluator.Evaluate(hand2));

        Hand hand3 = new Hand("As Ad Ac Ah Qc");
        Assert.Equal(Ranking.FourOfAKind, HandRankingEvaluator.Evaluate(hand3));

        Hand hand4 = new Hand("9h 9s 9d 9c 8c");
        Assert.Equal(Ranking.FourOfAKind, HandRankingEvaluator.Evaluate(hand4));
    }

    [Fact]
    private void MethodShouldCorrectlyReturnStraightFlushForAHandWithStraightFlush()
    {
        Hand hand = new Hand("9c 6c 7c 0c 8c");
        Assert.Equal(Ranking.StraightFlush, HandRankingEvaluator.Evaluate(hand));

        Hand hand2 = new Hand("2d 3d 4d 5d Ad");
        Assert.Equal(Ranking.StraightFlush, HandRankingEvaluator.Evaluate(hand2));

        Hand hand3 = new Hand("As Js Qs Ks Ts");
        Assert.Equal(Ranking.StraightFlush, HandRankingEvaluator.Evaluate(hand3));

        Hand hand4 = new Hand("9h 8h 6h 7h 5h");
        Assert.Equal(Ranking.StraightFlush, HandRankingEvaluator.Evaluate(hand4));
    }
}
