using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;
using System.Windows.Media;
using System.Globalization;

namespace WpfLessonPratice
{
    [ValueConversion(typeof(double), typeof(Brush))]
    class NumberColorConverter : System.Windows.Data.IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value is null) return new SolidColorBrush(Colors.Blue);
            var v = (double)value;
            if (v < 100)
            { return new SolidColorBrush(Colors.Blue); }
            else if (v > 1000)
            { return new SolidColorBrush(Colors.Coral); }
            else
            { return new SolidColorBrush(Colors.Green); }
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}
