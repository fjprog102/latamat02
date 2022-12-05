namespace KOT.Services.Test;

using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;

public class PlayerServiceMockData
{
    public static List<Player>? GetListMock()
    {
        return new List<Player>
        {
            new Player("player1", new Monster("monster1", 1, 0), 0),
            new Player("player2", new Monster("monster2", 1, 0), 0),
            new Player("player3", new Monster("monster3", 1, 0), 0)
        };
    }

    public static List<Player>? GetSingleMock()
    {
        return new List<Player> { new Player("player1", new Monster("monster1", 1, 0), 0) };
    }

    public static void DoNothing()
    {
        //Does nothing for mocking purposes
    }
}

public class PlayerServiceTests
{
    [Fact]
    public void TestReadMethodWithId()
    {
        //Set expected result
        var expected = PlayerServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PlayerCollectionName = "Players";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<Player>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<Player>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock
            .Setup(x => x.Find<Player>(It.IsAny<string>(), filterMock.Object))
            .Returns(expected!);

        //Initialize service
        var service = new PlayerService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PlayerPayload(id: "Non null");

        var result = service.Read(payload: payload);

        Assert.Equal(typeof(List<Player>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestReadMethodWithoutId()
    {
        //Set expected result
        var expected = PlayerServiceMockData.GetListMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PlayerCollectionName = "Players";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<Player>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<Player>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock.Setup(x => x.Find<Player>(It.IsAny<string>(), null)).Returns(expected!);

        //Initialize service
        var service = new PlayerService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PlayerPayload();

        var result = service.Read(payload: payload);

        Assert.Equal(typeof(List<Player>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestCreateMethodExpectedElement()
    {
        //Set expected result
        var expected = PlayerServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PlayerCollectionName = "Players";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Setup database service patches
        dbMock
            .Setup(x => x.InsertOne<Player>(It.IsAny<string>(), It.IsAny<Player>()))
            .Callback(PlayerServiceMockData.DoNothing);

        //Initialize service
        var service = new PlayerService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PlayerPayload(name: "player1", myMonster: new Monster("monster1", 0, 10), energyCubes: 0);

        var result = service.Create(payload: payload);

        Assert.Equal(typeof(List<Player>), expected!.GetType());
        Assert.Single(collection: result);
    }

    [Fact]
    public void TestDeleteMethodWithId()
    {
        //Set expected result
        var expected = PlayerServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PlayerCollectionName = "Players";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<Player>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<Player>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock
            .Setup(x => x.Delete<Player>(It.IsAny<string>(), filterMock.Object))
            .Returns(expected!.First());

        //Initialize service
        var service = new PlayerService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PlayerPayload(id: "Non null");

        var result = service.Delete(payload: payload);

        Assert.Equal(typeof(List<Player>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestDeleteMethodWithoutId()
    {
        //Set expected result
        var expected = new List<Player> { };

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PlayerCollectionName = "Players";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Initialize service
        var service = new PlayerService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PlayerPayload();

        var result = service.Delete(payload: payload);

        Assert.Equal(typeof(List<Player>), expected!.GetType());
        Assert.Empty(collection: result);
    }

    [Fact]
    public void TestUpdateMethod()
    {
        var settings = new KOTDatabaseSettings();
        var options = Options.Create(settings);
        var dbMock = new Mock<IDatabaseService>();
        var service = new PlayerService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PlayerPayload();

        Assert.IsType<Element[]>(service.Update(payload));

    }
}
