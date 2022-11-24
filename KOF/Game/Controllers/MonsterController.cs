namespace KOF.Controllers;

using KOF.Models;
using KOF.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class MonsterController : ControllerBase
{
    private readonly MonsterService _service = new MonsterService();
    public MonsterController()
    {
    }

    [HttpGet("GetAll")]
    public ActionResult<List<Monster>> GetAll() =>
        _service.GetAll();

    [HttpPost]
    public IActionResult Create(Monster monster)
    {
        _service.Add(monster);
        return CreatedAtAction(nameof(Create), new { id = monster.Id }, monster);
    }
}
