namespace PokerHands.HandsMainEvaluator.Test.Adriel;

using Hands.Adriel;
using HandsMainEvaluator.Adriel;

public class HandMainEvaluatorTest
{
    [Fact]
    private void MethodShouldReturnTwoMainCardsAsASortedArray()
    {
        Hand hand = new Hand("2s 6d 4s 5s 6s");
        Assert.Equal("6d", HandMainEvaluator.Pair(hand).First().ToString());
        Assert.Equal("6s", HandMainEvaluator.Pair(hand).Last().ToString());

        Hand hand2 = new Hand("2s 7d 4s 7s 6s");
        Assert.Equal("7d", HandMainEvaluator.Pair(hand2).First().ToString());
        Assert.Equal("7s", HandMainEvaluator.Pair(hand2).Last().ToString());
    }

    [Fact]
    private void MethodShouldReturnTwoGroupsOfTwoMainCardsEachAsAConcatenatedArray()
    {

        //TwoPairs
        Hand hand = new Hand("4s 6d 4d 5s 6s");
        Assert.Equal("4s", HandMainEvaluator.TwoPairs(hand).First().ToString());
        Assert.Equal("4d", HandMainEvaluator.TwoPairs(hand).ElementAt(1).ToString());
        Assert.Equal("6d", HandMainEvaluator.TwoPairs(hand).ElementAt(2).ToString());
        Assert.Equal("6s", HandMainEvaluator.TwoPairs(hand).Last().ToString());

        Hand hand2 = new Hand("Js 3d 2d Jd 3h");
        Assert.Equal("Js", HandMainEvaluator.TwoPairs(hand2).First().ToString());
        Assert.Equal("Jd", HandMainEvaluator.TwoPairs(hand2).ElementAt(1).ToString());
        Assert.Equal("3d", HandMainEvaluator.TwoPairs(hand2).ElementAt(2).ToString());
        Assert.Equal("3h", HandMainEvaluator.TwoPairs(hand2).Last().ToString());
    }

    [Fact]
    private void MethodShouldReturnFourMainCardsAsASortedArray()
    {
        Hand hand3 = new Hand("Js 3d Jc Jd Jh");
        Assert.Equal("Js", HandMainEvaluator.FourOfAKind(hand3).First().ToString());
        Assert.Equal("Jc", HandMainEvaluator.FourOfAKind(hand3).ElementAt(1).ToString());
        Assert.Equal("Jd", HandMainEvaluator.FourOfAKind(hand3).ElementAt(2).ToString());
        Assert.Equal("Jh", HandMainEvaluator.FourOfAKind(hand3).Last().ToString());

        Hand hand4 = new Hand("7s 7d 7c 4d 7h");
        Assert.Equal("7s", HandMainEvaluator.FourOfAKind(hand4).First().ToString());
        Assert.Equal("7d", HandMainEvaluator.FourOfAKind(hand4).ElementAt(1).ToString());
        Assert.Equal("7c", HandMainEvaluator.FourOfAKind(hand4).ElementAt(2).ToString());
        Assert.Equal("7h", HandMainEvaluator.FourOfAKind(hand4).Last().ToString());
    }

    [Fact]
    private void MethodShouldReturnThreeMainCardsAsASortedArray()
    {
        Hand hand = new Hand("4s 6d 4d 5s 4c");
        Assert.Equal("4s", HandMainEvaluator.ThreeOfAKind(hand).First().ToString());
        Assert.Equal("4d", HandMainEvaluator.ThreeOfAKind(hand).ElementAt(1).ToString());
        Assert.Equal("4c", HandMainEvaluator.ThreeOfAKind(hand).Last().ToString());

        Hand hand2 = new Hand("Js 3d 2d 3c 3h");
        Assert.Equal("3d", HandMainEvaluator.ThreeOfAKind(hand2).First().ToString());
        Assert.Equal("3c", HandMainEvaluator.ThreeOfAKind(hand2).ElementAt(1).ToString());
        Assert.Equal("3h", HandMainEvaluator.ThreeOfAKind(hand2).Last().ToString());
    }

    [Fact]
    private void MethodShouldReturnFiveMainCardsAsAnArray()
    {
        //High Card
        Hand hand = new Hand("7s 5d 2h 8d 3c");
        Assert.Equal("2h", HandMainEvaluator.OtherRankings(hand).First().ToString());
        Assert.Equal("3c", HandMainEvaluator.OtherRankings(hand).ElementAt(1).ToString());
        Assert.Equal("5d", HandMainEvaluator.OtherRankings(hand).ElementAt(2).ToString());
        Assert.Equal("7s", HandMainEvaluator.OtherRankings(hand).ElementAt(3).ToString());
        Assert.Equal("8d", HandMainEvaluator.OtherRankings(hand).Last().ToString());

        //Full House
        Hand hand2 = new Hand("7s 5d 7h 5s 5c");
        Assert.Equal("5d", HandMainEvaluator.OtherRankings(hand2).First().ToString());
        Assert.Equal("5s", HandMainEvaluator.OtherRankings(hand2).ElementAt(1).ToString());
        Assert.Equal("5c", HandMainEvaluator.OtherRankings(hand2).ElementAt(2).ToString());
        Assert.Equal("7s", HandMainEvaluator.OtherRankings(hand2).ElementAt(3).ToString());
        Assert.Equal("7h", HandMainEvaluator.OtherRankings(hand2).Last().ToString());

        //Flush
        Hand hand3 = new Hand("6s 2s Js Qs 7s");
        Assert.Equal("2s", HandMainEvaluator.OtherRankings(hand3).First().ToString());
        Assert.Equal("6s", HandMainEvaluator.OtherRankings(hand3).ElementAt(1).ToString());
        Assert.Equal("7s", HandMainEvaluator.OtherRankings(hand3).ElementAt(2).ToString());
        Assert.Equal("Js", HandMainEvaluator.OtherRankings(hand3).ElementAt(3).ToString());
        Assert.Equal("Qs", HandMainEvaluator.OtherRankings(hand3).Last().ToString());

        //Straight
        Hand hand4 = new Hand("7s 5d 6h 4s 8c");
        Assert.Equal("4s", HandMainEvaluator.OtherRankings(hand4).First().ToString());
        Assert.Equal("5d", HandMainEvaluator.OtherRankings(hand4).ElementAt(1).ToString());
        Assert.Equal("6h", HandMainEvaluator.OtherRankings(hand4).ElementAt(2).ToString());
        Assert.Equal("7s", HandMainEvaluator.OtherRankings(hand4).ElementAt(3).ToString());
        Assert.Equal("8c", HandMainEvaluator.OtherRankings(hand4).Last().ToString());

        //Straight Flush
        Hand hand5 = new Hand("6s 5s 2s 3s 4s");
        Assert.Equal("2s", HandMainEvaluator.OtherRankings(hand5).First().ToString());
        Assert.Equal("3s", HandMainEvaluator.OtherRankings(hand5).ElementAt(1).ToString());
        Assert.Equal("4s", HandMainEvaluator.OtherRankings(hand5).ElementAt(2).ToString());
        Assert.Equal("5s", HandMainEvaluator.OtherRankings(hand5).ElementAt(3).ToString());
        Assert.Equal("6s", HandMainEvaluator.OtherRankings(hand5).Last().ToString());

        //Ace-low Straight Flush
        Hand hand6 = new Hand("As 5s 2s 4s 3s");
        Assert.Equal("As", HandMainEvaluator.OtherRankings(hand6).First().ToString());
        Assert.Equal("2s", HandMainEvaluator.OtherRankings(hand6).ElementAt(1).ToString());
        Assert.Equal("3s", HandMainEvaluator.OtherRankings(hand6).ElementAt(2).ToString());
        Assert.Equal("4s", HandMainEvaluator.OtherRankings(hand6).ElementAt(3).ToString());
        Assert.Equal("5s", HandMainEvaluator.OtherRankings(hand6).Last().ToString());
    }
}
