namespace KOT.Services.Interfaces;

using KOT.Models.Abstracts;
using KOT.Models;
public interface IPlayerService
{
    public IEnumerable<Element> Read(PlayerPayload data);
    public IEnumerable<Element> Create(PlayerPayload data);
    public IEnumerable<Element> Delete(PlayerPayload data);
    public IEnumerable<Element> Update(PlayerPayload data);
}
