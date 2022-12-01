namespace KOT.Services;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

public class PlayerService : IPlayerService
{
    public readonly IMongoCollection<Player> PlayerCollection;

    public PlayerService(IOptions<KOTDatabaseSettings> kotDatabaseSettings)
    {
        var mongoClient = new MongoClient(kotDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(kotDatabaseSettings.Value.DatabaseName);
        PlayerCollection = mongoDatabase.GetCollection<Player>(
            kotDatabaseSettings.Value.PlayerCollectionName
        );
    }

    IEnumerable<Element> IPlayerService.Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            return PlayerCollection.Find(x => x.Id!.Equals(payload.Id)).ToList();
        }

        return PlayerCollection.Find(x => true).ToList();
    }

    IEnumerable<Element> IPlayerService.Create(DataHolder payload)
    {
        if (payload.GetType() == typeof(PlayerPayload))
        {
            PlayerPayload args = (PlayerPayload)payload;
            var newCard = new Player((string)args.Name!, (Monster)args.MyMonster!);
            PlayerCollection.InsertOne(newCard);
            return new Element[] { newCard };
        }

        return new Element[0];
    }

    IEnumerable<Element> IPlayerService.Delete(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var deleted = PlayerCollection.FindOneAndDelete(x => x.Id!.Equals(payload.Id));
            return new Element[] { deleted };
        }

        return new Element[0];
    }

    IEnumerable<Element> IPlayerService.Update(DataHolder payload)
    {
        if (payload.Id != null || payload.GetType() == typeof(MonsterPayload))
        {
            PlayerPayload args = (PlayerPayload)payload;
            var newPlayer = new Player((string)args.Name!, (Monster)args.MyMonster!);

            var filter = Builders<Player>.Filter.Eq(player => player.Id, payload.Id);
            var update = Builders<Player>.Update
                .Set(player => player.Name, newPlayer.Name)
                .Set(player => player.MyMonster, newPlayer.MyMonster);

            PlayerCollection.UpdateOne(filter, update);

            return new Element[] { newPlayer };
        }

        return new Element[0];
    }
}
