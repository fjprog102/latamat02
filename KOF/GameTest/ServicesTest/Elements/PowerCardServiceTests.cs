using KOT.Models;
using KOT.Services;
using KOT.Services.Interfaces;
using Moq;

public class MockData
{
    public static PowerCard[] GetMockData()
    {
        return new PowerCard[]
        {
            new PowerCard("name1", 1, 0),
            new PowerCard("name2", 2, 1),
            new PowerCard("name3", 3, 0),
        };
    }
}

public class PowerCardServiceTests
{
    /*
    [Fact]
    public void TestsPowerCardServiceReadMethod()
    {
        var mock = new Mock<PowerCardService>();

        Assert.True(false);
    }*/
}
