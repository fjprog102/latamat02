namespace KOT.Services;

using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class MonsterService : IMonsterService
{
    private readonly List<Monster> Monsters = new List<Monster>
    {
        new Monster("CyberKitty", 5, 10),
        new Monster("Gigazaur", 7, 10)
    };

    private readonly IMongoCollection<Monster> MonsterCollection;

    public MonsterService(IOptions<KOTDatabaseSettings> kotDatabaseSettings)
    {
        var mongoClient = new MongoClient(kotDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(kotDatabaseSettings.Value.DatabaseName);
        MonsterCollection = mongoDatabase.GetCollection<Monster>(
            kotDatabaseSettings.Value.MonsterCollectionName
        );
    }

    IEnumerable<Element> IMonsterService.Create(MonsterPayload payload)
    {
        if (payload.GetType() == typeof(MonsterPayload))
        {
            MonsterPayload args = (MonsterPayload)payload;
            var newMonster = new Monster((string)args.Name!, (int)args.VictoryPoints!, (int)args.LifePoints!);

            MonsterCollection.InsertOne(newMonster);
            return new Element[] { newMonster };
        }

        return new Element[0];
    }

    IEnumerable<Element> IMonsterService.Read(MonsterPayload payload)
    {
        if (payload.Id != null)
        {
            return MonsterCollection.Find(x => x.Id!.Equals(payload.Id)).ToList();
        }

        return MonsterCollection.Find(x => true).ToList();
    }

    IEnumerable<Element> IMonsterService.Update(MonsterPayload payload)
    {
        if (payload.Id != null || payload.GetType() == typeof(MonsterPayload))
        {
            MonsterPayload args = (MonsterPayload)payload;
            var newMonster = new Monster((string)args.Name!, (int)args.VictoryPoints!, (int)args.LifePoints!);

            var filter = Builders<Monster>.Filter.Eq(monster => monster.Id, payload.Id);
            var update = Builders<Monster>.Update
                .Set(monster => monster.Name, newMonster.Name)
                .Set(monster => monster.VictoryPoints, newMonster.VictoryPoints)
                .Set(monster => monster.LifePoints, newMonster.LifePoints);

            MonsterCollection.UpdateOne(filter, update);

            return new Element[] { newMonster };
        }

        return new Element[0];
    }

    IEnumerable<Element> IMonsterService.Delete(MonsterPayload payload)
    {
        if (payload.Id != null)
        {
            var deleted = MonsterCollection.FindOneAndDelete(x => x.Id!.Equals(payload.Id));
            return new Element[] { deleted };
        }

        return new Element[0];
    }
}
