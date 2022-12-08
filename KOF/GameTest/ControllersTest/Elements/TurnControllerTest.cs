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
        List<Player> players = new List<Player>()
        {
            new Player("Jose", new Monster("Alienoid", 0, 10), 0),
            new Player("Shirley", new Monster("Cyber Kitty", 0, 10), 0)
        };
        return new List<Game> { new Game(players) };
    }

    public static List<Game> PostMethodMockSingle()
    {
        List<Player> players = new List<Player>()
        {
            new Player("Jose", new Monster("Alienoid", 0, 10), 0),
        };
        return new List<Game> { new Game(players) };
    }

    [Fact]
    public void TestsPostMethod201Response()
    {
        var gameService = new Mock<IGameService>();
        var payload = new TurnPayload("", new string[] { });
        gameService
            .Setup(mock => mock.Read(It.IsAny<GamePayload>()))
            .Returns(TurnControllerMockData.PostMethodMock());
        gameService
            .Setup(mock => mock.Update(It.IsAny<GamePayload>()))
            .Returns(TurnControllerMockData.PostMethodMockSingle());

        var patched = new TurnController(gameService.Object);
        var result = (OkObjectResult)patched.Post(payload: payload);

        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod400Response()
    {
        var gameService = new Mock<IGameService>();
        var patched = new TurnController(gameService.Object);
        var result = (BadRequestResult)patched.Post(null!);

        Assert.Equal(400, result.StatusCode);
    }
}
