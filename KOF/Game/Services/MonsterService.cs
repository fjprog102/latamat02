namespace KOF.Services;

using KOF.Models;

public static class MonsterService
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

    public static List<Monster> GetAll() => Monsters;

    public static void Add(Monster monster)
    {
        monster.Id = nextId++;
        Monsters.Add(monster);
    }
}
