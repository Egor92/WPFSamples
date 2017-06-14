using System;
using System.Collections.Generic;
using System.Globalization;
using System.Windows.Data;
using WpfApplication1.Enums;

namespace WpfApplication1.Converters
{
    public class GenderToTextConverter : IValueConverter
    {
        private static IDictionary<Gender, string> _descriptions = new Dictionary<Gender, string>
        {
            { Gender.Male, "мужской" },
            { Gender.Female, "женский" },
        };

        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            if (!(value is Gender))
                return null;
            var gender = (Gender) value;
            if (!_descriptions.ContainsKey(gender))
                return null;
            return _descriptions[gender];
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotSupportedException();
        }
    }
}
