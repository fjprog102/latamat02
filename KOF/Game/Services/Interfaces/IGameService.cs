using KOT.Models;
using KOT.Models.Abstracts;

namespace KOT.Services.Interfaces;

public interface IGameService
{
    public IEnumerable<Element> Read(GamePayload data);
    public IEnumerable<Element> Create(GamePayload data);
    public IEnumerable<Element> Delete(GamePayload data);
    public IEnumerable<Element> Update(GamePayload data);
}
