using ICanRead.Core.Model;
using ICanRead.Core.Resources;
using MediaManager;
using MediaManager.Library;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Essentials;

namespace ICanRead.Core.Services
{
    public static class Ext
        {
       public static Task ForEachAsync<T>(this IEnumerable<T> sequence, Func<T, Task> action)
    {
        return Task.WhenAll(sequence.Select(action));
    }
}
    public class SeriesPlayer : ISeriesPlayer
    {
        //    //OS - place file in Resources directory. CrossMediaManager.Current.AudioPlayer.Play(new MediaFile("beep.mp3", MediaFileType.Audio, ResourceAvailability.Local));
        //  private readonly List<( string key, Stream stream)> fileStreams = new List<( string key, Stream stream )>();


        //public ISeriesPlayer AddCorrectAnswerSound() => AddResourceFile($"ICanRead.Core.Resources.Audio.{ResourceNames.CorrectAnswerFileName}");
        ////public SeriesPlayer AddWrongAnswerSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.WrongAnswerFileName}");
        //public ISeriesPlayer AddClickSound() => AddResourceFile($"ICanRead.Core.Resources.Audio.{ResourceNames.ClickSoundFileName}");
        //public ISeriesPlayer AddLevelDoneSound() => AddResourceFile($"ICanRead.Core.Resources.Audio.{ResourceNames.LevelDoneSoundFileName}");
        //public ISeriesPlayer AddGameOverSound() => AddResourceFile($"ICanRead.Core.Resources.Audio.{ResourceNames.GameOverSoundFileName}");

        List<MediaItem> mediaItems = new List<MediaItem>();
        public ISeriesPlayer AddCorrectAnswerSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.CorrectAnswerFileName}");
        //public SeriesPlayer AddWrongAnswerSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.WrongAnswerFileName}");
        public ISeriesPlayer AddClickSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.ClickSoundFileName}");
        public ISeriesPlayer AddLevelDoneSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.LevelDoneSoundFileName}");
        public ISeriesPlayer AddGameOverSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.GameOverSoundFileName}");
        public ISeriesPlayer AddWord(Word word)
            {
            if (word.AudioFileName == null && mediaItems.Any())
                throw new NotSupportedException("Currently series with text-to-speech not in first position are not supported");
            //if (word.AudioFileName == null)
            //    textToSpeachWord = word;
            //else
            AddSound($"{ResourceNames.WordsAudioFilePath}{word.AudioFileName}");
            return this;
            //return AddResourceFile($"ICanRead.Core.Resources.Audio.Words.{word.AudioFileName}");
        }

        
        public async Task Play()
        {
            //foreach (var s in fileStreams)
            //{
            //    var medadata = await CrossMediaManager.Current.Play(s.stream, s.key);
            //    if (s!=fileStreams.Last())
            //        Thread.Sleep((int)medadata.Duration.TotalMilliseconds);
            //}
            //  await CrossMediaManager.Current.Play(fileStream);
               await CrossMediaManager.Current.Play(mediaItems);
            //Debug.WriteLine("!!!!!!!!!!!!!!!!!!!!!PLAY!!!!!!!!!!!!!!!!!!!!!!!!!");
            //Debug.WriteLine(mediaItems.Aggregate("",(s,j)=>s+";  "+j.MediaUri));
            //Debug.WriteLine(new System.Diagnostics.StackTrace());
        }


        private SeriesPlayer AddSound(string uri)
        {
            mediaItems.Add(new MediaItem(uri));
            return this;
        }
        //private SeriesPlayer AddResourceFile(string filename)
        //{
           
        //    //var fileName = "ICanRead.Core.Resources.Words." + word.AudioFileName;
        //    var embeddedResourceDbStream = Assembly.GetExecutingAssembly().GetManifestResourceStream(filename);
        //    fileStreams.Add(( filename, embeddedResourceDbStream) );
        //    // await MediaManager.CrossMediaManager.Current.Play(embeddedResourceDbStream, word.AudioFileName).ConfigureAwait(false);
        //    return this;
        //}
        #region  TextToSpeach
        //Word textToSpeachWord = null;
        //public async Task Play()
        //{
        //    if (textToSpeachWord != null)
        //        await WordTextToSpeach(textToSpeachWord);
        //    await CrossMediaManager.Current.Play(mediaItems);
        // }

        //public ISeriesPlayer AddWord(Word word)
        //{
        //    if (word.audiofilename == null && mediaitems.any())
        //        throw new notsupportedexception("currently series with text-to-speech not in first position are not supported");
        //    if (word.audiofilename == null)
        //        texttospeachword = word;
        //    else
        //        AddSound($"{ResourceNames.WordsAudioFilePath}{word.AudioFileName}");
        //    return this;
        //}

        //private async Task WordTextToSpeach(Word word)
        //{
        //    var res = await TextToSpeech.GetLocalesAsync();
        //    var langLocale = res.FirstOrDefault(ContentItem => ContentItem.Country == word.Lang.ToUpper()
        //    || ContentItem.Language == word.Lang.ToLower());
        //    await TextToSpeech.SpeakAsync(word.Text, settings: new SpeakSettings() { Locale = langLocale });
        //}
        #endregion
    }
}
