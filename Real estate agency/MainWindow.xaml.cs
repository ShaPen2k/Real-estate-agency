using Real_estate_agency;
using Real_estate_agency.Classes;
using Real_estate_agency.Pages;
using System.Runtime.InteropServices;
using System.Windows;
using System.Windows.Controls;
using System.Windows.Input;
using System.Windows.Interop;
using System.Windows.Media;
using System.Linq;

namespace Real_estate_agency
{
    public partial class MainWindow : Window
    {
        Agents entryAgent = AuthorizationWindow.entryAgent;


        public MainWindow()
        {
            InitializeComponent();
            this.Loaded += MainWindow_Loaded;
            MainFrame.Navigate(new StatsPage());
        }

        private void MainWindow_Loaded(object sender, RoutedEventArgs e)
        {
            ThemeToggle.Checked -= ThemeToggle_Checked;
            ThemeToggle.Unchecked -= ThemeToggle_Unchecked;

            ThemeToggle.Checked += ThemeToggle_Checked;
            ThemeToggle.Unchecked += ThemeToggle_Unchecked;
        }

        [DllImport("user32.dll")]
        public static extern IntPtr SendMessage(IntPtr hWnd, int wMsg, int wParam, int lParam);

        private void pnlControlBar_MouseLeftButtonDown(object sender, MouseButtonEventArgs e)
        {
            WindowInteropHelper helper = new WindowInteropHelper(this);
            SendMessage(helper.Handle, 161, 2, 0);
        }

        private void pnlControlBar_MouseEnter(object sender, MouseEventArgs e)
        {
            this.MaxHeight = SystemParameters.MaximizedPrimaryScreenHeight;
        }

        private void btnClose_Click(object sender, RoutedEventArgs e)
        {
            Application.Current.Shutdown();
        }

        private void btnMinimize_Click(object sender, RoutedEventArgs e)
        {
            this.WindowState = WindowState.Minimized;
        }

        private void btnMaximize_Click(object sender, RoutedEventArgs e)
        {
            if (this.WindowState == WindowState.Normal)
                this.WindowState = WindowState.Maximized;
            else
                this.WindowState = WindowState.Normal;
        }

        private void Customers_Checked(object sender, RoutedEventArgs e)
        {
                MainFrame.Navigate(new CustomerDataPage());
        }

        private void Dashboard_Checked_1(object sender, RoutedEventArgs e)
        {
            if (MainFrame?.Content is not StatsPage)
            {
                MainFrame?.Navigate(new StatsPage());
            }
        }

        private void Agents_Checked(object sender, RoutedEventArgs e)
        {
            if (entryAgent == null)
                MainFrame.Navigate(new AgentsDataPage());
            else
                MainFrame.Navigate(new AddUserPage(2, entryAgent));
        }

        private void Owners_Checked(object sender, RoutedEventArgs e)
        {
                MainFrame.Navigate(new OwnerDataPage());
        }

        private void Realty_Checked(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new RealtyPage());
        }

        private void RadioButton_Checked(object sender, RoutedEventArgs e)
        {
                MainFrame.Navigate(new DealsDataPage());
        }

        private void RadioButton_Checked_1(object sender, RoutedEventArgs e)
        {
        }

        private void ThemeToggle_Checked(object sender, RoutedEventArgs e)
        {
            var appRes = Application.Current.Resources;
            var light = appRes.MergedDictionaries
                          .FirstOrDefault(d => d.Source.OriginalString.EndsWith("UIColors.xaml"));
            if (light != null) appRes.MergedDictionaries.Remove(light);

            var dark = new ResourceDictionary { Source = new Uri("Styles/UIColorsDark.xaml", UriKind.Relative) };
            appRes.MergedDictionaries.Add(dark);
            tbTema.Text = "Светлая тема";

            MainFrame?.Refresh();
        }

        private void ThemeToggle_Unchecked(object sender, RoutedEventArgs e)
        {
            var appRes = Application.Current.Resources;
            var light = appRes.MergedDictionaries
                          .FirstOrDefault(d => d.Source.OriginalString.EndsWith("UIColorsDark.xaml"));
            if (light != null) appRes.MergedDictionaries.Remove(light);

            var dark = new ResourceDictionary { Source = new Uri("Styles/UIColors.xaml", UriKind.Relative) };
            appRes.MergedDictionaries.Add(dark);
            tbTema.Text = "Тёмная тема";
        }

        private void RadioButton_Checked_2(object sender, RoutedEventArgs e)
        {
            MainFrame.Navigate(new ClientRequestDataPage());
        }
    }
}