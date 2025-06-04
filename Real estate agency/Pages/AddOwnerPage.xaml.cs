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
    /// Логика взаимодействия для AddOwnerPage.xaml
    /// </summary>
    public partial class AddOwnerPage : Page
    {
        OwnersFromDB ownersFromDB = new OwnersFromDB();
        Owners owners = new Owners();
        int page;
        int reqPage;
        Owners requireOwner;
        Agents entryAgent = AuthorizationWindow.entryAgent;
        public AddOwnerPage(int choice, Owners owner, int p_page)
        {
            InitializeComponent();
            reqPage = p_page;
            page = choice;
            if (page == 2)
            {
                owners = owner;
                requireOwner = owner;
                tbName.Text = owners.Name;
                tbLastName.Text = owners.LastName;
                tbPhone.Text = owners.Phone;
                tbMail.Text = owners.Email;
                zagalovok.Text = "Редактирование владельца";
                AddClient.Content = "Обновить";
            }
            else
            {
                zagalovok.Text = "Добавление владельца";
                AddClient.Content = "Добавить";
            }
        }

        private void AddClient_Click(object sender, RoutedEventArgs e)
        {
            if (page == 1)
            {
                try
                {
                    if (tbName.Text == "" || tbLastName.Text == "" || tbPhone.Text == "" || tbMail.Text == "" )
                    {
                        MessageBox.Show("Необходимо заполнить все поля!");
                        
                    }
                    else
                    {
                        owners.Name = tbName.Text;
                        owners.LastName = tbLastName.Text;
                        owners.Phone = tbPhone.Text;
                        owners.Email = tbMail.Text;

                        ownersFromDB.AddNewOwner(owners);
                        NavigationService.Navigate(new OwnerDataPage());
                    }

                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {
                owners.Name = tbName.Text;
                owners.LastName = tbLastName.Text;
                owners.Phone = tbPhone.Text;
                owners.Email = tbMail.Text;


                owners.Id = requireOwner.Id;
                ownersFromDB.UpdateOwner(owners);
                NavigationService.Navigate(new OwnerDataPage());
            }
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            if(reqPage == 1)
                NavigationService.Navigate(new OwnerDataPage());
            else
                NavigationService.Navigate(new RealtyPage());
        }
    }
}
