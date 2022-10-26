// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------
using CommunityToolkit.Maui.Markup;
using ICanReadWordsGame.Controls;
using ICanReadWordsGame.Converters;
using ICanReadWordsGame.Model;
using ICanReadWordsGame.Services;
using ICanReadWordsGame.ViewModel;


namespace ICanReadWordsGame.Pages
{

    [QueryProperty(nameof(CurrentLanguage), nameof(CurrentLanguage))]
    [QueryProperty(nameof(LevelId), nameof(LevelId))]
    [QueryProperty(nameof(StarsCount), nameof(StarsCount))]
    [QueryProperty(nameof(Points), nameof(Points))]
    public partial class GameOverPage 
    {
        public int LevelId { get; set; }
        public string CurrentLanguage { get; set; }
        public int StarsCount { get; set; }
        public int Points { get; set; }
        public GameOverPage(GameOverViewModel viewModel)
        {
            BindingContext = viewModel;

            InitializeComponent();

        }
        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            var viewModel = (GameOverViewModel)BindingContext;

            await viewModel.Initialize(CurrentLanguage, LevelId, StarsCount,Points);
        }
    }
}