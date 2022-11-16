namespace PokerHands.HandsKickersEvaluator.Test.Adriel;

using Hands.Adriel;
using HandsKickersEvaluator.Adriel;

public class HandKickersEvaluatorTest
{
    [Fact]
    private void MethodShouldReturnThreeKickerCardsAsASortedArray()
    {
        Hand hand = new Hand("2s 2d 4s 5s 6s");
        Assert.Equal("4s", HandKickersEvaluator.Pair(hand).First().ToString());
        Assert.Equal("5s", HandKickersEvaluator.Pair(hand).ElementAt(1).ToString());
        Assert.Equal("6s", HandKickersEvaluator.Pair(hand).Last().ToString());

        Hand hand2 = new Hand("7s 7d Qs Ks Js");
        Assert.Equal("Js", HandKickersEvaluator.Pair(hand2).First().ToString());
        Assert.Equal("Qs", HandKickersEvaluator.Pair(hand2).ElementAt(1).ToString());
        Assert.Equal("Ks", HandKickersEvaluator.Pair(hand2).Last().ToString());
    }

    //Same method receives TwoPairs or FourOfAKind
    [Fact]
    private void MethodShouldReturnOneKickerCardsAsAnArray()
    {
        Hand hand = new Hand("2s 2d 4s 4d 6s");
        Assert.Equal("6s", HandKickersEvaluator.TwoPairsOrFourOfAKind(hand).First().ToString());
        Assert.Equal("6s", HandKickersEvaluator.TwoPairsOrFourOfAKind(hand).Last().ToString());

        Hand hand2 = new Hand("7s 7h 7c 7d Js");
        Assert.Equal("Js", HandKickersEvaluator.TwoPairsOrFourOfAKind(hand2).First().ToString());
        Assert.Equal("Js", HandKickersEvaluator.TwoPairsOrFourOfAKind(hand2).Last().ToString());

    }

    [Fact]
    private void MethodShouldReturnTwoKickerCardsAsASortedArray()
    {
        Hand hand = new Hand("6s 2d 2c 2s 5s");
        Assert.Equal("5s", HandKickersEvaluator.Pair(hand).First().ToString());
        Assert.Equal("6s", HandKickersEvaluator.Pair(hand).Last().ToString());

        Hand hand2 = new Hand("7s 7d 7c Qs Js");
        Assert.Equal("Js", HandKickersEvaluator.Pair(hand2).First().ToString());
        Assert.Equal("Qs", HandKickersEvaluator.Pair(hand2).Last().ToString());
    }
}
