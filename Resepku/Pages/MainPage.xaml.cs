namespace Resepku;

public partial class MainPage : ContentPage
{
	public MainPage()
	{
		InitializeComponent();
        Appearing += MainPage_Appearing;
	}

    private void MainPage_Appearing(object sender, EventArgs e)
    {
        LoadMasakan();
    }

    private async void LoadMasakan()
    {
        try
        {
            var load_data = await App.SQLiteDb.LoadMakanan();
            if (load_data != null)
            {
                list_menu.ItemsSource = load_data;
            }
        }
        catch (Exception en)
        {
            throw new Exception(en.Message);
        }
    }

    private void list_menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is MakananModels data)
        {
            Navigation.PushAsync(new DetailResepPage(data));
        }
    }

    async void btn_add_new_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageResepPage());
    }
}