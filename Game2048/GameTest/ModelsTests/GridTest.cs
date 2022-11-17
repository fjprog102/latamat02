namespace ModelsTests;

using Models;

public class GridTest
{
    [Fact]
    public void ItShouldCreateAGridWithTheCorrectSize()
    {
        Grid grid = new Grid(2, 4);
        Grid gridTwo = new Grid(10, 10);
        Assert.Equal(8, grid.size);
        Assert.Equal(100, gridTwo.size);
    }

    [Fact]
    public void ItShouldThrownAnExceptionWithNegativeInputsAndZeros()
    {
        Assert.Throws<Exception>(() => new Grid(0, 4));
        Assert.Throws<Exception>(() => new Grid(-2, 2));
        Assert.Throws<Exception>(() => new Grid(4, -8));
        Assert.Throws<Exception>(() => new Grid(-3, -3));
    }

    [Fact]
    public void GridShouldHaveTheCellsEmptyWhenCreated()
    {
        Grid grid = new Grid(2, 4);
        Assert.Empty(grid.Cells);
    }

    // [Fact]
    // public void ItShouldCreateTheGridCells()
    // {
    //     Grid grid = new Grid(2, 4);
    //     Tile element = new Tile();
    //     grid.createCells(element);
    //     Assert.Equal(8, grid.Cells.Count());
    // }
}
