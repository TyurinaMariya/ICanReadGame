using ICanReadWordsGame.Model;
using Plugin.Maui.Audio;
using System.IO;
using ICanReadWordsGame.Resources;

namespace ICanReadWordsGame.Services
{
    //todo переделать на фасад , который получает ISeriesPlayer в конструкторе  
    public sealed class PlayerService : IPlayerService
    {
        private readonly IAudioManager _audioManager;
        public PlayerService(IAudioManager audioManager)
        {
            _audioManager = audioManager;
        }
        public ISeriesPlayer GetSeriesPlayer() => new SeriesPlayer(_audioManager);

        public async Task PlayClickSound()=>await GetSeriesPlayer().AddClickSound().Play();
        public async Task PlayWord (Word word) => await GetSeriesPlayer().AddWord(word).Play();
        public async Task PlayGameOverSound()=> await GetSeriesPlayer().AddGameOverSound().Play();
        public async Task PlayCorrectAnswerSound() => await GetSeriesPlayer().AddCorrectAnswerSound().Play();
        public async Task PlayLevelDoneSound() => await GetSeriesPlayer().AddLevelDoneSound().Play();
    }
}
