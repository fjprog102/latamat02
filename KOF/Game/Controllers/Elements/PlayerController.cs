using System.Text.Json;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KOT.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IDataService playerService;

    public PlayerController(IDataService instance)
    {
        playerService = instance;
    }

    [HttpGet(Name = "GetPlayer")]
    public IActionResult Get([FromBody] PlayerPayload payload)
    {
        try
        {
            var result = playerService.Read(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost(Name = "PostPlayer")]
    public IActionResult Post([FromBody] PlayerPayload payload)
    {
        try
        {
            var result = playerService.Create(payload);
            return Created("Tests", result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
