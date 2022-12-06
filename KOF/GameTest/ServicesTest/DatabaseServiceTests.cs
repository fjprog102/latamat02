using KOT.Models;
using KOT.Services;
using Microsoft.Extensions.Options;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using MongoDB.Driver;

public class DatabaseServiceTests
{
    public IOptions<KOTDatabaseSettings> GetOptions()
    {
        var settings = new KOTDatabaseSettings();
        settings.ConnectionString =
            "mongodb+srv://root:root@kotdatabase.qjcyfel.mongodb.net/?retryWrites=true&w=majority";
        settings.DatabaseName = "TestDatabase";
        settings.TestDatabaseName = "TestDatabase";
        settings.TestCollectionName = "TestCollection";
        var options = Options.Create(settings);
        return options;
    }

    private void CleanUpDatabase()
    {
        var connectionString =
            "mongodb+srv://root:root@kotdatabase.qjcyfel.mongodb.net/?retryWrites=true&w=majority";
        var testDatabaseName = "TestDatabase";
        var testCollectionName = "TestCollection";
        var mongoClient = new MongoClient(connectionString);
        var mongoDatabase = mongoClient.GetDatabase(testDatabaseName);

        mongoDatabase.DropCollection(testCollectionName);
    }

    public class TestModel<T>
    {
        [BsonId]
        [BsonRepresentation(BsonType.ObjectId)]
        public string? Id { get; set; }

        [BsonElement("value")]
        public T Value { get; set; }

        public TestModel(T value)
        {
            Value = value;
        }
    }

    [Fact]
    public void TestsGetFilterId()
    {
        var options = GetOptions();
        var service = new DatabaseService(kotDatabaseSettings: options);
        var idMock = new ObjectId();
        var filter = service.GetFilterId<TestModel<int>>(idMock.ToString());

        Assert.True(filter is FilterDefinition<TestModel<int>>);
    }

    [Fact]
    public void TestsFindMethodWithFilter()
    {
        var options = GetOptions();
        var service = new DatabaseService(kotDatabaseSettings: options);
        var idMock = new ObjectId();
        var filter = service.GetFilterId<TestModel<int>>(idMock.ToString());

        var result = service.Find<TestModel<int>>(options.Value.TestCollectionName, filter);

        Assert.True(result is IEnumerable<TestModel<int>>);
    }

    [Fact]
    public void TestsFindMethodWithoutFilter()
    {
        var options = GetOptions();
        var service = new DatabaseService(kotDatabaseSettings: options);

        var result = service.Find<TestModel<int>>(options.Value.TestCollectionName, null);

        Assert.True(result is IEnumerable<TestModel<int>>);
    }

    [Fact]
    public void TestsInsertOneMethod()
    {
        CleanUpDatabase();
        var options = GetOptions();
        var service = new DatabaseService(kotDatabaseSettings: options);

        var entity = new TestModel<int>(value: 5);
        service.InsertOne<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            document: entity
        );

        var result = service.Find<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            filter: null
        );

        Assert.True(result is IEnumerable<TestModel<int>>);
        Assert.Single(collection: result);
        CleanUpDatabase();
    }

    [Fact]
    public void TestsUpdateOneMethod()
    {
        CleanUpDatabase();
        var options = GetOptions();
        var service = new DatabaseService(kotDatabaseSettings: options);

        var entity = new TestModel<int>(value: 5);

        service.InsertOne<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            document: entity
        );

        var current = service.Find<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            filter: null
        );
        var id = current.First().Id;
        var filter = service.GetFilterId<TestModel<int>>(value: id!);

        var newEntity = new TestModel<int>(value: 10);
        newEntity.Id = id;
        service.UpdateOne<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            filter: filter,
            document: newEntity
        );

        var result = service.Find<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            filter: filter
        );

        Assert.True(result is IEnumerable<TestModel<int>>);
        Assert.Single(collection: result);
        Assert.Equal(newEntity.Id, result.First().Id);
        Assert.Equal(newEntity.Value, result.First().Value);
        CleanUpDatabase();
    }

    [Fact]
    public void TestsDeleteMethod()
    {
        CleanUpDatabase();
        var options = GetOptions();
        var service = new DatabaseService(kotDatabaseSettings: options);

        var entity = new TestModel<int>(value: 5);
        service.InsertOne<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            document: entity
        );

        var current = service.Find<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            filter: null
        );
        var id = current.First().Id;
        var filter = service.GetFilterId<TestModel<int>>(value: id!);

        service.Delete<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            filter: filter
        );

        var result = service.Find<TestModel<int>>(
            collectionName: options.Value.TestCollectionName,
            filter: null
        );

        Assert.True(result is IEnumerable<TestModel<int>>);
        Assert.Empty(collection: result);
        CleanUpDatabase();
    }
}
