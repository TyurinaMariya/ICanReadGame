using ICanRead.Core.Model;
using ICanRead.Core.Resources;
using MediaManager;
using MvvmCross.IoC;
using Plugin.SimpleAudioPlayer;
using System;
using System.IO;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ICanRead.Core.Services
{
    public sealed class PlayerService : IPlayerService
    {
        private readonly IMvxIoCProvider ioCProvider;
        public PlayerService( IMvxIoCProvider ioCProvider)
        {
            CrossMediaManager.Current.Init();
            this.ioCProvider = ioCProvider;
        }

        public ISeriesPlayer GetSeriesPlayer() => ioCProvider.Resolve<ISeriesPlayer>();
        public Task PlayClickSound() => GetSeriesPlayer().AddClickSound().Play();
        public Task PlayWord (Word word) => GetSeriesPlayer().AddWord(word).Play();

        public Task PlayGameOverSound()=> GetSeriesPlayer().AddGameOverSound().Play();
    }
}
