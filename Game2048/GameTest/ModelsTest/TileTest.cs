namespace ModelsTests;

using Models;

public class TileTest
{
    [Fact]
    public void TileComponentShouldThrowAnArgumentErrorIfCreatedWithIncorrectValue()
    {
        string message = "Tile value must be a multiple of two";

        ArgumentException ex1 = Assert.Throws<ArgumentException>(() => new Tile(1));
        Assert.Equal(message, ex1.Message);

        ArgumentException ex2 = Assert.Throws<ArgumentException>(() => new Tile(3));
        Assert.Equal(message, ex2.Message);

        ArgumentException ex3 = Assert.Throws<ArgumentException>(() => new Tile(5));
        Assert.Equal(message, ex3.Message);

        ArgumentException ex4 = Assert.Throws<ArgumentException>(() => new Tile(7));
        Assert.Equal(message, ex4.Message);

    }

    [Fact]
    public void TileComponentShouldBeCreatedWithAccordingValue()
    {
        Assert.Equal(0, new Tile(0).Value);
        Assert.Equal(2, new Tile(2).Value);
        Assert.Equal(4, new Tile(4).Value);
        Assert.Equal(8, new Tile(8).Value);
    }
}
