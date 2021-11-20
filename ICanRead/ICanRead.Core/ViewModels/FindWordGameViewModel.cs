// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Acr.UserDialogs;
using ICanRead.Core.Model;
using ICanRead.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


namespace ICanRead.Core.ViewModels
{
    public enum WordSize
    {
        Short = 1,
        Medium = 2,
        Long = 3,
        Sentence = 4
    }
    public class FindWordGameViewModel : MvxViewModel<(string lang, int levelId, int wordNum)>
    {
        public static FindWordGameViewModel Instance;

        private readonly IUserSettings _settings;
        private readonly INavigationService _navigationService;
        private readonly IPlayerService _playerService;
        private readonly IDataManager _dataManager;
        private Level _level;
        private int _wordNumber;
        private int _wrongAnswers = 0;
        private int _levelId;
        public bool IsLevelEnded { get; private set; }
        public Word[] Words { get; set; }
        private string _currentLanguage;

        public string AnswerWordPicture { get; set; }
        public Word AnswerWord { get; set; }
        public int CorrectAnswers { get; private set; }

        public int Score => _settings.CurrentScore;
        public int LevelWords => _level.Words.Count;

        public FindWordGameViewModel(
            IUserSettings settings,
            INavigationService navigationService,
            IPlayerService playerService,
            IDataManager dataManager)
        {
            Instance = this;
            this._settings = settings;
            this._navigationService = navigationService;
            this._playerService = playerService;
            this._dataManager = dataManager;
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _level = await _dataManager.GetLevelById(_levelId);
            await InitWords();
        }
        private async Task InitWords()
        {
            AnswerWord = await _dataManager.GetLevelWord(_level, _wordNumber);
            var wordsCount = GetWordSize(AnswerWord) == WordSize.Sentence ? AppSettings.CountWordsForSentences :
                AppSettings.CountWordsForExpessions;
            Words = await _dataManager.GetListWithRandomWords(AnswerWord, wordsCount);
            WordsSize = Words.Max(w => GetWordSize(w));
            if (GetWordSize(AnswerWord) < WordsSize && WordsSize == WordSize.Sentence)
                Words = await _dataManager.GetListWithRandomWords(AnswerWord, AppSettings.CountWordsForSentences);
        }
        public override void Prepare((string lang, int levelId, int wordNum) parameter)
        {
            _currentLanguage = parameter.lang;
            _wordNumber = parameter.wordNum;
            _levelId = parameter.levelId;
        }

        private int GetPoints(int starsCount)
        {
            return starsCount * AppSettings.ScoreCoefficient;
        }
        private int GetStars()
        {
            if (_wrongAnswers <= AppSettings.ErrorsCountForOneStar)
                return 3;
            if (_wrongAnswers <= AppSettings.ErrorsCountForTwoStars)
                return 2;
            if (_wrongAnswers <= AppSettings.ErrorsCountForThreeStars)
                return 1;
            return 0;
        }
        private WordSize GetWordSize(Word word) =>
            word.Text.Length switch
            {
                var l when l > AppSettings.LongWordLength => WordSize.Sentence,
                var l when l > AppSettings.MediumWordLength => WordSize.Long,
                var l when l > AppSettings.ShortWordLength => WordSize.Medium,
                _ => WordSize.Short
            };
        public WordSize WordsSize { get; set; }
        public IMvxAsyncCommand BackCommand =>
            new MvxAsyncCommand(async () =>
           {
               await _playerService.PlayClickSound();
               await _navigationService.Close(this);
           });

        public IMvxAsyncCommand SpeachAswerCommand
            =>
            new MvxAsyncCommand(async () =>
            {
                await _playerService.PlayWord(AnswerWord);
            });
        public IMvxAsyncCommand<Word> ChooseWordCommand =>
            new MvxAsyncCommand<Word>(async (word) =>
            {
                if (word == AnswerWord)
                {
                    CorrectAnswers++;
                    if (_wordNumber >= _level.Words.Count() - 1)
                    {
                        IsLevelEnded = true;
                        await _playerService.GetSeriesPlayer()
                                            .AddWord(word)
                                            .AddLevelDoneSound()
                                            .Play();
                        await Task.Delay(3000);
                        var stars = GetStars();

                        var nextLevel = await _dataManager.GetNextLevel(_level);
                        if (nextLevel == null)
                            await _navigationService.CloseAndNavigate<GameOverViewModel, (string lang, Level level, int starsCount, int points)>
                                   ((_currentLanguage, _level, stars, GetPoints(stars)));
                        else
                            await _navigationService.CloseAndNavigate<GameResultViewModel, (string lang, Level level, int starsCount, int points)>
                                        ((_currentLanguage, _level, stars, GetPoints(stars)));
                    }

                    else
                    {
                        await _playerService.GetSeriesPlayer()
                                            .AddWord(word)
                                            .AddCorrectAnswerSound()
                                            .Play();
                        _wordNumber++;
                        await InitWords();
                    }
                }
                else
                {
                    await _playerService.GetSeriesPlayer()
                                            .AddWord(word)
                                            .Play();
                    _wrongAnswers++;
                }
            });


    }

}