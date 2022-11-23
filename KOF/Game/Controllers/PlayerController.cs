using KOF.Models;
using KOF.Services;
using Microsoft.AspNetCore.Mvc;

namespace KOTGame.Controllers;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    public PlayerController() { }

    [HttpGet]
    public ActionResult<List<Player>> GetAll() => PlayerService.GetAll();

    [HttpGet("{id}")]
    public ActionResult<Player> Get(int id)
    {
        var player = PlayerService.Get(id);

        if (player == null)
            return NotFound();

        return player;
    }

    // POST action
    [HttpPost]
    public IActionResult Create(Player player)
    {
        PlayerService.Add(player);
        return CreatedAtAction(nameof(Create), new { id = Player.PID }, player);
    }

    // PUT action

    // DELETE action
}
