namespace ModelsTests;

using KOT.Models;

public class TokyoBoardTest
{
    private readonly TokyoBoard Board = new TokyoBoard();

    [Fact]
    public void ItShouldHaveAnInitializedTokyoCityAttribute()
    {
        Assert.NotNull(Board.TokyoCity);
        Assert.IsType<List<Player>>(Board.TokyoCity);
    }

    [Fact]
    public void ItShouldHaveANullTokyoBayAttribute()
    {
        Assert.Null(Board.TokyoBay);
    }

    [Fact]
    public void ItShouldHaveAnInitializedOutsideTokyoAttribute()
    {
        Assert.NotNull(Board.OutsideTokyo);
        Assert.IsType<List<Player>>(Board.OutsideTokyo);
    }
}
