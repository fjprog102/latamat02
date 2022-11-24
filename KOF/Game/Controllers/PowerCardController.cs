using System.Text.Json;
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
    public IActionResult Get([FromBody] PowerCardPayload payload)
    {
        var result = powerCardService.Read(payload);
        return Ok(result);
    }

    [HttpPost(Name = "PostPowerCard")]
    public IActionResult Post([FromBody] PowerCardPayload payload)
    {
        var result = powerCardService.Create(payload);
        return Ok(result);
    }
}
