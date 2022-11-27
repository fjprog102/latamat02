namespace KOT.Services;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;

public class PlayerService : IDataService
{
    private List<Player> Players { get; }
    private int nextId = 3;

    public PlayerService()
    {
        Players = new List<Player>
        {
            new Player
            {
                PID = 1,
                Name = "Pedro",
                MyMonster = new Monster()
            },
            new Player
            {
                PID = 2,
                Name = "Pablo",
                MyMonster = new Monster()
            }
        };
    }
    IEnumerable<Element> IDataService.Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            return Players.Select(player => player).Where(player => player.PID!.Equals(payload.Id));
        }

        return Players;
    }

    IEnumerable<Element> IDataService.Create(DataHolder payload)
    {
        if (payload.GetType() == typeof(PlayerPayload))
        {
            PlayerPayload args = (PlayerPayload)payload;
            var player = new Player();
            player.PID = nextId;
            player.Name = args.Name;
            player.MyMonster = args.MyMonster;
            Players.Add(player);
            return new Element[] { player };
        }

        return new Element[0];
    }
    IEnumerable<Element> IDataService.Delete(DataHolder payload)
    {
    //     if (payload.Id != null)
    //     {
    //         var card = cards
    //             .Select(card => card)
    //             .Where(card => card.IdAttr!.Equals(payload.Id))
    //             .ToArray();

    //         cards.Remove(card.First());

    //         return card;
    //     }

        return new Element[0];
    }

    IEnumerable<Element> IDataService.Update(DataHolder payload)
    {
        return new Element[0];
    }
    // public List<Player> GetAll() => Players;

    // public Player? Get(int pid) => Players.FirstOrDefault(p => p.PID == pid);

    // public void Add(Player player)
    // {
    //     player.PID = nextId++;
    //     Players.Add(player);
    // }

    // public void Delete(int pid)
    // {
    //     var player = Get(pid);
    //     if (player is null)
    //     {
    //         return;
    //     }

    //     Players.Remove(player);
    // }

    // public void Update(Player player)
    // {
    //     var index = Players.FindIndex(p => p.PID == player.PID);
    //     if (index == -1)
    //     {
    //         return;
    //     }

    //     Players[index] = player;
    // }
}
