namespace KOT.Models.Processor;
using KOT.Models.Abstracts;
using KOT.Models;

public class Effect
{
    public int? Heart { get; set; } 
    public int? CostReduction { get; set; } 
    public int? Star { get; set; }
    public int? Energy { get; set; } 
    public int? Damage { get; set; }
    public Effect(int heart = 0, 
                int costReduction =0, 
                int star = 0,
                int energy = 0,
                int damage = 0)
    {
        Heart = heart;
        CostReduction = costReduction;
        Star = star;
        Energy = energy;
        Damage = damage;
    }
}
