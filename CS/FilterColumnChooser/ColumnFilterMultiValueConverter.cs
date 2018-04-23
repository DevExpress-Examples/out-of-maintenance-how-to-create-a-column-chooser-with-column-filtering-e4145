using DevExpress.Xpf.Grid;
using System;
using System.Collections;
using System.Globalization;
using System.Linq;
using System.Windows.Data;

namespace FilterColumnChooserExample
{
    public class ColumnFilterMultiValueConverter : IMultiValueConverter
    {
        public object Convert(object[] values, Type targetType, object parameter, CultureInfo culture) {
            if (values[0] == null) return null;
            var columns = ((IList)values[0]).Cast<BaseColumn>();
            string filter = values[1].ToString();
            if (String.IsNullOrEmpty(filter))
                return columns;
            return columns.Where(col => col.HeaderCaption.ToString().StartsWith(filter, true, culture));
        }
        public object[] ConvertBack(object value, Type[] targetTypes, object parameter, CultureInfo culture) {
            throw new NotImplementedException();
        }
    }
}
