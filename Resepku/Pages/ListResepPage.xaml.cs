namespace Resepku;

public partial class ListResepPage : ContentView
{
    public ListResepPage()
    {
        InitializeComponent();
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

    private async void list_menu_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        var data = e.CurrentSelection.FirstOrDefault() as MakananModels;
        if (data != null)
        {
            var target = new ManageResepPage()
                        {
                        _currentResep = data
                        };
            await Navigation.PushAsync(target);
        }
    }

    async void btn_add_new_Clicked(object sender, EventArgs e)
    {
        await Navigation.PushAsync(new ManageResepPage());
    }
}