namespace KOT.Models.Test;
using KOT.Models.Processor;

public class EffectTest
{
    [Fact]
    public void ShouldReturnDefaultAttributes()
    {
        Effect effect = new Effect();
        Assert.Equal(0, effect.HeartPoints);
        Assert.Equal(0, effect.CostReduction);
        Assert.Equal(0, effect.StarPoints);
        Assert.Equal(0, effect.EnergyPoints);
        Assert.Equal(0, effect.DamagePoints);
    }

    [Fact]
    public void ShouldReturnAttributes()
    {
        Effect effect = new Effect(heartPoints: 2, starPoints: 7, damagePoints:3);
        Assert.Equal(2, effect.HeartPoints);
        Assert.Equal(0, effect.CostReduction);
        Assert.Equal(7, effect.StarPoints);
        Assert.Equal(0, effect.EnergyPoints);
        Assert.Equal(3, effect.DamagePoints);
    }
}
