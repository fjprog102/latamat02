using System.Text.Json;
using KOT.Controllers;
using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace KOT.Tests;

public class PowerCardControllerMockData
{
    public static List<PowerCard> GetMethodMock()
    {
        return new List<PowerCard>
        {
            new PowerCard("name1", 1, 0),
            new PowerCard("name2", 2, 1),
            new PowerCard("name3", 3, 0),
        };
    }

    public static List<PowerCard> PostMethodMock()
    {
        return new List<PowerCard> { new PowerCard("name4", 1, 1) };
    }
}

public class PowerCardControllerTests
{
    [Fact]
    public void TestsGetMethod200Response()
    {
        var powerCardService = new Mock<IDataService>();
        var payload = new PowerCardPayload();
        powerCardService
            .Setup(mock => mock.Read(payload))
            .Returns(PowerCardControllerMockData.GetMethodMock());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (OkObjectResult)patched.Get(payload);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void TestsGetMethod400Response()
    {
        var powerCardService = new Mock<IDataService>();
        var payload = new PowerCardPayload();
        powerCardService.Setup(mock => mock.Read(payload)).Throws(new Exception());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (BadRequestResult)patched.Get(payload);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod201Response()
    {
        var powerCardService = new Mock<IDataService>();
        var payload = new PowerCardPayload(name: "name4", cost: 1, type: 1);
        powerCardService
            .Setup(mock => mock.Create(payload))
            .Returns(PowerCardControllerMockData.PostMethodMock());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (CreatedResult)patched.Post(payload);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod400Response()
    {
        var powerCardService = new Mock<IDataService>();
        var payload = new PowerCardPayload(name: "name4", cost: 1, type: 1);
        powerCardService.Setup(mock => mock.Create(payload)).Throws(new Exception());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (BadRequestResult)patched.Post(payload);
        Assert.Equal(400, result.StatusCode);
    }
}
