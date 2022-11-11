using PokerHands.Juan;
using Xunit.Abstractions;

public class PokerHandsDataClass : TheoryData<String, String>
{
    public PokerHandsDataClass()
    {
        Add(
            "Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C AH  Black: 2H 4S 4C 2D 4H  White: 2S 8S AS QS 3S  Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C KH  Black: 2H 3D 5S 9C KD  White: 2D 3H 5C 9S KH",
            "White wins. - with high card: Ace"
        );
        /*
        Add(
            "Black: 2H 4S 4C 2D 4H  White: 2S 8S AS QS 3S",
            "Black wins. - with full house: 4 over 2"
        );
        Add("Black: 2H 3D 5S 9C KD  White: 2C 3H 4S 8C KH", "Black wins. - with high card: 9");
        Add("Black: 2H 3D 5S 9C KD  White: 2D 3H 5C 9S KH", "Push.");
        */
    }
}

public class PokerHandsTestJuan
{
    private readonly ITestOutputHelper output;

    public PokerHandsTestJuan(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [ClassData(typeof(PokerHandsDataClass))]
    public void TestPokerHands(String input, String expected)
    {
        output.WriteLine("This is output from {0}", new PokerHandsJuan().PlayHands(input));
        Assert.Equal(expected, new PokerHandsJuan().PlayHands(input));
    }
}
