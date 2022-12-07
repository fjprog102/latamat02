﻿namespace KOT.Controllers;

using System.Text.Json;
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

    [HttpGet("{id}")]
    public IActionResult Get(string? id)
    {
        try
        {
            Turn turn = new Turn();
            var game = new GamePayload(id);
            var result = gameService.Read(game).First();
            var changedGame = new GamePayload(result.Id, result.Board,
            result.BoardProcessor, result.ActivePlayerName, result.Players, result.Winner);
            string[] dices = { "one", "one", "one", "energy", "smash" };
            turn.Play(changedGame, dices);
            return Ok(gameService.Update(changedGame));
        }
        catch (Exception)
        {
            return BadRequest();
        }
    }
}