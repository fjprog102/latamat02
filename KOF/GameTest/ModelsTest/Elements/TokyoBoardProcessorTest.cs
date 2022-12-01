namespace ModelsTests;

using KOT.Models;
using KOT.Models.Processors;

public class TokyoBoardProcessorTest
{
    private readonly TokyoBoardProcessor Processor = new TokyoBoardProcessor();
    private readonly TokyoBoard Board = new TokyoBoard();
    private readonly Player player = new Player("player", new Monster("player", 10, 10));

    [Fact]
    public void ItShouldThrowAnExceptionWhenGamePlayersAreLessThanTwo()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           player,
        };
        Assert.Throws<Exception>(() => Processor.CheckAmountOfPlayers(gamePlayers));
    }

    [Fact]
    public void ItShouldThrowAnExceptionWhenGamePlayersAreMoreThanSix()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           player,
           player,
           player,
           player,
           player,
           player,
           player,
        };
        Assert.Throws<Exception>(() => Processor.CheckAmountOfPlayers(gamePlayers));
    }

    [Fact]
    public void ItShouldSetTokyoBayWhenPlayersAreMoreThanFour()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           player,
           player,
           player,
           player,
           player,
        };
        Processor.SetTokyoBoard(gamePlayers, Board);
        Assert.NotNull(Board.TokyoBay);
    }

    [Fact]
    public void ItShouldNotSetTokyoBayWhenPlayersAreLessThanFive()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           player,
           player,
           player,
           player,
        };
        Processor.SetTokyoBoard(gamePlayers, Board);
        Assert.Null(Board.TokyoBay);
    }

    [Fact]
    public void ItShouldSetAllPlayersOutsideTokyo()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           player,
           player,
           player,
           player,
           player,
        };
        Processor.SetTokyoBoard(gamePlayers, Board);
        Assert.Equal(5, Board.OutsideTokyo.Count());
        Assert.Empty(Board.TokyoBay);
        Assert.Empty(Board.TokyoCity);
    }

    [Fact]
    public void ItShouldChangeTheBoardPlaceOfThePlayer()
    {
        List<Player> gamePlayers = new List<Player>()
        {
           player,
           player,
           player,
           player,
           player,
        };
        Processor.SetTokyoBoard(gamePlayers, Board);
        Assert.Equal(5, Board.OutsideTokyo.Count());
        Assert.Empty(Board.TokyoCity);
        Processor.ChangePlayerBoardPlace(gamePlayers[0], Board.OutsideTokyo, Board.TokyoCity);
        Assert.Equal(4, Board.OutsideTokyo.Count());
        Assert.Single(Board.TokyoCity);
        Processor.ChangePlayerBoardPlace(gamePlayers[3], Board.OutsideTokyo, Board.TokyoBay);
        Assert.Equal(3, Board.OutsideTokyo.Count());
        Assert.Single(Board.TokyoBay);
        Assert.Single(Board.TokyoCity);
        Processor.ChangePlayerBoardPlace(gamePlayers[3], Board.TokyoBay, Board.TokyoCity);
        Assert.Equal(3, Board.OutsideTokyo.Count());
        Assert.Empty(Board.TokyoBay);
        Assert.Equal(2, Board.TokyoCity.Count());
    }
}
