namespace KOT.Controllers.Test;

using KOT.Controllers;
using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class TurnControllerMockData
{
    public static List<Game> PostMethodMock()
    {
        List<Player> players = new List<Player>() { new Player("Jose", new Monster("Alienoid", 0, 10), 0),
            new Player("Shirley", new Monster("Cyber Kitty", 0, 10), 0) };
        return new List<Game> { new Game(players) };
    }

    [Fact]
    public void TestsPostMethod201Response()
    {
        var gameService = new Mock<IGameService>();
        var payload = new GamePayload();
        gameService
            .Setup(mock => mock.Create(payload))
            .Returns(TurnControllerMockData.PostMethodMock());

        var patched = new TurnController(gameService.Object);

        var result = (CreatedResult)patched.Post(null);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod400Response()
    {
        var gameService = new Mock<IGameService>();
        var payload = new GamePayload();
        gameService.Setup(mock => mock.Create(payload)).Throws(new Exception());

        var patched = new TurnController(gameService.Object);

        var result = (BadRequestResult)patched.Post(null);
        Assert.Equal(400, result.StatusCode);
    }
}
