namespace KOT.Models.Test;

using KOT.Models;
using KOT.Models.Processor;

public class GameTest
{
    private readonly TokyoBoard board = new TokyoBoard();
    private readonly TokyoBoardProcessor processor = new TokyoBoardProcessor();

    [Fact]
    public void ItShouldThrownAnExceptionIfThenullBoardIsNull()
    {
        TokyoBoard? nullBoard = null;
        Assert.Throws<Exception>(() => new Game(nullBoard!, processor));
    }

    [Fact]
    public void ItShouldCreateTheGameWithAnInitiliazedBoard()
    {
        Game game = new Game(board, processor);
        Assert.NotNull(game);
    }
}
