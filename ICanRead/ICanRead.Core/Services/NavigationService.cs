using MvvmCross.Navigation;
using MvvmCross.ViewModels;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace ICanRead.Core.Services
{
    public class NavigationService : INavigationService
    {
        private readonly IMvxNavigationService mvxNavigation;

        public NavigationService(IMvxNavigationService mvxNavigation)
        {
            this.mvxNavigation = mvxNavigation;
        }
        //public async Task<bool> ClosePages<TResult>(IMvxViewModelResult<TResult> viewModel,
        //    int countClosingPages, TResult result, CancellationToken cancellationToken = default)
        //{

        //    if (countClosingPages > 1)
        //    {
        //        var navigation = GetNavigation();
        //        for (int i = 0; i < countClosingPages-1; i++)
        //        {
        //            if (navigation.NavigationStack.Count - 2 < 0)
        //                break;
        //            navigation.RemovePage(navigation.NavigationStack[navigation.NavigationStack.Count-2]);
        //        }

        //    }
        //    return await mvxNavigation.Close(viewModel, result, cancellationToken);
        //}

        
        //public  Task<bool> Close<TResult>(IMvxViewModelResult<TResult> viewModel, TResult result, CancellationToken cancellationToken)
        //{
        //    return mvxNavigation.Close<TResult>(viewModel, result, cancellationToken);
        //}

        public Task<bool> Close(IMvxViewModel viewModel, CancellationToken cancellationToken)
        {
            return mvxNavigation.Close(viewModel, cancellationToken);
        }

        public async Task<bool> CloseAndNavigate<TViewModel, TParameter>(TParameter param, IMvxBundle presentationBundle = null, CancellationToken cancellationToken = default) where TViewModel : IMvxViewModel<TParameter>
        { 
            var result =  await mvxNavigation.Navigate<TViewModel, TParameter>(param,  presentationBundle, cancellationToken);
            var navigation = GetNavigation();
            navigation.RemovePage(navigation.NavigationStack[navigation.NavigationStack.Count - 2]);
            return result;
        }
        private INavigation GetNavigation() => (Application.Current.MainPage as NavigationPage).Navigation;
        // Task<bool> ClosePages(IMvmvxNavigationxViewModel viewModel, CancellationToken cancellationToken = default);

    }
}
