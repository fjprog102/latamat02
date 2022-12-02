namespace KOT.Services;

using KOT.Models;
using KOT.Models.Abstracts;
using Microsoft.Extensions.Options;
using KOT.Services.Interfaces;

public class GameService : IGameService
{
    private static readonly TokyoBoard Board = new TokyoBoard();

    private readonly List<Game> Games = new List<Game> { new Game(Board) };

    private readonly string _gameCollection;
    private readonly IDatabaseService _dbInstance;

    public GameService(
        IOptions<KOTDatabaseSettings> kotDatabaseSettings,
        IDatabaseService dbInstance
    )
    {
        _gameCollection = kotDatabaseSettings.Value.GameCollectionName;
        _dbInstance = dbInstance;
    }

    IEnumerable<Element> IGameService.Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<Game>(payload.Id);
            return _dbInstance.Find<Game>(collectionName: _gameCollection, filter: filter);
        }

        return _dbInstance.Find<Game>(collectionName: _gameCollection, null);
    }

    IEnumerable<Element> IGameService.Create(DataHolder payload)
    {
        if (payload.GetType() == typeof(GamePayload))
        {
            GamePayload args = (GamePayload)payload;
            var newGame = new Game((TokyoBoard)args.Board!);
            _dbInstance.InsertOne<Game>(collectionName: _gameCollection, document: newGame);
            return new List<Game> { newGame };
        }

        return new List<Game> { };
    }

    IEnumerable<Element> IGameService.Delete(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<Game>(payload.Id);
            var deleted = _dbInstance.Delete<Game>(collectionName: _gameCollection, filter: filter);
            return new List<Game> { deleted };
        }

        return new List<Game> { };
    }
}
