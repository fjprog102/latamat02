namespace KOT.Models.TestDeck;
using KOT.Services.Processors;
using KOT.Models;
public class PowerCardDeckTest
{
    [Fact]
    public void ShouldReturnAPowerCard()
    {
        PowerCardDeck powerCardDeck = new PowerCardDeck();
        Assert.IsType<PowerCard>(powerCardDeck.Deck.First());
    }

}
