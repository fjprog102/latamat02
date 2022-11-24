namespace KOF.Models;

public class Monster : DataHolder
{
    public new int Id { get; set; }
    public string? Name { get; set; }
    public int VictoryPoints { get; set; }
    public int LifePoints { get; set; }
}
