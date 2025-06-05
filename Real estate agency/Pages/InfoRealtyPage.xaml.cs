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
        OwnersFromDB ownersFromDB = new OwnersFromDB();
        Owners owners = new Owners();
        ClientsFromDB clientsFromDB = new ClientsFromDB();

        int page;
        public InfoRealtyPage(Realty realty, int p_page)
        {
            page = p_page;
            InitializeComponent();
            DataContext = realty;
            address = realty.Address;
            int viewCount = realtyFromDB.GetViewCount(realty.Id);
            ViewCountText.Text = viewCount.ToString();
            InitializeWebView();
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (page == 1) 
            {
                NavigationService.Navigate(new RealtyPage());
            }
            else if (page == 2)
            {
                NavigationService.Navigate(new ClientRequestDataPage());
            }
            else
            {
                NavigationService.Navigate(new OwnerDataPage());
            }
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

        private void Hyperlink_RequestNavigate_1(object sender, RequestNavigateEventArgs e)
        {
            if (sender is Hyperlink hyperlink && hyperlink.Inlines.FirstInline is Run run)
            {
                string phone = run.Text;
                owners = ownersFromDB.GetOwnerByPhone(phone);
                NavigationService.Navigate(new AddOwnerPage(2, owners, 2));
            }
            e.Handled = true;
        }
        private void EyeIcon_Click(object sender, MouseButtonEventArgs e)
        {
            List<ViewedClients> clients = realtyFromDB.GetClientsWhoViewedRealty(((Realty)DataContext).Id);
            if (clients.Any())
            {
                ClientsListBox.ItemsSource = clients;
                NoViewsText.Visibility = Visibility.Collapsed;
                ClientsListBox.Visibility = Visibility.Visible;
            }
            else
            {
                ClientsListBox.ItemsSource = null;
                NoViewsText.Visibility = Visibility.Visible;
                ClientsListBox.Visibility = Visibility.Collapsed;
            }
            ClientsPopup.IsOpen = true;
        }

        private void Hyperlink_PreviewMouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            try
            {
                if (sender is Hyperlink hyperlink)
                {
                    var dataContext = (hyperlink.DataContext as ViewedClients);
                    if (dataContext != null)
                    {
                        var client = clientsFromDB.GetClientById(dataContext.Id);
                        if (client != null)
                        {
                            NavigationService.Navigate(new AddCustomersPage(2, client, 2));
                        }
                        else
                        {
                            MessageBox.Show("Клиент не найден.");
                        }
                    }
                    else
                    {
                        MessageBox.Show("DataContext пуст.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обработке ссылки: " + ex.Message);
            }
            e.Handled = true;
        }
    }
}