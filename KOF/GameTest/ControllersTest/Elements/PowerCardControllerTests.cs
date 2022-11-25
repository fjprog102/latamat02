using System.Text.Json;
using KOF.Controllers;
using KOF.Models;
using KOF.Services.Interfaces;
using Moq;

namespace KOF.Tests;

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

    /*
        public static string ExpectedGet =
            "[{\"IdAttr\":\"12345678\",\"NameAttr\":\"name1\",\"CostAttr\":1,\"TypeAttr\":0},{\"IdAttr\":\"12345678\",\"NameAttr\":\"name2\",\"CostAttr\":2,\"TypeAttr\":1},{\"IdAttr\":\"12345678\",\"NameAttr\":\"name3\",\"CostAttr\":3,\"TypeAttr\":0}]";
        public static string ExpectedPost =
            "[{\"IdAttr\":\"12345678\",\"NameAttr\":\"name4\",\"CostAttr\":1,\"TypeAttr\":1}]";
    
            */
}

public class PowerCardControllerTests
{
    [Fact]
    public void TestsGetMethod200Response()
    {
        /*
        var powerCardService = new Mock<IPowerCard>();
        powerCardService
            .Setup(mock => mock.GetMethod(null))
            .Returns(PowerCardControllerMockData.GetMethodMock());

        var patched = new PowerCardController(powerCardService.Object);

        var result = patched.Get();
        string jsonString = JsonSerializer.Serialize<IEnumerable<PowerCard>>(result);
        Assert.Equal(PowerCardControllerMockData.ExpectedGet, jsonString);
        */
    }

    [Fact]
    public void TestsPostMethod200Response()
    {
        /*
        var powerCardService = new Mock<IPowerCard>();
        powerCardService
            .Setup(mock => mock.PostMethod("", 0, 0))
            .Returns(PowerCardControllerMockData.PostMethodMock());

        var patched = new PowerCardController(powerCardService.Object);

        var result = patched.Post("", 0, 0);
        string jsonString = JsonSerializer.Serialize<IEnumerable<PowerCard>>(result);
        Assert.Equal(PowerCardControllerMockData.ExpectedPost, jsonString);
        */
    }
}
