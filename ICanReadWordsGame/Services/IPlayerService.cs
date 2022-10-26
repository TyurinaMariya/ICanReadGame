using ICanReadWordsGame.Model;

namespace ICanReadWordsGame.Services
{
    public interface IPlayerService
    {
        ISeriesPlayer GetSeriesPlayer();
        Task PlayClickSound();
        Task PlayGameOverSound();
        Task PlayWord(Word word);
        Task PlayCorrectAnswerSound();
        Task PlayLevelDoneSound();
    }
}
