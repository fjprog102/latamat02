using CardJuan;
using HandJuan;
using PlayedHandJuan;

namespace PlayedHandTestsJuan
{
    public class PlayedHandTests
    {
        [Fact]
        public void TestGetStraigthFlush()
        {
            string opt = "";
            string expected = "AH2H3H4H5H";
            foreach (Card card in PlayedHand.GetStraightFlush(new Hand("2H 3H 4H 5H AH")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
        }

        [Fact]
        public void TestGetFourOfAKind()
        {
            string opt = "";
            string expected = "2C2D2H2S";
            foreach (Card card in PlayedHand.GetFourOfAKind(new Hand("2C 2D 2H 2S AH")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
            opt = "";
            expected = "2C2D2H2S";
            foreach (Card card in PlayedHand.GetFourOfAKind(new Hand("2C 2D 2H 2S 8H")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
        }

        [Fact]
        public void TestGetFullHouse()
        {
            string opt = "";
            string expected = "2C2D3H3S3H";
            foreach (Card card in PlayedHand.GetFullHouse(new Hand("2C 2D 3H 3S 3H")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
        }

        [Fact]
        public void TestGetFlush()
        {
            string opt = "";
            string expected = "AC2C3C5C7C";
            foreach (Card card in PlayedHand.GetFlush(new Hand("2C 3C 5C 7C AC")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
        }

        [Fact]
        public void TestGetStraigth()
        {
            string opt = "";
            string expected = "AH2C3D4H5S";
            foreach (Card card in PlayedHand.GetStraigth(new Hand("2C 3D 4H 5S AH")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
        }

        [Fact]
        public void TestGetThreeOfAKind()
        {
            string opt = "";
            string expected = "2C2D2H";
            foreach (Card card in PlayedHand.GetThreeOfAKind(new Hand("2C 2D 2H 5S AH")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
        }

        [Fact]
        public void TestGetTwoPairs()
        {
            string opt = "";
            string expected = "2C2D3H3S";
            foreach (Card card in PlayedHand.GetTwoPairs(new Hand("2C 2D 3H 3S AH")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
        }

        [Fact]
        public void TestGetPair()
        {
            string opt = "";
            string expected = "2C2D";
            foreach (Card card in PlayedHand.GetPair(new Hand("2C 2D 3H 4S AH")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
        }

        [Fact]
        public void TestGetHighesCard()
        {
            string opt = "";
            string expected = "AH";
            foreach (Card card in PlayedHand.GetHighest(new Hand("2C 7D 3H 6S AH")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
            opt = "";
            expected = "KH";
            foreach (Card card in PlayedHand.GetHighest(new Hand("2C 7D 3H 6S KH")))
            {
                opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, opt);
        }
    }
}
