// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Akavache;
using Xamarin.Essentials;

namespace ICanRead.Core.Services
{
    public class AppSettings 
    {
        public const string DbFileName = "game.db";
        public static string[] Languages = new[] { "ua", "ru", "en" };
        public static int CountWordsForExpessions = 8;
        public static int CountWordsForSentences = 5;
        public static int ShortWordLength = 8;
        public static int MediumWordLength = 12;
        public static int LongWordLength = 16;
        public static int ScoreCoefficient = 10;
        public static int ErrorsCountForOneStar = 1;
        public static int ErrorsCountForTwoStars = 3;
        public static int ErrorsCountForThreeStars = 5;
    }
}
