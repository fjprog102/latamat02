namespace Models;

public class Grid
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public int Size { get; set; }

    public Tile?[,] Cells;

    public Grid(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
        {
            throw new Exception("Rows and columns should bigger than zero.");
        }

        Rows = rows;
        Columns = columns;
        Size = rows * columns;
        Cells = new Tile[rows, columns];
    }

    public void InsertElement(int x, int y, Tile element)
    {
        if (x > Cells.GetLength(0) || y > Cells.GetLength(1))
        {
            throw new IndexOutOfRangeException("Index was outside of the grid.");
        }

        Cells[x, y] = element;
    }
}
