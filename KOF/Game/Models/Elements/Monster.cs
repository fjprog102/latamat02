namespace KOT.Models;

using KOT.Models.Abstracts;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Monster : Element
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }
    [BsonElement("Name")]
    public string Name { get; set; }
    [BsonElement("VictoryPoints")]
    public int VictoryPoints { get; set; }
    [BsonElement("LifePoints")]
    public int LifePoints { get; set; }

    public Monster(string name, int victoryPoints, int lifePoints)
    {
        Name = name;
        VictoryPoints = victoryPoints;
        LifePoints = lifePoints;
    }
}
