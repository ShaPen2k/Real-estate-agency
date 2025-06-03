using Real_estate_agency.Classes;
using Real_estate_agency.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
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
    /// Логика взаимодействия для AgentsPage.xaml
    /// </summary>
    public partial class AgentsPage : Page
    {
        
        public List<Employee> employees { get; set; } = new List<Employee>();
        public List<Agents> agents { get; set; } = new List<Agents>();

        Agents entryAgent = AuthorizationWindow.entryAgent;

        AgentsFromDB agentsFromDB = new AgentsFromDB();

        public AgentsPage()
        {
            InitializeComponent();
            ListOfAgents.ItemsSource = agentsFromDB.LoadAgents();
        }

        private void Button_Click(object sender, RoutedEventArgs e)
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
                    Agents agentToRemove = button.CommandParameter as Agents;
                    if (agentToRemove != null)
                    {
                        agentsFromDB.DeleteAgent(agentToRemove);
                        ListOfAgents.ItemsSource = agentsFromDB.LoadAgents();
                    }
                }
            }
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                // Получаем сотрудника из параметра команды
                Agents agent = button.CommandParameter as Agents;
                if (entryAgent != null)
                {
                    button.IsEnabled = false;
                }
                else
                {
                    // Получаем сотрудника из параметра команды
                    Agents agentToRemove = button.CommandParameter as Agents;
                    if (agentToRemove != null)
                    {
                        NavigationService.Navigate(new AddUserPage(2, agent));
                    }
                }
            }
            
        }


        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            agents = agentsFromDB.SearchAgents(tbSearch.Text);
            ListOfAgents.ItemsSource = agents;
        }

        private void tbSearch_TextChanged_1(object sender, TextChangedEventArgs e)
        {

        }

        private void AddAgent_Click_1(object sender, RoutedEventArgs e)
        {

        }
    }
}
