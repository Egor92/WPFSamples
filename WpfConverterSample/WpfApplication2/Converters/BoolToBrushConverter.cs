using System;
using System.Globalization;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace WpfApplication2.Converters
{
    public class BoolToBrushConverter : MarkupExtension, IValueConverter
    {
        public Brush TrueBrush { get; set; }

        public Brush FalseBrush { get; set; }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is bool))
                return null;

            if ((bool) value)
                return TrueBrush;
            return FalseBrush;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var brush = value as Brush;
            return Equals(brush, TrueBrush);
        }
    }
}
