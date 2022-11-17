namespace Models;

public class Grid
{
    private int Rows { get; set; }
    private int Columns { get; set; }
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

    public void InsertElement(int x, int y, GridElement element)
    {
        if (x > Cells.GetLength(0) || y > Cells.GetLength(1))
        {
            throw new IndexOutOfRangeException("Index was outside of the grid.");
        }

        Cells[x, y] = element;
    }
}
