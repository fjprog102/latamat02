using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Models.Processor;
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

    public void UpdateOne<T>(string collectionName, FilterDefinition<T>? filter, T document)
    {
        var coll = GetCollection<T>(collectionName: collectionName);
        coll.ReplaceOne(filter: filter, replacement: document);
    }

    public T Delete<T>(string collectionName, FilterDefinition<T> filter)
    {
        var coll = GetCollection<T>(collectionName: collectionName);
        return coll.FindOneAndDelete(filter);
    }
}
