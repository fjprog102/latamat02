using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;
using MongoDB.Driver;

namespace KOT.Services;

public class PowerCardService : IPowerCardService
{
    private readonly List<PowerCard> cards = new List<PowerCard> { new PowerCard("testA", 1, 1) };

    private readonly IMongoCollection<PowerCard> PowerCardCollection;

    public PowerCardService(IOptions<KOTDatabaseSettings> kotDatabaseSettings)
    {
        var mongoClient = new MongoClient(kotDatabaseSettings.Value.ConnectionString);
        var mongoDatabase = mongoClient.GetDatabase(kotDatabaseSettings.Value.DatabaseName);
        PowerCardCollection = mongoDatabase.GetCollection<PowerCard>(
            kotDatabaseSettings.Value.PowerCardCollectionName
        );
    }

    IEnumerable<Element> IPowerCardService.Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            return PowerCardCollection.Find(x => x.Id!.Equals(payload.Id)).ToList();
            //return cards.Select(card => card).Where(card => card.IdAttr!.Equals(payload.Id));
        }

        return PowerCardCollection.Find(x => true).ToList();
        //return cards;
    }

    IEnumerable<Element> IPowerCardService.Create(DataHolder payload)
    {
        if (payload.GetType() == typeof(PowerCardPayload))
        {
            PowerCardPayload args = (PowerCardPayload)payload;
            var newCard = new PowerCard((string)args.Name!, (int)args.Cost!, (int)args.Type!);
            //cards.Add(newCard);
            PowerCardCollection.InsertOne(newCard);
            return new Element[] { newCard };
        }

        return new Element[0];
    }

    IEnumerable<Element> IPowerCardService.Delete(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var deleted = PowerCardCollection.FindOneAndDelete(x => x.Id!.Equals(payload.Id));
            return new Element[] { deleted };
        }

        return new Element[0];
    }

    IEnumerable<Element> IPowerCardService.Update(DataHolder payload)
    {
        return new Element[0];
    }
}
