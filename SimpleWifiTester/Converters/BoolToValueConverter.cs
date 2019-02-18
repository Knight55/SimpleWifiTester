using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Data;

namespace SimpleWifiTester.Converters
{
    public class BoolToValueConverter<T> : IValueConverter
    {
        public T FalseValue { get; set; }

        public T TrueValue { get; set; }


        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null) return FalseValue;

            return (bool) value ? TrueValue : FalseValue;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return value?.Equals(TrueValue) ?? false;
        }
    }

    public class BoolToStringConverter : BoolToValueConverter<string> { }
}
