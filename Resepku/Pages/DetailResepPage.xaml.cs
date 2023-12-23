using Resepku.Services;
using System.Globalization;

namespace Resepku;

public partial class DetailResepPage : ContentPage
{
	private MakananModels _currMakanan { get; set; }
	public DetailResepPage(MakananModels tempdata)
	{
		InitializeComponent();
		_currMakanan = tempdata != null ? tempdata : new();
		this.BindingContext = _currMakanan;
    }

    async void btn_edit_Clicked(object sender, EventArgs e)
    {
		await Navigation.PushAsync(new ManageResepPage(_currMakanan));
    }
}