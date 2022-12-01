using KOT.Models;
using KOT.Services;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;

public class PowerCardServiceMockData
{
    public static List<PowerCard>? GetListMock()
    {
        return new List<PowerCard>
        {
            new PowerCard("name1", 1, 0),
            new PowerCard("name2", 1, 0),
            new PowerCard("name3", 1, 0),
        };
    }

    public static List<PowerCard>? GetSingleMock()
    {
        return new List<PowerCard> { new PowerCard("name1", 1, 0) };
    }

    public static void DoNothing()
    {
        //Does nothing for mocking purposes
    }
}

public class PowerCardServiceTests
{
    [Fact]
    public void TestReadMethodWithId()
    {
        //Set expected result
        var expected = PowerCardServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PowerCardCollectionName = "PowerCards";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<PowerCard>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<PowerCard>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock
            .Setup(x => x.Find<PowerCard>(It.IsAny<string>(), filterMock.Object))
            .Returns(expected!);

        //Initialize service
        var service = new PowerCardService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PowerCardPayload(id: "Non null");

        var result = service.Read(payload: payload);

        Assert.Equal(typeof(List<PowerCard>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestReadMethodWithoutId()
    {
        //Set expected result
        var expected = PowerCardServiceMockData.GetListMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PowerCardCollectionName = "PowerCards";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<PowerCard>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<PowerCard>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock.Setup(x => x.Find<PowerCard>(It.IsAny<string>(), null)).Returns(expected!);

        //Initialize service
        var service = new PowerCardService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PowerCardPayload();

        var result = service.Read(payload: payload);

        Assert.Equal(typeof(List<PowerCard>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestCreateMethodExpectedElement()
    {
        //Set expected result
        var expected = PowerCardServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PowerCardCollectionName = "PowerCards";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Setup database service patches
        dbMock
            .Setup(x => x.InsertOne<PowerCard>(It.IsAny<string>(), It.IsAny<PowerCard>()))
            .Callback(PowerCardServiceMockData.DoNothing);

        //Initialize service
        var service = new PowerCardService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PowerCardPayload(name: "name1", cost: 1, type: 0);

        var result = service.Create(payload: payload);

        Assert.Equal(typeof(List<PowerCard>), expected!.GetType());
        Assert.Single(collection: result);
    }

    [Fact]
    public void TestCreateMethodWrongElement()
    {
        //Set expected result
        var expected = new List<PowerCard> { };

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PowerCardCollectionName = "PowerCards";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Initialize service
        var service = new PowerCardService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PlayerPayload();

        var result = service.Create(payload: payload);

        Assert.Equal(typeof(List<PowerCard>), expected!.GetType());
        Assert.Empty(collection: result);
    }

    [Fact]
    public void TestDeleteMethodWithId()
    {
        //Set expected result
        var expected = PowerCardServiceMockData.GetSingleMock();

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PowerCardCollectionName = "PowerCards";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();
        var filterMock = new Mock<FilterDefinition<PowerCard>>();

        //Setup database service patches
        dbMock.Setup(x => x.GetFilterId<PowerCard>(It.IsAny<string>())).Returns(filterMock.Object);
        dbMock
            .Setup(x => x.Delete<PowerCard>(It.IsAny<string>(), filterMock.Object))
            .Returns(expected!.First());

        //Initialize service
        var service = new PowerCardService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PowerCardPayload(id: "Non null");

        var result = service.Delete(payload: payload);

        Assert.Equal(typeof(List<PowerCard>), expected!.GetType());
        Assert.Equal(expected: expected, actual: result);
    }

    [Fact]
    public void TestDeleteMethodWithoutId()
    {
        //Set expected result
        var expected = new List<PowerCard> { };

        // Service settings
        var settings = new KOTDatabaseSettings();
        settings.PowerCardCollectionName = "PowerCards";
        var options = Options.Create(settings);

        // Mock database service instance
        var dbMock = new Mock<IDatabaseService>();

        //Initialize service
        var service = new PowerCardService(kotDatabaseSettings: options, dbInstance: dbMock.Object);
        var payload = new PowerCardPayload();

        var result = service.Delete(payload: payload);

        Assert.Equal(typeof(List<PowerCard>), expected!.GetType());
        Assert.Empty(collection: result);
    }
}
