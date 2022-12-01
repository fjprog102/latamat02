namespace KOT.Services;

using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;

public class MonsterService : IMonsterService
{
    private readonly List<Monster> Monsters = new List<Monster>
    {
        new Monster("CyberKitty", 5, 10),
        new Monster("Gigazaur", 7, 10)
    };

    IEnumerable<Element> IMonsterService.Create(MonsterPayload payload)
    {
        if (payload.GetType() == typeof(MonsterPayload))
        {
            MonsterPayload args = (MonsterPayload)payload;
            var newMonster = new Monster((string)args.Name!, (int)args.VictoryPoints!, (int)args.LifePoints!);

            Monsters.Add(newMonster);
            return new Element[] { newMonster };
        }

        return new Element[0];
    }

    IEnumerable<Element> IMonsterService.Read(MonsterPayload payload)
    {
        if (payload.Id != null)
        {
            return Monsters.Where(monster => monster.IdAttr!.Equals(payload.Id));
        }

        return Monsters;
    }

    IEnumerable<Element> IMonsterService.Update(MonsterPayload payload)
    {
        if (payload.Id != null || payload.GetType() == typeof(MonsterPayload))
        {
            MonsterPayload args = (MonsterPayload)payload;
            var newMonster = new Monster((string)args.Name!, (int)args.VictoryPoints!, (int)args.LifePoints!);

            Monsters[Monsters.FindIndex(monster => monster.IdAttr == payload.Id)] = newMonster;

            return new Element[] { newMonster };
        }

        return new Element[0];
    }

    IEnumerable<Element> IMonsterService.Delete(MonsterPayload payload)
    {
        if (payload.Id != null)
        {
            var monster = Monsters
                .Where(monster => monster.IdAttr!.Equals(payload.Id))
                .ToArray();

            Monsters.Remove(monster.First());

            return monster;
        }

        return new Element[0];
    }
}
