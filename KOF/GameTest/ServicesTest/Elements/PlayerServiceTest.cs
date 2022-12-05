namespace KOT.Services.PlayerTest;

using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;
using Moq;

public class PlayerServiceMockData
{
    public static List<Player>? GetListMock()
    {
        return new List<Player>
        {
            new Player("player1", new Monster("monster1", 10, 10), 14),
            new Player("player2", new Monster("monster2", 10, 10),20),
            new Player("player3", new Monster("monster3", 10, 10), 30),
        };
    }

    public static List<Player>? GetSingleMock()
    {
        return new List<Player> { new Player("player1", new Monster("monster1", 10, 10), 14) };
    }

    public static void DoNothing()
    {
        //Does nothing for mocking purposes
    }
}
public class PlayerServiceTest
{

}
