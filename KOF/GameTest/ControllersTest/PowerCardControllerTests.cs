using System.Text.Json;
using KOF.Controllers;
using KOF.Models;

namespace KOF.Tests;

public class PowerCardControllerMockData
{
    public static List<PowerCard> GetPowerCards()
    {
        return new List<PowerCard>
        {
            new PowerCard("name1", 1, 0),
            new PowerCard("name2", 2, 1),
            new PowerCard("name3", 3, 0),
        };
    }
}

public class PowerCardControllerTests : IClassFixture<PowerCardController>
{
    [Fact]
    public void TestGetPowerCardController()
    {
        var mock = new PowerCardController();
        mock._powerCards = PowerCardControllerMockData.GetPowerCards();

        var result = mock.Get();
        var expected = JsonSerializer.Serialize(PowerCardControllerMockData.GetPowerCards());

        Assert.Equal(expected, JsonSerializer.Serialize(result));
    }
}
