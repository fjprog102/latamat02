namespace Models;

public class Grid 
{
    private int rows { get; set; }
    private int columns { get; set; }
    public int size { get; set; }

    public List<GridElement> Cells = new List<GridElement>();

    public Grid(int rows, int columns)
    {
        if (rows <= 0  || columns <= 0)
        {
            throw new Exception("Rows and columns should bigger than zero.");
        }
        this.rows = rows;
        this.columns = columns;
        size = rows * columns;
    }

    public void createCells(GridElement element)
    {
        for(int index = 0; index < size; index++)
        {
            Cells.Add(element);
        }
    }
}
