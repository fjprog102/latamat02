using KOT.Models.Abstracts;

namespace KOT.Models;

public class PlayerPayload : DataHolder
{
    public string? Name { get; set; }
    public Monster? MyMonster { get; set; }

    public PlayerPayload(
        int? pid = null,
        string? name = null,
        Monster? monster = null
    )
    {
        Id = pid.ToString();
        Name = name;
        MyMonster = monster;
    }
}
