using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Windows.Data;
using System.Windows.Markup;
using System.Windows.Media;

namespace WpfApplication2.Converters
{
    public class IntToBrushMultiConverter : MarkupExtension, IMultiValueConverter
    {
        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            return this;
        }

        public object Convert(object[] value, Type targetType, object parameter, CultureInfo culture)
        {
            var a = (byte)(int)value[0];
            var r = (byte)(int)value[1];
            var g = (byte)(int)value[2];
            var b = (byte)(int)value[3];

            var color = Color.FromArgb(a, r, g, b);
            return new SolidColorBrush(color);
        }

        public object[] ConvertBack(object value, Type[] targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
