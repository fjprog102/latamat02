namespace KOT.Controllers.PlayerActions.Test;

using KOT.Controllers.Abstracts;
using KOT.Controllers.PlayerActions;
using KOT.Models;
using KOT.Models.Processor;

public class ExecutePowerCardTest
{
    public Player player1 = new Player(
    "Player1",
    new Monster("Monster1", 5, 10),
    14,
    new List<CardDetails>()
    {
            new CardDetails(new PowerCard("Corner Store", 3, 1), new Effect(starPoints: 1))

    }
);
    public Player player2 = new Player(
        "Player2",
        new Monster("Monster2", 5, 10),
        14,
        new List<CardDetails>()
        {
            new CardDetails(new PowerCard("Skycraper", 6, 1), new Effect(starPoints: 4)),
            new CardDetails(new PowerCard("Energize", 8, 1), new Effect(energyPoints: 9)),
        }
    );
    public Player player3 = new Player(
        "Player3",
        new Monster("Monster3", 5, 8),
        14,
        new List<CardDetails>()
        {
            new CardDetails(new PowerCard("Skycraper", 6, 1), new Effect(starPoints: 4)),
            new CardDetails(new PowerCard("Corner Store", 3, 1), new Effect(heartPoints: 1))
        }
    );
    public Player player4 = new Player(
        "Player4",
        new Monster("Monster4", 5, 8),
        14,
        new List<CardDetails>()
        {
            new CardDetails(new PowerCard("Heal", 3, 1), new Effect(heartPoints: 2)),
            new CardDetails(new PowerCard("Heal", 3, 1), new Effect(energyPoints: 2)),
            new CardDetails(new PowerCard("Skycraper", 6, 1), new Effect(starPoints: 4)),
        }
    );
    public Player player5 = new Player(
        "Player5",
        new Monster("Monster5", 5, 10),
        14,
        new List<CardDetails>()
        {
            new CardDetails(new PowerCard("Energize", 8, 1), new Effect(energyPoints: 9)),
        }
    );
    private readonly ExecutePowerCard Analizer = new ExecutePowerCard();

    [Fact]
    public void ItShouldBeAChildInstance()
    {
        var instance = new ExecutePowerCard();
        Assert.True(instance.Instance.GetType().IsSubclassOf(typeof(GameAction<ExecutePowerCard>)));
    }

    [Fact]
    public void ItShouldExecuteAllThePowerCardsEffectOfThePlayer()
    {
        Assert.Equal(8, player4.MyMonster.LifePoints);
        Assert.Equal(14, player4.EnergyCubes);
        Assert.Equal(5, player4.MyMonster.VictoryPoints);
        Assert.Equal(2, player4.PowerCards![0].effect.LifePoints);
        Assert.Equal(2, player4.PowerCards![1].effect.EnergyPoints);
        Assert.Equal(4, player4.PowerCards![2].effect.VictoryPoints);
        Analizer.ExecuteEffect(player4);
        Assert.Equal(10, player4.MyMonster.LifePoints);
        Assert.Equal(16, player4.EnergyCubes);
        Assert.Equal(9, player4.MyMonster.VictoryPoints);
    }

    [Fact]
    public void ItShouldExecuteThePowerCardOfTheActivePlayer()
    {
        List<Player> players = new List<Player>() { player1, player2, player3, player4, player5 };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), player1.Name);

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.Contains(player1, game.Board!.OutsideTokyo);
        Assert.Equal(player1.Name, game.ActivePlayerName);
        Assert.Equal(5, player1.MyMonster.VictoryPoints);
        Analizer.Execute(null!, game);
        Assert.Equal(6, player1.MyMonster.VictoryPoints);

        game.BoardProcessor!.ChangePlayerBoardPlace(player2, game.Board!.OutsideTokyo, game.Board.TokyoCity);
        Assert.Contains(player2, game.Board!.TokyoCity);
        game.ActivePlayerName = player2.Name;
        Assert.Equal(player2.Name, game.ActivePlayerName);
        Assert.Equal(5, player2.MyMonster.VictoryPoints);
        Assert.Equal(14, player2.EnergyCubes);
        Analizer.Execute(null!, game);
        Assert.Equal(9, player2.MyMonster.VictoryPoints);
        Assert.Equal(23, player2.EnergyCubes);

        game.BoardProcessor!.ChangePlayerBoardPlace(player4, game.Board!.OutsideTokyo, game.Board.TokyoBay);
        Assert.Contains(player4, game.Board!.TokyoBay);
        game.ActivePlayerName = player4.Name;
        Assert.Equal(player4.Name, game.ActivePlayerName);
        Assert.Equal(5, player4.MyMonster.VictoryPoints);
        Assert.Equal(14, player4.EnergyCubes);
        Assert.Equal(8, player4.MyMonster.LifePoints);
        Analizer.Execute(null!, game);
        Assert.Equal(9, player4.MyMonster.VictoryPoints);
        Assert.Equal(16, player4.EnergyCubes);
        Assert.Equal(10, player4.MyMonster.LifePoints);
    }
}
