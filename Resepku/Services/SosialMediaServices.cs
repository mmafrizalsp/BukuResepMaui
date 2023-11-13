using System;
using Resepku.Models;

namespace Resepku.Services;

public class SosialMediaServices
{
	public async Task<List<SosialMediaModels>> ListSosmed()
	{
        var lstItem = new List<SosialMediaModels>
        {
            new()
            {
                Id = 1,
                Nama = "GitHub",
                Photo = "https://cdn-icons-png.flaticon.com/512/2111/2111432.png",
                Url = "https://github.com/mmafrizalsp"
            },
            new()
            {
                Id = 2,
                Nama = "email",
                Photo = "https://cdn-icons-png.flaticon.com/512/2549/2549872.png",
                Url = "mailto:ferryafrizal@outlook.co.id"
            },
            new()
            {
                Id = 3,
                Nama = "LinkeIn",
                Photo = "https://cdn-icons-png.flaticon.com/512/3536/3536505.png",
                Url = "https://www.linkedin.com/in/afrizzzzal"
            },
            new()
            {
                Id = 4,
                Nama = "Websites",
                Photo = "https://cdn-icons-png.flaticon.com/512/576/576204.png",
                Url = "http://corikat.my.id"
            }
        };
        return await Task.FromResult(lstItem);
	}
}