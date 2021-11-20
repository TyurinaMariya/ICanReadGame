using ICanRead.Core.Model;
using MediaManager;
using System.Threading.Tasks;

namespace ICanRead.Core.Services
{
    public interface IPlayerService
    {
        ISeriesPlayer GetSeriesPlayer();
        Task PlayClickSound();
        Task PlayGameOverSound();
        Task PlayWord(Word word);
    }
}
