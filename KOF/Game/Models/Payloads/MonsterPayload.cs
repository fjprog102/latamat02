namespace KOT.Models;

using KOT.Models.Abstracts;

public class MonsterPayload : DataHolder
{
    public string? Name { get; set; }
    public int? VictoryPoints { get; set; }
    public int? LifePoints { get; set; }

    public MonsterPayload(
        string? id = null,
        string? name = null,
        int? victoryPoints = null,
        int? lifePoints = null
    )
    {
        Id = id;
        Name = name;
        VictoryPoints = victoryPoints;
        LifePoints = lifePoints;
    }
}
