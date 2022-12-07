namespace KOT.Controllers;

using System.Text.Json;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

[ApiController]
[Route("[controller]")]
public class TurnController : ControllerBase
{
    private readonly IGameService gameService;

    public TurnController(IGameService instance)
    {
        gameService = instance;
    }

    [HttpPost]
    public IActionResult Post([FromBody] TurnPayload payload)
    {
        try
        {
            Turn turn = new Turn();
            var result = gameService.Read(new GamePayload(payload.Id)).First();
            var changedGame = new GamePayload(result.Id, result.Board,
                result.BoardProcessor, result.Deck, result.ActivePlayerName, result.Players, result.Winner);
            turn.Play(changedGame, payload.DiceResult);

            return Ok(gameService.Update(changedGame));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}
