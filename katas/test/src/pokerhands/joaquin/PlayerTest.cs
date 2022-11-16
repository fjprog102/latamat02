namespace PokerHands.Joaquin;

public class PlayerTest
{
    [Fact]
    public void ItShouldCreateAPlayerWithoutThrowingAnException()
    {
        Player black = new Player("Black", new Hand("AS JC 4C 7H 2D"));
        Player white = new Player("White", new Hand("7H AH 8S QD TS"));
        Assert.Equal("Black", black.name);
        Assert.Equal("White", white.name);
    }

    [Fact]
    public void ItShouldThrowAnExceptionWithInvalidInputs()
    {
        Assert.Throws<ArgumentException>(() => new Player("jg", new Hand("AS JC 4C 7H 2D")));
        Assert.Throws<ArgumentException>(() => new Player("ThisNameIsTooLong", new Hand("7H AH 8S QD TS")));
        Assert.Throws<ArgumentException>(() => new Player("Jorge", new Hand("7H AH TS")));
        Assert.Throws<ArgumentException>(() => new Player("Jose", new Hand("374289239")));
    }
}
