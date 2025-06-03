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
using System.Windows.Shapes;

namespace Real_estate_agency
{
    /// <summary>
    /// Логика взаимодействия для AuthorizationWindow.xaml
    /// </summary>
    public partial class AuthorizationWindow : Window
    {
        public AuthorizationWindow()
        {
            InitializeComponent();
        }

        public static Agents entryAgent;
        AgentsFromDB agentsFromDB = new AgentsFromDB();
        public static Employee entryEmployee;
        EmployeeFromDB employeeFromDB = new EmployeeFromDB();


        private void btnEnter_Click(object sender, RoutedEventArgs e)
        {
            if(tbLogin.Text == "" || tbPassword.Text == "")
            {
                MessageBox.Show("Заполните все поля!");
            }
            else
            {
                if(agentsFromDB.FindAgentByPassword(tbPassword.Text, tbLogin.Text) != null)
                {
                    entryAgent = agentsFromDB.FindAgentByPassword(tbPassword.Text, tbLogin.Text);
                    // Открываем второе окно
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();
                    
                    // Закрываем текущее окно
                    this.Close();
                }
                else if(employeeFromDB.FindAgentByPassword(tbPassword.Text, tbLogin.Text) != null)
                {
                    entryEmployee = employeeFromDB.FindAgentByPassword(tbPassword.Text, tbLogin.Text);
                    MessageBox.Show("Вы вошли под администратором");
                    // Открываем второе окно
                    MainWindow mainWindow = new MainWindow();
                    mainWindow.Show();

                    // Закрываем текущее окно
                    this.Close();
                }
                else
                {
                    MessageBox.Show("Пользователь не найден");
                }
            }
            
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }
    }
}
