namespace Player.Test.Joaquin;

using PokerHand.Joaquin;

public class PlayerTest
{
    [Fact]
    public void ItShouldCreateAPlayer()
    {
        _ = new Player("Black", new Hand("AS JC 4C 7H 2D"));
        _ = new Player("White", new Hand("7H AH 8S QD TS"));
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
