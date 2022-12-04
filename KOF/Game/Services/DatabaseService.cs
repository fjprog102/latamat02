using KOT.Models;
using KOT.Models.Processor;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Driver;

namespace KOT.Services;

public class DatabaseService : IDatabaseService
{
    private readonly MongoClient _mongoClient;
    private readonly IMongoDatabase _mongoDatabase;

    public DatabaseService(IOptions<KOTDatabaseSettings> kotDatabaseSettings)
    {
        _mongoClient = new MongoClient(kotDatabaseSettings.Value.ConnectionString);
        _mongoDatabase = _mongoClient.GetDatabase(kotDatabaseSettings.Value.DatabaseName);
    }

    private IMongoCollection<T> GetCollection<T>(string collectionName)
    {
        return _mongoDatabase.GetCollection<T>(collectionName);
    }

    public FilterDefinition<T> GetFilterId<T>(string value)
    {
        var id = new ObjectId(value);
        return Builders<T>.Filter.AnyEq("_id", id);
    }

    public IEnumerable<T> Find<T>(string collectionName, FilterDefinition<T>? filter)
    {
        var coll = GetCollection<T>(collectionName: collectionName);
        if (filter != null)
        {
            return coll.Find(filter).ToList();
        }
        else
        {
            return coll.Find(x => true).ToList();
        }
    }

    public void InsertOne<T>(string collectionName, T document)
    {
        var coll = GetCollection<T>(collectionName: collectionName);
        coll.InsertOne(document: document);
    }

    public void UpdateGame(string collectionName, GamePayload document)
    {
        var objectId = new ObjectId(document.Id);
        var filter = Builders<Game>.Filter.AnyEq("_id", objectId);
        var update = Builders<Game>.Update
            .Set(game => game.Board, document.Board)
            .Set(game => game.BoardProcessor, document.BoardProcessor)
            .Set(game => game.ActivePlayerName, document.ActivePlayerName);

        var coll = GetCollection<Game>(collectionName: collectionName);
        coll.UpdateOne(filter, update);
    }

    public T Delete<T>(string collectionName, FilterDefinition<T> filter)
    {
        var coll = GetCollection<T>(collectionName: collectionName);
        return coll.FindOneAndDelete(filter);
    }
}
