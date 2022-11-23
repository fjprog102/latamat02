namespace KOF.Controllers;

using KOF.Models;
using KOF.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MonsterController : ControllerBase
{
    public MonsterController()
    {
    }

    [HttpGet("GetAll")]
    public ActionResult<List<Monster>> GetAll() =>
        MonsterService.GetAll();

    [HttpPost]
    public IActionResult Create(Monster monster)
    {            
        MonsterService.Add(monster);
        return CreatedAtAction(nameof(Create), new { id = monster.Id }, monster);
    }
}
