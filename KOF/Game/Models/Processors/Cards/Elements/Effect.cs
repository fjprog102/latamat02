namespace KOT.Models.Processor;
using KOT.Models.Abstracts;
using KOT.Models;

public class Effect
{
    public int? HeartPoints { get; set; } 
    public int? CostReduction { get; set; } 
    public int? StarPoints { get; set; }
    public int? EnergyPoints { get; set; } 
    public int? DamagePoints { get; set; }
    public Effect(int heartPoints = 0, 
                int costReduction =0, 
                int starPoints = 0,
                int energyPoints = 0,
                int damagePoints = 0)
    {
        HeartPoints = heartPoints;
        CostReduction = costReduction;
        StarPoints = starPoints;
        EnergyPoints = energyPoints;
        DamagePoints = damagePoints;
    }
}
