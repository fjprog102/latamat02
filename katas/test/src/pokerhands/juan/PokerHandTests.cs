using PokerHandsJuan;

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
    [Theory]
    [ClassData(typeof(TestPlayHandsDataClass))]
    public void TestPlayHands(string input, string expected)
    {
        Assert.Equal(expected, PlayHands.Play(input));
    }
}
