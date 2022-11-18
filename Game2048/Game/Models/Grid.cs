namespace Models;

public class Grid
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public int Size { get; set; }

    public GridElement[,] Cells;

    public Grid(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
        {
            throw new Exception("Rows and columns should bigger than zero.");
        }

        Rows = rows;
        Columns = columns;
        Size = rows * columns;
        Cells = new GridElement[rows, columns];
    }

    public int[] GetRandomCoordinates()
    {
        Random r = new Random();
        int[] coordinates = { r.Next(0, Rows), r.Next(0, Columns) };
        return coordinates;
    }

    public void InsertElement(int[] XY, GridElement element)
    {
        if (XY[0] > Cells.GetLength(0) || XY[1] > Cells.GetLength(1))
        {
            throw new IndexOutOfRangeException("Index was outside of the grid.");
        }

        Cells[XY[0], XY[1]] = element;
    }
}
