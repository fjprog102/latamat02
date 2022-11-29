namespace KOT.Services;
using KOT.Models;
using KOT.Models.Abstracts;
using KOT.Services.Interfaces;

public class PlayerService : IPlayerService
{
    private readonly List<Player> Players = new List<Player> {
         new Player("player1", new Monster("monster1", 10, 10){}),
         new Player("player2", new Monster("monster2", 10, 10){})
         };
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
}
