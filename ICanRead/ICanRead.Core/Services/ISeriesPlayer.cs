using ICanRead.Core.Model;
using System.Threading.Tasks;

namespace ICanRead.Core.Services
{
    public interface ISeriesPlayer
    {
        Task Play();
        ISeriesPlayer AddGameOverSound();
        ISeriesPlayer AddCorrectAnswerSound();
        ISeriesPlayer AddLevelDoneSound();
        ISeriesPlayer AddWord(Word word);
        ISeriesPlayer AddClickSound();
    }

    
}
