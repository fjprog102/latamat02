using KOF.Models.Abstracts;

namespace KOF.Models;

public class PowerCard : AbstractCard
{
    public int Id { get; set; }
    private string Name { get; set; }
    private int Cost { get; set; }
    private CardTypes Type { get; set; }

    public PowerCard(string name, int cost, int type)
    {
        Name = name;
        Cost = cost;
        Type = (CardTypes)type;
    }

    public int IdAttr => Id;
    public string NameAttr => Name;
    public int CostAttr => Cost;
    public CardTypes TypeAttr => Type;
}
