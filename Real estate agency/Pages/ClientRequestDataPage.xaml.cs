using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Data;
using System.Windows.Documents;
using System.Windows.Input;
using System.Windows.Media;
using System.Windows.Media.Imaging;
using System.Windows.Navigation;
using System.Windows.Shapes;
using Real_estate_agency.Classes;
using Real_estate_agency.Model;

namespace Real_estate_agency.Pages
{
    /// <summary>
    /// Логика взаимодействия для ClientRequestDataPage.xaml
    /// </summary>
    public partial class ClientRequestDataPage : Page
    {
        public List<ClientRequests> clientRequests { get; set; } = new List<ClientRequests>();
        private readonly ClientsRequestsFromDB clientsRequestsFromDB = new ClientsRequestsFromDB();
        private readonly RealtyFromDB realtyDB = new RealtyFromDB();

        public ClientRequestDataPage()
        {
            InitializeComponent();
            dataGrid.ItemsSource = clientsRequestsFromDB.LoadClientsRequests();
            DataContext = this;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            clientRequests = clientsRequestsFromDB.SearchClients(tbSearch.Text);
            dataGrid.ItemsSource = clientRequests;
        }

        private void AddClientRequest_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                ClientRequests clientReq = new ClientRequests();
                NavigationService.Navigate(new AddClientRequests(1, clientReq));
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                ClientRequests clientReq = button.DataContext as ClientRequests;
                if (clientReq != null)
                {
                    NavigationService.Navigate(new AddClientRequests(2, clientReq));
                }
            }
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                ClientRequests clientReq = button.DataContext as ClientRequests;
                if (clientReq != null)
                {
                    clientsRequestsFromDB.delete_client_request(clientReq);
                    dataGrid.ItemsSource = clientsRequestsFromDB.LoadClientsRequests();
                }
            }
        }

        private void Hyperlink_RequestNavigate(object sender, RequestNavigateEventArgs e)
        {
            if (sender is Hyperlink hyperlink)
            {
                ClientRequests clientReq = hyperlink.Tag as ClientRequests;
                if (clientReq != null)
                {
                    Realty realty = realtyDB.GetRealtyById(clientReq.RealtyId);
                    if (realty != null)
                    {
                        NavigationService.Navigate(new InfoRealtyPage(realty, 2));
                    }
                    else
                    {
                        MessageBox.Show("Недвижимость не найдена.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    }
                }
                e.Handled = true;
            }
        }
    }
}