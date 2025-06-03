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
    /// Логика взаимодействия для AgentsDataPage.xaml
    /// </summary>
    public partial class AgentsDataPage : Page
    {
        public List<Agents> agents { get; set; } = new List<Agents>();

        Agents entryAgent = AuthorizationWindow.entryAgent;

        AgentsFromDB agentsFromDB = new AgentsFromDB();
        public AgentsDataPage()
        {
            InitializeComponent();
            dataGrid.ItemsSource = agentsFromDB.LoadAgents();
            DataContext = this;
            
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Agents agent = new Agents();
                if (entryAgent != null)
                {
                    AddAgent.IsEnabled = false;
                }
                else
                {
                    NavigationService.Navigate(new AddUserPage(1, agent));
                }
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            agents = agentsFromDB.SearchAgents(tbSearch.Text);
            dataGrid.ItemsSource = agents;
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Agents agents = button.DataContext as Agents;
                if (agents != null)
                {
                    agentsFromDB.DeleteAgent(agents);
                    dataGrid.ItemsSource = agentsFromDB.LoadAgents();
                    // Здесь выполняем удаление или другую логику
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            Button button = sender as Button;
            if (button != null)
            {
                Agents agent = button.DataContext as Agents;
                if (agent != null)
                {
                    NavigationService.Navigate(new AddUserPage(2, agent));
                }
            }
        }
    }
}
