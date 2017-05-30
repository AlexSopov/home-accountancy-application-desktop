using System;
using System.Globalization;
using System.Windows.Data;
using static HomeAccountancy.Model.RegularTransaction;

namespace HomeAccountancy.Converters
{
    public class IntToExecutingStrategyConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (int)((ExecutingStrategy)value);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            return (ExecutingStrategy)value;
        }
    }
}
