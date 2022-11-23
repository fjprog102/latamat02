namespace KOF.Services;

using KOF.Models;

public static class PlayerService
{
    public static class PizzaService
{
    static List<Player> Players { get; }
    //static int nextId = 3;
    static PlayerService()
    {
        Players = new List<Player>
        {
            new Player { Id = "aodfjD5f", Name = "Classic Italian", IsGlutenFree = false },
            new Player { Id = "2sdfXx6f", Name = "Veggie", IsGlutenFree = true }
        };
    }

    public static List<Player> GetAll() => Players;

    public static Player? Get(int id) => Players.FirstOrDefault(p => p.Id == id);

    public static void Add(Player player)
    {
        player.Id = nextId++;
        Players.Add(player);
    }

    public static void Delete(int id)
    {
        var player = Get(id);
        if(player is null)
            return;

        Players.Remove(player);
    }

    public static void Update(Players player)
    {
        var index = Players.FindIndex(p => p.Id == player.Id);
        if(index == -1)
            return;

        Players[index] = player;
    }
}
}
