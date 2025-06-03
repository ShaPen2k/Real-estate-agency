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
    /// Логика взаимодействия для AddRealtyPage.xaml
    /// </summary>
    public partial class AddRealtyPage : Page
    {
        RealtyFromDB realtyFromDB = new RealtyFromDB();
        Realty realty = new Realty();
        int page;
        Realty requireRealty;
        public AddRealtyPage(int choice, Realty realty2)
        {
            InitializeComponent();
            page = choice;
            if (page == 2)
            {
                requireRealty = realty2;
                tbAddress.Text = realty2.Address;
                tbPrice.Text = realty2.Price.ToString();
                var selectedItem = cbType.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == realty2.Type);
                if (selectedItem != null)
                {
                    cbType.SelectedItem = selectedItem;
                }
                var selectedItem2 = cbStatus.Items.Cast<ComboBoxItem>().FirstOrDefault(item => item.Content.ToString() == realty2.Status);
                if (selectedItem != null)
                {
                    cbStatus.SelectedItem = selectedItem2;
                }
                cbArea.Text = realty2.Area.ToString();
                tbRooms.Text = realty2.Rooms.ToString();
                string ownerPhone = realtyFromDB.SearchOwnersByPhone(realty2.OwnerPhone.ToString());
                tbUrl.Text = realty2.Url.ToString();
                tbUnderground.Text = realty2.Underground.ToString();
                tbFloor.Text = realty2.Floor.ToString();
                tbJk.Text = realty2.Residential_conplex.ToString();
                tbNumberOwner.Text = ownerPhone;
                zagalovok.Text = "Редактирование Недвижимости";
                AddAgent.Content = "Обновить";
            }
            else
            {
                zagalovok.Text = "Добавление Недвижимости";
                AddAgent.Content = "Добавить";
            }
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            if (page == 1)
            {
                try
                {
                    if (tbAddress.Text == "" || tbRooms.Text == "" || tbPrice.Text == "" || tbNumberOwner.Text == "")
                    {
                        MessageBox.Show("Необходимо заполнить все поля!");
                        
                    }
                    else
                    {
                        realty.Address = tbAddress.Text;
                        realty.Status = cbStatus.Text;
                        realty.Area = Convert.ToDouble(cbArea.Text);
                        realty.Rooms = Convert.ToInt32(tbRooms.Text);
                        realty.Price = Convert.ToDouble(tbPrice.Text);
                        int ownerId = Int32.Parse(tbNumberOwner.Text);
                        realty.Url = tbUrl.Text;
                        realty.Underground = tbUnderground.Text;
                        realty.Floor = Convert.ToInt32(tbFloor.Text);
                        realty.Residential_conplex = tbJk.Text;
                        realtyFromDB.AddNewRealty(realty, cbType.SelectedIndex + 1, cbStatus.SelectedIndex + 1, ownerId);
                        NavigationService.Navigate(new RealtyPage());
                    }
                    
                }
                catch (Exception ex) { MessageBox.Show(ex.Message); }
            }
            else
            {

                realty.Address = tbAddress.Text;
                realty.Status = cbStatus.Text;
                realty.Area = Convert.ToDouble(cbArea.Text);
                realty.Rooms = Convert.ToInt32(tbRooms.Text);
                realty.OwnerPhone = tbNumberOwner.Text;
                realty.Price = Convert.ToDouble(tbPrice.Text);
                realty.Id = requireRealty.Id;
                realty.Url = tbUrl.Text;
                int ownerId = Int32.Parse(tbNumberOwner.Text);
                realty.Underground = tbUnderground.Text;
                realty.Floor = Convert.ToInt32(tbFloor.Text);
                realty.Residential_conplex = tbJk.Text;
                realtyFromDB.UpdateRealty(realty, cbType.SelectedIndex + 1, cbStatus.SelectedIndex + 1, ownerId);
                NavigationService.Navigate(new RealtyPage());
            }
            
        }

        private void Back_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new RealtyPage());
        }
    }
}
