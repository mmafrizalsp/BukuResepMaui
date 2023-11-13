using System;
using Microsoft.Maui.Controls;
using Resepku.Models;
using Resepku.Services;
namespace Resepku;

public partial class AboutMePage : ContentPage
{
	public AboutMePage()
	{
		InitializeComponent();
		imgsource.Source = "https://avatars.githubusercontent.com/u/10679395?s=400&u=b53db425d5efe55f5d33dd23dc0bc45899278a71&v=4";
        Appearing += AboutMePage_Appearing;
    }

    private void AboutMePage_Appearing(object sender, EventArgs e)
    {
        LoadSosmed();
    }

    private async void LoadSosmed()
    {
        var _info = new SosialMediaServices(); 
        try
        {
            var datanya = await _info.ListSosmed();
            if (datanya != null)
            {
                listsosmed.ItemsSource = datanya;
            }
        }
        catch (Exception en)
        {
            await DisplayAlert("Error", en.Message, "OK");
        }
    }

    void OpenTargetSosmedByUrl(Object sender, TappedEventArgs e)
    {
        
    }

    async void listsosmed_SelectionChanged(object sender, SelectionChangedEventArgs e)
    {
        if (e.CurrentSelection.FirstOrDefault() is SosialMediaModels datanya)
        {
            await Browser.Default.OpenAsync(new Uri(datanya.Url), BrowserLaunchMode.SystemPreferred);
        }
    }
}