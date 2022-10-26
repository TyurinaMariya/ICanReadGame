
namespace ICanReadWordsGame.Services
{
    public interface INavigationService
    {
        void CloseCurrent();

        Task Navigate(Type page, Dictionary<string,object> parameters) ;
        Task CloseAndNavigate(Type page, Dictionary<string, object> parameters);

    }
}
