using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace WpfApplication2.Converters
{
    public class StringToBrushConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (value == null)
                return null;
            var hex = value.ToString();
            var convertedValue = ColorConverter.ConvertFromString(hex);
            if (convertedValue == null)
                return null;
            var color = (Color) convertedValue;
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
