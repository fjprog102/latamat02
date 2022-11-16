using HandJuan;

namespace TestHandsJuan
{
    public class TestHandDataClass : TheoryData<string, string>
    {
        public TestHandDataClass()
        {
            Add(
                "2H 3D 5S 9C KD",
                "suit:H value:2 weigth:2  suit:D value:3 weigth:3  suit:S value:5 weigth:5  suit:C value:9 weigth:9  suit:D value:K weigth:13  "
            );
        }
    }

    public class TestHands
    {
        [Theory]
        [ClassData(typeof(TestHandDataClass))]
        public void TestHand(string input, string expected)
        {
            Assert.Equal(expected, new Hand(input).ToStr());
        }
    }
}
