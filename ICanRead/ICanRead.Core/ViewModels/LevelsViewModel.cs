using ICanRead.Core.Model;
using ICanRead.Core.Services;
using MediaManager;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Linq;
using System.Threading.Tasks;

namespace ICanRead.Core.ViewModels
{
    public class LevelsViewModel : MvxViewModel<(string lang, GameTypes gameType)>
    {
        public enum LevelState
        {
            Locked,
            Unlocked,
            OneStar,
            TwoStars,
            ThreeStars
        }
        private readonly IMvxNavigationService _navigationService;
        private readonly IPlayerService _playerService;
        private readonly IDataManager _dataManager;
        public GameTypes GameType { get; private set; }
        public string CurrentLanguage { get; private set; }
        public Level[] Levels { get; private set; }

        public LevelsViewModel(IMvxNavigationService navigationService, 
            IPlayerService playerService, IDataManager dataManager)
        {
            _navigationService = navigationService;
            _playerService = playerService;
            _dataManager = dataManager;
          //  CrossMediaManager.Current.Init();
        }
        public override async Task Initialize()
        {
            await base.Initialize();

            var game = await _dataManager.GetGame(GameType, CurrentLanguage);
            Levels = game.Levels
                .OrderBy(l => l.Number)
                .ToArray();

            _dataManager.InitStarsCount(Levels);
            _dataManager.UnlockNextLevel(Levels);

        }

        public override void Prepare((string lang, GameTypes gameType) type)
        {
            CurrentLanguage = type.lang;
            GameType = type.gameType;
        }

        public IMvxAsyncCommand<int> StartCommand =>
             new MvxAsyncCommand<int>(async level =>
             {
                 await _playerService.PlayClickSound();
                 switch (GameType)
                 {
                     case GameTypes.FindWord:
                         await _navigationService.Navigate<FindWordGameViewModel, (string lang, int level, int wordNum)>
                          ((CurrentLanguage, Levels[level - 1].Id, 0));
                         break;
                     case GameTypes.FindPicture:
                     case GameTypes.TypeWord:
                         throw new NotImplementedException();
                 }
             });
        public IMvxAsyncCommand BackCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _playerService.PlayClickSound();
                await _navigationService.Close(this);
            });
        
    }
}
