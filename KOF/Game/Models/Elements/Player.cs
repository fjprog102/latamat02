namespace KOT.Models;
using KOT.Models.Abstracts;
public class Player : Element
{
    public string Id { get; set; }
    public string Name { get; set; }
    public Monster? MyMonster { get; set; }

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
