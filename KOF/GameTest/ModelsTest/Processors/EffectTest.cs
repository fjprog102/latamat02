namespace KOT.Models.Test;
using KOT.Models.Processor;

public class EffectTest
{
    [Fact]
    public void ShouldReturnDefaultAttributes()
    {
        Effect effect = new Effect();
        Assert.Equal(0, effect.LifePoints);
        Assert.Equal(0, effect.VictoryPoints);
        Assert.Equal(0, effect.EnergyPoints);
    }

    [Fact]
    public void ShouldReturnAttributes()
    {
        Effect effect = new Effect(heartPoints: 2, starPoints: 7);
        Assert.Equal(2, effect.LifePoints);
        Assert.Equal(7, effect.VictoryPoints);
        Assert.Equal(0, effect.EnergyPoints);
    }
}
