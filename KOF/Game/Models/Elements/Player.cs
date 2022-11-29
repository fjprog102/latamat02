namespace KOT.Models;
using KOT.Models.Abstracts;
public class Player : Element
{
    private string Id { get; set; }
    private string Name { get; set; }
    private Monster? MyMonster { get; set; }

    public Player(string name, Monster monster)
    {
        Id = "123456789";
        Name = name;
        MyMonster = monster;
    }

    public string? IdAttr => Id;
    public string NameAttr => Name;
    public Monster? MonsterAttr => MyMonster;
}
