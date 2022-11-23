namespace KOF.Services;

using KOF.Models;

public static class PlayerService
{
    static List<Player> Players { get; }

    static PlayerService()
    {
        Players = new List<Player>
        {
            new Player
            {
                PID = "aodfjD5f",
                DisplayName = "Pedro",
                Email = "pedro@gmail.com",
                Password = "asd123",
                PhotoID = "xkslf123ad5"
            },
            new Player
            {
                PID = "AsdldF$d",
                DisplayName = "Pablo",
                Email = "pablo@gmail.com",
                Password = "asd1234",
                PhotoID = "5sdf3xdf5gd"
            }
        };
    }

    public static List<Player> GetAll() => Players;

    public static Player? Get(string pid) => Players.FirstOrDefault(p => p.PID == pid);

    public static void Add(Player player)
    {
        const string chars =
            "0123456789ABCDEFGHIJKLMNOPQRSTUVWXYZabcdefghijklmnopqrstuvwxyz#@$^*()";
        Random random = new Random();
        var randomPID = new string(
            Enumerable.Repeat(chars, 16).Select(s => s[random.Next(s.Length)]).ToArray()
        );
        player.PID = randomPID;
        Players.Add(player);
    }

    public static void Delete(string id)
    {
        var player = Get(id);
        if (player is null)
            return;

        Players.Remove(player);
    }

    public static void Update(Player player)
    {
        var index = Players.FindIndex(p => p.PID == player.PID);
        if (index == -1)
            return;

        Players[index] = player;
    }
}
