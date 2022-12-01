using System.Text.Json;
using KOT.Controllers;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services;
using KOT.Tests;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;
using Xunit.Abstractions;

namespace KOT.Tests;

public class PowerCardServiceMockData
{
    public static List<PowerCard>? GetListMock()
    {
        return new List<PowerCard>
        {
            new PowerCard("name1", 1, 0),
            new PowerCard("name2", 2, 1),
            new PowerCard("name3", 3, 0),
        };
    }

    public static List<PowerCard>? GetSingleMock()
    {
        return new List<PowerCard> { new PowerCard("name", 1, 1) };
    }
}

public class PowerCardServiceTests
{
    /*
    [Fact]
    public void TestReadMethod()
    {
        var optionsMock = new DataBaseTestHelper("PowerCards");
        var patched = new PowerCardService(optionsMock.GetOptions.Object);
        var payload = new PowerCardPayload();
        var x = patched.Read(payload: payload);

        output.WriteLine(x.Count().ToString());
        Assert.True(false);
    }
    

    [Fact]
    public void TestReadMethod()
    {
        var mockIMongoCollection = new Mock<IMongoCollection<PowerCard>>();
        var asyncCursor = new Mock<IAsyncCursor<PowerCard>>();

        var expectedResult = PowerCardServiceMockData.GetListMock();

        asyncCursor.SetupSequence(_async => _async.MoveNext(default)).Returns(true).Returns(false);
        asyncCursor.SetupGet(_async => _async.Current).Returns(expectedResult!);

        var service = PowerCardService()
        var result = LoadPeople(mockIMongoCollection.Object);

        Assert.Equals(expectedResult, result);
    }
    */
}
