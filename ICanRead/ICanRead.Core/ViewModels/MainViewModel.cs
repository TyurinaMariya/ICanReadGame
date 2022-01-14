// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using ICanRead.Core.Model;
using ICanRead.Core.Services;
using MediaManager;
using MvvmCross.Commands;
using MvvmCross.Logging;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;

namespace ICanRead.Core.ViewModels
{
    public class MainViewModel : MvxViewModel
    {

        private readonly IMvxNavigationService _navigationService;
        private readonly IMvxLogProvider _mvxLogProvider;
        private readonly IPlayerService _playerService;
        private readonly IMvxLog log;
        private string _currentLanguage = "ua";

        public MainViewModel(IMvxNavigationService navigationService, IMvxLogProvider mvxLogProvider,
            IPlayerService playerService)
        {
            this._navigationService = navigationService;
            this._mvxLogProvider = mvxLogProvider;
            this._playerService = playerService;
            this.log = mvxLogProvider.GetLogFor(GetType());

            CrossMediaManager.Current.Init();

        }
        public string CurrentLanguage
        {
            get => _currentLanguage;
            set => SetProperty(ref _currentLanguage, value);
        }

        //public MvxAsyncCommand<string> PressedGestureCommand =>
        //    new MvxAsyncCommand<string>(async lang =>
        //    {
        //       await _playerService.PlayClickSound();
        //        if (lang == CurrentLanguage)
        //            return;
        //        if (!AppSettings.Languages.Contains(lang))
        //            throw new ArgumentException($"Language should be in array : {AppSettings.Languages}");
        //        CurrentLanguage = lang;

        //    });

        public IMvxAsyncCommand StartCommand =>
            new MvxAsyncCommand(async () =>
            {
                await _playerService.PlayClickSound();

               

                await _navigationService.Navigate<LevelsViewModel, (string lang, GameTypes gameType)>
                                          ((CurrentLanguage, GameTypes.FindWord));

                //await _navigationService.Navigate<GameOverViewModel, (string lang, Level level, int starsCount, int points)>
                //             (("ua", new Level(), 2, 44400));
            });

      

    }

}