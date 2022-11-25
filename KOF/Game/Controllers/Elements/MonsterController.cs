namespace KOT.Controllers;

using KOT.Models;
using KOT.Services;
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
        new MonsterService().GetAll();

    [HttpPost]
    public IActionResult Create(Monster monster)
    {
        new MonsterService().Add(monster);
        return CreatedAtAction(nameof(Create), new { id = monster.Id }, monster);
    }
}
