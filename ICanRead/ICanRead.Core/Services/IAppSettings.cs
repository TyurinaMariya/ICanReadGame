// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

namespace ICanRead.Core.Services
{
    public interface IUserSettings
    {
        int GetLevelStars(long levelId);
        void SetLevelStars(long levelId, int stars);
        int CurrentScore { get; set; }
    }
}