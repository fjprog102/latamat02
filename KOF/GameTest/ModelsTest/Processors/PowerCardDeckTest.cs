namespace KOT.Models.Test;

using KOT.Models.Processor;
using KOT.Services.Processors;

public class PowerCardDeckTest
{
    [Fact]
    public void ShouldReturnCardDetails()
    {
        PowerCardDeck powerCardDeck = new PowerCardDeck();
        Assert.IsType<CardDetails>(powerCardDeck.Deck.First());
    }

    [Fact]
    public void ShouldReturnEffectsForAPowerCard()
    {
        PowerCardDeck powerCardDeck = new PowerCardDeck();
        var heartPoints =
            from cardDetails in powerCardDeck.Deck
            where cardDetails.powerCard.Name == "Heal"
            select cardDetails.effect.HeartPoints;
        Assert.Equal(2, heartPoints.ToList()[0]);
    }

    [Fact]
    public void ShouldReturnEffectsForAGivenPowerCardName()
    {
        PowerCardDeck powerCardDeck = new PowerCardDeck();
        Effect powerCardEffect = powerCardDeck.GetEffect("Heal");
        Assert.Equal(2, powerCardEffect.HeartPoints);

        Effect powerCardEffect1 = powerCardDeck.GetEffect("Jet Fighters");
        Assert.Equal(5, powerCardEffect1.StarPoints);
        Assert.Equal(4, powerCardEffect1.DamagePoints);
    }
}
