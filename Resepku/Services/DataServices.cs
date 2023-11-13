using System;
using LiteDB;

namespace Resepku.Services;


public class DataServices : IDataServices
{
	private const string _dbName = "makananku";
	private string GetDbPath => Path.Combine(FileSystem.Current.AppDataDirectory, $"{_dbName}.db");
	private readonly LiteDatabase _initDb = null;

	public DataServices()
	{
		_initDb = new LiteDatabase(GetDbPath);
	}

	public async Task<IEnumerable<MakananModels>> DaftarMenu()
	{
		var lstItem = new List<MakananModels>();
		try
		{
			var collection = _initDb.GetCollection<MakananModels>(_dbName);
			lstItem = collection.Query().ToList();
		}
		catch (Exception en)
		{
			throw new Exception(en.Message);
		}
        return await Task.FromResult(lstItem);
	}

	public async Task<bool> SaveItem(MakananModels context)
	{
		var hasil = false;
		try
		{
			var collection = _initDb.GetCollection<MakananModels>(_dbName);
			collection.Insert(context);
			collection.EnsureIndex(x => x.Id);
		}
		catch (Exception en)
		{
			throw new Exception(en.Message);
		}
		return await Task.FromResult(hasil);
	}

    public async Task<bool> DeleteItem(MakananModels context)
    {
        var hasil = false;
        try
        {
            var collection = _initDb.GetCollection<MakananModels>(_dbName);
            collection.Delete(context.Id);
            collection.EnsureIndex(x => x.Id);
        }
        catch (Exception en)
        {
            throw new Exception(en.Message);
        }
        return await Task.FromResult(hasil);
    }

    public async Task<bool> UpdateItem(MakananModels context)
    {
        var hasil = false;
        try
        {
            var collection = _initDb.GetCollection<MakananModels>(_dbName);
			collection.Update(context);
            collection.EnsureIndex(x => x.Id);
        }
        catch (Exception en)
        {
            throw new Exception(en.Message);
        }
        return await Task.FromResult(hasil);
    }
}