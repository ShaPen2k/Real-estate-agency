using LiveCharts;
using LiveCharts.Wpf;
using Real_estate_agency.Model;
using System.Windows;
using System.Windows.Controls;

namespace Real_estate_agency
{
    public partial class StatsPage : Page
    {
        StatsFromDB statsFromDB = new StatsFromDB();

        public SeriesCollection FlatAvailabilitySeries { get; set; }
        public SeriesCollection HouseAvailabilitySeries { get; set; }

        // Свойства для привязки данных
        public int Flat1Room { get; set; }
        public int Flat2Room { get; set; }
        public int Flat3Room { get; set; }
        public int Flat4Room { get; set; }
        public string FlatStatus1 { get; set; }
        public string FlatStatus2 { get; set; }
        public string FlatStatus3 { get; set; }
        public string HouseStatus1 { get; set; }
        public string HouseStatus2 { get; set; }
        public string HouseStatus3 { get; set; }
        public string AllAgents { get; set; }
        public string PercentAgent { get; set; }
        public int AmountAgent { get; set; }

        public StatsPage()
        {
            InitializeComponent();
            this.Loaded += StatsPage_Loaded;
            this.KeepAlive = false;
        }

        private void StatsPage_Loaded(object sender, RoutedEventArgs e)
        {
            LoadData();
        }

        private void LoadData()
        {
            // Загрузка данных для агентов
            AllAgents = statsFromDB.getAllAgents();
            PercentAgent = statsFromDB.getPercentAgent();
            AmountAgent = Int32.Parse(statsFromDB.getAvgAgentAmount());

            // Загрузка данных для квартир
            Flat1Room = Int32.Parse(statsFromDB.getAvgCostFlat1Room());
            Flat2Room = Int32.Parse(statsFromDB.getAvgCostFlat2Room());
            Flat3Room = Int32.Parse(statsFromDB.getAvgCostFlat3Room());
            Flat4Room = Int32.Parse(statsFromDB.getAvgCostFlat4Room());

            // Загрузка данных для доступности квартир
            FlatStatus1 = statsFromDB.getCountFlatStatus1();
            FlatStatus2 = statsFromDB.getCountFlatStatus2();
            FlatStatus3 = statsFromDB.getCountFlatStatus3();

            // Загрузка данных для доступности домов
            HouseStatus1 = statsFromDB.getCountHouseStatus1();
            HouseStatus2 = statsFromDB.getCountHouseStatus2();
            HouseStatus3 = statsFromDB.getCountHouseStatus3();

            // Инициализация круговых диаграмм
            FlatAvailabilitySeries = new SeriesCollection
            {
                new PieSeries { Title = "Купить", Values = new ChartValues<double> { Convert.ToDouble(FlatStatus1) } },
                new PieSeries { Title = "Снять", Values = new ChartValues<double> { Convert.ToDouble(FlatStatus2) } },
                new PieSeries { Title = "Продано", Values = new ChartValues<double> { Convert.ToDouble(FlatStatus3) } }
            };

            HouseAvailabilitySeries = new SeriesCollection
            {
                new PieSeries { Title = "Купить", Values = new ChartValues<double> { Convert.ToDouble(HouseStatus1) } },
                new PieSeries { Title = "Снять", Values = new ChartValues<double> { Convert.ToDouble(HouseStatus2) } },
                new PieSeries { Title = "Продано", Values = new ChartValues<double> { Convert.ToDouble(HouseStatus3) } }
            };

            DataContext = this;
        }
    }
}