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
    public partial class AddCustomersPage : Page
    {
        ClientsFromDB clientsFromDB = new ClientsFromDB();
        Clients clients = new Clients();
        int page;
        int reqPage;
        Agents entryAgent = AuthorizationWindow.entryAgent;
        Clients requireClient;

        public AddCustomersPage(int choice, Clients clients, int p_page)
        {
            InitializeComponent();
            page = choice;
            if (page == 2)
            {
                requireClient = clients;
                tbName.Text = clients.Name;
                tbLastName.Text = clients.LastName;
                tbPhone.Text = clients.Phone;
                tbMail.Text = clients.Email;
                zagalovok.Text = "Редактирование клиента";
                AddClient.Content = "Обновить";
            }
            else
            {
                zagalovok.Text = "Добавление клиента";
                AddClient.Content = "Добавить";
            }
            reqPage = p_page;
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            if (page == 1)
            {
                try
                {
                    if (tbName.Text == "" || tbLastName.Text == "" || tbPhone.Text == "" || tbMail.Text == "")
                    {
                        MessageBox.Show("Необходимо заполнить все поля!");
                    }
                    else
                    {
                        clients.Name = tbName.Text;
                        clients.LastName = tbLastName.Text;
                        clients.Phone = tbPhone.Text;
                        clients.Email = tbMail.Text;

                        clientsFromDB.AddNewClient(clients);
                        NavigationService.Navigate(new CustomerDataPage());
                    }
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                clients.Name = tbName.Text;
                clients.LastName = tbLastName.Text;
                clients.Phone = tbPhone.Text;
                clients.Email = tbMail.Text;


                clients.Id = requireClient.Id;
                clientsFromDB.UpdateClient(clients);
                NavigationService.Navigate(new CustomerDataPage());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (reqPage == 1)
                NavigationService.Navigate(new CustomerDataPage());
            else
                NavigationService.Navigate(new RealtyPage());
        }
    }
}
