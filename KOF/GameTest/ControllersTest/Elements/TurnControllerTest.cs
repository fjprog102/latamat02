namespace KOT.Controllers.Test;

using KOT.Controllers;
using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class TurnControllerMockData
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

    // [Fact]
    // public void TestsGetMethod200Response()
    // {
    //     Mock<IGameService>? gameService = new Mock<IGameService>();
    //     gameService
    //         .Setup(mock => mock.Read(It.IsAny<GamePayload>()))
    //         .Returns(TurnControllerMockData.GetMethodMock());

    //     var patched = new TurnController(gameService.Object);

    //     var result = (OkObjectResult)patched.Get(id: null);
    //     Assert.Equal(200, result.StatusCode);
    // }

    [Fact]
    public void TestsGetMethod400Response()
    {
        Mock<IGameService>? gameService = new Mock<IGameService>();
        gameService
            .Setup(mock => mock.Read(It.IsAny<GamePayload>()))
            .Throws(new Exception());

        var patched = new TurnController(gameService.Object);

        var result = (BadRequestResult)patched.Get(id: null);
        Assert.Equal(400, result.StatusCode);
    }
}
