// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using MvvmCross.Converters;
using System;
using System.Globalization;
using Xamarin.Forms;


namespace ICanRead.Core.Converters
{
    public class StringEqualityConverter : MvxValueConverter<string, bool>, IValueConverter
    {
        protected override bool Convert(string value, Type targetType, object parameter, CultureInfo cultureInfo)
        {
            return value!=null && value == (parameter as string);
        }

    }
}