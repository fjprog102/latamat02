namespace KOF.Controllers.Test;

using KOF.Controllers;
using KOF.Models;
using KOF.Services;
using Microsoft.AspNetCore.Mvc;

public class MonsterControllerTest
{
    private readonly MonsterController mc = new MonsterController();

    [Fact]
    public void ShouldReturnAnActionResultListOfMonsters()
    {
        Assert.IsType<ActionResult<List<Monster>>>(mc.GetAll());
    }

    [Fact]
    public void ShouldReturnACreatedAtActionResult()
    {
        var monster = new Monster { Name = "New Monster", VictoryPoints = 10, LifePoints = 10 };
        Assert.IsType<CreatedAtActionResult>(mc.Create(monster));
    }
}
