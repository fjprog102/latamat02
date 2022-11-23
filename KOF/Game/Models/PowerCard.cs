using KOF.Models.Abstracts;

namespace KOF.Models;

public class PowerCard : AbstractCard
{
    private string Id { get; set; }
    private string Name { get; set; }
    private int Cost { get; set; }
    private CardTypes Type { get; set; }

    public PowerCard(string name, int cost, int type)
    {
        Id = "12345678";
        Name = name;
        Cost = cost;
        Type = (CardTypes)type;
    }

    public string IdAttr => Id;
    public string NameAttr => Name;
    public int CostAttr => Cost;
    public CardTypes TypeAttr => Type;
}
