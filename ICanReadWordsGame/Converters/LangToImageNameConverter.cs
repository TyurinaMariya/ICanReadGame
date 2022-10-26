// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using System.Globalization;
using ICanReadWordsGame.Services;

namespace ICanReadWordsGame.Converters
{
    public class LangToImageNameConverter :  IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var paramstr = parameter as string;
            if (!AppSettings.Languages.Contains(paramstr))
                throw new ArgumentException($"parameter should be in array : {AppSettings.Languages.Aggregate("", (l, a) => $"{l}{a}; ")}");

            var valuestr = value as string;
            if (!AppSettings.Languages.Contains(value))
                throw new ArgumentException($"value should be in array : {AppSettings.Languages.Aggregate("", (l, a) => $"{l}{a}; ")}");

            return (valuestr == paramstr) ? $"{paramstr}btnclicked.png" : $"{paramstr}btn.png";
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }


    }
}