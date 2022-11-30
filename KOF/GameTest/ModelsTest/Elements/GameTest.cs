namespace KOT.Models.Test;

using KOT.Models;

public class GameTest
{
    private readonly TokyoBoard board = new TokyoBoard(new List<Player>() { new Player("player1", null), new Player("player2", null) });

    [Fact]
    public void ItShouldThrownAnExceptionIfThenullBoardIsNull()
    {
        TokyoBoard? nullBoard = null;
        Assert.Throws<Exception>(() => new Game(nullBoard!));
    }

    [Fact]
    public void ItShouldCreateTheGameWithAnInitiliazedBoard()
    {
        Game game = new Game(board);
        Assert.NotNull(game);
    }

    [Fact]
    public void ItShouldInitiliazeTheGameWithANewId()
    {
        Game game = new Game(board);
        Assert.IsType<string>(game.Id);
        Assert.NotNull(game.Id);
    }
}
