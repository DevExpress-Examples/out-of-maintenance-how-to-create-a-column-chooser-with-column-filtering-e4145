using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;
using System.Windows.Data;
using System.Collections.ObjectModel;
using DevExpress.Xpf.Grid;
using System.Globalization;

namespace FilterColumnChooserExample
{
    public partial class MainWindow : Window
    {
        public MainWindow()
        {
            InitializeComponent();
            gcMain.ItemsSource = CreateData(10);
        }

        private static List<Task> CreateData(int listCnt)
        {
            Random rand = new Random();
            List<Task> list = new List<Task>();
            for (int i = 0; i < listCnt; i++)
            {
                DateTime startDate = new DateTime(rand.Next(DateTime.Today.Year - 3, DateTime.Today.Year), rand.Next(1, 12), rand.Next(1, 27));
                list.Add(new Task { Name = "Task" + (i + 1), StartDate = startDate, FinishDate = startDate.AddDays(rand.NextDouble() * (DateTime.Now - startDate).Days), IsComplete = Math.Round(rand.NextDouble()) == 0 });
            }
            return list;
        }
    }

    public class Task
    {
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime FinishDate { get; set; }
        public bool IsComplete { get; set; }
    }

    public class ColumnFilterMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture)
        {
            ReadOnlyCollection<ColumnBase> columns = values[0] as ReadOnlyCollection<ColumnBase>;
            string filter = values[1].ToString();
            if (String.IsNullOrEmpty(filter))
                return columns;
            return columns.Where(col => col.HeaderCaption.ToString().StartsWith(filter, true, culture));
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}