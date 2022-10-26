// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

namespace ICanReadWordsGame.Services
{
    public class UserSettings: IUserSettings
    {
        public int CurrentScore
        {
            get => Preferences.Get(nameof(CurrentScore), 0);
            set => Preferences.Set(nameof(CurrentScore), value);
        }
        public int GetLevelStars(long levelId)=>Preferences.Get($"Level{levelId}", -1);
        public void SetLevelStars(long levelId, int stars)=>Preferences.Set($"Level{levelId}", stars);


    }
}
