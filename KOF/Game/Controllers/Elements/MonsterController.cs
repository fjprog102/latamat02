namespace KOT.Controllers;

using KOT.Models;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MonsterController : ControllerBase
{
    private readonly string uriString = "localhost:<port>/monster";
    private readonly IMonsterService MonsterService;

    public MonsterController(IMonsterService instance)
    {
        MonsterService = instance;
    }

    [HttpPost]
    public IActionResult Post([FromBody] MonsterPayload payload)
    {
        try
        {
            var result = MonsterService.Create(payload);
            return Created(uriString, result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet("{id?}")]
    public IActionResult Get(string? id)
    {
        try
        {
            var payload = new MonsterPayload(id);
            var result = MonsterService.Read(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpPut]
    public IActionResult Put([FromBody] MonsterPayload payload)
    {
        try
        {
            var result = MonsterService.Update(payload);
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
            var payload = new MonsterPayload(id);
            var result = MonsterService.Delete(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
