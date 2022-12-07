﻿namespace KOT.Controllers.Test;

using KOT.Controllers;
using KOT.Models;
using KOT.Models.Processor;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class GameControllerMockData
{
    public static List<Game> GetMethodMock()
    {
        List<Player> players = new List<Player>() { new Player("Jose", new Monster("Alienoid", 0, 10), 0),
            new Player("Shirley", new Monster("Cyber Kitty", 0, 10), 0) };

        return new List<Game>
        {
            new Game(players),
            new Game(players),
            new Game(players)
        };
    }

    public static List<Game> PostMethodMock()
    {
        List<Player> players = new List<Player>() { new Player("Jose", new Monster("Alienoid", 0, 10), 0),
            new Player("Shirley", new Monster("Cyber Kitty", 0, 10), 0) };
        return new List<Game> { new Game(players) };
    }
}

public class GameControllerTest
{
    [Fact]
    public void TestsGetMethod200Response()
    {
        Mock<IGameService>? gameService = new Mock<IGameService>();
        gameService
            .Setup(mock => mock.Read(It.IsAny<GamePayload>()))
            .Returns(GameControllerMockData.GetMethodMock());

        var patched = new GameController(gameService.Object);

        var result = (OkObjectResult)patched.Get(id: null);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void TestsGetMethod400Response()
    {
        Mock<IGameService>? gameService = new Mock<IGameService>();
        gameService
            .Setup(mock => mock.Read(It.IsAny<GamePayload>()))
            .Throws(new Exception());

        var patched = new GameController(gameService.Object);

        var result = (BadRequestResult)patched.Get(id: null);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod201Response()
    {
        var gameService = new Mock<IGameService>();
        var payload = new GamePayload();
        gameService
            .Setup(mock => mock.Create(payload))
            .Returns(GameControllerMockData.PostMethodMock());

        var patched = new GameController(gameService.Object);

        var result = (CreatedResult)patched.Post(payload);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod400Response()
    {
        var gameService = new Mock<IGameService>();
        var payload = new GamePayload();
        gameService.Setup(mock => mock.Create(payload)).Throws(new Exception());

        var patched = new GameController(gameService.Object);

        var result = (BadRequestResult)patched.Post(payload);
        Assert.Equal(400, result.StatusCode);
    }
}