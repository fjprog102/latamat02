namespace KOT.Services;

using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class GameService : IGameService
{
    private static readonly TokyoBoard Board = new TokyoBoard();

    private readonly List<Game> Games = new List<Game> { new Game(Board) };

    private readonly IMongoCollection<Game> GameCollection;

    public GameService(IOptions<KOTDatabaseSettings> kotDatabaseSettings)
    {
        var mongoClient = new MongoClient(kotDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(kotDatabaseSettings.Value.DatabaseName);
        GameCollection = mongoDatabase.GetCollection<Game>(
            kotDatabaseSettings.Value.GameCollectionName
        );
    }

    IEnumerable<Element> IGameService.Read(DataHolder payload)
    // public IEnumerable<Element> Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            return Games.Where(game => game.Id!.Equals(payload.Id));
            //return GameCollection.Find(x => x.Id!.Equals(payload.Id)).ToList();
        }

        return Games;
        // return GameCollection.Find(x => true).ToList();
    }

    IEnumerable<Element> IGameService.Create(DataHolder payload)
    // public IEnumerable<Element> Create(DataHolder payload)
    {
        if (payload.GetType() == typeof(GamePayload))
        {
            GamePayload args = (GamePayload)payload;
            var newGame = new Game((TokyoBoard)args.Board!);
            Games.Add(newGame);
            // GameCollection.InsertOne(newGame);
            return new Element[] { newGame };
        }

        return new Element[0];
    }

    IEnumerable<Element> IGameService.Delete(DataHolder payload)
    // public IEnumerable<Element> Delete(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var game = Games.Where(game => game.Id!.Equals(payload.Id)).ToArray();

            Games.Remove(game.First());

            return game;
            // var deleted = GameCollection.FindOneAndDelete(x => x.Id!.Equals(payload.Id));
            // return new Element[] { deleted };
        }

        return new Element[0];
    }

    IEnumerable<Element> IGameService.Update(DataHolder payload)
    // public IEnumerable<Element> Update(DataHolder payload)
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
