namespace KOT.Models.Processor;

using KOT.Models;

public abstract class CardsAction<T> where T : CardsAction<T>, new()
{
    private static readonly T _instance = new T();
    // public abstract void Execute(List<string> dices, GamePayload game);
    public T Instance => _instance;
}
