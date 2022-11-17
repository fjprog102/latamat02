namespace Models;

public class Grid
{
    private int Rows { get; set; }
    private int Columns { get; set; }
    public int Size { get; set; }

    public List<GridElement> Cells = new List<GridElement>();

    public Grid(int rows, int columns)
    {
        if (rows <= 0 || columns <= 0)
        {
            throw new Exception("Rows and columns should bigger than zero.");
        }

        Rows = rows;
        Columns = columns;
        Size = rows * columns;
    }

    public void CreateCells(GridElement element)
    {
        for (int index = 0; index < Size; index++)
        {
            Cells.Add(element);
        }
    }
}
