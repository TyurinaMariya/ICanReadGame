using System.Collections.Concurrent;
using ICanReadWordsGame.Model;
using ICanReadWordsGame.Resources;
using Plugin.Maui.Audio;

namespace ICanReadWordsGame.Services;

//public static class Ext
//{
//    public static Task ForEachAsync<T>(this IEnumerable<T> sequence, Func<T, Task> action)
//    {
//        return Task.WhenAll(sequence.Select(action));
//    }
//}

//public class ObservableSeriesPlayer : SeriesPlayer, IDisposable
//{
//    private EventHandler _playbackEnded;

//    public ISeriesPlayer AddCallback(EventHandler playbackEnded)
//    {
//        _playbackEnded = playbackEnded;
//        return this;
//    }

//    public ObservableSeriesPlayer(IAudioManager audioManager) : base(audioManager)
//    {
//    }

//    public async Task Play(EventHandler playbackEnded)
//    {
//        while (_fileStreams.Any())
//        {
//            var stream = await _fileStreams[0].stream;
//            _fileStreams.RemoveAt(0);
//            using var player = _audioManager.CreatePlayer(stream);
//            if (_fileStreams.Any())
//                player.PlaybackEnded += ContinuePlaying;
//            else if (playbackEnded != null)
//                player.PlaybackEnded += playbackEnded;
//            player.Play();
//        }
//        //foreach (var s in _fileStreams)
//        //{
//        //    _audioManager.CreatePlayer(await s.stream).Play();
//        //}
//    }


//    public void Dispose()
//    {
        
//    }
//}

public class SeriesPlayer : ISeriesPlayer, IDisposable
{
    public void Dispose()
    {
        if (_player != null)
        {
            _player.PlaybackEnded -= _playbackEnded;
        }
    }
    public SeriesPlayer(IAudioManager audioManager)
    {
        _audioManager = audioManager;
    }
    private EventHandler _playbackEnded;
    private readonly IAudioManager _audioManager;
    private  IAudioPlayer _player;
    private readonly List<(string key, Task<Stream> stream)> _fileStreams = new();

    //public SeriesPlayer AddWrongAnswerSound() => AddSound($"{ResourceNames.AudioFilePath}{ResourceNames.WrongAnswerFileName}");
    public ISeriesPlayer AddCorrectAnswerSound() => AddResourceFile(ResourceNames.CorrectAnswerFileName);
    
    public ISeriesPlayer AddClickSound() => AddResourceFile(ResourceNames.ClickSoundFileName);
    public ISeriesPlayer AddLevelDoneSound() =>  AddResourceFile(ResourceNames.LevelDoneSoundFileName);
    public ISeriesPlayer AddGameOverSound() => AddResourceFile(ResourceNames.GameOverSoundFileName);
    public ISeriesPlayer AddWord(Word word) => AddResourceFile(word.AudioFileName);
    public ISeriesPlayer AddCallback(EventHandler playbackEnded)
    {
        _playbackEnded = playbackEnded;
        return this;
    }
    //public async Task Play()
    //{
    //    while (_fileStreams.Any())
    //    {
    //        var stream = await _fileStreams[0].stream;
    //        _fileStreams.RemoveAt(0);
    //        using var player = _audioManager.CreatePlayer(stream);
    //        if (_fileStreams.Any())
    //            player.PlaybackEnded += ContinuePlaying;
    //        player.Play();
    //    }
    //    //foreach (var s in _fileStreams)
    //    //{
    //    //    _audioManager.CreatePlayer(await s.stream).Play();
    //    //}
    //}
    public async Task Play()
    {
        while (_fileStreams.Any())
        {
            var stream = await _fileStreams[0].stream;
            _fileStreams.RemoveAt(0);
            var player = _audioManager.CreatePlayer(stream);
            if (_fileStreams.Any())
                player.PlaybackEnded += ContinuePlaying;
            else if (_playbackEnded != null)
            {
                player.PlaybackEnded += _playbackEnded;
                _player = player;
            }

            player.Play();
        }
        //foreach (var s in _fileStreams)
        //{
        //    _audioManager.CreatePlayer(await s.stream).Play();
        //}
    }


    async void ContinuePlaying(object sender, EventArgs e)
    {
        await Play();
    }

    private  SeriesPlayer AddResourceFile(string filename)
    {
        _fileStreams.Add((filename, FileSystem.OpenAppPackageFileAsync(filename)));
        return this;
    }
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

