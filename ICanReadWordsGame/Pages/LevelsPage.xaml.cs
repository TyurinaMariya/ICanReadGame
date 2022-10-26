// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using System.Diagnostics;
using ICanReadWordsGame.Converters;
using ICanReadWordsGame.Services;
using ICanReadWordsGame.ViewModel;
using ImageTextButton = ICanReadWordsGame.Controls.ImageTextButton;
using  CommunityToolkit.Maui.Markup;

namespace ICanReadWordsGame.Pages
{
    [QueryProperty(nameof(CurrentLanguage), "lang")]
    [QueryProperty(nameof(GameType), "gametype")]
    public partial class LevelsPage : ContentPage
    {
        public GameTypes GameType { get; set; } = GameTypes.FindWord;
        public string CurrentLanguage { get; set; } = "ua";
        const int LevelRowsCount = 5;
        const int LevelColumnCount = 3;
        private bool _initialized;
        public LevelsPage(LevelsViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

        }
        protected override async  void OnNavigatedTo(NavigatedToEventArgs args)
        {
            await Initialize();

            base.OnNavigatedTo(args);
        }
      
        protected  async Task Initialize()
        {
            if (_initialized)
                return;
            await ((LevelsViewModel)BindingContext).Initialize(CurrentLanguage, GameType);
            DrawLevels();
            _initialized = true;
        }


        private void DrawLevels()
        {
            int levelsCount = 0;
            var viewModel = ((LevelsViewModel)BindingContext);
            for (int rowIndex = 0; rowIndex < LevelRowsCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < LevelColumnCount; columnIndex++)
                {
                    if (++levelsCount > viewModel.Levels.Length)
                        return;
                    var imageButton = new ImageTextButton
                    {
                        Text = levelsCount.ToString(),
                        FontSize = 28,
                        TextMargin = new Thickness(0, -12, 0, 0),
                        ClickedTextMargin = new Thickness(7, -19, 0, 0),
                        Margin = new Thickness(5, 5, 5, 5),
                        CommandParameter = levelsCount
                    }
                        .Row(rowIndex)
                        .Column(columnIndex)
                        ;
                    imageButton.SetBinding(ImageTextButton.CommandProperty, new Binding("StartCommand"));
                    imageButton.SetBinding(ImageTextButton.ImageSourceProperty,
                        new Binding($"Levels[{levelsCount - 1}].State", converter: new LevelStateToImageNameConverter()));
                    imageButton.SetBinding(ImageTextButton.ClickedImageSourceProperty,
                        new Binding($"Levels[{levelsCount - 1}].State", converter: new LevelStateToClickedImageNameConverter()));
                    page1Grid.Children.Add(imageButton);
                }
            }

        }

    }
}