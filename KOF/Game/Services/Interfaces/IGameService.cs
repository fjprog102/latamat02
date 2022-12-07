using KOT.Models;
using KOT.Models.Abstracts;

namespace KOT.Services.Interfaces;

public interface IGameService
{
    public IEnumerable<Game> Read(GamePayload data);
    public IEnumerable<Game> Create(GamePayload data);
    public IEnumerable<Game> Delete(GamePayload data);
    public IEnumerable<Game> Update(GamePayload data);
}
