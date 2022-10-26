using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ICanReadWordsGame.Model;
using ICanReadWordsGame.Pages;
using ICanReadWordsGame.Services;

namespace ICanReadWordsGame.ViewModel
{

    public partial class GameResultViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IUserSettings _settings;
        private Level _nextLevel;
        private Level _level;
        readonly IDataManager _dataManager;
        private int _scorePoints;
        private   string _currentLang;
        [ObservableProperty] 
        private int _starsCount;
        public int Score => _settings.CurrentScore;
        [ObservableProperty]
        private bool _nextLevelExists;

        public GameResultViewModel(INavigationService navigationService, IUserSettings settings,
             IDataManager dataManager)
        {
            _navigationService = navigationService;
            _settings = settings;
            _dataManager = dataManager;

        }

        public async Task Initialize(string lang, int levelId, int starsCount, int points)
        {

            _currentLang = lang;
            StarsCount = starsCount;
            _level = await _dataManager.GetLevelById(levelId); ;
            _scorePoints = points;
            _nextLevel = await _dataManager.GetNextLevel(_level);
            NextLevelExists = _nextLevel != null;
            _settings.CurrentScore += _scorePoints;
            OnPropertyChanged(nameof(Score));
            await _dataManager.SaveLevelStars(_level.Id, StarsCount);
        }

        [RelayCommand]
        public void ShowLevelsList()
        {
             _navigationService.CloseCurrent();
        }
        [RelayCommand]
        public async Task RepeatLevel()
        {
            await _navigationService.CloseAndNavigate(typeof(FindWordGamePage),
                new Dictionary<string, object>
            {
                { "lang", _currentLang },
                {"level", _level.Id},
                { "wordNum", 0 }
            });
        }
        [RelayCommand]
        public async Task NextLevel()
        {
            await _navigationService.CloseAndNavigate( typeof(FindWordGamePage), 
   new Dictionary<string, object>
                {
                    { "lang", _currentLang },
                    {"level", _nextLevel.Id},
                    { "wordNum", 0 }
                });
        }
    }
}
