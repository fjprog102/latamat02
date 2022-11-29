namespace KOT.Models;

using KOT.Models.Abstracts;

public class Monster : Element
{
    private string Id { get; set; }
    private string Name { get; set; }
    private int VictoryPoints { get; set; }
    private int LifePoints { get; set; }

    public Monster(string name, int victoryPoints, int lifePoints)
    {
        Id = "123";
        Name = name;
        VictoryPoints = victoryPoints;
        LifePoints = lifePoints;
    }

    public string? IdAttr => Id;
    public string NameAttr => Name;
    public int VictoryPointsAttr => VictoryPoints;
    public int LifePointsAttr => LifePoints;
}
