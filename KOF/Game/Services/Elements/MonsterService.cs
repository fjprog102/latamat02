namespace KOT.Services;

using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;

public class MonsterService : IMonsterService
{
    private readonly string _monsterCollection;
    private readonly IDatabaseService _dbInstance;

    public MonsterService(
        IOptions<KOTDatabaseSettings> kotDatabaseSettings,
        IDatabaseService dbInstance
    )
    {
        _monsterCollection = kotDatabaseSettings.Value.MonsterCollectionName;
        _dbInstance = dbInstance;
    }

    public IEnumerable<Element> Create(MonsterPayload payload)
    {
        MonsterPayload args = (MonsterPayload)payload;
        var newMonster = new Monster((string)args.Name!, (int)args.VictoryPoints!, (int)args.LifePoints!);
        _dbInstance.InsertOne<Monster>(
            collectionName: _monsterCollection,
            document: newMonster
        );
        return new List<Monster> { newMonster };
    }

    public IEnumerable<Element> Read(MonsterPayload payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<Monster>(payload.Id);
            return _dbInstance.Find<Monster>(
                collectionName: _monsterCollection,
                filter: filter
            );
        }

        return _dbInstance.Find<Monster>(collectionName: _monsterCollection, null);
    }

    public IEnumerable<Element> Delete(MonsterPayload payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<Monster>(payload.Id);
            var deleted = _dbInstance.Delete<Monster>(
                collectionName: _monsterCollection,
                filter: filter
            );
            return new List<Monster> { deleted };
        }

        return new List<Monster> { };
    }

    public IEnumerable<Element> Update(MonsterPayload payload)
    {
        return new Element[0];
    }
}
