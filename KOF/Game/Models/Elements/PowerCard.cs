using KOT.Models.Abstracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;
using KOT.Models.Processor;
namespace KOT.Models;

public class PowerCard : AbstractCard
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("Cost")]
    public int Cost { get; set; }

    [BsonElement("Type")]
    public CardTypes Type { get; set; }
    // public Effect? effect { get; set; }

    public PowerCard(string name, int cost, int type)
    {
        Name = name;
        Cost = cost;
        Type = (CardTypes)type;
        // effect = _effect;
    }
}
