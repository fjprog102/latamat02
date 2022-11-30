namespace KOT.Controllers.Test;

using System.Text.Json;
using KOT.Controllers;
using KOT.Models;
using KOT.Services;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;
using Moq;

public class MonsterControllerMockData
{
    public static List<Monster> GetMethodMock()
    {
        return new List<Monster>
        {
            new Monster("Monster1", 5, 5),
            new Monster("Monster2", 7, 7),
            new Monster("Monster3", 10, 10),
        };
    }

    public static List<Monster> PostMethodMock()
    {
        return new List<Monster> { new Monster("Monster4", 1, 1) };
    }

    public static List<Monster> PutMethodMock()
    {
        return new List<Monster> { new Monster("Monster5", 1, 1) };
    }

    public static List<Monster> DeleteMethodMock()
    {
        return new List<Monster> { new Monster("Monster6", 1, 1) };
    }
}

public class MonsterControllerTest
{
    [Fact]
    public void TestsGetMethod200Response()
    {
        var monsterService = new Mock<IMonsterService>();
        monsterService
            .Setup(mock => mock.Read(It.IsAny<MonsterPayload>()))
            .Returns(MonsterControllerMockData.GetMethodMock());

        var patched = new MonsterController(monsterService.Object);

        var result = (OkObjectResult)patched.Get(id: null);
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void TestsGetMethod400Response()
    {
        var monsterService = new Mock<IMonsterService>();
        var payload = new MonsterPayload();
        monsterService
            .Setup(mock => mock.Read(It.IsAny<MonsterPayload>()))
            .Throws(new Exception());

        var patched = new MonsterController(monsterService.Object);

        var result = (BadRequestResult)patched.Get(id: null);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod201Response()
    {
        var monsterService = new Mock<IMonsterService>();
        var payload = new MonsterPayload(name: "Monster4", victoryPoints: 1, lifePoints: 1);
        monsterService
            .Setup(mock => mock.Create(payload))
            .Returns(MonsterControllerMockData.PostMethodMock());

        var patched = new MonsterController(monsterService.Object);

        var result = (CreatedResult)patched.Post(payload);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void TestsPostMethod400Response()
    {
        var monsterService = new Mock<IMonsterService>();
        var payload = new MonsterPayload(name: "Monster4", victoryPoints: 1, lifePoints: 1);
        monsterService
            .Setup(mock => mock.Create(payload))
            .Throws(new Exception());

        var patched = new MonsterController(monsterService.Object);

        var result = (BadRequestResult)patched.Post(payload);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void TestsPutMethod201Response()
    {
        var monsterService = new Mock<IMonsterService>();
        var payload = new MonsterPayload(id: "123", name: "Monster5", victoryPoints: 1, lifePoints: 1);
        monsterService
            .Setup(mock => mock.Update(payload))
            .Returns(MonsterControllerMockData.PutMethodMock());

        var patched = new MonsterController(monsterService.Object);

        var result = (CreatedResult)patched.Put(payload);
        Assert.Equal(201, result.StatusCode);
    }

    [Fact]
    public void TestsPutMethod400Response()
    {
        var monsterService = new Mock<IMonsterService>();
        var payload = new MonsterPayload(name: "Monster5", victoryPoints: 1, lifePoints: 1);
        monsterService
            .Setup(mock => mock.Update(payload))
            .Throws(new Exception());

        var patched = new MonsterController(monsterService.Object);

        var result = (BadRequestResult)patched.Put(payload);
        Assert.Equal(400, result.StatusCode);
    }

    [Fact]
    public void TestsDeleteMethod201Response()
    {
        var monsterService = new Mock<IMonsterService>();
        monsterService
            .Setup(mock => mock.Delete(It.IsAny<MonsterPayload>()))
            .Returns(MonsterControllerMockData.DeleteMethodMock());

        var patched = new MonsterController(monsterService.Object);

        var result = (OkObjectResult)patched.Delete("123");
        Assert.Equal(200, result.StatusCode);
    }

    [Fact]
    public void TestsDeleteMethod400Response()
    {
        var monsterService = new Mock<IMonsterService>();
        monsterService
            .Setup(mock => mock.Delete(It.IsAny<MonsterPayload>()))
            .Throws(new Exception());

        var patched = new MonsterController(monsterService.Object);

        var result = (BadRequestResult)patched.Delete("123");
        Assert.Equal(400, result.StatusCode);
    }
}
