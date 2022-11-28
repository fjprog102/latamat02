using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KOT.Controllers;

[ApiController]
[Route("[controller]")]
public class PowerCardController : ControllerBase
{
    private readonly IDataService powerCardService;

    private readonly string uriString = "localhost:<port>/powercard";

    public PowerCardController(IDataService instance)
    {
        powerCardService = instance;
    }

    [HttpGet(Name = "GetPowerCard")]
    public IActionResult Get([FromBody] PowerCardPayload payload)
    {
        try
        {
            var result = powerCardService.Read(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost(Name = "PostPowerCard")]
    public IActionResult Post([FromBody] PowerCardPayload payload)
    {
        try
        {
            var result = powerCardService.Create(payload);
            return Created(uriString, result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
