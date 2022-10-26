using ICanReadWordsGame.Model;
using ICanReadWordsGame.Services;
using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ICanReadWordsGame.Pages;

namespace ICanReadWordsGame.ViewModel
{
    public partial class LevelsViewModel : ObservableObject
    {
        private readonly INavigationService _navigationService;
        private readonly IDataManager _dataManager;
        public GameTypes GameType { get; private set; }
        public string CurrentLanguage { get; private set; }
        public Level[] Levels { get; private set; }

        public LevelsViewModel(INavigationService navigationService, IDataManager dataManager)
        {
            _navigationService = navigationService;
            _dataManager = dataManager;
        }
        public async Task Initialize(string lang, GameTypes gameType)
        {
            CurrentLanguage = lang ?? throw new ArgumentNullException(nameof(lang));
            GameType = gameType;

            var game = await _dataManager.GetGame(GameType, CurrentLanguage);
            Levels = game.Levels
                .OrderBy(l => l.Number)
                .ToArray();

            await _dataManager.InitStarsCount(Levels);
            await _dataManager.UnlockNextLevel(Levels);

        }

        [RelayCommand]
        public async Task Start(int level)
        {
            switch (GameType)
            {
                case GameTypes.FindWord:
                    await _navigationService.Navigate(typeof(FindWordGamePage),//"//MainPage/LevelsPage/FindWordGamePage",
                        new Dictionary<string, object>
                            { { "lang", CurrentLanguage }, { "level", Levels[level - 1].Id }, {"wordNum",0}}
                );
                    break;
                case GameTypes.FindPicture:
                case GameTypes.TypeWord:
                    throw new NotImplementedException();
            }
        }
        [RelayCommand]
        public void Back()
        {
            _navigationService.CloseCurrent();
        }

    }
}
