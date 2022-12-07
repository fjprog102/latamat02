using KOT.Models.Processor;

namespace KOT.Models.Test;

public class CardDetailsTest
{
    [Fact]
    public void ShouldReturnCardAndDefaultAttributes()
    {
        PowerCard myPowerCard = new PowerCard("powercard1", 2, 0);
        Effect powerCardEffect = new Effect();
        CardDetails myCardDetails = new CardDetails(myPowerCard, powerCardEffect);

        Assert.Equal(myPowerCard.Name, myCardDetails.powerCard.Name);
        Assert.Equal(myPowerCard.Cost, myCardDetails.powerCard.Cost);
        Assert.Equal(myPowerCard.Type, myCardDetails.powerCard.Type);
        Assert.Equal(powerCardEffect.LifePoints, myCardDetails.effect.LifePoints);
        Assert.Equal(powerCardEffect.VictoryPoints, myCardDetails.effect.VictoryPoints);
        Assert.Equal(powerCardEffect.EnergyPoints, myCardDetails.effect.EnergyPoints);
    }
    [Fact]
    public void ShouldReturnCardAndAttributes()
    {
        PowerCard myPowerCard = new PowerCard("Jet Fighters", 3, 0);
        Effect powerCardEffect = new Effect(starPoints: 5);
        CardDetails myCardDetails = new CardDetails(myPowerCard, powerCardEffect);

        Assert.Equal(myPowerCard.Name, myCardDetails.powerCard.Name);
        Assert.Equal(myPowerCard.Cost, myCardDetails.powerCard.Cost);
        Assert.Equal(myPowerCard.Type, myCardDetails.powerCard.Type);
        Assert.Equal(powerCardEffect.LifePoints, myCardDetails.effect.LifePoints);
        Assert.Equal(powerCardEffect.VictoryPoints, myCardDetails.effect.VictoryPoints);
        Assert.Equal(powerCardEffect.EnergyPoints, myCardDetails.effect.EnergyPoints);
    }
}
