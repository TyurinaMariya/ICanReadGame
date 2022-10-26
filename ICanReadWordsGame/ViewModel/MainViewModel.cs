// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using CommunityToolkit.Mvvm.ComponentModel;
using CommunityToolkit.Mvvm.Input;
using ICanReadWordsGame.Pages;
using ICanReadWordsGame.Services;

namespace ICanReadWordsGame.ViewModel
{
    public sealed partial class MainViewModel : ObservableObject
    {

        private readonly INavigationService _navigationService;
        private string _currentLanguage = "ua";

        public MainViewModel(INavigationService navigationService)
        {
            _navigationService = navigationService;


        }

        [RelayCommand]
        public async Task StartGame()
        {
            await _navigationService.Navigate(typeof(LevelsPage),
                new Dictionary<string, object> { { "lang", _currentLanguage } , {"gametype",GameTypes.FindWord}});
        }

       


    }

}