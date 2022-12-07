namespace KOT.Services.Test;

using KOT.Models;
using KOT.Models.Processor;
using KOT.Services;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;

public class GameServiceMockData
{
    public static List<Game>? GetListMock()
    {
        return new List<Game>
        {
            new Game(new List<Player>() { new Player("Jose", new Monster("Alienoid", 0, 10), 0) }),
            new Game(new List<Player>() { new Player("Shirley", new Monster("Cyber Kitty", 0, 10), 0) })
        };
    }

    public static List<Game>? GetSingleMock()
    {
        return new List<Game>
        {
            new Game(new List<Player>() { new Player("Jose", new Monster("Alienoid", 0, 10), 0) })
        };
    }

    public static void DoNothing()
    {
        //Does nothing for mocking purposes
    }
}

public class GameServiceTests
{
    [Fact]
    public void TestReadMethodWithId()
    {
        //Set expected result
        var expected = GameServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.GameCollectionName = "Games";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<Game>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<Game>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock
            .Setup(x => x.Find<Game>(It.IsAny<string>(), filterMock.Object))
            .Returns(expected!);

        //Initialize service
        var service = new GameService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new GamePayload(id: "Non null");

        var result = service.Read(payload: payload);

        Assert.Equal(typeof(List<Game>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestReadMethodWithoutId()
    {
        //Set expected result
        var expected = GameServiceMockData.GetListMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.GameCollectionName = "Games";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<Game>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<Game>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock.Setup(x => x.Find<Game>(It.IsAny<string>(), null)).Returns(expected!);

        //Initialize service
        var service = new GameService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new GamePayload();

        var result = service.Read(payload: payload);

        Assert.Equal(typeof(List<Game>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestCreateMethodExpectedElement()
    {
        //Set expected result
        var expected = GameServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.GameCollectionName = "Games";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Setup database service patches
        dbMock
            .Setup(x => x.InsertOne<Game>(It.IsAny<string>(), It.IsAny<Game>()))
            .Callback(GameServiceMockData.DoNothing);

        //Initialize service
        var service = new GameService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new GamePayload
        (
            board: new TokyoBoard(),
            boardProcessor: new TokyoBoardProcessor(),
            players: new List<Player> { new Player("Jose", new Monster("Alienoid", 0, 10), 0),
            new Player("Shirley", new Monster("Cyber Kitty", 0, 10), 0) }
        );

        var result = service.Create(payload: payload);

        Assert.Equal(typeof(List<Game>), expected!.GetType());
        Assert.Single(collection: result);
    }

    [Fact]
    public void TestDeleteMethodWithId()
    {
        //Set expected result
        var expected = GameServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.GameCollectionName = "Games";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<Game>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<Game>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock
            .Setup(x => x.Delete<Game>(It.IsAny<string>(), filterMock.Object))
            .Returns(expected!.First());

        //Initialize service
        var service = new GameService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new GamePayload(id: "Non null");

        var result = service.Delete(payload: payload);

        Assert.Equal(typeof(List<Game>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestDeleteMethodWithoutId()
    {
        //Set expected result
        var expected = new List<Game> { };

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.GameCollectionName = "Games";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Initialize service
        var service = new GameService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new GamePayload();

        var result = service.Delete(payload: payload);

        Assert.Equal(typeof(List<Game>), expected!.GetType());
        Assert.Empty(collection: result);
    }

    [Fact]
    public void TestUpdateMethod()
    {
        //Set expected result
        var expected = GameServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.GameCollectionName = "Games";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Setup database service patches
        dbMock
            .Setup(x => x.InsertOne<Game>(It.IsAny<string>(), It.IsAny<Game>()))
            .Callback(GameServiceMockData.DoNothing);

        //Initialize service
        var service = new GameService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new GamePayload
        (
            board: new TokyoBoard(),
            boardProcessor: new TokyoBoardProcessor(),
            players: new List<Player> { new Player("Jose", new Monster("Alienoid", 0, 10), 0),
            new Player("Shirley", new Monster("Cyber Kitty", 0, 10), 0) }
        );
        payload.Id = "id";
        payload.ActivePlayerName = "player";

        var result = service.Update(payload: payload);

        Assert.Equal(typeof(List<Game>), expected!.GetType());
        Assert.Single(collection: result);
    }
}
