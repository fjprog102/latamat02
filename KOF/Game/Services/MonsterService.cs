namespace KOF.Services;

using KOF.Models;

public class MonsterService
{
    private static List<Monster> Monsters { get; }

    private static int nextId = 3;
    static MonsterService()
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
        var monster = new MonsterService().GetById(id);
        if (monster is null)
        {
            return;
        }

        Monsters.Remove(monster);
    }
}
