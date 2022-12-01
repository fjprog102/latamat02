namespace KOT.Controllers;

using System.Text.Json;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    private readonly IGameService gameService;

    public GameController(IGameService instance)
    {
        gameService = instance;
    }

    [HttpGet("{id?}")]
    public IActionResult Get(string? id)
    {
        try
        {
            var result = gameService.Read(new GamePayload(id: id));
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPost()]
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

    [HttpPut]
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

    [HttpDelete("{id?}")]
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
