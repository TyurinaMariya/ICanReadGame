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
    
    public class IsLessThanConverter : IMvxValueConverter, IValueConverter
    {
        public object Convert(object value, Type targetType, object parameter, CultureInfo culture)
        {
            var paramInt= (int)parameter;

            var valueInt = (int)value; 

             return (valueInt < paramInt) ;
        }

        public object ConvertBack(object value, Type targetType, object parameter, CultureInfo culture)
        {
            throw new NotImplementedException();
        }

        
    }
}