using System;
using System.Globalization;
using Avalonia.Data.Converters;

namespace Material.Dialog.Converters
{
    public class HourStringConverter : IValueConverter
    {
        public object Convert(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            if (value is ushort v)
            {
                return v == 0 ? 12.ToString() : v.ToString();
            }

            return 0.ToString();
        }

        public object ConvertBack(object? value, Type targetType, object? parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }
    }
}