using KOF.Models;
using KOF.Services;
using KOF.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KOF.Controllers;

[ApiController]
[Route("[controller]")]
public class PowerCardController : ControllerBase
{
    private readonly IPowerCard powerCardService;

    public PowerCardController(IPowerCard instance)
    {
        powerCardService = instance;
    }

    [HttpGet(Name = "GetPowerCard")]
    public IEnumerable<PowerCard> Get()
    {
        return powerCardService.GetMethod();
    }

    [HttpPost(Name = "PostPowerCard")]
    public IEnumerable<PowerCard> Post([FromForm] string name, int cost, int type)
    {
        return powerCardService.PostMethod(name, cost, type);
    }
}
