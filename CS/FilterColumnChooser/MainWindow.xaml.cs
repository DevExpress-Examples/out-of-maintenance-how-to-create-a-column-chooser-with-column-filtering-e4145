using DevExpress.Xpf.Grid;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Windows;

namespace FilterColumnChooserExample
{
    public partial class MainWindow : Window
    {
        public MainWindow() {
            InitializeComponent();
        }

        private void Button_Click(object sender, RoutedEventArgs e) {
            GridControlBand band = new GridControlBand() { Header = "Band" + gcMain.Bands.Count };
            if (gcMain.Bands.Count == 0) {
                List<GridColumn> columns = gcMain.Columns.ToList();
                gcMain.Columns.Clear();
                foreach (var item in columns) {
                    band.Columns.Add(item);
                }
            }
            gcMain.Bands.Add(band);
        }

        private void btn_ShowChooser_Click(object sender, RoutedEventArgs e) {
            view.ShowColumnChooser();
        }
    }
}