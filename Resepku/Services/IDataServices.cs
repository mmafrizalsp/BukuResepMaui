namespace Resepku.Services;

public interface IDataServices
{
    Task<IEnumerable<MakananModels>> DaftarMenu();
    Task<bool> SaveItem(MakananModels context);
    Task<bool> DeleteItem(MakananModels context);
    Task<bool> UpdateItem(MakananModels context);
}