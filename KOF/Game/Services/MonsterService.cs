namespace KOT.Services;

using KOT.Models;

public class MonsterService
{
    private List<Monster> Monsters { get; }

    private int nextId = 3;
    public MonsterService()
    {
        Monsters = new List<Monster>
        {
            new Monster { Id = 1, Name = "CyberKitty", VictoryPoints = 5, LifePoints = 10 },
            new Monster { Id = 2, Name = "Gigazaur", VictoryPoints = 7, LifePoints = 10 }
        };
    }

    public Monster? GetById(int id) => Monsters.FirstOrDefault(monster => monster.Id == id);

    public List<Monster> GetAll() => Monsters;

    public void Add(Monster monster)
    {
        monster.Id = nextId++;
        Monsters.Add(monster);
    }

    public void Update(Monster monster)
    {
        var index = Monsters.FindIndex(m => m.Id == monster.Id);
        if (index == -1)
        {
            return;
        }

        Monsters[index] = monster;
    }

    public void Delete(int id)
    {
        var monster = GetById(id);
        if (monster is null)
        {
            return;
        }

        Monsters.Remove(monster);
    }
}
