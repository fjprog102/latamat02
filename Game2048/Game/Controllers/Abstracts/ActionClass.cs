using Models;

namespace Actions
{
    public abstract class AbstractAction<T> where T : AbstractAction<T>, new()
    {
        private static readonly T _instance = new T();

        public abstract void Execute();

        public List<Tile?> MergeRow(List<Tile?> values)
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
                            values[i]!.IncreaseValue();
                            break;
                        }
                    }
                }
            }

            return values;
        }

        public List<Tile?> MoveRow(List<Tile?> values)
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
