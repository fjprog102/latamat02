using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace KOT.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    private readonly IPlayerService playerService;
    private readonly string uriString = "localhost:<port>/player";

    public PlayerController(IPlayerService instance)
    {
        playerService = instance;
    }

    [HttpGet("{id?}")]
    public IActionResult Get(string? id)
    {
        try
        {
            var result = playerService.Read(new PlayerPayload(id: id));
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
            return Created(uriString, result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    [HttpPut]
    public IActionResult Put([FromBody] PlayerPayload payload)
    {
        try
        {
            var result = playerService.Update(payload);
            return Created(uriString, result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
    [HttpDelete("{id?}")]
    public IActionResult Delete(string? id)
    {
        try
        {
            var result = playerService.Delete(new PlayerPayload(id: id));
            return Ok(result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
