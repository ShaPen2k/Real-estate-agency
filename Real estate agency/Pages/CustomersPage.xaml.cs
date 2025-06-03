using Real_estate_agency.Classes;
using Real_estate_agency.Model;
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

namespace Real_estate_agency.Pages
{
    
    public partial class CustomersPage : Page
    {
        public List<Clients> clients { get; set; } = new List<Clients>();

        Agents entryAgent = AuthorizationWindow.entryAgent;

        ClientsFromDB clientsFromDB = new ClientsFromDB();
        public CustomersPage()
        {
            InitializeComponent();
            clients = clientsFromDB.LoadClients();
            ListOfAgents.ItemsSource = clients;
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            clients = clientsFromDB.SearchClients(tbSearch.Text);
            ListOfAgents.ItemsSource = clients;
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (entryAgent != null)
                {
                    button.IsEnabled = false;
                }
                else
                { 
                    // Получаем сотрудника из параметра команды
                    Clients clients = new Clients();
                    NavigationService.Navigate(new AddCustomersPage(1, clients));
                }
                
            }
            
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (entryAgent != null)
                {
                    button.IsEnabled = false;
                }
                else
                {
                    // Получаем сотрудника из параметра команды
                    Clients clientToRemove = button.CommandParameter as Clients;
                    if (clientToRemove != null)
                    {
                        clientsFromDB.DeleteClient(clientToRemove);
                        ListOfAgents.ItemsSource = clientsFromDB.LoadClients();
                    }
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                if (entryAgent != null)
                {
                    button.IsEnabled = false;
                }
                else
                {
                    // Получаем сотрудника из параметра команды
                    Clients client = button.CommandParameter as Clients;
                    if (client != null)
                    {
                        NavigationService.Navigate(new AddCustomersPage(2, client));
                    }
                }
            }
        }
    }
}
