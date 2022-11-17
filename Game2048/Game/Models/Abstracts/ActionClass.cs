namespace AbstractActionClass
{
    public abstract class AbstractAction<T> where T : AbstractAction<T>, new()
    {
        private static readonly T _instance = new T();

        public abstract void Execute();

        public T Instance => _instance;
    }
}
