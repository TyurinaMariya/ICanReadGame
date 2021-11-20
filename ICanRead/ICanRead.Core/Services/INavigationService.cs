using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System.Threading;
using System.Threading.Tasks;

namespace ICanRead.Core.Services
{
    public interface INavigationService
    {
        //Task<bool> ClosePages<TResult>(IMvxViewModelResult<TResult> viewModel,
        //    int countClosingPages, TResult result, CancellationToken cancellationToken = default);
        //Task<bool> Close<TResult>(IMvxViewModelResult<TResult> viewModel, TResult result, CancellationToken cancellationToken = default);
        
        Task<bool> Close(IMvxViewModel viewModel, CancellationToken cancellationToken = default);

        Task<bool> CloseAndNavigate<TViewModel, TParameter>(TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel<TParameter>;

    }
}
