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
    /// Логика взаимодействия для DealsPage.xaml
    /// </summary>
    public partial class DealsPage : Page
    {
        public List<Deals> deals { get; set; } = new List<Deals>();

        DealsFromDB dealsFromDB = new DealsFromDB();

        Agents entryAgent = AuthorizationWindow.entryAgent;

        public DealsPage()
        {
            InitializeComponent();
            deals = dealsFromDB.LoadDeals();
            ListOfAgents.ItemsSource = deals;
            cbStatus.SelectedIndex = 0;
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {

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
                    Deals dealToRemove = button.CommandParameter as Deals;
                    if (dealToRemove != null)
                    {
                        dealsFromDB.DeleteDeals(dealToRemove);
                        ListOfAgents.ItemsSource = dealsFromDB.LoadDeals();
                    }
                }
            }
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
                    NavigationService.Navigate(new AddDealsPage());
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {

            if (string.IsNullOrEmpty(tbSearch.Text) && cbStatus.SelectedIndex == 0)
            {
                deals = dealsFromDB.LoadDeals();
                ListOfAgents.ItemsSource = deals;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbStatus.SelectedIndex == 0)
            {
                deals = dealsFromDB.SearchDealsByLastname(tbSearch.Text);
                ListOfAgents.ItemsSource = deals;
            }
            else if (string.IsNullOrEmpty(tbSearch.Text) && cbStatus.SelectedIndex != 0)
            {
                deals = dealsFromDB.SearchDealsByStatus(cbStatus.SelectedIndex+1);
                ListOfAgents.ItemsSource = deals;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbStatus.SelectedIndex != 0)
            {
                deals = dealsFromDB.SearchDealsByBoth(tbSearch.Text, cbStatus.SelectedIndex+1);
                ListOfAgents.ItemsSource = deals;
            }
        }

        private void cbStatus_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text) && cbStatus.SelectedIndex == 0)
            {
                deals = dealsFromDB.LoadDeals();
                ListOfAgents.ItemsSource = deals;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbStatus.SelectedIndex == 0)
            {
                deals = dealsFromDB.SearchDealsByLastname(tbSearch.Text);
                ListOfAgents.ItemsSource = deals;
            }
            else if (string.IsNullOrEmpty(tbSearch.Text) && cbStatus.SelectedIndex != 0)
            {
                deals = dealsFromDB.SearchDealsByStatus(cbStatus.SelectedIndex + 1);
                ListOfAgents.ItemsSource = deals;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbStatus.SelectedIndex != 0)
            {
                deals = dealsFromDB.SearchDealsByBoth(tbSearch.Text, cbStatus.SelectedIndex+1);
                ListOfAgents.ItemsSource = deals;
            }
        }
    }
}
