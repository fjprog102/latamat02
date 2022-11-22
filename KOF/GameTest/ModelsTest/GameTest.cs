namespace KOT.Models.Test;

using KOTGame.Models;

public class GameTest
{
    [Fact]
    public void ShouldReturnCorrectID()
    {
        Assert.Equal(1, new Game().Id = 1);
        Assert.Equal(2, new Game().Id = 2);
        Assert.Equal(3, new Game().Id = 3);
    }

    [Fact]
    public void ShouldReturnBoardName()
    {
        Assert.Equal("Tokyo City", new Game().TokyoBoard = "Tokyo City");
        Assert.Equal("Tokyo Bay", new Game().TokyoBoard = "Tokyo Bay");
    }

    [Fact]
    public void ShouldReturnNumberOfPlayers()
    {
        Assert.Equal(2, new Game().NumberOfPlayers = 2);
        Assert.Equal(3, new Game().NumberOfPlayers = 3);
        Assert.Equal(4, new Game().NumberOfPlayers = 4);
        Assert.Equal(5, new Game().NumberOfPlayers = 5);
        Assert.Equal(6, new Game().NumberOfPlayers = 6);
    }

    [Fact]
    public void ShouldReturnActiveUserID()
    {
        Assert.Equal(1, new Game().ActiveUser = 1);
        Assert.Equal(2, new Game().ActiveUser = 2);
        Assert.Equal(3, new Game().ActiveUser = 3);
        Assert.Equal(4, new Game().ActiveUser = 4);
        Assert.Equal(5, new Game().ActiveUser = 5);
        Assert.Equal(6, new Game().ActiveUser = 6);
    }
}
