namespace Models;

public class Grid
{
    public int Rows { get; set; }
    public int Columns { get; set; }
    public int Size { get; set; }
    public List<int[]> EmptyCells = new List<int[]>();

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

    public void VerifyEmptyCells()
    {
        EmptyCells.Clear();
        for (int i = 0; i < Rows; i++)
        {
            for (int j = 0; j < Columns; j++)
            {
                if (Cells[i, j] == null)
                {
                    EmptyCells.Add(new int[] { i, j });
                }
            }
        }
    }

    public void InsertElement(int x, int y, GridElement element)
    {
        if (x > Cells.GetLength(0) || y > Cells.GetLength(1))
        {
            throw new IndexOutOfRangeException("Index was outside of the grid.");
        }

        Cells[x, y] = element;
    }

    public void GenerateRandomTile(Tile element)
    {
        VerifyEmptyCells();
        Random random = new Random();
        int randomPosition = random.Next(EmptyCells.Count);
        InsertElement(EmptyCells[randomPosition][0], EmptyCells[randomPosition][1], element);
        VerifyEmptyCells();
    }
}
