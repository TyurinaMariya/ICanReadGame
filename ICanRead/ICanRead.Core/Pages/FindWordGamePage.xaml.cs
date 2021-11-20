// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using ICanRead.Core.Controls;
using ICanRead.Core.Converters;
using ICanRead.Core.Services;
using ICanRead.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System;
using Xamarin.Forms;

namespace ICanRead.Core.Pages
{
    //[MvxMasterDetailPagePresentation]
    public partial class FindWordGamePage : MvxContentPage
    {
        public FindWordGamePage()
        {
            InitializeComponent();
        }

        protected override async void OnViewModelSet()
        {
            base.OnViewModelSet();
            var viewModel = ViewModel as FindWordGameViewModel;
            await viewModel.InitializeTask.Task;
            viewModel.PropertyChanged += ViewModel_PropertyChanged;
            DrawSmiles(viewModel);
            DrawWords(viewModel);
        }

        private void DrawWords(FindWordGameViewModel viewModel)
        {
            int rowIndex = 0;
            int columnIndex = 0;
            int columnCount ;
            int rowCount ;
            string imageSource;
            string clickedImageSource;
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
                    wordsGrid.ColumnDefinitions.Add(new ColumnDefinition());
                
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
                };

                imageButton.SetBinding(ImageTextButton.CommandProperty, new Binding("ChooseWordCommand"));
                imageButton.SetBinding(ImageTextButton.CommandParameterProperty, new Binding($"Words[{i}]"));
                imageButton.SetBinding(ImageTextButton.TextProperty, new Binding($"Words[{i}].Text"));
                wordsGrid.Children.Add(imageButton, columnIndex, rowIndex);

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
            if (((FindWordGameViewModel)ViewModel).IsLevelEnded)
                await balloons.TranslateTo(0, -900, 8000);
        }
    }

    private void DrawSmiles(FindWordGameViewModel viewModel)
    {
        for (int i = 0; i < viewModel.LevelWords; i++)
        {
            progressGrid.ColumnDefinitions.Add(new ColumnDefinition());
            var image = new Image()
            {
                Margin = new Thickness(1, 1, 1, 1),
                Source = "notansweredword.png"
            };
            image.PropertyChanged += Answeredword_PropertyChanged;
            var dt = new DataTrigger(typeof(Image))
            {
                Value = false,
                Binding = new Binding("CorrectAnswers", converter: new IsLessThanConverter(), converterParameter: (i + 1))
            };
            dt.Setters.Add(new Setter()
            {
                Property = Image.SourceProperty,
                Value = "answeredword.png"
            });
            image.Triggers.Add(dt);
            Grid.SetColumn(image, i);
            progressGrid.Children.Add(image, i, 0);
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