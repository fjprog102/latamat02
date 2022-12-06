using KOT.Controllers;
using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

public static class SelectDiceControllerMockData
{
    public static List<KofDice> GetListMock()
    {
        return new List<KofDice> { new KofDice() };
    }
}

public class SelectDiceControllerTests
{
    [Fact]
    public void TestPostMethod200Response()
    {
        var selectDiceService = new Mock<ISelectDiceService>();
        selectDiceService
            .Setup(mock => mock.SelectDices(It.IsAny<ChoosenDicePayload>()))
            .Returns(SelectDiceControllerMockData.GetListMock());

        var patched = new ChooseDicesController(selectDiceService.Object);
        var payload = new ChoosenDicePayload(new bool[0], new KofDice());
        var result = (OkObjectResult)patched.Post(payload: payload);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void TestPostMethod400Response()
    {
        var selectDiceService = new Mock<ISelectDiceService>();
        selectDiceService
            .Setup(mock => mock.SelectDices(It.IsAny<ChoosenDicePayload>()))
            .Throws(new Exception());

        var patched = new ChooseDicesController(selectDiceService.Object);
        var payload = new ChoosenDicePayload(new bool[0], new KofDice());
        var result = (BadRequestResult)patched.Post(payload: payload);
        Assert.Equal(400, result.StatusCode);
    }
}
