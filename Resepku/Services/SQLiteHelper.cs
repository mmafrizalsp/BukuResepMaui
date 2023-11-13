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
            else
            {
                item.Photo = Path.GetFileName(item.Photo);
            }
        }
        return data;
    }

    public async Task<int> SaveMakanan(MakananModels context)
    {
        try
        {
            var cekdatalama = (await LoadMakanan()).FirstOrDefault(x => x.Id == context.Id);
            if (cekdatalama != null)
            {
                return await db.UpdateAsync(context);
            }
            else
            {
                return await db.InsertAsync(context);
            }
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