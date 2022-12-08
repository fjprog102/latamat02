namespace KOT.Controllers.Test;
using System.Text.Json;
using KOT.Controllers;
using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;
using Xunit.Abstractions;
public class PlayerControllerMockData
{
    public static List<Player> GetMethodMock()
    {
        return new List<Player>
        {
            new Player("player1", new Monster("monster1", 10, 10)),
            new Player("player2", new Monster("monster2", 9, 9)),
            new Player("player3", new Monster("monster3", 8, 8)),
        };
    }

    public static List<Player> PostMethodMock()
    {
        return new List<Player> { new Player("player4", new Monster("monster4", 7, 7)) };
    }

    public static List<Player> PutMethodMock()
    {
        return new List<Player> { new Player("player4", new Monster("monster4", 7, 7)) };
    }

    public static List<Player> DeleteMethodMock()
    {
        return new List<Player> { new Player("player4", new Monster("monster4", 7, 7)) };
    }
}
public class PlayerControllerTest
{
    [Fact]
    public void TestsGetMethod200Response()
    {
        var playerService = new Mock<IPlayerService>();
        playerService
            .Setup(mock => mock.Read(It.IsAny<PlayerPayload>()))
            .Returns(PlayerControllerMockData.GetMethodMock());

        var patched = new PlayerController(playerService.Object);

        var result = (OkObjectResult)patched.Get(id: null);
        Assert.Equal(200, result.StatusCode);
    }
    [Fact]
    public void TestsGetMethod400Response()
    {
        var playerService = new Mock<IPlayerService>();
        playerService
            .Setup(mock => mock.Read(It.IsAny<PlayerPayload>()))
            .Throws(new Exception());

        var patched = new PlayerController(playerService.Object);

        var result = (BadRequestResult)patched.Get(id: null);
        Assert.Equal(400, result.StatusCode);
    }
    [Fact]
    public void TestsPostMethod201Response()
    {
        var playerService = new Mock<IPlayerService>();
        var payload = new PlayerPayload(name: "name4", myMonster: null);
        playerService
            .Setup(mock => mock.Create(payload))
            .Returns(PlayerControllerMockData.PostMethodMock());

        var patched = new PlayerController(playerService.Object);

        var result = (CreatedResult)patched.Post(payload);
        Assert.Equal(201, result.StatusCode);
    }
    [Fact]
    public void TestsPostMethod400Response()
    {
        var playerService = new Mock<IPlayerService>();
        var payload = new PlayerPayload(name: "name4", myMonster: null);
        playerService.Setup(mock => mock.Create(payload)).Throws(new Exception());

        var patched = new PlayerController(playerService.Object);

        var result = (BadRequestResult)patched.Post(payload);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void TestsPutMethod201Response()
    {
        var playerService = new Mock<IPlayerService>();
        var payload = new PlayerPayload(name: "name4", myMonster: null);
        playerService
            .Setup(mock => mock.Update(payload))
            .Returns(PlayerControllerMockData.PutMethodMock());

        var patched = new PlayerController(playerService.Object);

        var result = (CreatedResult)patched.Put(payload);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void TestsPutMethod400Response()
    {
        var playerService = new Mock<IPlayerService>();
        var payload = new PlayerPayload(name: "name4", myMonster: null);
        playerService
            .Setup(mock => mock.Update(payload))
            .Throws(new Exception());

        var patched = new PlayerController(playerService.Object);

        var result = (BadRequestResult)patched.Put(payload);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void TestsDeleteMethod201Response()
    {
        var playerService = new Mock<IPlayerService>();
        playerService
            .Setup(mock => mock.Delete(It.IsAny<PlayerPayload>()))
            .Returns(PlayerControllerMockData.DeleteMethodMock());

        var patched = new PlayerController(playerService.Object);

        var result = (OkObjectResult)patched.Delete("123");
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void TestsDeleteMethod400Response()
    {
        var playerService = new Mock<IPlayerService>();
        playerService
            .Setup(mock => mock.Delete(It.IsAny<PlayerPayload>()))
            .Throws(new Exception());

        var patched = new PlayerController(playerService.Object);

        var result = (BadRequestResult)patched.Delete("123");
        Assert.Equal(400, result.StatusCode);
    }
}
