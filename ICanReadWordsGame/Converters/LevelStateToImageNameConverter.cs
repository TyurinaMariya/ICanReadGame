// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using ICanReadWordsGame.Model;

namespace ICanReadWordsGame.Converters
{
    public class LevelStateToImageNameConverter : IValueConverter
    {
        public virtual object Convert(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            var levelState = (LevelState)value;
            switch (levelState)
            {
                case LevelState.Locked: return "lockedlevel.png";
                case LevelState.Unlocked: return "notexecutedlevel.png";
                case LevelState.OneStar: return "onestar.png";
                case LevelState.TwoStars: return "twostars.png";
                case LevelState.ThreeStars: return "threestars.png";
            }

            throw new NotImplementedException();
        }
        public object ConvertBack(object value, Type targetType, object parameter, System.Globalization.CultureInfo culture)
        {
            return !(bool)value;
        }
    }

}