using System;
using System.Collections.Generic;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Media.Animation;
using Real_estate_agency.Classes;
using Real_estate_agency.Model;
using OfficeOpenXml;
using System.IO;

namespace Real_estate_agency.Pages
{
    public partial class RealtyPage : Page
    {
        public List<Realty> realties { get; set; } = new List<Realty>();
        RealtyFromDB realtyFromDB = new RealtyFromDB();
        Agents entryAgent = AuthorizationWindow.entryAgent;

        private int currentPage = 1;
        private int pageSize = 20;
        private int totalItems;
        private int totalPages;

        private int? selectedTypeId;
        private int? selectedStatusId;
        private decimal? minPrice;
        private decimal? maxPrice;
        private decimal? minArea;
        private decimal? maxArea;
        private int? roomsFilter;

        public RealtyPage()
        {
            InitializeComponent();
            // Инициализация фильтров по умолчанию
            selectedTypeId = null;
            selectedStatusId = null;
            minPrice = null;
            maxPrice = null;
            minArea = null;
            maxArea = null;
            roomsFilter = null;
            LoadData();
            if (entryAgent != null)
            {
                AddAgent.Visibility = Visibility.Hidden;
            }
            // Подписка на события Popup
            FilterPopup.Opened += FilterPopup_Opened;
            FilterPopup.Closed += FilterPopup_Closed;
            cbTypeFilter.SelectedIndex = 0;
            cbStatusFilter.SelectedIndex = 0;
            cbRoomsFilter.SelectedIndex = 0;
        }

        private void FilterPopup_Opened(object sender, EventArgs e)
        {
            if (FilterBorder != null)
            {
                var openAnimation = Resources["OpenPopupAnimation"] as Storyboard;
                if (openAnimation != null)
                {
                    Storyboard.SetTarget(openAnimation, FilterBorder);
                    openAnimation.Begin();
                }
            }
        }

        private void FilterPopup_Closed(object sender, EventArgs e)
        {
            if (FilterBorder != null)
            {
                var closeAnimation = Resources["ClosePopupAnimation"] as Storyboard;
                if (closeAnimation != null)
                {
                    Storyboard.SetTarget(closeAnimation, FilterBorder);
                    closeAnimation.Begin();
                }
            }
        }

        private void SliderPrice_ValueChanged(object sender, RoutedPropertyChangedEventArgs<double> e)
        {
            if (sender is Slider slider)
            {
                double roundedValue = Math.Round(slider.Value / 1000000) * 1000000;
                slider.Value = roundedValue;
            }
        }

        private void ShowFilters_Click(object sender, RoutedEventArgs e)
        {
            FilterPopup.IsOpen = true;
        }

        private void ApplyFilters_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                // Чтение значений из полей фильтров
                selectedTypeId = cbTypeFilter.SelectedIndex == 0 ? (int?)null : cbTypeFilter.SelectedIndex == 1 ? 1 : 2;
                selectedStatusId = cbStatusFilter.SelectedIndex == 0 ? (int?)null : cbStatusFilter.SelectedIndex;
                minPrice = sliderMinPrice.Value == 0 ? (decimal?)null : (decimal)sliderMinPrice.Value;
                maxPrice = sliderMaxPrice.Value == 150000000 ? (decimal?)null : (decimal)sliderMaxPrice.Value;
                minArea = sliderMinArea.Value == 0 ? (decimal?)null : (decimal)sliderMinArea.Value;
                maxArea = sliderMaxArea.Value == 1000 ? (decimal?)null : (decimal)sliderMaxArea.Value;
                roomsFilter = cbRoomsFilter.SelectedIndex == 0 ? (int?)null : cbRoomsFilter.SelectedIndex;

                // Проверка, что минимальные значения не превышают максимальные
                if (minPrice.HasValue && maxPrice.HasValue && minPrice > maxPrice)
                {
                    MessageBox.Show("Минимальная цена не может превышать максимальную.");
                    return;
                }
                if (minArea.HasValue && maxArea.HasValue && minArea > maxArea)
                {
                    MessageBox.Show("Минимальная площадь не может превышать максимальную.");
                    return;
                }

                currentPage = 1; // Сброс на первую страницу
                LoadData();
                FilterPopup.IsOpen = false; // Закрытие popup
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при применении фильтров: {ex.Message}");
            }
        }

        private void ResetFilters_Click(object sender, RoutedEventArgs e)
        {
            cbTypeFilter.SelectedIndex = 0;
            cbStatusFilter.SelectedIndex = 0;
            sliderMinPrice.Value = 0;
            sliderMaxPrice.Value = 150000000;
            sliderMinArea.Value = 0;
            sliderMaxArea.Value = 1000;
            cbRoomsFilter.SelectedIndex = 0;
            ApplyFilters_Click(sender, e); // Применить сброшенные фильтры
        }

        private void GenerateReport_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ExcelPackage.License.SetNonCommercialPersonal("Dream House");
                var allRealties = realtyFromDB.LoadAllRealties(selectedTypeId, selectedStatusId, minPrice, maxPrice, minArea, maxArea, roomsFilter);
                using (var package = new ExcelPackage())
                {
                    var worksheet = package.Workbook.Worksheets.Add("Отчёт по недвижимости");
                    // Заголовки столбцов
                    worksheet.Cells[1, 1].Value = "ID";
                    worksheet.Cells[1, 2].Value = "Адрес";
                    worksheet.Cells[1, 3].Value = "Цена";
                    worksheet.Cells[1, 4].Value = "Тип";
                    worksheet.Cells[1, 5].Value = "Статус";
                    worksheet.Cells[1, 6].Value = "Площадь";
                    worksheet.Cells[1, 7].Value = "Комнаты";
                    worksheet.Cells[1, 8].Value = "Телефон владельца";
                    worksheet.Cells[1, 9].Value = "URL";
                    worksheet.Cells[1, 10].Value = "Этаж";
                    worksheet.Cells[1, 11].Value = "Метро";
                    worksheet.Cells[1, 12].Value = "ЖК";

                    int row = 2;
                    foreach (var realty in allRealties)
                    {
                        worksheet.Cells[row, 1].Value = realty.Id;
                        worksheet.Cells[row, 2].Value = realty.Address;
                        worksheet.Cells[row, 3].Value = realty.Price;
                        worksheet.Cells[row, 4].Value = realty.Type;
                        worksheet.Cells[row, 5].Value = realty.Status;
                        worksheet.Cells[row, 6].Value = realty.Area;
                        worksheet.Cells[row, 7].Value = realty.Rooms;
                        worksheet.Cells[row, 8].Value = realty.OwnerPhone;
                        worksheet.Cells[row, 9].Value = realty.Url;
                        worksheet.Cells[row, 10].Value = realty.Floor;
                        worksheet.Cells[row, 11].Value = realty.Underground;
                        worksheet.Cells[row, 12].Value = realty.Residential_conplex;
                        row++;
                    }

                    var saveFileDialog = new Microsoft.Win32.SaveFileDialog
                    {
                        Filter = "Excel files (*.xlsx)|*.xlsx",
                        FileName = "Отчёт по недвижимости.xlsx"
                    };
                    if (saveFileDialog.ShowDialog() == true)
                    {
                        package.SaveAs(new FileInfo(saveFileDialog.FileName));
                        MessageBox.Show("Отчёт успешно сохранён.");
                    }
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show($"Ошибка при создании отчёта: {ex.Message}");
            }
        }

        private void LoadData()
        {
            totalItems = realtyFromDB.GetTotalRealtiesCount(selectedTypeId, selectedStatusId, minPrice, maxPrice, minArea, maxArea, roomsFilter);
            totalPages = (int)Math.Ceiling((double)totalItems / pageSize);
            if (currentPage < 1) currentPage = 1;
            if (currentPage > totalPages && totalPages > 0) currentPage = totalPages;
            else if (totalPages == 0) currentPage = 1;
            realties = realtyFromDB.LoadRealties(currentPage, pageSize, selectedTypeId, selectedStatusId, minPrice, maxPrice, minArea, maxArea, roomsFilter);
            ListOfAgents.ItemsSource = realties;
            PageInfo.Text = totalPages > 0 ? $"Страница {currentPage} из {totalPages}" : "Нет объектов";
        }

        private void Previous_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage > 1)
            {
                currentPage--;
                LoadData();
            }
        }

        private void Next_Click(object sender, RoutedEventArgs e)
        {
            if (currentPage < totalPages)
            {
                currentPage++;
                LoadData();
            }
        }

        private void Details_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Realty realty)
            {
                NavigationService.Navigate(new InfoRealtyPage(realty));
            }
        }

        private void AddAgent_Click(object sender, RoutedEventArgs e)
        {
            NavigationService.Navigate(new AddRealtyPage(1, new Realty()));
        }

        private void Edit_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Realty realty)
            {
                NavigationService.Navigate(new AddRealtyPage(2, realty));
            }
        }

        private void Delete_Click(object sender, RoutedEventArgs e)
        {
            if (sender is Button button && button.CommandParameter is Realty realty)
            {
                realtyFromDB.DeleteRealty(realty);
                LoadData();
            }
        }
    }
}