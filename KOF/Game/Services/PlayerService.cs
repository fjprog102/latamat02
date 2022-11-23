namespace KOF.Services;

using KOF.Models;

public static class PlayerService
{
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
}
