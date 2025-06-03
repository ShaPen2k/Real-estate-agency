using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.IO;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using Real_estate_agency.Classes;
using Real_estate_agency.Model;

namespace Real_estate_agency.Pages
{
    /// <summary>
    /// Логика взаимодействия для InfoRealtyPage.xaml
    /// </summary>
    /// 
    public partial class InfoRealtyPage : Page
    {
        RealtyFromDB realtyFromDB = new RealtyFromDB();
        string address = string.Empty;
        public InfoRealtyPage(Realty realty)
        {
            InitializeComponent();
            DataContext = realty;
            address = realty.Address;
            InitializeWebView();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RealtyPage());
        }

        private async void InitializeWebView()
        {
            string htmlPath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "map.html");
            await MapWebView.EnsureCoreWebView2Async(null);

            // Подписка на событие завершения загрузки страницы
            MapWebView.CoreWebView2.NavigationCompleted += async (sender, e) =>
            {
                // Вызов функции initMap после загрузки страницы
                await MapWebView.CoreWebView2.ExecuteScriptAsync($"initMap('{address}')");
            };

            MapWebView.Source = new Uri($"file:///{htmlPath.Replace("\\", "/")}");
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            Process.Start(new ProcessStartInfo(e.Uri.AbsoluteUri) { UseShellExecute = true });
            e.Handled = true;
        }
    }
}
