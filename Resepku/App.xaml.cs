using Resepku.Services;

namespace Resepku;

public partial class App : Application
{
	public App()
	{
		InitializeComponent();

		MainPage = new AppShell();
	}

    static SQLiteHelper db;

    public static SQLiteHelper SQLiteDb
    {
        get
        {
            if (db == null)
            {
                db = new SQLiteHelper(Path.Combine(Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData), "XamarinSQLite.db3"));
            }
            return db;
        }
    }
}