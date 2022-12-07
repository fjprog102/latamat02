namespace KOT.Controllers.Test;

using KOT.Controllers;
using KOT.Models;
using KOT.Models.Processor;

public class DiceAnalyzerTest
{
    private readonly DiceAnalyzer Analyzer = new DiceAnalyzer();

    [Fact]
    public void ItShouldOnlyExecuteGainLifeActionAndUpdatePlayerOneLifePoints()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 2));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 7));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 6));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 9));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerOne.Name);
        string[] oneHeart = { "one", "two", "heart", "one", "two", "three" };

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.Equal(10, playerOne.MyMonster!.VictoryPoints);
        Assert.Equal(2, playerOne.MyMonster!.LifePoints);
        Assert.Equal(0, playerOne.EnergyCubes);
        Analyzer.ResolveDice(oneHeart, game);
        Assert.Equal(10, playerOne.MyMonster!.VictoryPoints);
        Assert.Equal(3, playerOne.MyMonster!.LifePoints);
        Assert.Equal(0, playerOne.EnergyCubes);
        Assert.Equal(7, playerTwo.MyMonster!.LifePoints);
        Assert.Equal(6, playerThree.MyMonster!.LifePoints);
        Assert.Equal(9, playerFour.MyMonster!.LifePoints);

    }

    [Fact]
    public void ItShouldOnlyExecuteGainVictoryActionAndUpdatePlayerTwoVictoryPoints()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 2));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerTwo.Name);
        string[] threeOnes = { "one", "one", "three", "one", "two", "one" };

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.Equal(10, playerTwo.MyMonster!.VictoryPoints);
        Assert.Equal(10, playerTwo.MyMonster!.LifePoints);
        Assert.Equal(0, playerTwo.EnergyCubes);
        Analyzer.ResolveDice(threeOnes, game);
        Assert.Equal(12, playerTwo.MyMonster!.VictoryPoints);
        Assert.Equal(10, playerTwo.MyMonster!.LifePoints);
        Assert.Equal(0, playerTwo.EnergyCubes);
        Assert.Equal(10, playerOne.MyMonster!.VictoryPoints);
        Assert.Equal(10, playerThree.MyMonster!.VictoryPoints);
        Assert.Equal(10, playerFour.MyMonster!.VictoryPoints);
    }

    [Fact]
    public void ItShouldOnlyExecuteGainEnergyActionAndUpdatePlayerThreeEnergyCubes()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 2));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerThree.Name);
        string[] fourEnergy = { "energy", "one", "energy", "one", "energy", "energy" };

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);

        Assert.Equal(10, playerThree.MyMonster!.VictoryPoints);
        Assert.Equal(10, playerThree.MyMonster!.LifePoints);
        Assert.Equal(0, playerThree.EnergyCubes);
        Analyzer.ResolveDice(fourEnergy, game);
        Assert.Equal(10, playerThree.MyMonster!.VictoryPoints);
        Assert.Equal(10, playerThree.MyMonster!.LifePoints);
        Assert.Equal(4, playerThree.EnergyCubes);
        Assert.Equal(0, playerOne.EnergyCubes);
        Assert.Equal(0, playerTwo.EnergyCubes);
        Assert.Equal(0, playerFour.EnergyCubes);
    }

    [Fact]
    public void ItShouldExecuteAllActionsAndUpdatePlayerFourAttributesAndSmashRestOfThePlayers()
    {
        Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 2));
        Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
        Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
        Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 9));
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), new PowerCardDeck(), playerFour.Name);
        string[] allActions = { "two", "two", "energy", "two", "heart", "smash" };

        game.BoardProcessor!.SetTokyoBoard(players, game.Board!);
        game.BoardProcessor.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoCity);
        game.BoardProcessor.ChangePlayerBoardPlace(playerTwo, game.Board.OutsideTokyo, game.Board.TokyoCity);
        game.BoardProcessor.ChangePlayerBoardPlace(player: playerThree, game.Board.OutsideTokyo, game.Board.TokyoCity);

        Assert.Equal(10, playerFour.MyMonster!.VictoryPoints);
        Assert.Equal(9, playerFour.MyMonster!.LifePoints);
        Assert.Equal(0, playerFour.EnergyCubes);
        Analyzer.ResolveDice(allActions, game);
        Assert.Equal(12, playerFour.MyMonster!.VictoryPoints);
        Assert.Equal(10, playerFour.MyMonster!.LifePoints);
        Assert.Equal(1, playerFour.EnergyCubes);

        Assert.Equal(1, playerOne.MyMonster!.LifePoints);
        Assert.Equal(9, playerTwo.MyMonster!.LifePoints);
        Assert.Equal(9, playerThree.MyMonster!.LifePoints);
    }
}
