using KOF.Models;
using KOF.Models.Abstracts;

namespace KOF.Services.Interfaces;

public interface IDataService
{
    public IEnumerable<Element> Read(DataHolder data);
    public IEnumerable<Element> Create(DataHolder data);
    public IEnumerable<Element> Delete(DataHolder data);
    public IEnumerable<Element> Update(DataHolder data);
}
