namespace KOTGame.Services;

using KOTGame.Models;

public static class GameService
{
    private static List<Game> Games { get; }

    private static int nextId = 4;

    static GameService()
    {
        Games = new List<Game>
        {
            new Game
            {
                Id = 1,
                TokyoBoard = "Tokyo City",
                NumberOfPlayers = 3,
                ActiveUser = 1
            },
            new Game
            {
                Id = 2,
                TokyoBoard = "Tokyo Bay",
                NumberOfPlayers = 6,
                ActiveUser = 1
            },
            new Game
            {
                Id = 3,
                TokyoBoard = "Tokyo Bay",
                NumberOfPlayers = 2,
                ActiveUser = 1
            }
        };
    }

    public static List<Game> GetAll() => Games;

    public static void Add(Game game)
    {
        game.Id = nextId++;
        Games.Add(game);
    }
}
