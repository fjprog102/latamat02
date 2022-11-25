using KOT.Models;
using KOT.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOT.Controllers;

[ApiController]
[Route("[controller]")]
public class GameController : ControllerBase
{
    public GameController() { }

    // GET all action
    [HttpGet]
    public ActionResult<List<Game>> GetAll() => GameService.GetAll();

    // POST action
    [HttpPost]
    public IActionResult Create(Game game)
    {
        GameService.Add(game);
        return CreatedAtAction(nameof(Create), new { id = game.Id }, game);
    }

    // PUT action

    // DELETE action
}
