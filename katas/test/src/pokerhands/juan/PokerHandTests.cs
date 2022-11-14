using PokerHands.Juan;
using Xunit.Abstractions;

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

public class TestPlayHandsDataClass : TheoryData<string, string>
{
    public TestPlayHandsDataClass()
    {
        Add("2H 3D 5S 9C KD  2H 3D 5S 9C KD", "Tie with a High card");
        Add("2H 3H 4H 5H AH  2H 3H 4H 5H AH", "Tie with a Straigth flush");
        Add("2H 2D 6S 7C KD  2H 2D 5S 9C KD", "Hand: 2H 2D 5S 9C KD wins with a Pair");
        Add("2H 2D 2S 7C KD  2H 2D 2S 3C KD", "Hand: 2H 2D 2S 7C KD wins with a Three of a kind");
        Add("2H 3D 5S 9C KD  2C 3H 4S 8C KH", "Hand: 2H 3D 5S 9C KD wins with a High card");
        Add("2H 2D 3S 3C KD  2C 2H 4S 4C KH", "Hand: 2C 2H 4S 4C KH wins with a Two pairs");
        Add("2H 2D 3S 3C 3D  2C 2H 4S 4C KH", "Hand: 2H 2D 3S 3C 3D wins with a Full house");
        Add("2H 3D 4S 5C 6D  2C 2H 4S 4C KH", "Hand: 2H 3D 4S 5C 6D wins with a Straigth");
        Add("2C 2H 4S 4C KH  2H 3H 4H 5H 9H", "Hand: 2H 3H 4H 5H 9H wins with a Flush");
        Add("2H 2H 2H 2H 9H  2C 2H 4S 4C KH", "Hand: 2H 2H 2H 2H 9H wins with a Four of a kind");
    }
}

public class PokerHandsTestJuan
{
    private readonly ITestOutputHelper output;

    private string CardToString(Card card)
    {
        return card.ValueAttr.ToString() + card.SuitAttr.ToString();
    }

    public PokerHandsTestJuan(ITestOutputHelper output)
    {
        this.output = output;
    }

    [Theory]
    [ClassData(typeof(TestCardsDataClass))]
    public void TestCard(string input, string expected)
    {
        Assert.Equal(expected, new Card(input).ToStr());
    }

    [Theory]
    [ClassData(typeof(TestHandDataClass))]
    public void TestHand(string input, string expected)
    {
        Assert.Equal(expected, new Hand(input).ToStr());
    }

    [Fact]
    public void TestHandIsStaigthFlush()
    {
        Assert.True(GetHandType.IsStraightFlush(new Hand("2H 3H 4H 5H AH")));
        Assert.False(GetHandType.IsStraightFlush(new Hand("2H 3H 4H 6H AH")));
        Assert.False(GetHandType.IsStraightFlush(new Hand("2H 3H 4H 5C AH")));
    }

    [Fact]
    public void TestHandIsFourOfAKind()
    {
        Assert.True(GetHandType.IsFourOfAKind(new Hand("2C 2D 2H 2S AH")));
        Assert.False(GetHandType.IsFourOfAKind(new Hand("2C 2D 2H 3S AH")));
        Assert.False(GetHandType.IsFourOfAKind(new Hand("2C 3D 4H 5S AH")));
    }

    [Fact]
    public void TestHandIsFullHouse()
    {
        Assert.True(GetHandType.IsFullHouse(new Hand("2C 2D 3H 3S 3H")));
        Assert.False(GetHandType.IsFullHouse(new Hand("2C 2D 3H 3S AH")));
        Assert.False(GetHandType.IsFullHouse(new Hand("2C 3D 4H 5S AH")));
    }

    [Fact]
    public void TestHandIsFlush()
    {
        Assert.True(GetHandType.IsFlush(new Hand("2C 3C 5C 7C AC")));
        Assert.False(GetHandType.IsFlush(new Hand("2C 3H 5C 7C AC")));
    }

    [Fact]
    public void TestHandIsStraight()
    {
        Assert.True(GetHandType.IsStraight(new Hand("2C 3D 4H 5S AH")));
        Assert.False(GetHandType.IsStraight(new Hand("2C 3D 4H 6S AH")));
    }

    [Fact]
    public void TestHandIsThreeOfAKind()
    {
        Assert.True(GetHandType.IsThreeOfAKind(new Hand("2C 2D 2H 5S AH")));
        Assert.False(GetHandType.IsThreeOfAKind(new Hand("2C 2D 3H 3S AH")));
        Assert.False(GetHandType.IsThreeOfAKind(new Hand("2C 3D 4H 5S AH")));
    }

    [Fact]
    public void TestHandIsTwoPairs()
    {
        Assert.True(GetHandType.IsTwoPairs(new Hand("2C 2D 3H 3S AH")));
        Assert.False(GetHandType.IsTwoPairs(new Hand("2C 2D 3H 4S AH")));
        Assert.False(GetHandType.IsTwoPairs(new Hand("3C 3D 3H 5S AH")));
    }

    [Fact]
    public void TestHandIsPair()
    {
        Assert.True(GetHandType.IsPair(new Hand("2C 2D 3H 4S AH")));
        Assert.False(GetHandType.IsPair(new Hand("3C 3D 3H 5S AH")));
    }

    [Fact]
    public void TestHandIsHighCard()
    {
        var hand = new Hand("2C 3D 4H 5S 7H");
        Assert.True(GetHandType.IsHighCard(hand));
        Assert.False(GetHandType.IsFlush(hand));
        Assert.False(GetHandType.IsFourOfAKind(hand));
        Assert.False(GetHandType.IsFullHouse(hand));
        Assert.False(GetHandType.IsStraight(hand));
        Assert.False(GetHandType.IsThreeOfAKind(hand));
        Assert.False(GetHandType.IsTwoPairs(hand));
    }

    [Fact]
    public void TestGetStraigthFlush()
    {
        string opt = "";
        string expected = "AH2H3H4H5H";
        foreach (Card card in GetPlayedHand.GetStraightFlush(new Hand("2H 3H 4H 5H AH")))
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
        foreach (Card card in GetPlayedHand.GetFourOfAKind(new Hand("2C 2D 2H 2S AH")))
        {
            opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
        }

        Assert.Equal(expected, opt);
        opt = "";
        expected = "2C2D2H2S";
        foreach (Card card in GetPlayedHand.GetFourOfAKind(new Hand("2C 2D 2H 2S 8H")))
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
        foreach (Card card in GetPlayedHand.GetFullHouse(new Hand("2C 2D 3H 3S 3H")))
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
        foreach (Card card in GetPlayedHand.GetFlush(new Hand("2C 3C 5C 7C AC")))
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
        foreach (Card card in GetPlayedHand.GetStraigth(new Hand("2C 3D 4H 5S AH")))
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
        foreach (Card card in GetPlayedHand.GetThreeOfAKind(new Hand("2C 2D 2H 5S AH")))
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
        foreach (Card card in GetPlayedHand.GetTwoPairs(new Hand("2C 2D 3H 3S AH")))
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
        foreach (Card card in GetPlayedHand.GetPair(new Hand("2C 2D 3H 4S AH")))
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
        foreach (Card card in GetPlayedHand.GetHighest(new Hand("2C 7D 3H 6S AH")))
        {
            opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
        }

        Assert.Equal(expected, opt);
        opt = "";
        expected = "KH";
        foreach (Card card in GetPlayedHand.GetHighest(new Hand("2C 7D 3H 6S KH")))
        {
            opt += card.ValueAttr.ToString() + card.SuitAttr.ToString();
        }

        Assert.Equal(expected, opt);
    }

    [Theory]
    [ClassData(typeof(TestPlayHandsDataClass))]
    public void TestPlayHands(string input, string expected)
    {
        Assert.Equal(expected, PlayHands.Play(input));
    }
}
