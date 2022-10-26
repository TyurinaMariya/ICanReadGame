using System.Globalization;

namespace ICanReadWordsGame.Converters;

public class BooleanInverseConverter : IValueConverter
{
    public object Convert(object value, Type targetType, object parameter, CultureInfo culture)=>!(bool)value;

    public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
    {
        throw new NotImplementedException();
    }


}