namespace ModelsTests;

using KOT.Models;

public class TokyoBoardTest
{
    [Fact]
    public void ItShouldThrowAnExceptionWhenGamePlayersAreLessThanTwo()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           new Player(),
        };
        Assert.Throws<Exception>(() => new TokyoBoard(gamePlayers));
    }

    [Fact]
    public void ItShouldThrowAnExceptionWhenGamePlayersAreMoreThanSix()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           new Player(),
           new Player(),
           new Player(),
           new Player(),
           new Player(),
           new Player(),
           new Player(),
        };
        Assert.Throws<Exception>(() => new TokyoBoard(gamePlayers));
    }

    [Fact]
    public void ItShouldInstanceTokyoBayWhenPlayersAreMoreThanFour()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           new Player(),
           new Player(),
           new Player(),
           new Player(),
           new Player(),
        };
        TokyoBoard board = new TokyoBoard(gamePlayers);
        Assert.NotNull(board.TokyoBay);
    }

    [Fact]
    public void ItShouldNotInstanceTokyoBayWhenPlayersAreLessThanFive()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           new Player(),
           new Player(),
           new Player(),
           new Player(),
        };
        TokyoBoard board = new TokyoBoard(gamePlayers);
        Assert.Null(board.TokyoBay);
    }

    [Fact]
    public void ItShouldPlaceAllPlayersOutsideTokyoWhenBoardIsInitialized()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           new Player(),
           new Player(),
           new Player(),
           new Player(),
           new Player(),
        };
        TokyoBoard board = new TokyoBoard(gamePlayers);
        Assert.Equal(5, board.OutsideTokyo.Count());
        Assert.Empty(board.TokyoBay);
        Assert.Empty(board.TokyoCity);
    }

    [Fact]
    public void ItShouldChangeTheBoardPlaceOfThePlayer()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           new Player(),
           new Player(),
           new Player(),
           new Player(),
           new Player(),
        };
        TokyoBoard board = new TokyoBoard(gamePlayers);
        Assert.Equal(5, board.OutsideTokyo.Count());
        Assert.Empty(board.TokyoCity);
        board.ChangePlayerBoardPlace(gamePlayers[0], board.OutsideTokyo, board.TokyoCity);
        Assert.Equal(4, board.OutsideTokyo.Count());
        Assert.Single(board.TokyoCity);
        board.ChangePlayerBoardPlace(gamePlayers[3], board.OutsideTokyo, board.TokyoBay);
        Assert.Equal(3, board.OutsideTokyo.Count());
        Assert.Single(board.TokyoBay);
        Assert.Single(board.TokyoCity);
        board.ChangePlayerBoardPlace(gamePlayers[3], board.TokyoBay, board.TokyoCity);
        Assert.Equal(3, board.OutsideTokyo.Count());
        Assert.Empty(board.TokyoBay);
        Assert.Equal(2, board.TokyoCity.Count());
    }
}
