namespace ICanReadWordsGame.Converters;

public class LevelStateToClickedImageNameConverter : LevelStateToImageNameConverter
{
    public override object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
    {
        return $"clicked{base.Convert(value,  targetType, parameter, culture)}";
    }
}