namespace KOT.Controllers.Abstracts;

using KOT.Models;

public abstract class PowerCardAction<T> where T : PowerCardAction<T>, new()
{
    private static readonly T _instance = new T();
    public abstract void Execute(GamePayload game);
    public T Instance => _instance;
}
