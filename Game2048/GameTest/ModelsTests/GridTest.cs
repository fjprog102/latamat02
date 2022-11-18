namespace ModelsTests;

using Models;

public class GridTest
{
    private readonly Tile element = new Tile(4);

    [Fact]
    public void ItShouldCreateAGridWithTheCorrectSize()
    {
        Grid grid = new Grid(2, 4);
        Grid gridTwo = new Grid(10, 10);
        Assert.Equal(8, grid.Size);
        Assert.Equal(100, gridTwo.Size);
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
    public void ItShouldCreateTheCellsOfTheGrid()
    {
        Grid grid = new Grid(10, 8);
        Assert.Equal(10, grid.Cells.GetLength(0));
        Assert.Equal(8, grid.Cells.GetLength(1));
        Grid gridTwo = new Grid(3, 3);
        Assert.Equal(3, gridTwo.Cells.GetLength(0));
        Assert.Equal(3, gridTwo.Cells.GetLength(1));
    }

    [Fact]
    public void ItShouldInsertAnElementOnTheGrid()
    {
        Grid grid = new Grid(10, 8);
        grid.InsertElement(2, 3, element);
        grid.InsertElement(8, 7, element);
        grid.InsertElement(7, 4, element);
        Assert.Equal(element, grid.Cells[2, 3]);
        Assert.Equal(element, grid.Cells[8, 7]);
        Assert.Equal(element, grid.Cells[7, 4]);
    }

    [Fact]
    public void ItShouldThrownAnExceptionWithInvalidCoordinatesInputs()
    {
        Grid grid = new Grid(10, 8);
        Assert.Throws<IndexOutOfRangeException>(() => grid.InsertElement(11, 4, element));
        Assert.Throws<IndexOutOfRangeException>(() => grid.InsertElement(3, 8, element));
        Assert.Throws<IndexOutOfRangeException>(() => grid.InsertElement(10, 8, element));
    }
}
