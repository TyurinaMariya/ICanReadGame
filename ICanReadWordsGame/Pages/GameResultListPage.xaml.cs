// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using ICanReadWordsGame.ViewModel;

namespace ICanReadWordsGame.Pages
{
    [QueryProperty(nameof(CurrentLanguage), nameof(CurrentLanguage))]
    [QueryProperty(nameof(LevelId), nameof(LevelId))]
    [QueryProperty(nameof(StarsCount), nameof(StarsCount))]
    [QueryProperty(nameof(Points), nameof(Points))]
    public partial class GameResultPage :ContentPage
    {
        public int LevelId { get; set; }
        public string CurrentLanguage { get; set; }
        public int StarsCount { get; set; }
        public int Points { get; set; }
        public GameResultPage(GameResultViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }
        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            var viewModel = (GameResultViewModel)BindingContext;
            await viewModel.Initialize(CurrentLanguage, LevelId, StarsCount, Points);
        }
    }
}