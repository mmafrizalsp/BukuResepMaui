namespace Resepku;

public class MakananModels
{
	public string Id => Guid.NewGuid().ToString().Replace("-", "");
	public string Nama { get; set; }
	public string Deskripsi { get; set; }
	public string Photo { get; set; } = "dotnet_bot";
    public string TglDitambahkan { get; set; }
}