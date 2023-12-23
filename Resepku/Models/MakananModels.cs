using Resepku.Services;

namespace Resepku;

public class MakananModels
{
	public string Id { get; set; }
	public string Nama { get; set; }
	public string Deskripsi { get; set; }
	public string Photo { get; set; } = "dotnet_bot";
    public string TglDitambahkan { get; set; }
    public string TglDitambahkanId
	{
		get
		{
			return TglDitambahkan.ToTanggalIndoFormat();
		}
	}
}