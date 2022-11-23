namespace KOF.Controllers;

using KOF.Models;
using KOF.Services;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class PlayerController : ControllerBase
{
    PlayerService playerService = new PlayerService();

    public PlayerController() { }

    [HttpGet]
    public ActionResult<List<Player>> GetAll() => playerService.GetAll();

    [HttpGet("{pid}")]
    public ActionResult<Player> Get(int pid)
    {
        var player = playerService.Get(pid);

        if (player == null)
            return NotFound();

        return player;
    }

    [HttpPost]
    public IActionResult Create(Player player)
    {
        player.MyMonster = new Monster();
        playerService.Add(player);
        return CreatedAtAction(nameof(Create), new { id = player.PID }, player);
    }

    [HttpPut("{pid}")]
    public IActionResult Update(int pid, Player player)
    {
        if (pid != player.PID)
            return BadRequest();

        var existingPlayer = playerService.Get(pid);
        if (existingPlayer is null)
            return NotFound();

        playerService.Update(player);

        return NoContent();
    }

    [HttpDelete("{pid}")]
    public IActionResult Delete(int pid)
    {
        var player = playerService.Get(pid);

        if (player is null)
            return NotFound();

        playerService.Delete(pid);

        return NoContent();
    }
}
