using ICanReadWordsGame.Services;

namespace ICanReadWordsGame
{
    public partial class App : Application
    {
        public IPlayerService PlayerService { get; }

        public App(MainPage mainPage,IPlayerService playerService)
        {
            PlayerService = playerService;
            InitializeComponent();

            //  MainPage = new AppShell();
            MainPage = new NavigationPage(mainPage);
        }
    }
}