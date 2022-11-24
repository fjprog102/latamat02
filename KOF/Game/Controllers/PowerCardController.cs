using KOF.Models;
using KOF.Models.Abstracts;
using KOF.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KOF.Controllers;

[ApiController]
[Route("[controller]")]
public class PowerCardController : ControllerBase
{
    private readonly IDataService powerCardService;

    public PowerCardController(IDataService instance)
    {
        powerCardService = instance;
    }

    [HttpGet(Name = "GetPowerCard")]
    public IActionResult Get([FromForm] string? id = null)
    {
        var payload = new PowerCardPayload(id: id);
        var result = powerCardService.Read(payload);
        return Ok(result);
    }

    [HttpPost(Name = "PostPowerCard")]
    public IActionResult Post([FromForm] string name, int cost, int type, string? id = null)
    {
        var payload = new PowerCardPayload(id: id, name: name, cost: cost, type: type);
        var result = powerCardService.Create(payload);
        return Ok(result);
    }
}
