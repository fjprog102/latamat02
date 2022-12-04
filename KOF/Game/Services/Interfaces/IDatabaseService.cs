using MongoDB.Driver;
using KOT.Models;

namespace KOT.Services.Interfaces;

public interface IDatabaseService
{
    public FilterDefinition<T> GetFilterId<T>(string value);
    public IEnumerable<T> Find<T>(string collectionName, FilterDefinition<T>? filter);
    public void InsertOne<T>(string collectionName, T document);
    public void UpdateGame(string collectionName, GamePayload document);
    public T Delete<T>(string collectionName, FilterDefinition<T> filter);
}
