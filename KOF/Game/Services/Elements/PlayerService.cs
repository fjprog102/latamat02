namespace KOT.Services;

using KOT.Models;

public class PlayerService
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

    public List<Player> GetAll() => Players;

    public Player? Get(int pid) => Players.FirstOrDefault(p => p.PID == pid);

    public void Add(Player player)
    {
        player.PID = nextId++;
        Players.Add(player);
    }

    public void Delete(int pid)
    {
        var player = Get(pid);
        if (player is null)
        {
            return;
        }

        Players.Remove(player);
    }

    public void Update(Player player)
    {
        var index = Players.FindIndex(p => p.PID == player.PID);
        if (index == -1)
        {
            return;
        }

        Players[index] = player;
    }
}
