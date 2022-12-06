namespace KOT.Controllers.PowerCardsActions.Test;
using KOT.Models;
using KOT.Models.Processor;

using KOT.Services.Processors;

public class NewGame
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
            new CardDetails(new PowerCard("Skycraper", 6, 1), new Effect(starPoints: 4))
        }
    );
    public Player player3 = new Player(
        "Player3",
        new Monster("Monster3", 5, 10),
        14,
        new List<CardDetails>()
        {
            new CardDetails(new PowerCard("Skycraper", 6, 1), new Effect(starPoints: 4)),
            new CardDetails(new PowerCard("Corner Store", 3, 1), new Effect(starPoints: 1))
        }
    );
    public Player player4 = new Player(
        "Player4",
        new Monster("Monster4", 5, 10),
        14,
        new List<CardDetails>()
        {
            new CardDetails(new PowerCard("Heal", 3, 1), new Effect(heartPoints: 2)),
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
    public Player player6 = new Player(
        "Player6",
        new Monster("Monster6", 5, 10),
        14,
        new List<CardDetails>()
        {
            new CardDetails(
                new PowerCard("Jet Fighters", 5, 1),
                new Effect(starPoints: 5, damagePoints: 4)
            )
        }
    );

    public GamePayload FirstGame()
    {
        List<Player> players = new List<Player>() { player1, player2, player3, player4 };
        GamePayload game = new GamePayload(
            null,
            new TokyoBoard(),
            new TokyoBoardProcessor(),
            player1.Name
        );
        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        return game;
    }

    public GamePayload SecondGame()
    {
        List<Player> players = new List<Player>() { player1, player2, player3, player4 };
        GamePayload game = new GamePayload(
            null,
            new TokyoBoard(),
            new TokyoBoardProcessor(),
            player2.Name
        );
        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        return game;
    }

    public GamePayload ThirdGame()
    {
        List<Player> players = new List<Player>() { player1, player2, player3, player4 };
        GamePayload game = new GamePayload(
            null,
            new TokyoBoard(),
            new TokyoBoardProcessor(),
            player3.Name
        );
        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        return game;
    }

    public GamePayload FourthGame()
    {
        List<Player> players = new List<Player>() { player1, player2, player3, player4 };
        GamePayload game = new GamePayload(
            null,
            new TokyoBoard(),
            new TokyoBoardProcessor(),
            player4.Name
        );
        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        return game;
    }

    public GamePayload FifthGame()
    {
        List<Player> players = new List<Player>() { player2, player3, player4, player5 };
        GamePayload game = new GamePayload(
            null,
            new TokyoBoard(),
            new TokyoBoardProcessor(),
            player5.Name
        );
        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        return game;
    }

    public GamePayload SixthGame()
    {
        List<Player> players = new List<Player>() { player6, player3, player4, player5 };
        GamePayload game = new GamePayload(
            null,
            new TokyoBoard(),
            new TokyoBoardProcessor(),
            player6.Name
        );
        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        return game;
    }
}

public class PowerCardsAnalizerTest
{
    private readonly ExecutePowerCard Analizer = new ExecutePowerCard();

    [Fact]
    public void ItShouldUpdateVictoryPoints()
    {
        NewGame newGame = new NewGame();
        GamePayload game = newGame.FirstGame();
        Analizer.Execute(game); //5victorypoints +1 star
        Player activePlayer = game.Board?.OutsideTokyo!.Find(
            player => player.Name == game.ActivePlayerName
        )!;
        Assert.Equal(6, activePlayer.MyMonster.VictoryPoints);

        game = newGame.SecondGame();
        Analizer.Execute(game); //5victorypoints + 4 stars
        activePlayer = game.Board?.OutsideTokyo!.Find(
            player => player.Name == game.ActivePlayerName
        )!;
        Assert.Equal(9, activePlayer.MyMonster.VictoryPoints);

        game = newGame.ThirdGame();
        Analizer.Execute(game); // 5victorypoints + 4 stars + 1 star
        activePlayer = game.Board?.OutsideTokyo!.Find(
            player => player.Name == game.ActivePlayerName
        )!;
        Assert.Equal(10, activePlayer.MyMonster.VictoryPoints);
    }

    [Fact]
    public void ItShouldUpdateLifePoints()
    {
        NewGame newGame = new NewGame();
        GamePayload game = newGame.FourthGame();
        Analizer.Execute(game); //5victorypoints +1 star
        Player activePlayer = game.Board?.OutsideTokyo!.Find(
            player => player.Name == game.ActivePlayerName
        )!;
        Assert.Equal(12, activePlayer.MyMonster.LifePoints); //lifepoints: 10, heartpoints:2
    }

    [Fact]
    public void ItShouldUpdateEnergyPoints()
    {
        NewGame newGame = new NewGame();
        GamePayload game = newGame.FifthGame();
        Analizer.Execute(game); //5victorypoints +1 star
        Player activePlayer = game.Board?.OutsideTokyo!.Find(
            player => player.Name == game.ActivePlayerName
        )!;
        Assert.Equal(23, activePlayer.EnergyCubes); //energycubes: 14, energypoints:9
    }

    [Fact]
    public void ItShouldUpdateExecuteDamage()
    {
        NewGame newGame = new NewGame();
        GamePayload game = newGame.SixthGame();
        Analizer.Execute(game); //5victorypoints + starPoints: 5, damagePoints: 4
        Player activePlayer = game.Board?.OutsideTokyo!.Find(
            player => player.Name == game.ActivePlayerName
        )!;
        Assert.Equal(10, activePlayer.MyMonster.VictoryPoints); //energycubes: 14, energypoints:9

        Assert.Equal(10, game.Board?.OutsideTokyo![0].MyMonster.LifePoints); //active player not affected by damage
        Assert.Equal(6, game.Board?.OutsideTokyo![1].MyMonster.LifePoints); //player affected by damage
        Assert.Equal(6, game.Board?.OutsideTokyo![2].MyMonster.LifePoints); //player affected by damage
        Assert.Equal(6, game.Board?.OutsideTokyo![3].MyMonster.LifePoints); //player affected by damage
    }
}
