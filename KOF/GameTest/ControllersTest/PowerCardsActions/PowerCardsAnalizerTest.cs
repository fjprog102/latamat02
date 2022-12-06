namespace KOT.Controllers.PowerCardsActions.Test;
using KOT.Models;
using KOT.Models.Processor;

public class PowerCardsAnalizerTest
{
    private readonly PowerCardsAnalizer Analizer = new PowerCardsAnalizer();
    private readonly Monster monster1 = new Monster("Monster1", 5, 10);
    List<PowerCard> powerCards = new List<PowerCard>()
    {
        new PowerCard("Corner Store", 3, 1),
        new PowerCard("Skycraper", 6, 1),
        new PowerCard("Heal", 3, 1),
        new PowerCard("Energize", 8, 1),
        new PowerCard("Apartament Building", 5, 1),
        new PowerCard("Jet Fighters", 5, 1)
    };

    [Fact]
    public void ItShouldUpdateVictoryPoints()
    {
        Player player1 = new Player(
            "Player1",
            monster1,
            14,
            new List<CardDetails>() {  }
        );
        Player player2 = new Player(
            "Player2",
            new Monster("Monster2", 5, 10),
            14,
            new List<CardDetails>() {  }
        );
        Player player3 = new Player(
            "Player3",
            new Monster("Monster3", 5, 10),
            14,
            new List<CardDetails>() {  }
        );
        Analizer.ResolveCards(player1); //5victorypoints +1 star
        Assert.Equal(6, player1.MyMonster.VictoryPoints);

        Analizer.ResolveCards(player2); //5victorypoints + 4 stars
        Assert.Equal(9, player2.MyMonster.VictoryPoints);

        Analizer.ResolveCards(player3); //5victorypoints + 4 stars + 1 star
        Assert.Equal(10, player3.MyMonster.VictoryPoints);
    }
}
