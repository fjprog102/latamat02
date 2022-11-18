namespace ModelsTests;

using Models;

public class GridTest
{
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
        Tile element = new Tile(4);

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
        Tile element = new Tile(4);

        Grid grid = new Grid(10, 8);
        grid.InsertElement(new int[2] { 2, 3 }, element);
        grid.InsertElement(new int[2] { 8, 7 }, element);
        grid.InsertElement(new int[2] { 7, 4 }, element);
        Assert.Equal(element, grid.Cells[2, 3]);
        Assert.Equal(element, grid.Cells[8, 7]);
        Assert.Equal(element, grid.Cells[7, 4]);
    }

    [Fact]
    public void ItShouldReturnArrayWithLengthOfTwo()
    {
        Assert.Equal(2, new Grid(10, 8).GetRandomCoordinates().Length);
        Assert.Equal(2, new Grid(4, 4).GetRandomCoordinates().Length);
        Assert.Equal(2, new Grid(3, 7).GetRandomCoordinates().Length);
    }

    [Fact]
    public void RandomNumberInColumnShouldBeLessThan()
    {
        Assert.True(8 > new Grid(10, 8).GetRandomCoordinates()[1]);
        Assert.True(4 > new Grid(4, 4).GetRandomCoordinates()[1]);
        Assert.True(7 > new Grid(3, 7).GetRandomCoordinates()[1]);
    }

    [Fact]
    public void RandomNumberInRowShouldBeLessThan()
    {
        Assert.True(10 > new Grid(10, 8).GetRandomCoordinates()[0]);
        Assert.True(4 > new Grid(4, 4).GetRandomCoordinates()[0]);
        Assert.True(3 > new Grid(3, 7).GetRandomCoordinates()[0]);
    }

    [Fact]
    public void ItShouldThrownAnExceptionWithInvalidCoordinatesInputs()
    {
        Tile element = new Tile(4);

        Grid grid = new Grid(10, 8);
        Assert.Throws<IndexOutOfRangeException>(
            () => grid.InsertElement(new int[2] { 11, 4 }, element)
        );
        Assert.Throws<IndexOutOfRangeException>(
            () => grid.InsertElement(new int[2] { 3, 8 }, element)
        );
        Assert.Throws<IndexOutOfRangeException>(
            () => grid.InsertElement(new int[2] { 10, 8 }, element)
        );
    }
}
