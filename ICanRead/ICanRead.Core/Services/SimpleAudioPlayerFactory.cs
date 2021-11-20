using MvvmCross;
using Plugin.SimpleAudioPlayer;

namespace ICanRead.Core.Services
{
    public sealed class SimpleAudioPlayerFactory : ISimpleAudioPlayerFactory
    {
        public ISimpleAudioPlayer GetSimpleAudioPlayer()
        {
            return Mvx.IoCProvider.Resolve<ISimpleAudioPlayer>();
        }
    }
}
