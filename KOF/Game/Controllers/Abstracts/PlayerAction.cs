namespace KOT.Controllers.Abstracts;

using KOT.Models;

public abstract class PlayerAction<T> where T : PlayerAction<T>, new()
{
    private static readonly T _instance = new T();
    public abstract void Execute(List<string> dices, GamePayload game);
    public T Instance => _instance;
}
