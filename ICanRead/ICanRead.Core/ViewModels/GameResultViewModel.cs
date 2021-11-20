using ICanRead.Core.Model;
using ICanRead.Core.Services;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICanRead.Core.ViewModels
{
    
    public class GameResultViewModel : MvxViewModel<(string lang, Level level, int starsCount, int points)>
    {
        private readonly INavigationService _navigationService;
        private readonly IUserSettings settings;
        private Level _nextLevel;
        private Level _level;
        IDataManager _dataManager;
        private int _scorePoints;
        public string CurrentLang { get; set; }
        public int StarsCount { get; private set; }

        public int Score { get => settings.CurrentScore; } 
        public bool NextLevelExists { get; set; }

        public GameResultViewModel(INavigationService navigationService, IUserSettings settings,
             IDataManager dataManager)
        {
            this._navigationService = navigationService;
            this.settings = settings;
            this._dataManager = dataManager;
            
        }

        public override async Task Initialize()
        {
            await base.Initialize();

            _nextLevel = await _dataManager.GetNextLevel(_level);
            NextLevelExists = _nextLevel != null;
            settings.CurrentScore  = settings.CurrentScore + _scorePoints;
            _dataManager.SaveLevelStars( _level.Id, StarsCount);
        }

        public override void Prepare((string lang, Level level, int starsCount,  int points ) type)
        {
            CurrentLang = type.lang;
            StarsCount = type.starsCount;
            _level = type.level;
            _scorePoints = type.points;

            base.Prepare();
        }

        public IMvxAsyncCommand ShowLevelsListCommand =>
           new MvxAsyncCommand(async () =>
           {
               await _navigationService.Close(this);
           });
        public IMvxAsyncCommand RepeatLevelCommand=>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.CloseAndNavigate<FindWordGameViewModel, (string lang, int levelId, int wordNum)>
                     ((CurrentLang, _level.Id, 0));
            });
        public IMvxAsyncCommand NextLevelCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _navigationService.CloseAndNavigate<FindWordGameViewModel, (string lang, int levelId, int wordNum)>
                    ((CurrentLang, _nextLevel.Id, 0));
            });
    }
}
