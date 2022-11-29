namespace KOT.Services.Interfaces;

using KOT.Models;
using KOT.Models.Abstracts;

public interface IMonsterService
{
    public IEnumerable<Element> Read(MonsterPayload data);
    public IEnumerable<Element> Create(MonsterPayload data);
    public IEnumerable<Element> Delete(MonsterPayload data);
    public IEnumerable<Element> Update(MonsterPayload data);
}
