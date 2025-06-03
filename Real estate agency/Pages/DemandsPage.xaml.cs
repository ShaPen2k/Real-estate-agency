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
    /// Логика взаимодействия для DemandsPage.xaml
    /// </summary>
    public partial class DemandsPage : Page
    {
        public List<Demands> demands { get; set; } = new List<Demands>();

        Agents entryAgent = AuthorizationWindow.entryAgent;

        DemandsFromDB demandsFromDB = new DemandsFromDB();
        public DemandsPage()
        {
            InitializeComponent();
            cbType.SelectedIndex = 0;
            demands = demandsFromDB.LoadDemands();
            ListOfAgents.ItemsSource = demands;
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
                    Demands demandstoremove = button.CommandParameter as Demands;
                    if (demandstoremove != null)
                    {
                        demandsFromDB.DeleteDemand(demandstoremove);
                        ListOfAgents.ItemsSource = demandsFromDB.LoadDemands();
                    }
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex == 0)
            {
                demands = demandsFromDB.LoadDemands();
                ListOfAgents.ItemsSource = demands;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex == 0)
            {
                demands = demandsFromDB.SearchDemandsByLastname(tbSearch.Text);
                ListOfAgents.ItemsSource = demands;
            }
            else if (string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex != 0)
            {
                demands = demandsFromDB.SearchDemandsByType(cbType.SelectedIndex);
                ListOfAgents.ItemsSource = demands;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex != 0)
            {
                demands = demandsFromDB.SearchDemandsByBoth(tbSearch.Text, cbType.SelectedIndex);
                ListOfAgents.ItemsSource = demands;
            }
        }

        private void cbType_SelectionChanged(object sender, SelectionChangedEventArgs e)
        {
            if (string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex == 0)
            {
                demands = demandsFromDB.LoadDemands();
                ListOfAgents.ItemsSource = demands;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex == 0)
            {
                demands = demandsFromDB.SearchDemandsByLastname(tbSearch.Text);
                ListOfAgents.ItemsSource = demands;
            }
            else if (string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex != 0)
            {
                demands = demandsFromDB.SearchDemandsByType(cbType.SelectedIndex);
                ListOfAgents.ItemsSource = demands;
            }
            else if (!string.IsNullOrEmpty(tbSearch.Text) && cbType.SelectedIndex != 0)
            {
                demands = demandsFromDB.SearchDemandsByBoth(tbSearch.Text, cbType.SelectedIndex);
                ListOfAgents.ItemsSource = demands;
            }
        }
    }
}
