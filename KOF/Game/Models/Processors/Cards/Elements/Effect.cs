namespace KOT.Models.Processor;
using KOT.Models;
using KOT.Models.Abstracts;

public class Effect
{
    public int LifePoints { get; set; }
    public int VictoryPoints { get; set; }
    public int EnergyPoints { get; set; }

    public Effect(int heartPoints = 0,
                int starPoints = 0,
                int energyPoints = 0
    )
    {
        LifePoints = heartPoints;
        VictoryPoints = starPoints;
        EnergyPoints = energyPoints;
    }
}
