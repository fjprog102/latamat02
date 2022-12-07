namespace KOT.Models.Test;

using KOT.Models;
using KOT.Models.Processor;

public class GameTest
{
    private readonly TokyoBoard board = new TokyoBoard();
    private readonly TokyoBoardProcessor processor = new TokyoBoardProcessor();
    private readonly List<Player> players = new List<Player>() { new Player("Jose", new Monster("Alienoid", 0, 10), 0),
            new Player("Shirley", new Monster("Cyber Kitty", 0, 10), 0) };

    [Fact]
    public void ItShouldCreateTheGameWithAnInitiliazedBoard()
    {
        Game game = new Game(players);
        Assert.NotNull(game);
    }
}
