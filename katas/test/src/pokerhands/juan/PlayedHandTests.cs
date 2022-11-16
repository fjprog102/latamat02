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
            string output = "";
            string expected = "AH2H3H4H5H";
            foreach (Card card in PlayedHand.GetStraightFlush(new Hand("2H 3H 4H 5H AH")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestGetFourOfAKind()
        {
            string output = "";
            string expected = "2C2D2H2S";
            foreach (Card card in PlayedHand.GetFourOfAKind(new Hand("2C 2D 2H 2S AH")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
            output = "";
            expected = "2C2D2H2S";
            foreach (Card card in PlayedHand.GetFourOfAKind(new Hand("2C 2D 2H 2S 8H")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestGetFullHouse()
        {
            string output = "";
            string expected = "2C2D3H3S3H";
            foreach (Card card in PlayedHand.GetFullHouse(new Hand("2C 2D 3H 3S 3H")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestGetFlush()
        {
            string output = "";
            string expected = "AC2C3C5C7C";
            foreach (Card card in PlayedHand.GetFlush(new Hand("2C 3C 5C 7C AC")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestGetStraigth()
        {
            string output = "";
            string expected = "AH2C3D4H5S";
            foreach (Card card in PlayedHand.GetStraigth(new Hand("2C 3D 4H 5S AH")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestGetThreeOfAKind()
        {
            string output = "";
            string expected = "2C2D2H";
            foreach (Card card in PlayedHand.GetThreeOfAKind(new Hand("2C 2D 2H 5S AH")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestGetTwoPairs()
        {
            string output = "";
            string expected = "2C2D3H3S";
            foreach (Card card in PlayedHand.GetTwoPairs(new Hand("2C 2D 3H 3S AH")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestGetPair()
        {
            string output = "";
            string expected = "2C2D";
            foreach (Card card in PlayedHand.GetPair(new Hand("2C 2D 3H 4S AH")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
        }

        [Fact]
        public void TestGetHighesCard()
        {
            string output = "";
            string expected = "AH";
            foreach (Card card in PlayedHand.GetHighest(new Hand("2C 7D 3H 6S AH")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
            output = "";
            expected = "KH";
            foreach (Card card in PlayedHand.GetHighest(new Hand("2C 7D 3H 6S KH")))
            {
                output += card.ValueAttr.ToString() + card.SuitAttr.ToString();
            }

            Assert.Equal(expected, output);
        }
    }
}
