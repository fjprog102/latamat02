using KOF.Models;

namespace KOF.Services.Interfaces;

public interface IPowerCard
{
    public IEnumerable<PowerCard> GetMethod(string? id = null);
    public IEnumerable<PowerCard> PostMethod(string? name, int cost, int type);
}
