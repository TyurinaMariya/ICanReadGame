using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ICanReadWordsGame.Model;
using ICanReadWordsGame.Pages;
using ICanReadWordsGame.Services;

namespace ICanReadWordsGame.ViewModel
{

    public partial class GameOverViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IUserSettings _settings;
        private Level _level;
        readonly IDataManager _dataManager;
        private readonly IPlayerService _player;
        private int _scorePoints;
        private string _currentLang;
        [ObservableProperty]
        private int _starsCount;

        public int Score => _settings.CurrentScore;

        public GameOverViewModel(INavigationService navigationService, IUserSettings settings,
             IDataManager dataManager, IPlayerService player)
        {
            _navigationService = navigationService;
            _settings = settings;
            _dataManager = dataManager;
            _player = player;
        }

        public async Task Initialize(string lang, int levelId, int starsCount, int points)
        {
            _currentLang = lang;
            _level = await _dataManager.GetLevelById(levelId);
            _scorePoints = points;
            StarsCount = starsCount;
            
            _settings.CurrentScore += +_scorePoints;
            await _dataManager.SaveLevelStars(_level.Id, StarsCount);

            await _player.PlayGameOverSound();
        }



        [RelayCommand]
        public void ShowLevelsList()
        {
            _navigationService.CloseCurrent();
        }
        [RelayCommand]
        public async Task RepeatLevel()
        {
            await _navigationService.CloseAndNavigate(
                typeof(FindWordGamePage),
                new Dictionary<string, object>{
                        {"lang",_currentLang},
                        {"levelId",_level.Id},
                        {"wordNum",0}});
        }

    }
}
