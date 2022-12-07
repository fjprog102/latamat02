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

    public IEnumerable<Game> Create(GamePayload payload)
    {
        GamePayload args = (GamePayload)payload;
        var newGame = new Game((List<Player>)args.Players!);
        _dbInstance.InsertOne<Game>(
            collectionName: _gameCollection,
            document: newGame
        );
        return new List<Game> { newGame };
    }

    public IEnumerable<Game> Read(GamePayload payload)
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

    public IEnumerable<Game> Update(GamePayload payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<Game>(payload.Id);
            var newGame = new Game(payload.Players!);
            newGame.Id = payload.Id;
            newGame.Board = payload.Board;
            newGame.BoardProcessor = payload.BoardProcessor;
            newGame.ActivePlayerName = payload.ActivePlayerName;
            newGame.Winner = payload.Winner;
            _dbInstance.UpdateOne<Game>(
                collectionName: _gameCollection,
                filter: filter,
                document: newGame
            );

            return new List<Game> { newGame };
        }

        return new List<Game> { };
    }

    public IEnumerable<Game> Delete(GamePayload payload)
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
