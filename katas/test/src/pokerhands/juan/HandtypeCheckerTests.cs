using HandJuan;
using HandtypeCheckerJuan;

namespace TestHandtypeCheckerJuan
{
    public class HandtypeCheckerTests
    {
        [Fact]
        public void TestHandIsStaigthFlush()
        {
            Assert.True(HandTypeChecker.IsStraightFlush(new Hand("2H 3H 4H 5H AH")));
            Assert.False(HandTypeChecker.IsStraightFlush(new Hand("2H 3H 4H 6H AH")));
            Assert.False(HandTypeChecker.IsStraightFlush(new Hand("2H 3H 4H 5C AH")));
        }

        [Fact]
        public void TestHandIsFourOfAKind()
        {
            Assert.True(HandTypeChecker.IsFourOfAKind(new Hand("2C 2D 2H 2S AH")));
            Assert.False(HandTypeChecker.IsFourOfAKind(new Hand("2C 2D 2H 3S AH")));
            Assert.False(HandTypeChecker.IsFourOfAKind(new Hand("2C 3D 4H 5S AH")));
        }

        [Fact]
        public void TestHandIsFullHouse()
        {
            Assert.True(HandTypeChecker.IsFullHouse(new Hand("2C 2D 3H 3S 3H")));
            Assert.False(HandTypeChecker.IsFullHouse(new Hand("2C 2D 3H 3S AH")));
            Assert.False(HandTypeChecker.IsFullHouse(new Hand("2C 3D 4H 5S AH")));
        }

        [Fact]
        public void TestHandIsFlush()
        {
            Assert.True(HandTypeChecker.IsFlush(new Hand("2C 3C 5C 7C AC")));
            Assert.False(HandTypeChecker.IsFlush(new Hand("2C 3H 5C 7C AC")));
        }

        [Fact]
        public void TestHandIsStraight()
        {
            Assert.True(HandTypeChecker.IsStraight(new Hand("2C 3D 4H 5S AH")));
            Assert.False(HandTypeChecker.IsStraight(new Hand("2C 3D 4H 6S AH")));
        }

        [Fact]
        public void TestHandIsThreeOfAKind()
        {
            Assert.True(HandTypeChecker.IsThreeOfAKind(new Hand("2C 2D 2H 5S AH")));
            Assert.False(HandTypeChecker.IsThreeOfAKind(new Hand("2C 2D 3H 3S AH")));
            Assert.False(HandTypeChecker.IsThreeOfAKind(new Hand("2C 3D 4H 5S AH")));
        }

        [Fact]
        public void TestHandIsTwoPairs()
        {
            Assert.True(HandTypeChecker.IsTwoPairs(new Hand("2C 2D 3H 3S AH")));
            Assert.False(HandTypeChecker.IsTwoPairs(new Hand("2C 2D 3H 4S AH")));
            Assert.False(HandTypeChecker.IsTwoPairs(new Hand("3C 3D 3H 5S AH")));
        }

        [Fact]
        public void TestHandIsPair()
        {
            Assert.True(HandTypeChecker.IsPair(new Hand("2C 2D 3H 4S AH")));
            Assert.False(HandTypeChecker.IsPair(new Hand("3C 3D 3H 5S AH")));
        }

        [Fact]
        public void TestHandIsHighCard()
        {
            var hand = new Hand("2C 3D 4H 5S 7H");
            Assert.True(HandTypeChecker.IsHighCard(hand));
            Assert.False(HandTypeChecker.IsFlush(hand));
            Assert.False(HandTypeChecker.IsFourOfAKind(hand));
            Assert.False(HandTypeChecker.IsFullHouse(hand));
            Assert.False(HandTypeChecker.IsStraight(hand));
            Assert.False(HandTypeChecker.IsThreeOfAKind(hand));
            Assert.False(HandTypeChecker.IsTwoPairs(hand));
        }
    }
}
