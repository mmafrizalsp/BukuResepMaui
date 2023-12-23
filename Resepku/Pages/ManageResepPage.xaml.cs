using Resepku.Services;

namespace Resepku;

public partial class ManageResepPage : ContentPage
{
	public MakananModels _currentResep { get; set; }
	public ManageResepPage(MakananModels tempdata = null)
	{
		InitializeComponent();
		_currentResep = tempdata == null ? new() : tempdata;

        this.BindingContext = _currentResep;
	}

    async void btn_simpan_Clicked(object sender, EventArgs e)
    {
        _currentResep.TglDitambahkan = DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
		input_date.IsVisible = true;
        try
		{
			if (string.IsNullOrEmpty(_currentResep.Id))
			{
				_currentResep.Id = Guid.NewGuid().ToString().Replace("-", "");
			}
            var proses_simpan = await App.SQLiteDb.SaveMakanan(_currentResep);
			if (proses_simpan == 1)
			{
                await DisplayAlert("Informasi", "Data berhasil disimpan", "OK");
				await Navigation.PopAsync();
            }
			else
			{
                throw new Exception("Gagal menyimpan data");
            }
		}
		catch (Exception en)
		{
			await DisplayAlert("Error", en.Message, "OK");
		}
    }

    async void FrameGambarTapped(object sender, TappedEventArgs e)
    {
		await AmbilGambar();
    }

    private async Task AmbilGambar()
	{
		try
		{
			var gambar = await MediaPicker.PickPhotoAsync();
			await LoadGambar(gambar);
            Console.WriteLine($"CapturePhotoAsync COMPLETED: {_currentResep.Photo}");
        }
        catch (FeatureNotSupportedException fnsEx)
        {
            // Feature is not supported on the device  
        }
        catch (PermissionException pEx)
        {
            // Permissions not granted  
        }
        catch (Exception ex)
        {
            Console.WriteLine($"CapturePhotoAsync THREW: {ex.Message}");
        }
    }

	private async Task LoadGambar(FileResult konten)
	{
		try
		{
			if (konten == null)
			{
				_currentResep.Photo = string.Empty;
				return;
			}

			var berkas = Path.Combine(FileSystem.AppDataDirectory, konten.FileName);
            using (Stream stream = await konten.OpenReadAsync())
            using (var newStream = File.OpenWrite(berkas))
            {
                await stream.CopyToAsync(newStream);
            }
			_currentResep.Photo = berkas;
			prev_gambar.Source = berkas;
        }
		catch (Exception en)
		{
			throw new Exception(en.Message);
		}
	}
}