namespace KOF.Models;

public abstract class DataHolder
{
    public object? Id { get; set; }
}

public class PowerCardPayload : DataHolder
{
    public string? Name { get; set; }
    public int? Cost { get; set; }
    public int? Type { get; set; }

    public PowerCardPayload(object? id, string? name = null, int? cost = null, int? type = null)
    {
        Id = id;
        Name = name;
        Cost = cost;
        Type = type;
    }
}
