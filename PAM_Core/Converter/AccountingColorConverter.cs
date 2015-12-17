using System;
using System.Globalization;
using System.Windows.Data;

namespace PAM.Converter
{
    public class AccountingColorConverter : IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int || value is long || value is float || value is double))
                throw new Exception("AccountingColorConverter: Can't convert a non numeric value!");

            if ((value is int       && (int)value       >= 0) ||
                (value is long      && (long)value      >= 0) ||
                (value is float     && (float)value     >= 0) ||
                (value is double    && (double)value    >= 0))
                return "Black";
            else
                return "Red";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new Exception("AccountingColorConverter: Can't convert back!");
        }
    }
}
