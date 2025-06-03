using Real_estate_agency.Classes;
using Real_estate_agency.Model;
using System;
using System.Collections.Generic;
using System.Globalization;
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
    /// Логика взаимодействия для AddUserPage.xaml
    /// </summary>
    public partial class AddUserPage : Page
    {
        AgentsFromDB agentsFromDB = new AgentsFromDB();
        Agents agents = new Agents();
        int page;
        Agents requireAgent;
        Agents entryAgent = AuthorizationWindow.entryAgent;
        public AddUserPage(int choice, Agents agent)
        {
            InitializeComponent();
            page = choice;
            
            if (page == 2)
            {
                if (entryAgent != null)
                {
                    Back.Visibility = Visibility.Hidden;
                    tbLogin.Text = entryAgent.Login;
                    tbPassword.Text = entryAgent.Password;
                    tbName.Text = entryAgent.Name;
                    tbLastName.Text = entryAgent.LastName;
                    tbPhone.Text = entryAgent.Phone;
                    tbExperience.Text = entryAgent.Experience.ToString();
                    tbMail.Text = entryAgent.Email;
                    DpBirthday.SelectedDate = entryAgent.Birthday;
                    DpHireDate.SelectedDate = entryAgent.HireDate;
                    TbPercent.Text = entryAgent.Percent.ToString();
                    TbAmount.Text = entryAgent.Amount.ToString();
                    zagalovok.Text = "Редактирование агента";
                    AddAgent.Content = "Обновить";
                }
                else 
                {
                    requireAgent = agent;
                    tbLogin.Text = agent.Login;
                    tbPassword.Text = agent.Password;
                    tbName.Text = agent.Name;
                    tbLastName.Text = agent.LastName;
                    tbPhone.Text = agent.Phone;
                    tbExperience.Text = agent.Experience.ToString();
                    tbMail.Text = agent.Email;
                    DpBirthday.SelectedDate = agent.Birthday;
                    DpHireDate.SelectedDate = agent.HireDate;
                    TbPercent.Text = agent.Percent.ToString();
                    TbAmount.Text = agent.Amount.ToString();
                    zagalovok.Text = "Редактирование агента";
                    AddAgent.Content = "Обновить";
                }
                
            }
            else
            {
                zagalovok.Text = "Добавление агента";
                AddAgent.Content = "Добавить";
            }
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            if(page == 1) { 
            try
            {
                    if (tbName.Text == "" || tbLastName.Text == "" || tbPhone.Text == "" || tbMail.Text == "" || tbExperience.Text == "" || TbAmount.Text == "" || TbPercent.Text == "")
                    {
                        MessageBox.Show("Необходимо заполнить все поля!");
                    }
                    else
                    {
                        agents.Login = tbLogin.Text;
                        agents.Password = tbPassword.Text;
                        agents.Name = tbName.Text;
                        agents.LastName = tbLastName.Text;
                        agents.Phone = tbPhone.Text;
                        agents.Experience = Int32.Parse(tbExperience.Text);
                        agents.Email = tbMail.Text;

                        DateTime? selectedDate = DpBirthday.SelectedDate;

                        if (selectedDate.HasValue)
                        {
                            // Если дата выбрана, присваиваем её агенту
                            agents.Birthday = selectedDate.Value;
                        }
                        else
                        {
                            // Дата не выбрана
                            MessageBox.Show("Выберите дату!");
                        }

                        DateTime? hireDate = DpHireDate.SelectedDate;

                        if (hireDate.HasValue)
                        {
                            // Если дата выбрана, присваиваем её агенту
                            agents.Birthday = hireDate.Value;
                        }
                        else
                        {
                            // Дата не выбрана
                            MessageBox.Show("Выберите дату!");
                        }
                        agents.Percent = Convert.ToInt32(TbPercent.Text);
                        agents.Amount = Convert.ToDouble(TbAmount.Text);

                        agentsFromDB.AddNewAgent(agents);
                        NavigationService.Navigate(new AgentsDataPage());
                    }
               
            }
            catch (Exception ex){ MessageBox.Show(ex.Message); }
        }
            else
            {
                agents.Login = tbLogin.Text;
                agents.Password = tbPassword.Text;
                agents.Name = tbName.Text;
                agents.LastName = tbLastName.Text;
                agents.Phone = tbPhone.Text;
                agents.Experience = Int32.Parse(tbExperience.Text);
                agents.Email = tbMail.Text;

                DateTime? selectedDate = DpBirthday.SelectedDate;

                if (selectedDate.HasValue)
                {
                    agents.Birthday = selectedDate.Value;
                }
                else
                {
                    // Дата не выбрана
                    MessageBox.Show("Выберите дату!");
                }

                DateTime? hireDate = DpHireDate.SelectedDate;

                if (hireDate.HasValue)
                {
                    // Если дата выбрана, присваиваем её агенту
                    agents.HireDate = hireDate.Value;
                }
                else
                {
                    // Дата не выбрана
                    MessageBox.Show("Выберите дату!");
                }
                agents.Percent = Convert.ToInt32(TbPercent.Text);
                agents.Amount = Convert.ToDouble(TbAmount.Text);
                if(entryAgent != null)
                {
                    agents.Id = entryAgent.Id;
                    agentsFromDB.UpdateAgent(agents);
                    NavigationService.Navigate(new AgentsDataPage());
                }
                else
                {
                    agents.Id = requireAgent.Id;
                    agentsFromDB.UpdateAgent(agents);
                    NavigationService.Navigate(new AgentsDataPage());
                }
                
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if (entryAgent != null) 
            {
                NavigationService.Navigate(new AgentsPage());
                
            }
            else
            {
                NavigationService.Navigate(new AgentsDataPage());
            }
        }
    }
}
