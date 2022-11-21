using Models;

namespace Actions
{
    public abstract class AbstractAction<T> where T : AbstractAction<T>, new()
    {
        private static readonly T _instance = new T();

        public abstract void Execute(Grid grid);

        public List<Tile?> MergeList(List<Tile?> values)
        {
            for (int i = values.Count() - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (!IsEmpty(values, j) && !IsEmpty(values, i))
                    {
                        if (IsSameValue(values, i, j))
                        {
                            values[j] = null;
                            values[i] = new Tile(values[i]!.Value * 2);
                            break;
                        }

                        break;
                    }
                }
            }

            return values;
        }

        public List<Tile?> MoveList(List<Tile?> values)
        {
            for (int i = values.Count() - 1; i > 0; i--)
            {
                for (int j = i - 1; j >= 0; j--)
                {
                    if (!IsEmpty(values, j) && IsEmpty(values, i))
                    {
                        values[i] = values[j];
                        values[j] = null;
                        break;
                    }
                }
            }

            return values;
        }

        public List<Tile?> GetRow(Grid grid, int rowNumber)
        {
            return Enumerable
                .Range(0, grid.Columns)
                .Select(x => grid.Cells[rowNumber, x])
                .ToList()!;
        }

        public List<Tile?> GetColumn(Grid grid, int columnNumber)
        {
            return Enumerable
                .Range(0, grid.Rows)
                .Select(x => grid.Cells[x, columnNumber])
                .ToList()!;
        }

        public void SetRow(Grid grid, List<Tile?> row, int rowNumber)
        {
            for (int i = 0; i < row.Count(); i++)
            {
                grid.Cells[rowNumber, i] = row.ElementAt(i);
            }
        }

        public void SetColumn(Grid grid, List<Tile?> row, int columnNumber)
        {
            for (int i = 0; i < row.Count(); i++)
            {
                grid.Cells[i, columnNumber] = row.ElementAt(i);
            }
        }

        public bool IsEmpty(List<Tile?> values, int index)
        {
            return values.ElementAt(index) == null;
        }

        public bool IsSameValue(List<Tile?> values, int indexA, int indexB)
        {
            return values.ElementAt(indexA)!.Value == values.ElementAt(indexB)!.Value;
        }

        public T Instance => _instance;
    }
}
