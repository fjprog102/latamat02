using KOT.Models;
using KOT.Services;
using System.Text.Json;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KOT.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService playerService;

    public PlayerController(IPlayerService instance)
    {
        playerService = instance;
    }

    [HttpGet]
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

    [HttpPost]
    public IActionResult Post([FromBody] PlayerPayload payload)
    {
        try
        {
            var result = playerService.Create(payload);
            return Created("PlayerTest", result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
