namespace KOT.Controllers.Test;

using KOT.Controllers;
using KOT.Models;
using KOT.Models.Processor;

public class TurnTest
{
    private readonly Turn Turn = new Turn();

    [Fact]
    public void ItShouldHavePlayerActionsAndDicesAsAttributes()
    {
        Assert.NotNull(Turn.Dices);
        Assert.NotNull(Turn.Start);
        Assert.NotNull(Turn.Analyzer);
        Assert.NotNull(Turn.Move);
        Assert.NotNull(Turn.BuyCard);
        Assert.NotNull(Turn.End);
    }

    private readonly Player playerOne = new Player("Jose", new Monster("Gigazaur", 10, 9));
    private readonly Player playerTwo = new Player("Juan", new Monster("Gigazaur", 10, 10));
    private readonly Player playerThree = new Player("Adriel", new Monster("Gigazaur", 10, 10));
    private readonly Player playerFour = new Player("Jorge", new Monster("Gigazaur", 10, 10));
    private readonly Player playerFive = new Player("Valeria", new Monster("Gigazaur", 10, 10));

    [Fact]
    public void ItShouldExecutePlayerOneTurnAndNotAffectOtherPlayers()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), playerOne.Name, players);
        List<string> rolledDices = new List<string>() { "three", "three", "three", "smash", "heart", "energy" };

        game.BoardProcessor!.SetTokyoBoard(game.Players!, game.Board!);

        Turn.Play(game, rolledDices);

        // Player One actions:
        // Gains four VictoryPoints (+3 rolledDices, +1 for entering in Tokyo)
        Assert.Equal(14, playerOne.MyMonster.VictoryPoints);
        // Gains one EnergyCubes (rolledDices)
        Assert.Equal(1, playerOne.EnergyCubes);
        // Gains one LifePoint (rolledDices) for being OutsideTokyo
        Assert.Equal(10, playerOne.MyMonster.LifePoints);
        // Doesn't smash other monsters (1 points for rolledDices) for being in the same place
        Assert.Equal(10, playerTwo.MyMonster.LifePoints);
        Assert.Equal(10, playerThree.MyMonster.LifePoints);
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        Assert.Equal(10, playerFive.MyMonster.LifePoints);
        // Enters in Tokyo
        Assert.True(game.Board!.TokyoCity.Exists(player => player.Name == playerOne.Name));
        // Ends turn changing activePlayer (playerTwo)
        Assert.Equal("Juan", game.ActivePlayerName);
    }

    [Fact]
    public void ItShouldExecutePlayerOneTurnAndAffectOtherPlayers()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), playerOne.Name, players);
        List<string> rolledDices = new List<string>() { "two", "two", "two", "smash", "heart", "energy" };

        game.BoardProcessor!.SetTokyoBoard(game.Players!, game.Board!);
        // Change PlayerOne place to affect other players
        game.BoardProcessor!.ChangePlayerBoardPlace(playerOne, game.Board!.OutsideTokyo, game.Board.TokyoCity);

        Turn.Play(game, rolledDices);

        // Player One actions:
        // Gains 4 VictoryPoints (2 points for starting turn in Tokyo + 2 points of rolledDices)
        Assert.Equal(14, playerOne.MyMonster.VictoryPoints);
        // Gains One EnergyCubes (rolledDices)
        Assert.Equal(1, playerOne.EnergyCubes);
        // Doesn't gain 1 LifePoint (rolledDices) for being in Tokyo
        Assert.Equal(9, playerOne.MyMonster.LifePoints);
        // Smash other monsters (1 points for rolledDices) for being in different places
        Assert.Equal(9, playerTwo.MyMonster.LifePoints);
        Assert.Equal(9, playerThree.MyMonster.LifePoints);
        Assert.Equal(9, playerFour.MyMonster.LifePoints);
        Assert.Equal(9, playerFive.MyMonster.LifePoints);
        // Stays in Tokyo
        Assert.True(game.Board.TokyoCity.Exists(player => player.Name == playerOne.Name));
        // Ends turn changing activePlayer (playerTwo)
        Assert.Equal("Juan", game.ActivePlayerName);
    }

    [Fact]
    public void ItShouldExecuteATurnForEachPlayer()
    {
        List<Player> players = new List<Player>() { playerOne, playerTwo, playerThree, playerFour, playerFive };
        GamePayload game = new GamePayload(null, new TokyoBoard(), new TokyoBoardProcessor(), playerOne.Name, players);
        List<string> rolledDices = new List<string>() { "two", "two", "two", "smash", "heart", "energy" };

        game.BoardProcessor!.SetTokyoBoard(game.Players!, game.Board!);

        Turn.Play(game, rolledDices);

        // Player One actions:
        // Gains 4 VictoryPoints (+2 rolledDices, +1 for entering in Tokyo)
        Assert.Equal(13, playerOne.MyMonster.VictoryPoints);
        // Gains 1 EnergyCubes (rolledDices)
        Assert.Equal(1, playerOne.EnergyCubes);
        // Gains 1 LifePoint (rolledDices) for being OutsideTokyo
        Assert.Equal(10, playerOne.MyMonster.LifePoints);
        // Doesn't smash other monsters (1 points for rolledDices) for being in the same place
        Assert.Equal(10, playerTwo.MyMonster.LifePoints);
        Assert.Equal(10, playerThree.MyMonster.LifePoints);
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        Assert.Equal(10, playerFive.MyMonster.LifePoints);
        // Enters in Tokyo
        Assert.True(game.Board!.TokyoCity.Exists(player => player.Name == playerOne.Name));
        // Ends turn changing activePlayer (playerTwo)
        Assert.Equal("Juan", game.ActivePlayerName);

        rolledDices = new List<string>() { "smash", "smash", "energy", "heart", "heart", "energy" };

        Turn.Play(game, rolledDices);

        // Player Two actions:
        // Gains 1 VictoryPoints for entering Tokyo
        Assert.Equal(11, playerTwo.MyMonster.VictoryPoints);
        // Gains 2 EnergyCubes (rolledDices)
        Assert.Equal(2, playerTwo.EnergyCubes);
        // No gains of LifePoints (it has already the maximum)
        Assert.Equal(10, playerTwo.MyMonster.LifePoints);
        // Smash monsters (2 points for rolledDices) in Tokyo (onlyPlayerone) for being OutsideTokyo
        Assert.Equal(8, playerOne.MyMonster.LifePoints);
        Assert.Equal(10, playerThree.MyMonster.LifePoints);
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        Assert.Equal(10, playerFive.MyMonster.LifePoints);
        // Enters in TokyoBay
        Assert.True(game.Board!.TokyoBay!.Exists(player => player.Name == playerTwo.Name));
        // Ends turn changing activePlayer (playerThree)
        Assert.Equal("Adriel", game.ActivePlayerName);

        rolledDices = new List<string>() { "three", "three", "smash", "three", "energy", "three" };

        Turn.Play(game, rolledDices);

        // Player Three actions:
        // Gains 4 VictoryPoints (3 + 1)
        Assert.Equal(15, playerThree.MyMonster.VictoryPoints);
        // Gains 1 EnergyCubes (rolledDices)
        Assert.Equal(1, playerThree.EnergyCubes);
        // No gains of LifePoints
        Assert.Equal(10, playerThree.MyMonster.LifePoints);
        // Smash monsters (1 points for rolledDices) in Tokyo (PlayerOne and PlayerTwo) for being OutsideTokyo
        Assert.Equal(7, playerOne.MyMonster.LifePoints);
        Assert.Equal(9, playerTwo.MyMonster.LifePoints);
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        Assert.Equal(10, playerFive.MyMonster.LifePoints);
        // Enters in TokyoBay
        Assert.True(game.Board!.TokyoBay!.Exists(player => player.Name == playerThree.Name));
        // Ends turn changing activePlayer (playerFour)
        Assert.Equal("Jorge", game.ActivePlayerName);

        rolledDices = new List<string>() { "energy", "energy", "one", "one", "one", "heart" };

        Turn.Play(game, rolledDices);

        // Player Four actions:
        // Gains 1 VictoryPoints (rolledDices)
        Assert.Equal(11, playerFour.MyMonster.VictoryPoints);
        // Gains 2 EnergyCubes (rolledDices)
        Assert.Equal(2, playerFour.EnergyCubes);
        // No gains of LifePoints (it has already the maximum)
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        // Doesn't smash monsters
        Assert.Equal(7, playerOne.MyMonster.LifePoints);
        Assert.Equal(9, playerTwo.MyMonster.LifePoints);
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        Assert.Equal(10, playerFive.MyMonster.LifePoints);
        // It doesn't enter in Tokyo because he didn't smash any monster
        Assert.True(game.Board!.OutsideTokyo!.Exists(player => player.Name == playerFour.Name));
        // Ends turn changing activePlayer (playerFour)
        Assert.Equal("Valeria", game.ActivePlayerName);

        rolledDices = new List<string>() { "smash", "smash", "smash", "smash", "energy", "heart" };

        Turn.Play(game, rolledDices);

        // Player Five actions:
        // Gains 1 EnergyCubes (rolledDices)
        Assert.Equal(1, playerFive.EnergyCubes);
        // No gains of LifePoints (it has already the maximum)
        Assert.Equal(10, playerFive.MyMonster.LifePoints);
        // Smash monsters (4 points for rolledDices) in Tokyo (PlayerOne, PlayerTwo and PlayerThree) for being OutsideTokyo
        Assert.Equal(3, playerOne.MyMonster.LifePoints);
        Assert.Equal(5, playerTwo.MyMonster.LifePoints);
        Assert.Equal(6, playerThree.MyMonster.LifePoints);
        Assert.Equal(10, playerFour.MyMonster.LifePoints);
        // Enters in Tokyo
        Assert.True(game.Board!.TokyoBay!.Exists(player => player.Name == playerFive.Name));
        // Gains 1 VictoryPoints for entering Tokyo
        Assert.Equal(11, playerFive.MyMonster.VictoryPoints);
        // Ends turn changing activePlayer (playerFour)
        Assert.Equal("Jose", game.ActivePlayerName);
    }
}
