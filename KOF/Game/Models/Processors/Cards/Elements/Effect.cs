namespace KOT.Models.Processor;
using KOT.Models;
using KOT.Models.Abstracts;

public class Effect
{
    public int HeartPoints { get; set; }
    public int StarPoints { get; set; }
    public int EnergyPoints { get; set; }
    public int DamagePoints { get; set; }
    public Effect(int heartPoints = 0,
                int starPoints = 0,
                int energyPoints = 0,
                int damagePoints = 0)
    {
        HeartPoints = heartPoints;
        StarPoints = starPoints;
        EnergyPoints = energyPoints;
        DamagePoints = damagePoints;
    }
}
