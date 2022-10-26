using ICanReadWordsGame.Services;
using ICanReadWordsGame.ViewModel;

namespace ICanReadWordsGame
{
    public partial class MainPage
    {
        public MainPage(MainViewModel viewModel)
        {
            InitializeComponent();

            BindingContext = viewModel;

        }

    }
}