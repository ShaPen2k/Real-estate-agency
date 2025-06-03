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
    /// Логика взаимодействия для OwnerDataPage.xaml
    /// </summary>
    public partial class OwnerDataPage : Page
    {
        public List<Owners> owners { get; set; } = new List<Owners>();

        OwnersFromDB ownersFromDB = new OwnersFromDB();

        Agents entryAgent = AuthorizationWindow.entryAgent;
        public OwnerDataPage()
        {
            InitializeComponent();
            owners = ownersFromDB.LoadOwners();
            dataGrid.ItemsSource = owners;
            DataContext = this;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Owners owner = button.DataContext as Owners;
                if (owner != null)
                {
                    ownersFromDB.DeleteOwner(owner);
                    dataGrid.ItemsSource = ownersFromDB.LoadOwners();
                    // Здесь выполняем удаление или другую логику
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Owners owner = button.DataContext as Owners;
                if (owner != null)
                {
                    NavigationService.Navigate(new AddOwnerPage(2, owner));
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            owners = ownersFromDB.SearchOwners(tbSearch.Text);
            dataGrid.ItemsSource = owners;
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Owners owner = new Owners();
                NavigationService.Navigate(new AddOwnerPage(1, owner));
            }
        }
    }
}
