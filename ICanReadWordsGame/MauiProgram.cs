using CommunityToolkit.Maui;
using ICanReadWordsGame.Model;
using ICanReadWordsGame.Pages;
using ICanReadWordsGame.Services;
using ICanReadWordsGame.ViewModel;
using Plugin.Maui.Audio;
namespace ICanReadWordsGame
{
    public static class MauiProgram
    {
        public static MauiApp CreateMauiApp()
        {
            var builder = MauiApp.CreateBuilder();
            builder
                .UseMauiCommunityToolkit()
                .UseMauiApp<App>()
                .ConfigureFonts(fonts =>
                {
                    fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
                    fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
                })
            .Services
                .AddSingleton(AudioManager.Current)
                .AddSingleton<IDataManager, DataManager>()
                .AddSingleton<INavigationService, NavigationService>()
                .AddScoped<IPlayerService, PlayerService>()
                .AddScoped<IUserSettings, UserSettings>()
                .AddTransientWithShellRoute<GameOverPage, GameOverViewModel>(nameof(GameOverPage))
                .AddTransientWithShellRoute<MainPage, MainViewModel>(nameof(MainPage))
                .AddTransientWithShellRoute<LevelsPage, LevelsViewModel>($"{nameof(MainPage)}/{nameof(LevelsPage)}")
                .AddTransientWithShellRoute<FindWordGamePage, FindWordGameViewModel>(
                    $"{nameof(MainPage)}/{nameof(LevelsPage)}/{nameof(FindWordGamePage)}")
                .AddTransientWithShellRoute<GameResultPage, GameResultViewModel>(
                    $"{nameof(MainPage)}/{nameof(LevelsPage)}/{nameof(GameResultPage)}")
                .AddTransient<IMauiInitializeService, DatabaseInitializer>();

            return builder.Build();
        }
    }
}