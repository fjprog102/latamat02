namespace KOT.Controllers;

using System.Text.Json;
using KOT.Models;
using KOT.Services;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MonsterController : ControllerBase
{
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
            return Created("Monster", result.First());
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    [HttpGet]
    public IActionResult Get([FromBody] MonsterPayload payload)
    {
        try
        {
            var result = MonsterService.Read(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }

    // [HttpPut]
    // public IActionResult Put([FromBody] MonsterPayload payload)
    // {
    //     try
    //     {
    //         var result = MonsterService.Update(payload);
    //         return Ok(result);
    //     }
    //     catch (Exception)
    //     {
    //         return BadRequest();
    //     }
    // }

    [HttpDelete]
    public IActionResult Put([FromBody] MonsterPayload payload)
    {
        try
        {
            var result = MonsterService.Delete(payload);
            return Ok(result);
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
