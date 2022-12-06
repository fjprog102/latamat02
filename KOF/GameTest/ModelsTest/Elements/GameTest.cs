namespace KOT.Models.Test;

using KOT.Models;
using KOT.Models.Processor;

public class GameTest
{
    private readonly TokyoBoard board = new TokyoBoard();
    private readonly TokyoBoardProcessor processor = new TokyoBoardProcessor();
    private readonly List<Player> players = new List<Player>();

    [Fact]
    public void ItShouldCreateTheGameWithAnInitiliazedBoard()
    {
        Game game = new Game(board, processor, players, "");
        Assert.NotNull(game);
    }
}
