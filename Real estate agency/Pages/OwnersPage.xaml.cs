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
    /// Логика взаимодействия для OwnersPage.xaml
    /// </summary>
    public partial class OwnersPage : Page
    {
        public List<Owners> owners { get; set; } = new List<Owners>();

        OwnersFromDB ownersFromDB = new OwnersFromDB();

        Agents entryAgent = AuthorizationWindow.entryAgent;
        public OwnersPage()
        {
            InitializeComponent();
            owners = ownersFromDB.LoadOwners();
            ListOfAgents.ItemsSource = owners;
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
                    Owners owner = button.CommandParameter as Owners;
                    if (owner != null)
                    {
                        NavigationService.Navigate(new AddOwnerPage(2, owner));
                    }
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
                    Owners ownerToRemove = button.CommandParameter as Owners;
                    if (ownerToRemove != null)
                    {
                        ownersFromDB.DeleteOwner(ownerToRemove);
                        ListOfAgents.ItemsSource = ownersFromDB.LoadOwners();
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            owners = ownersFromDB.SearchOwners(tbSearch.Text);
            ListOfAgents.ItemsSource = owners;
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
                    Owners owners = new Owners();
                    NavigationService.Navigate(new AddOwnerPage(1, owners));
                }
            }
        }
    }
}
