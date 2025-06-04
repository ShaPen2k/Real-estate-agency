using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Navigation;
using Real_estate_agency.Classes;
using Real_estate_agency.Model;
using Xceed.Words.NET;
using System.IO;
using System.Globalization;
using System.Windows.Media.Animation;

namespace Real_estate_agency.Pages
{
    public partial class CustomerDataPage : Page
    {
        public List<Clients> clients { get; set; } = new List<Clients>();
        Agents entryAgent = AuthorizationWindow.entryAgent;
        ClientsFromDB clientsFromDB = new ClientsFromDB();
        private Clients currentClientForGenerate;

        public CustomerDataPage()
        {
            InitializeComponent();
            clients = clientsFromDB.LoadClients();
            dataGrid.ItemsSource = clients;
            DataContext = this;
        }

        private void btnDelete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Clients client)
            {
                clientsFromDB.DeleteClient(client);
                clients = clientsFromDB.LoadClients();
                dataGrid.ItemsSource = clients;
            }
        }

        private void btnEdit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.DataContext is Clients client)
            {
                NavigationService.Navigate(new AddCustomersPage(2, client, 1));
            }
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button)
            {
                Clients client = new Clients();
                NavigationService.Navigate(new AddCustomersPage(1, client, 1));
            }
        }

        private void tbSearch_TextChanged(object sender, TextChangedEventArgs e)
        {
            clients = clientsFromDB.SearchClients(tbSearch.Text);
            dataGrid.ItemsSource = clients;
        }

        private void btnGenerateContract_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Clients client)
            {
                currentClientForGenerate = client;
                generateContractPopup.IsOpen = true;
            }
        }

        private void btnGenerateDocument_Click(object sender, RoutedEventArgs e)
        {
            if (currentClientForGenerate != null)
            {
                // Валидация полей
                if (string.IsNullOrWhiteSpace(tbAddress.Text) ||
                    string.IsNullOrWhiteSpace(tbPassportNumber.Text) ||
                    string.IsNullOrWhiteSpace(tbPassportSeries.Text) ||
                    string.IsNullOrWhiteSpace(tbIssuedBy.Text))
                {
                    MessageBox.Show("Пожалуйста, заполните все поля.", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                    return;
                }

                try
                {
                    string address = tbAddress.Text;
                    string passportNumber = tbPassportNumber.Text;
                    string passportSeries = tbPassportSeries.Text;
                    string issuedBy = tbIssuedBy.Text;

                    // Путь к папке сохранения
                    string outputDirectory = @"..\..\..\Documents";
                    Directory.CreateDirectory(outputDirectory);

                    // Загрузка шаблона документа
                    using (DocX document = DocX.Load(@"..\..\..\Templates\template.docx"))
                    {
                        // Замена плейсхолдеров
                        document.ReplaceText("{FullName}", currentClientForGenerate.CombinedUser);
                        document.ReplaceText("{Address}", address);
                        document.ReplaceText("{PassportNumber}", passportNumber);
                        document.ReplaceText("{PassportSeries}", passportSeries);
                        document.ReplaceText("{IssuedBy}", issuedBy);
                        document.ReplaceText("{Date}", DateTime.Now.ToString("dd MMMM yyyy", new CultureInfo("ru-RU")));

                        var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                        {
                            Filter = "Word Documents (*.docx)|*.docx",
                            FileName = $"ДоговорОР_{currentClientForGenerate.Id}.docx",
                            InitialDirectory = Path.GetFullPath(outputDirectory)
                        };
                        if (saveFileDialog.ShowDialog() == true)
                        {
                            document.SaveAs(saveFileDialog.FileName);
                            MessageBox.Show($"Договор сохранён как {saveFileDialog.FileName}", "Успех", MessageBoxButton.OK, MessageBoxImage.Information);
                        }
                        else
                        {
                            return; // Отмена сохранения
                        }
                    }

                    // Закрытие попапа
                    generateContractPopup.IsOpen = false;
                }
                catch (Exception ex)
                {
                    MessageBox.Show($"Ошибка при создании договора: {ex.Message}", "Ошибка", MessageBoxButton.OK, MessageBoxImage.Error);
                }
            }
        }

        private void btnCancelGenerate_Click(object sender, RoutedEventArgs e)
        {
            tbAddress.Text = string.Empty;
            tbPassportNumber.Text = string.Empty;
            tbPassportSeries.Text = string.Empty;
            tbIssuedBy.Text = string.Empty;
            generateContractPopup.IsOpen = false;
        }

        private void generateContractPopup_Opened(object sender, EventArgs e)
        {
            if (PopupBorder != null)
            {
                var openAnimation = Resources["OpenPopupAnimation"] as Storyboard;
                if (openAnimation != null)
                {
                    Storyboard.SetTarget(openAnimation, PopupBorder);
                    openAnimation.Begin();
                }
            }
        }

        private void generateContractPopup_Closed(object sender, EventArgs e)
        {
            if (PopupBorder != null)
            {
                var closeAnimation = Resources["ClosePopupAnimation"] as Storyboard;
                if (closeAnimation != null)
                {
                    Storyboard.SetTarget(closeAnimation, PopupBorder);
                    closeAnimation.Begin();
                }
            }
        }
    }
}