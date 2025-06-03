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
using System.Xml.Linq;

namespace Real_estate_agency.Pages
{
    /// <summary>
    /// Логика взаимодействия для AddDealsPage.xaml
    /// </summary>
    public partial class AddDealsPage : Page
    {
        Deals deals = new Deals();
        Agents entryAgent = AuthorizationWindow.entryAgent;
        DealsFromDB DealsFromDB = new DealsFromDB();
        public AddDealsPage()
        {
            InitializeComponent();
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                if (tbNumberAgent.Text == "" || tbNumberOwner.Text == "" || tbNumberClient.Text == "" || tbDealCost.Text == "")
                {
                    MessageBox.Show("Необходимо заполнить все поля!");
                    
                }
                else
                {
                    int numberRealty = Int32.Parse(tbNumberOwner.Text);
                    int numberClient = Int32.Parse(tbNumberClient.Text);
                    int numberAgent = Int32.Parse(tbNumberAgent.Text);
                    DateTime? dealDate = DateTime.Now;
                    DateTime? selectedDate = DpDealDate.SelectedDate;

                    if (selectedDate.HasValue)
                    {
                        // Если дата выбрана, присваиваем её агенту
                        dealDate = selectedDate.Value;
                    }
                    else
                    {
                        // Дата не выбрана
                        MessageBox.Show("Выберите дату!");
                    }

                    double dealCost = Convert.ToDouble(tbDealCost.Text);

                    DealsFromDB.AddNewDeal(numberRealty, numberClient, numberAgent, dealDate, dealCost);
                    NavigationService.Navigate(new DealsDataPage());
                }
                
            }
            catch (Exception ex) { MessageBox.Show(ex.Message); }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if ( entryAgent!= null)
            {
                NavigationService.Navigate(new DealsPage());

            }
            else
            {
                NavigationService.Navigate(new DealsDataPage());
            }
        }

    }

        
}
