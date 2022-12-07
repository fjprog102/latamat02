namespace KOT.Models;
using KOT.Models.Abstracts;
using KOT.Models.Processor;
using MongoDB.Bson;
using MongoDB.Bson.Serialization.Attributes;

public class Player : Element
{
    [BsonId]
    [BsonRepresentation(BsonType.ObjectId)]
    public string? Id { get; set; }

    [BsonElement("Name")]
    public string Name { get; set; }

    [BsonElement("MyMonster")]
    public Monster MyMonster { get; set; }

    [BsonElement("EnergyCubes")]
    public int EnergyCubes { get; set; }

    [BsonElement("PowerCards")]
    public List<CardDetails>? PowerCards { get; set; }

    public Player(string name, Monster myMonster, int energyCubes = 0, List<CardDetails>? powerCards = null)
    {
        Name = name;
        MyMonster = myMonster;
        EnergyCubes = energyCubes;
        PowerCards = powerCards;
    }
}
