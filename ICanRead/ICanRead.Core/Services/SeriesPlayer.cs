using ICanRead.Core.Model;
using ICanRead.Core.Resources;
using MediaManager;
using MediaManager.Library;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ICanRead.Core.Services
{
    public class SeriesPlayer:ISeriesPlayer
    {
        //    //OS - place file in Resources directory. CrossMediaManager.Current.AudioPlayer.Play(new MediaFile("beep.mp3", MediaFileType.Audio, ResourceAvailability.Local));
        Word textToSpeachWord = null;
        List<MediaItem> mediaItems = new List<MediaItem>();
        public ISeriesPlayer AddCorrectAnswerSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.CorrectAnswerFileName}");
        //public SeriesPlayer AddWrongAnswerSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.WrongAnswerFileName}");
        public ISeriesPlayer AddClickSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.ClickSoundFileName}");
        public ISeriesPlayer AddLevelDoneSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.LevelDoneSoundFileName}");
        public ISeriesPlayer AddGameOverSound()=> AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.GameOverSoundFileName}");
        private SeriesPlayer AddSound(string uri)
        {
            mediaItems.Add(new MediaItem(uri));
            return this;
        }

        public ISeriesPlayer AddWord(Word word)
        {
            if (word.AudioFileName == null && mediaItems.Any())
                throw new NotSupportedException("Currently series with text-to-speech not in first position are not supported");
            if (word.AudioFileName == null)
                textToSpeachWord = word;
            else
                AddSound($"{ResourceNames.WordsAudioFilePath}{word.AudioFileName}");
            return this;
        }
        //private  SeriesPlayer AddWordSound(string wordFileName) => AddSound($"{ResourceNames.WordsAudioFilePath}{wordFileName}");
        public async Task Play()
        {
            if (textToSpeachWord != null)
                await WordTextToSpeach(textToSpeachWord);
            await CrossMediaManager.Current.Play(mediaItems);
        }

        private async Task WordTextToSpeach(Word word)
        {
            var res = await TextToSpeech.GetLocalesAsync();
            var langLocale = res.FirstOrDefault(ContentItem => ContentItem.Country == word.Lang.ToUpper()
            || ContentItem.Language == word.Lang.ToLower());
            await TextToSpeech.SpeakAsync(word.Text, settings: new SpeakSettings() { Locale = langLocale });
        }
    }
}
