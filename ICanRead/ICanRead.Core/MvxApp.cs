// ---------------------------------------------------------------
// <author>Paul Datsyuk</author>
// <url>https://www.linkedin.com/in/pauldatsyuk/</url>
// ---------------------------------------------------------------

using Acr.UserDialogs;
using ICanRead.Core.Model;
using ICanRead.Core.Resources;
using ICanRead.Core.Services;
using MediaManager;
using MediaManager.Library;
using MvvmCross;
using MvvmCross.Base;
using MvvmCross.IoC;
using MvvmCross.Navigation;
using MvvmCross.Plugin.Json;
using MvvmCross.ViewModels;
using Plugin.SimpleAudioPlayer;
using System.IO;
using System.Linq;
using Xamarin.Forms;

namespace ICanRead.Core
{
    public class MvxApp : MvxApplication
    {


        public override void Initialize()
        {
            base.Initialize();
            //new MediaItem("file:///android_asset/Audio/Words/toucan.ua.mp3").
            Mvx.IoCProvider.RegisterSingleton<ISimpleAudioPlayerFactory>(() => new SimpleAudioPlayerFactory());
            Mvx.IoCProvider.RegisterType<IPlayerService, PlayerService>();
            //   Mvx.IoCProvider.RegisterType<ISimpleAudioPlayer>(() => CrossSimpleAudioPlayer.CreateSim
            //   pleAudioPlayer());
            Mvx.IoCProvider.RegisterSingleton<IResourceHelpers>(() => new ResourceHelpers());
            CreatableTypes()
                .EndingWith("Service")
                .AsInterfaces()
                .RegisterAsLazySingleton();
            Mvx.IoCProvider.RegisterType<ISeriesPlayer, SeriesPlayer>();
            CreatableTypes().
                EndingWith("Repository")
                .AsTypes()
                .RegisterAsLazySingleton();

            Mvx.IoCProvider.RegisterType<IUserSettings, UserSettings>();
            Mvx.IoCProvider.RegisterType<IDataManager, DataManager>();
            Mvx.IoCProvider.RegisterType<IMvxJsonConverter, MvxJsonConverter>();
            Mvx.IoCProvider.RegisterSingleton<IUserDialogs>(() => UserDialogs.Instance);
            Mvx.IoCProvider.RegisterSingleton<IPath>(() => DependencyService.Get<IPath>());
    
            Resources.AppResources.Culture = Mvx.IoCProvider.Resolve<Services.ILocalizeService>().GetCurrentCultureInfo();

            RegisterAppStart<ViewModels.MainViewModel>();
  


    }


}
}