using System.Globalization;

namespace Resepku.Services
{
    public static class Converterd
    {
        public static string ToTanggalIndoFormat(this object source)
        {
            return Convert.ToDateTime(source).ToString("dd MMMM yyyy HH:mm:ss", new CultureInfo("id-ID", false));
        }
    }
}