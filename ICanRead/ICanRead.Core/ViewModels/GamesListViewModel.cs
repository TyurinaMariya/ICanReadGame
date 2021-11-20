// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Acr.UserDialogs;
using MvvmCross.Commands;
using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using ICanRead.Core.Helpers;
using ICanRead.Core.Services;
using System.Collections.Generic;
using MediaManager;

namespace ICanRead.Core.ViewModels
{
    public class GamesListViewModel : MvxViewModel<string>
    {
        private readonly IMvxNavigationService navigationService;
        private readonly IUserSettings settings;

        public string CurrentLang { get; private set; }

        public GamesListViewModel(IMvxNavigationService navigationService, Services.IUserSettings settings)
        {
            this.navigationService = navigationService;
            this.settings = settings;
            CrossMediaManager.Current.Init();
        }

        public IMvxAsyncCommand BackCommand => new MvxAsyncCommand(async () =>
        {
            await navigationService.Close(this);
        });

        public override void Prepare(string parameter)
        {
            CurrentLang = parameter;
        }
        public IMvxAsyncCommand FindWordGameCommand => new MvxAsyncCommand(async () =>
        {
            await navigationService.Navigate<LevelsViewModel, (string lang, GameTypes gameType)>
                                     ( (CurrentLang, GameTypes.FindWord));
        });

        public IMvxAsyncCommand FindPictureGameCommand => new MvxAsyncCommand(async () =>
        {
            await navigationService.Navigate<LevelsViewModel, (string lang, GameTypes gameType)>
                                     ((CurrentLang, GameTypes.FindPicture));
        });

        public IMvxAsyncCommand TypeWordGameCommand => new MvxAsyncCommand(async () =>
        {
            await navigationService.Navigate<LevelsViewModel, (string lang, GameTypes gameType)>
                                     ((CurrentLang, GameTypes.TypeWord));
        });

    }
}