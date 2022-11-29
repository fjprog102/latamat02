namespace KOT.Services.Test;

using KOT.Models;
using KOT.Services;

public class PlayerServiceTest
{
    [Fact]
    public void ShouldReturnAListWithAllPlayers()
    {
        PlayerService playerService = new PlayerService();
        Assert.IsType<List<Player>>(playerService.GetAll());
        Assert.True(playerService.GetAll().Any());
    }

    [Fact]
    public void ShouldReturnAPlayerByPID()
    {
        PlayerService playerService = new PlayerService();
        Assert.False(object.ReferenceEquals(null, playerService.Get(1)));
        Assert.False(object.ReferenceEquals(null, playerService.Get(2)));
    }

    [Fact]
    public void ShouldReturnNonNullObjectWhenANewPlayerIsCreated()
    {
        PlayerService playerService = new PlayerService();
        playerService.Add(
            new Player()
            {
                PID = 3,
                Name = "Kive",
                MyMonster = new Monster("Monster", 1, 1)
            }
        );
        Assert.False(object.ReferenceEquals(null, playerService.Get(3)));
    }

    [Fact]
    public void ShouldReturnNullWhenAPlayerIsDeleted()
    {
        PlayerService playerService = new PlayerService();
        playerService.Delete(2);
        Assert.True(object.ReferenceEquals(null, playerService.Get(2)));
    }

    [Fact]
    public void ShouldReturnNewNameWhenAPlayerIsUpdated()
    {
        PlayerService playerService = new PlayerService();
        Assert.Equal("Pablo", playerService.Get(2)?.Name);
        Player player = new Player()
        {
            PID = 2,
            Name = "Jose",
            MyMonster = new Monster("Monster", 1, 1)
        };
        playerService.Update(player);
        Assert.Equal("Jose", playerService.Get(2)?.Name);
    }
}
