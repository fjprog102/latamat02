using CardJuan;

namespace TestCardsJuan
{
    public class TestCardsDataClass : TheoryData<string, string>
    {
        public TestCardsDataClass()
        {
            Add("2H", "suit:H value:2 weigth:2");
            Add("TH", "suit:H value:T weigth:10");
            Add("JH", "suit:H value:J weigth:11");
            Add("QH", "suit:H value:Q weigth:12");
            Add("KH", "suit:H value:K weigth:13");
            Add("AH", "suit:H value:A weigth:1");
        }
    }

    public class TestCards
    {
        [Theory]
        [ClassData(typeof(TestCardsDataClass))]
        public void TestCard(string input, string expected)
        {
            Assert.Equal(expected, new Card(input).ToStr());
        }
    }
}
