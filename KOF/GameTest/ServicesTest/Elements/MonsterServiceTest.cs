namespace KOT.Services.Test;

using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;

public class MonsterServiceMockData
{
    public static List<Monster>? GetListMock()
    {
        return new List<Monster>
        {
            new Monster("name1", 1, 0),
            new Monster("name2", 1, 0),
            new Monster("name3", 1, 0),
        };
    }

    public static List<Monster>? GetSingleMock()
    {
        return new List<Monster> { new Monster("name1", 1, 0) };
    }

    public static void DoNothing()
    {
        //Does nothing for mocking purposes
    }
}

public class MonsterServiceTests
{
    [Fact]
    public void TestReadMethodWithId()
    {
        //Set expected result
        var expected = MonsterServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.MonsterCollectionName = "Monsters";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<Monster>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<Monster>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock
            .Setup(x => x.Find<Monster>(It.IsAny<string>(), filterMock.Object))
            .Returns(expected!);

        //Initialize service
        var service = new MonsterService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new MonsterPayload(id: "Non null");

        var result = service.Read(payload: payload);

        Assert.Equal(typeof(List<Monster>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestReadMethodWithoutId()
    {
        //Set expected result
        var expected = MonsterServiceMockData.GetListMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.MonsterCollectionName = "Monsters";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<Monster>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<Monster>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock.Setup(x => x.Find<Monster>(It.IsAny<string>(), null)).Returns(expected!);

        //Initialize service
        var service = new MonsterService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new MonsterPayload();

        var result = service.Read(payload: payload);

        Assert.Equal(typeof(List<Monster>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestCreateMethodExpectedElement()
    {
        //Set expected result
        var expected = MonsterServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.MonsterCollectionName = "Monsters";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Setup database service patches
        dbMock
            .Setup(x => x.InsertOne<Monster>(It.IsAny<string>(), It.IsAny<Monster>()))
            .Callback(MonsterServiceMockData.DoNothing);

        //Initialize service
        var service = new MonsterService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new MonsterPayload(name: "name1", victoryPoints: 1, lifePoints: 0);

        var result = service.Create(payload: payload);

        Assert.Equal(typeof(List<Monster>), expected!.GetType());
        Assert.Single(collection: result);
    }

    [Fact]
    public void TestDeleteMethodWithId()
    {
        //Set expected result
        var expected = MonsterServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.MonsterCollectionName = "Monsters";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<Monster>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<Monster>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock
            .Setup(x => x.Delete<Monster>(It.IsAny<string>(), filterMock.Object))
            .Returns(expected!.First());

        //Initialize service
        var service = new MonsterService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new MonsterPayload(id: "Non null");

        var result = service.Delete(payload: payload);

        Assert.Equal(typeof(List<Monster>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestDeleteMethodWithoutId()
    {
        //Set expected result
        var expected = new List<Monster> { };

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.MonsterCollectionName = "Monsters";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Initialize service
        var service = new MonsterService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new MonsterPayload();

        var result = service.Delete(payload: payload);

        Assert.Equal(typeof(List<Monster>), expected!.GetType());
        Assert.Empty(collection: result);
    }

    [Fact]
    public void TestUpdateMethod()
    {
        var settings = new KOTDatabaseSettings();
        var options = Options.Create(settings);
        var dbMock = new Mock<IDatabaseService>();
        var service = new MonsterService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new MonsterPayload();

        Assert.IsType<Element[]>(service.Update(payload));

    }
}
