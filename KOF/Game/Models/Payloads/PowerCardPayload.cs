using KOT.Models.Abstracts;

namespace KOT.Models;

public class PowerCardPayload : DataHolder
{
    public string? Name { get; set; }
    public int? Cost { get; set; }
    public int? Type { get; set; }

    public PowerCardPayload(
        string? id = null,
        string? name = null,
        int? cost = null,
        int? type = null
    )
    {
        Id = id;
        Name = name;
        Cost = cost;
        Type = type;
    }
}
