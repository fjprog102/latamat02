using KOF.Models;

namespace KOF.Services.Interfaces;

public interface IDataService
{
    public IEnumerator<DataHolder> Read(string? id = null);
    public ServiceResponse<DataHolder> Create(DataHolder data);
    public ServiceResponse<DataHolder> Delete(DataHolder data);
    public ServiceResponse<DataHolder> Update(DataHolder data);
}
