using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;
using Microsoft.Extensions.Options;

namespace KOT.Services;

public class PowerCardService : IPowerCardService
{
    private readonly string _powerCardCollection;
    private readonly IDatabaseService _dbInstance;

    public PowerCardService(
        IOptions<KOTDatabaseSettings> kotDatabaseSettings,
        IDatabaseService dbInstance
    )
    {
        _powerCardCollection = kotDatabaseSettings.Value.PowerCardCollectionName;
        _dbInstance = dbInstance;
    }

    public IEnumerable<Element> Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<PowerCard>(payload.Id);
            return _dbInstance.Find<PowerCard>(
                collectionName: _powerCardCollection,
                filter: filter
            );
        }

        return _dbInstance.Find<PowerCard>(collectionName: _powerCardCollection, null);
    }

    public IEnumerable<Element> Create(DataHolder payload)
    {
        if (payload.GetType() == typeof(PowerCardPayload))
        {
            PowerCardPayload args = (PowerCardPayload)payload;
            var newCard = new PowerCard((string)args.Name!, (int)args.Cost!, (int)args.Type!);
            _dbInstance.InsertOne<PowerCard>(
                collectionName: _powerCardCollection,
                document: newCard
            );
            return new List<PowerCard> { newCard };
        }

        return new List<PowerCard> { };
    }

    public IEnumerable<Element> Delete(DataHolder payload)
    {
        if (payload.Id != null)
        {
            var filter = _dbInstance.GetFilterId<PowerCard>(payload.Id);
            var deleted = _dbInstance.Delete<PowerCard>(
                collectionName: _powerCardCollection,
                filter: filter
            );
            return new List<PowerCard> { deleted };
        }

        return new List<PowerCard> { };
    }
}
