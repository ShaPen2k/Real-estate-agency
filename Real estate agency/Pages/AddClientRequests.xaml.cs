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
    /// <summary>
    /// Логика взаимодействия для AddCustomersPage.xaml
    /// </summary>
    public partial class AddClientRequests : Page
    {
        ClientsRequestsFromDB clientsFromDB = new ClientsRequestsFromDB();
        ClientRequests clients = new ClientRequests();
        int page;
        Agents entryAgent = AuthorizationWindow.entryAgent;
        ClientRequests requireClient;

        public AddClientRequests(int choice, ClientRequests clients)
        {
            InitializeComponent();
            page = choice;
            if (page == 2)
            {
                requireClient = clients;
                tbName.Text = clients.ClientId.ToString();
                tbLastName.Text = clients.RealtyId.ToString();
                zagalovok.Text = "Редактирование заявки";
                AddClientRequest.Content = "Обновить";
            }
            else
            {
                zagalovok.Text = "Добавление заявки";
                AddClientRequest.Content = "Добавить";
            }

        }

        private void AddClientRequest_Click(object sender, RoutedEventArgs e)
        {
            if (page == 1)
            {
                try
                {
                    if (tbName.Text == "" || tbLastName.Text == "" )
                    {
                        MessageBox.Show("Необходимо заполнить все поля!");
                    }
                    else
                    {
                        clients.ClientId = Int32.Parse(tbName.Text);
                        clients.RealtyId = Int32.Parse(tbLastName.Text);
                        clientsFromDB.AddNewClient(clients);
                        NavigationService.Navigate(new ClientRequestDataPage());
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                clients.ClientId = Int32.Parse(tbName.Text);
                clients.RealtyId = Int32.Parse(tbLastName.Text);
                clients.Id = requireClient.Id;
                clientsFromDB.UpdateClient(clients);
                NavigationService.Navigate(new ClientRequestDataPage());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (entryAgent != null)
            {
                NavigationService.Navigate(new ClientRequestDataPage());
            }
            else
            {
                NavigationService.Navigate(new ClientRequestDataPage());
            }
        }
    }
}
