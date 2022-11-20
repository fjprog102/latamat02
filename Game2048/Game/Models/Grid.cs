namespace Models;

public class Grid
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public int Size { get; set; }
    public Dictionary<int, int> NotEmptyCells = new Dictionary<int, int>();

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

        NotEmptyCells.Add(x, y);
        Cells[x, y] = element;
    }

    public bool IsEmpty(int x, int y)
    {
        if (NotEmptyCells.ContainsKey(x))
        {
            if (NotEmptyCells[x] == y)
            {
                Console.WriteLine(NotEmptyCells[x]);
                return false;
            }
        }

        return true;
    }

    public void GenerateRandomTile(GridElement element)
    {
        Random random = new Random();
        int xPosition = random.Next(1, Rows);
        int yPosition = random.Next(1, Columns);
        if (IsEmpty(xPosition, yPosition))
        {
            InsertElement(xPosition, yPosition, element);
        }
        else
        {
            GenerateRandomTile(element);
        }
    }
}
