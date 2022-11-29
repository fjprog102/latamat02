namespace KOT.Services;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;

public class PlayerService : IPlayerService
{
    private List<Player> Players = new List<Player> {
         new Player("player1", new Monster(){}),
         new Player("player2", new Monster(){}) 
         };
    // private int nextId = 3;
    IEnumerable<Element> IPlayerService.Read(DataHolder payload)
    {
        if (payload.Id != null)
        {
            return Players.Select(player => player).Where(player => player.IdAttr!.Equals(payload.Id));
        }
       
        return Players;
    }

    IEnumerable<Element> IPlayerService.Create(DataHolder payload)
    {
        if (payload.GetType() == typeof(PlayerPayload))
        {
            PlayerPayload args = (PlayerPayload)payload;
            var player = new Player((string)args.Name!, (Monster)args.MyMonster!);
            Players.Add(player);
            return new Element[] { player };
        }

        return new Element[0];
    }
    IEnumerable<Element> IPlayerService.Delete(DataHolder payload)
    {
            if (payload.Id != null)
            {
                var player = Players
                    .Select(player => player)
                    .Where(player => player.IdAttr!.Equals(payload.Id))
                    .ToArray();

                Players.Remove(player.First());

                return player;
            }

        return new Element[0];
    }

    IEnumerable<Element> IPlayerService.Update(DataHolder payload)
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
