using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace WpfApplication2.Converters
{
    public class IntToBrushConverter : MarkupExtension, IValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is int))
                return null;

            var alpha = (byte)(int)value;
            var color = Color.FromArgb(alpha, 0, 0, 0);
            return new SolidColorBrush(color);
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = value as SolidColorBrush;
            if (brush == null)
                return null;
            return brush.Color.A;
        }
    }
}
