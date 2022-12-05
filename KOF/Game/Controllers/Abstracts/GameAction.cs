namespace KOT.Controllers.Abstracts;

using KOT.Models;

public abstract class GameAction<T> where T : GameAction<T>, new()
{
    private static readonly T _instance = new T();
    public abstract void Execute(string[] dices, GamePayload game);
    public T Instance => _instance;
}
