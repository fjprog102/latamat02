using KOT.Models.Abstracts;
using KOT.Models.Processor;

namespace KOT.Models;

public class PlayerPayload : DataHolder
{
    public string? Name { get; set; }
    public Monster? MyMonster { get; set; }
    public int? EnergyCubes { get; set; }
    public List<CardDetails>? PowerCards { get; set; }

    public PlayerPayload(
        string? id = null,
        string? name = null,
        Monster? myMonster = null,
        int? energyCubes = 0,
        List<CardDetails>? powerCards = null
    )
    {
        Id = id;
        Name = name;
        MyMonster = myMonster;
        EnergyCubes = energyCubes;
        PowerCards = powerCards;
    }
}
