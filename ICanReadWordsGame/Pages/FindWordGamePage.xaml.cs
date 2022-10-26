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
    [QueryProperty(nameof(CurrentLanguage), "lang")]
    [QueryProperty(nameof(LevelId), "level")]
    [QueryProperty(nameof(WordNum), "wordNum")]
    public partial class FindWordGamePage :ContentPage
    {
        public int LevelId { get; set; } 
        public string CurrentLanguage { get; set; }
        public int WordNum { get; set; }

        public FindWordGamePage(FindWordGameViewModel viewModel)
        {
            InitializeComponent();
            BindingContext = viewModel;
        }

        protected override async void OnNavigatedTo(NavigatedToEventArgs args)
        {
            var viewModel =(FindWordGameViewModel) BindingContext ;
            await viewModel.Initialize(CurrentLanguage, LevelId, WordNum);
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
            DrawWords(viewModel);
            DrawSmiles(viewModel);
        }

        

        private void DrawWords(FindWordGameViewModel viewModel)
        {
            int rowIndex = 0;
            int columnIndex = 0;
            int columnCount ;
            int rowCount ;
            string imageSource;
            string clickedImageSource;
            //picture.Source = viewModel.AnswerWord.Entity.PictureFileName;

            //ones for all words
            if (viewModel.WordsSize == WordSize.Sentence)
            {
                columnCount = 1;
                rowCount = AppSettings.CountWordsForSentences;
                for (int i = 0; i < rowCount; i++)
                    wordsGrid.RowDefinitions.Add(new RowDefinition());
                imageSource = "sentence.png";
                clickedImageSource = "sentenceclicked.png";
            }
            else
            {
                columnCount = 2;
                rowCount = AppSettings.CountWordsForExpessions / 2;
                for (int i = 0; i < rowCount; i++)
                    wordsGrid.RowDefinitions.Add(new RowDefinition());
                for (int i = 0; i < columnCount; i++)
                    wordsGrid.ColumnDefinitions.Add(new ColumnDefinition( GridLength.Star));

                imageSource = "word.png";
                clickedImageSource = "wordclicked.png";
            }
            
            for (int i=0; i<viewModel.Words.Length;i++)
            {
                var imageButton = new ImageTextButton()
                {
                    FontSize = viewModel.WordsSize switch
                    {
                        WordSize.Short => 19,
                        WordSize.Medium => 13,
                        WordSize.Long => 10,
                        WordSize.Sentence => 14,
                        _ => throw new NotImplementedException()
                    },
                    TextMargin = new Thickness(0, 1, 0, 0),
                    ClickedTextMargin = new Thickness(3, -2, 0, 0),
                    Margin = new Thickness(0, 0, 0, 0),
                    ImageAspect = Aspect.Fill,
                    ImageSource = imageSource,
                    ClickedImageSource = clickedImageSource
                }
                    .Row(rowIndex)
                    .Column(columnIndex);

                imageButton.SetBinding(ImageTextButton.CommandProperty, new Binding("ChooseWordCommand"));
                imageButton.SetBinding(ImageTextButton.CommandParameterProperty, new Binding($"Words[{i}]"));
                imageButton.SetBinding(ImageTextButton.TextProperty, new Binding($"Words[{i}].Text"));
                wordsGrid.Children.Add(imageButton);

                if (++rowIndex == rowCount)
                {
                    columnIndex++;
                    if (columnIndex >= columnCount)
                        break;
                        rowIndex = 0;
                }
            }
        }
    

    private async void ViewModel_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(FindWordGameViewModel.IsLevelEnded))
        {
            if (((FindWordGameViewModel)BindingContext).IsLevelEnded)
                await balloons.TranslateTo(0, -900, 8000);
        }
    }

    private void DrawSmiles(FindWordGameViewModel viewModel)
    {
        for (int i = 0; i < viewModel.LevelWordsCount; i++)
        {
            progressGrid.ColumnDefinitions.Add(new ColumnDefinition());
            var image = new Image()
            {
                Margin = new Thickness(1, 1, 1, 1),
                Source = "notansweredword.png"
            }.Row(0).Column(i);
            image.PropertyChanged += Answeredword_PropertyChanged;
            var dt = new DataTrigger(typeof(Image))
            {
                Value = false,
                Binding = new Binding(nameof(FindWordGameViewModel.CorrectAnswers), 
                    converter: new IsLessThanConverter(),
                    converterParameter: (i + 1))
            };
            dt.Setters.Add(new Setter
            {
                Property = Image.SourceProperty,
                Value = "answeredword.png"
            });
            image.Triggers.Add(dt);
            Grid.SetColumn(image, i);
            progressGrid.Children.Add(image);
        }
    }

    private async void Answeredword_PropertyChanged(object sender, System.ComponentModel.PropertyChangedEventArgs e)
    {
        if (e.PropertyName == nameof(Image.Source))
        {
            await ((Image)sender).RelRotateTo(360, 500, null);
        }
    }

    private async void TapGestureRecognizer_Tapped(object sender, EventArgs e)
    {
        await balloons.TranslateTo(0, -900, 8000);
    }
}
}