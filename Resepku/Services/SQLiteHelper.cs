using System;
using SQLite;

namespace Resepku.Services;

public class SQLiteHelper
{
    SQLiteAsyncConnection db;
    public SQLiteHelper(string dbPath)
    {
        db = new SQLiteAsyncConnection(dbPath);
        db.CreateTableAsync<MakananModels>().Wait();
    }

    public async Task<List<MakananModels>> LoadMakanan()
    {
        var data = await db.Table<MakananModels>().ToListAsync();
        foreach (var item in data)
        {
            if (string.IsNullOrEmpty(item.Photo))
            {
                item.Photo = "dotnet_bot";
            }
        }
        return data;
    }

    public async Task<bool> CheckMakananExists(string makananId)
    {
        var data = await db.Table<MakananModels>().FirstOrDefaultAsync(x => x.Id == makananId);
        if (data != null)
            return true;
        else
            return false;
    }

    public async Task<int> SaveMakanan(MakananModels context)
    {
        try
        {
            var cekdatalama = await CheckMakananExists(context.Id);
            return cekdatalama ? await db.UpdateAsync(context) : await db.InsertAsync(context);
        }
        catch (Exception en)
        {
            throw new Exception(en.Message);
        }
    }

    public async Task<int> DeleteMakanan(MakananModels context)
    {
        try
        {
            return await db.DeleteAsync(context);
        }
        catch (Exception en)
        {
            throw new Exception(en.Message);
        }
    }
}