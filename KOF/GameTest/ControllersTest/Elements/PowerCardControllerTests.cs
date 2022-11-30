using KOT.Controllers;
using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

namespace KOT.Tests;

public class PowerCardControllerMockData
{
    public static List<PowerCard> GetListMock()
    {
        return new List<PowerCard>
        {
            new PowerCard("name1", 1, 0),
            new PowerCard("name2", 2, 1),
            new PowerCard("name3", 3, 0),
        };
    }

    public static List<PowerCard> GetSingleMock()
    {
        return new List<PowerCard> { new PowerCard("name", 1, 1) };
    }
}

public class PowerCardControllerTests
{
    [Fact]
    public void TestsGetMethod200Response()
    {
        var powerCardService = new Mock<IPowerCardService>();
        powerCardService
            .Setup(mock => mock.Read(It.IsAny<PowerCardPayload>()))
            .Returns(PowerCardControllerMockData.GetListMock());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (OkObjectResult)patched.Get(id: null);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void TestsGetMethod400Response()
    {
        var powerCardService = new Mock<IPowerCardService>();
        powerCardService
            .Setup(mock => mock.Read(It.IsAny<PowerCardPayload>()))
            .Throws(new Exception());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (BadRequestResult)patched.Get(id: null);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod201Response()
    {
        var powerCardService = new Mock<IPowerCardService>();
        var payload = new PowerCardPayload(name: "name", cost: 1, type: 1);
        powerCardService
            .Setup(mock => mock.Create(payload))
            .Returns(PowerCardControllerMockData.GetSingleMock());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (CreatedResult)patched.Post(payload);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod400Response()
    {
        var powerCardService = new Mock<IPowerCardService>();
        var payload = new PowerCardPayload(name: "name", cost: 1, type: 1);
        powerCardService.Setup(mock => mock.Create(payload)).Throws(new Exception());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (BadRequestResult)patched.Post(payload);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void TestsDeleteMethod200Response()
    {
        var powerCardService = new Mock<IPowerCardService>();
        var payload = new PowerCardPayload();
        powerCardService
            .Setup(mock => mock.Delete(It.IsAny<PowerCardPayload>()))
            .Returns(PowerCardControllerMockData.GetSingleMock());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (OkObjectResult)patched.Delete(id: null);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void TestsDeleteMethod400Response()
    {
        var powerCardService = new Mock<IPowerCardService>();
        var payload = new PowerCardPayload();
        powerCardService
            .Setup(mock => mock.Delete(It.IsAny<PowerCardPayload>()))
            .Throws(new Exception());

        var patched = new PowerCardController(powerCardService.Object);

        var result = (BadRequestResult)patched.Delete(id: null);
        Assert.Equal(400, result.StatusCode);
    }
}
