// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using System.Diagnostics;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ICanReadWordsGame.Model;
using ICanReadWordsGame.Pages;
using ICanReadWordsGame.Services;

namespace ICanReadWordsGame.ViewModel
{
    public enum WordSize
    {
        Short = 1,
        Medium = 2,
        Long = 3,
        Sentence = 4
    }
    public partial class FindWordGameViewModel : ObservableObject
    {
        public static FindWordGameViewModel Instance;

        private readonly IUserSettings _settings;
        private readonly INavigationService _navigationService;
        private readonly IPlayerService _playerService;
        private readonly IDataManager _dataManager;
        private Level _level;
        private int _wordNumber;
        private int _wrongAnswers ;
        private int _levelId;
        private string _currentLanguage;
        private Word _answerWord;
        public int Score => _settings.CurrentScore;
        public int LevelWordsCount => _level.Words.Count;
        [ObservableProperty]
        private int _correctAnswers;
        [ObservableProperty]
        private Word[] _words;
        [ObservableProperty]
        private string _answerWordPicture;
        [ObservableProperty]
        private bool _isLevelEnded;


        public FindWordGameViewModel(
            IUserSettings settings,
            INavigationService navigationService,
            IPlayerService playerService,
            IDataManager dataManager)
        {
            Instance = this;
            _settings = settings;
            _navigationService = navigationService;
            _playerService = playerService;
            _dataManager = dataManager;
        }

        public async Task Initialize(string lang, int levelId, int wordNum)
        {
            _currentLanguage = lang;
            _wordNumber = wordNum;
            _levelId = levelId;

            _level = await _dataManager.GetLevelById(_levelId);
            if (_level == null)
                throw new ArgumentException($"Level with LevelId={levelId} not found");
            await InitWords();
        }
        private async Task InitWords()
        {
            _answerWord = await _dataManager.GetLevelWord(_level, _wordNumber);
            AnswerWordPicture = _answerWord.Entity.PictureFileName;
            var wordsCount = GetWordSize(_answerWord) == WordSize.Sentence ? AppSettings.CountWordsForSentences :
                AppSettings.CountWordsForExpessions;
            Words = await _dataManager.GetListWithRandomWords(_answerWord, wordsCount);
            WordsSize = Words.Max(GetWordSize);
            if (GetWordSize(_answerWord) < WordsSize && WordsSize == WordSize.Sentence)
                Words = await _dataManager.GetListWithRandomWords(_answerWord, AppSettings.CountWordsForSentences);
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

        [RelayCommand]
        public void Back()
        {
             _navigationService.CloseCurrent();
        }

        [RelayCommand]
        public async Task AnswerVoice()
        {
            await _playerService.PlayWord(_answerWord);
        }

        private bool _chooseWordInProcess = false;

       

        [RelayCommand ]
        public async Task ChooseWord(Word word)
        {
            if (_chooseWordInProcess)
                return;

            try
            {
                _chooseWordInProcess = true;
                if (word.Equals(_answerWord))
                {
                    CorrectAnswers++;
                    if (_wordNumber >= _level.Words.Count - 1)
                    {
                        IsLevelEnded = true;
                        await _playerService.PlayWord(word);
                        await _playerService.PlayLevelDoneSound();

                        await Task.Delay(6000);
                        var stars = GetStars();

                        var nextLevel = await _dataManager.GetNextLevel(_level);
                        if (nextLevel == null)
                            await _navigationService.CloseAndNavigate(typeof(GameOverPage),
                                new Dictionary<string, object>
                                {
                                    { nameof(GameOverPage.CurrentLanguage), _currentLanguage },
                                    { nameof(GameOverPage.LevelId), _level.Id },
                                    { nameof(GameOverPage.StarsCount), stars },
                                    { nameof(GameOverPage.Points), GetPoints(stars) }
                                });
                        else
                            await _navigationService.CloseAndNavigate(typeof(GameResultPage),
                                new Dictionary<string, object>
                                {
                                    { nameof(GameResultPage.CurrentLanguage), _currentLanguage },
                                    { nameof(GameResultPage.LevelId), _level.Id },
                                    { nameof(GameResultPage.StarsCount), stars },
                                    { nameof(GameResultPage.Points), GetPoints(stars) }
                                });
                    }

                    else
                    {
                        //await _playerService.PlayWord(word);
                        //await _playerService.PlayCorrectAnswerSound();
                        //_wordNumber++;
                        //await Task.Delay(1000);
                        //await InitWords();


                        async void NextWord(object sender, EventArgs e)
                        {

                            _wordNumber++;
                            await InitWords();
                            _chooseWordInProcess = false;

                        }

                        var player = _playerService.GetSeriesPlayer();
                        await player.AddWord(word)
                            .AddCorrectAnswerSound()
                            .AddCallback(NextWord)
                            .Play();

                    }
                }
                else
                {
                    await _playerService.GetSeriesPlayer()
                        .AddWord(word)
                        .AddCallback((s,e) =>
                        {
                            _wrongAnswers++;
                            _chooseWordInProcess = false;
                        })
                        .Play();

                }
            }
            finally
            {
            }
        }


    }

}