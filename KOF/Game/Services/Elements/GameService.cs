namespace KOT.Services;

using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Models.Processor;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;

public class GameService : IGameService
{
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

    public IEnumerable<Element> Create(GamePayload payload)
    {
        GamePayload args = (GamePayload)payload;
        var newGame = new Game((TokyoBoard)args.Board!, (TokyoBoardProcessor)args.BoardProcessor!);
        _dbInstance.InsertOne<Game>(
            collectionName: _gameCollection,
            document: newGame
        );
        return new List<Game> { newGame };
    }

    public IEnumerable<Element> Read(GamePayload payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<Game>(payload.Id);
            return _dbInstance.Find<Game>(
                collectionName: _gameCollection,
                filter: filter
            );
        }

        return _dbInstance.Find<Game>(collectionName: _gameCollection, null);
    }

    public IEnumerable<Element> Update(GamePayload payload)
    {
        _dbInstance.UpdateGame(collectionName: _gameCollection, document: payload);

        var game = new Game(payload.Board!, payload.BoardProcessor!);
        game.Id = payload.Id;
        game.ActivePlayerName = payload.ActivePlayerName;

        return new List<Game> { game };
    }

    public IEnumerable<Element> Delete(GamePayload payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<Game>(payload.Id);
            var deleted = _dbInstance.Delete<Game>(
                collectionName: _gameCollection,
                filter: filter
            );
            return new List<Game> { deleted };
        }

        return new List<Game> { };
    }
}
