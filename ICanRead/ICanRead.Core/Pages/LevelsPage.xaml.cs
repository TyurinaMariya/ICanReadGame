// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using ICanRead.Core.Controls;
using ICanRead.Core.Converters;
using ICanRead.Core.ViewModels;
using MvvmCross.Forms.Presenters.Attributes;
using MvvmCross.Forms.Views;
using System;
using System.Diagnostics;
using System.Threading.Tasks;
using Xamarin.Forms;
using static ICanRead.Core.ViewModels.LevelsViewModel;

namespace ICanRead.Core.Pages
{
    public partial class LevelsPage : MvxContentPage
    {
        const int levelRowsCount = 5;
        const int levelColumnCount = 3;
        public LevelsPage()
        {
            InitializeComponent();
        }
        protected override  async void OnViewModelSet()
        {
            Debug.Write($"model set begin");
            base.OnViewModelSet();
            var viewModel = ViewModel as LevelsViewModel;
            await viewModel.InitializeTask.Task;
            //await viewModel.InitializeTask.Task;
            //    viewModel.PropertyChanged += ViewModel_PropertyChanged;
            DrawLevels(ViewModel as LevelsViewModel);
            Debug.Write($"model set end.");
        }

       
        private void DrawLevels(LevelsViewModel viewModel)
        {
            //productGrid.RowDefinitions.Add(new RowDefinition());
            //productGrid.ColumnDefinitions.Add(new ColumnDefinition());

            Debug.Write($"Start draw");
            int levelscount = 0;
            for (int rowIndex = 0; rowIndex < levelRowsCount; rowIndex++)
            {
                for (int columnIndex = 0; columnIndex < levelColumnCount; columnIndex++)
                {
                    if (++levelscount > viewModel.Levels.Length)
                        return;
                    var imageButton = new ImageTextButton()
                    {
                        Text = levelscount.ToString(),
                        FontSize = 28,
                        TextMargin = new Thickness(0, -12, 0, 0),
                        ClickedTextMargin = new Thickness(7, -19, 0, 0),
                        Margin = new Thickness(5, 5, 5, 5),
                        CommandParameter = levelscount
                    };
                    imageButton.SetBinding(ImageTextButton.CommandProperty, new Binding("StartCommand"));
                    imageButton.SetBinding(ImageTextButton.ImageSourceProperty, 
                        new Binding($"Levels[{levelscount - 1}].State", converter: new LevelStateToImageNameConverter()));
                    imageButton.SetBinding(ImageTextButton.ClickedImageSourceProperty,
                        new Binding($"Levels[{levelscount - 1}].State", converter: new LevelStateToClickedImageNameConverter()));
                    page1Grid.Children.Add(imageButton, columnIndex, rowIndex);
                }
            }
            Debug.Write($"End draw");
        }
        
    }
}