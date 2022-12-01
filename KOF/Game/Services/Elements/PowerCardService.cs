using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace KOT.Services;

public class PowerCardService : IPowerCardService
{
    public readonly IMongoCollection<PowerCard> PowerCardCollection;

    public PowerCardService(IOptions<KOTDatabaseSettings> kotDatabaseSettings)
    {
        var mongoClient = new MongoClient(kotDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(kotDatabaseSettings.Value.DatabaseName);
        PowerCardCollection = mongoDatabase.GetCollection<PowerCard>(
            kotDatabaseSettings.Value.PowerCardCollectionName
        );
    }

    public IEnumerable<Element> Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            return PowerCardCollection.Find(x => x.Id!.Equals(payload.Id)).ToList();
        }

        return PowerCardCollection.Find(x => true).ToList();
    }

    public IEnumerable<Element> Create(DataHolder payload)
    {
        if (payload.GetType() == typeof(PowerCardPayload))
        {
            PowerCardPayload args = (PowerCardPayload)payload;
            var newCard = new PowerCard((string)args.Name!, (int)args.Cost!, (int)args.Type!);
            PowerCardCollection.InsertOne(newCard);
            return new Element[] { newCard };
        }

        return new Element[0];
    }

    public IEnumerable<Element> Delete(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var deleted = PowerCardCollection.FindOneAndDelete(x => x.Id!.Equals(payload.Id));
            return new Element[] { deleted };
        }

        return new Element[0];
    }

    public IEnumerable<Element> Update(DataHolder payload)
    {
        return new Element[0];
    }
}
