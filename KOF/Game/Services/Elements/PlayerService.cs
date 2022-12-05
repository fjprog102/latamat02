namespace KOT.Services;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class PlayerService : IPlayerService
{
    private readonly string _playerCollection;
    private readonly IDatabaseService _dbInstance;

    public PlayerService(IOptions<KOTDatabaseSettings> kotDatabaseSettings,
        IDatabaseService dbInstance)
    {
        _playerCollection = kotDatabaseSettings.Value.PlayerCollectionName;
        _dbInstance = dbInstance;
    }

    public IEnumerable<Element> Read(PlayerPayload payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<Player>(payload.Id);
            return _dbInstance.Find<Player>(
                collectionName: _playerCollection,
                filter: filter
            );
        }

        return _dbInstance.Find<Player>(collectionName: _playerCollection, null);
    }

    public IEnumerable<Element> Create(PlayerPayload payload)
    {
        PlayerPayload args = (PlayerPayload)payload;
        var newPlayer = new Player((string)args.Name!, (Monster)args.MyMonster!, (int)args.EnergyCubes!);
        _dbInstance.InsertOne<Player>(
            collectionName: _playerCollection,
            document: newPlayer
        );
        return new List<Player> { newPlayer };

    }

    public IEnumerable<Element> Delete(PlayerPayload payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<Player>(payload.Id);
            var deleted = _dbInstance.Delete<Player>(
                collectionName: _playerCollection,
                filter: filter
            );
            return new List<Player> { deleted };
        }
        return new List<Player> { };
    }

    public IEnumerable<Element> Update(PlayerPayload payload)
    {
        return new Element[0];
    }
}
