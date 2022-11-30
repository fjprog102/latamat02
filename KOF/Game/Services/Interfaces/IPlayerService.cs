namespace KOT.Services.Interfaces;

using KOT.Models.Abstracts;

public interface IPlayerService
{
    public IEnumerable<Element> Read(DataHolder data);
    public IEnumerable<Element> Create(DataHolder data);
    public IEnumerable<Element> Delete(DataHolder data);
    public IEnumerable<Element> Update(DataHolder data);
}
