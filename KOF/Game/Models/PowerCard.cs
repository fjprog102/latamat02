using KOF.Models.Abstracts;

namespace KOF.Models;

public class PowerCard : AbstractCard
{
    private object Id { get; set; }
    private string Name { get; set; }
    private int Cost { get; set; }
    private CardTypes Type { get; set; }

    public PowerCard(string name, int cost, int type)
    {
        Id = new object(); //Pending for bson ObjectId
        Name = name;
        Cost = cost;
        Type = (CardTypes)type;
    }

    public object? IdAttr => Id;
    public string NameAttr => Name;
    public int CostAttr => Cost;
    public CardTypes TypeAttr => Type;
}
