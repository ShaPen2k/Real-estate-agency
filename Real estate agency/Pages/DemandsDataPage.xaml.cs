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
    /// Логика взаимодействия для DemandsDataPage.xaml
    /// </summary>
    public partial class DemandsDataPage : Page
    {
        public List<Demands> demands { get; set; } = new List<Demands>();

        Agents entryAgent = AuthorizationWindow.entryAgent;

        DemandsFromDB demandsFromDB = new DemandsFromDB();
        public DemandsDataPage()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
            demands = demandsFromDB.LoadDemands();
            dataGrid.ItemsSource = demands;
            DataContext = this;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Demands demand = button.DataContext as Demands;
                if (demand != null)
                {
                    demandsFromDB.DeleteDemand(demand);
                    dataGrid.ItemsSource = demandsFromDB.LoadDemands();
                    // Здесь выполняем удаление или другую логику
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex == 0)
            {
                demands = demandsFromDB.LoadDemands();
                dataGrid.ItemsSource = demands;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex == 0)
            {
                demands = demandsFromDB.SearchDemandsByLastname(tbSearch.Text);
                dataGrid.ItemsSource = demands;
            }
            else if (string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex != 0)
            {
                demands = demandsFromDB.SearchDemandsByType(cbType.SelectedIndex);
                dataGrid.ItemsSource = demands;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex != 0)
            {
                demands = demandsFromDB.SearchDemandsByBoth(tbSearch.Text, cbType.SelectedIndex);
                dataGrid.ItemsSource = demands;
            }
        }


        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex == 0)
            {
                demands = demandsFromDB.LoadDemands();
                dataGrid.ItemsSource = demands;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex == 0)
            {
                demands = demandsFromDB.SearchDemandsByLastname(tbSearch.Text);
                dataGrid.ItemsSource = demands;
            }
            else if (string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex != 0)
            {
                demands = demandsFromDB.SearchDemandsByType(cbType.SelectedIndex);
                dataGrid.ItemsSource = demands;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex != 0)
            {
                demands = demandsFromDB.SearchDemandsByBoth(tbSearch.Text, cbType.SelectedIndex);
                dataGrid.ItemsSource = demands;
            }
        }
    }
}
