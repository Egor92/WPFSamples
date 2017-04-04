using System;
using System.Linq;
using System.Windows;

namespace DataGridPerformance
{
    public partial class MainWindow : Window
    {
        private readonly Random _random = new Random();

        public MainWindow()
        {
            InitializeComponent();
        }

        private void FillTable(object sender, RoutedEventArgs e)
        {
            MyDataGrid.ItemsSource = Enumerable.Range(0, 1000).Select(CreateItem).ToList();
        }

        private Item CreateItem(int arg)
        {
            return new Item
            {
                Property1 = _random.Next(-10000, 10000),
                Property2 = _random.Next(-10000, 10000),
                Property3 = _random.Next(-10000, 10000),
                Property4 = _random.Next(-10000, 10000),
                Property5 = _random.Next(-10000, 10000),
                Property6 = _random.Next(-10000, 10000),
                Property7 = _random.Next(-10000, 10000),
                Property8 = _random.Next(-10000, 10000),
            };
        }
    }
}