using System.Text.Json;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KOT.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService gameService;

    public GameController(IGameService instance)
    {
        gameService = instance;
    }

    [HttpGet(Name = "GetName")]
    public IActionResult GetAll([FromBody] GamePayload payload)
    {
        try
        {
            var result = gameService.Read(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id}")]
    public IActionResult Get(string id)
    {
        try
        {
            var payload = new GamePayload(id);
            var result = gameService.Read(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost(Name = "PostGame")]
    public IActionResult Post([FromBody] GamePayload payload)
    {
        try
        {
            var result = gameService.Create(payload);
            return Created("Tests", result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut(Name = "PutGame")]
    public IActionResult Put([FromBody] GamePayload payload)
    {
        try
        {
            var result = gameService.Update(payload);
            return Created("Tests", result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpDelete(Name = "DeleteGame")]
    public IActionResult Delete([FromBody] GamePayload payload)
    {
        try
        {
            var result = gameService.Delete(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}

