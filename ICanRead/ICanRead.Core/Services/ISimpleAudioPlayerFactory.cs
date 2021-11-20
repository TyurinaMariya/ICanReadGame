using Plugin.SimpleAudioPlayer;

namespace ICanRead.Core.Services
{
    public interface ISimpleAudioPlayerFactory
    {
        ISimpleAudioPlayer GetSimpleAudioPlayer();
    }
}
