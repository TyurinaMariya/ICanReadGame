using ICanReadWordsGame.Model;

namespace ICanReadWordsGame.Services
{
    public interface ISeriesPlayer:IDisposable
    {
        Task Play();
        ISeriesPlayer AddGameOverSound();
        ISeriesPlayer AddCorrectAnswerSound();
        ISeriesPlayer AddLevelDoneSound();
        ISeriesPlayer AddWord(Word word);
        ISeriesPlayer AddCallback(EventHandler playbackEnded);
        ISeriesPlayer AddClickSound();
    }

    
}
