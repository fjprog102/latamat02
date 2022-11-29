namespace KOT.Services;

using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;

public class GameService : IGameService
{

    private static readonly TokyoBoard Board = new TokyoBoard(new List<Player>() { new Player(), new Player() });
    private readonly List<Game> Games = new List<Game> { new Game(Board) };

    IEnumerable<Element> IGameService.Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            return Games.Where(game => game.Id!.Equals(payload.Id));
        }

        return Games;
    }

    IEnumerable<Element> IGameService.Create(DataHolder payload)
    {
        if (payload.GetType() == typeof(GamePayload))
        {
            GamePayload args = (GamePayload)payload;
            var newGame = new Game((TokyoBoard)args.Board!);
            Games.Add(newGame);
            return new Element[] { newGame };
        }

        return new Element[0];
    }

    IEnumerable<Element> IGameService.Delete(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var game = Games
                .Where(game => game.Id!.Equals(payload.Id))
                .ToArray();

            Games.Remove(game.First());

            return game;
        }

        return new Element[0];
    }

    IEnumerable<Element> IGameService.Update(DataHolder payload)
    {
        if (payload.Id != null || payload.GetType() == typeof(GamePayload))
        {
            GamePayload args = (GamePayload)payload;
            var newGame = new Game((TokyoBoard)args.Board!);

            Games[Games.FindIndex(game => game.Id == payload.Id)] = newGame;

            return new Element[] { newGame };
        }

        return new Element[0];
    }
}
