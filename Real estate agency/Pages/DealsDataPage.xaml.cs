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
    /// Логика взаимодействия для DealsDataPage.xaml
    /// </summary>
    public partial class DealsDataPage : Page
    {
        public List<Deals> deals { get; set; } = new List<Deals>();

        DealsFromDB dealsFromDB = new DealsFromDB();

        Agents entryAgent = AuthorizationWindow.entryAgent;
        public DealsDataPage()
        {
            InitializeComponent();
            deals = dealsFromDB.LoadDeals();
            dataGrid.ItemsSource = deals;
            DataContext = this;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Deals deal = button.DataContext as Deals;
                if (deal != null)
                {
                    dealsFromDB.DeleteDeals(deal);
                    dataGrid.ItemsSource = dealsFromDB.LoadDeals();
                    // Здесь выполняем удаление или другую логику
                }
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {

        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text))
            {
                deals = dealsFromDB.LoadDeals();
                dataGrid.ItemsSource = deals;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text))
            {
                deals = dealsFromDB.SearchDealsByLastname(tbSearch.Text);
                dataGrid.ItemsSource = deals;
            }
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Deals deal = new Deals();
                NavigationService.Navigate(new AddDealsPage());
            }
        }

       
    }
}
