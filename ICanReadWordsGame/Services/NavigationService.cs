
using System.Reflection;

namespace ICanReadWordsGame.Services
{
    public class PageInitializer
    {
        private readonly ContentPage _page;
        private readonly Dictionary<string, object> _parameters;

        public PageInitializer(ContentPage page, Dictionary<string, object> parameters)
        {
            _page = page;
            _parameters = parameters;
        }

        public void InitParams()
        {
            if (_parameters == null)
                throw new ArgumentNullException();
            var typeOfPage = _page.GetType();
            var queryProperties = Attribute.GetCustomAttributes(typeOfPage)
                .Where(at => at is QueryPropertyAttribute)
                .Select(at => new { ((QueryPropertyAttribute)at).Name, ((QueryPropertyAttribute)at).QueryId })
                .ToArray();
            foreach (var queryProperty in queryProperties)
            {
                PropertyInfo prop = typeOfPage.GetProperty(queryProperty.Name, BindingFlags.Public | BindingFlags.Instance);
                if (prop != null && prop.CanWrite && _parameters.ContainsKey(queryProperty.QueryId))
                {
                    prop.SetValue(_page, _parameters[queryProperty.QueryId], null);
                }
                else
                    throw new ArgumentException(
                        $"Can't find property or parameter for queryProperty Name={queryProperty.Name} QueryId={queryProperty.QueryId}");
            }
        }
    }


    public class NavigationService : INavigationService
    {
        private readonly IServiceProvider _serviceProvider;

        private readonly Lazy<INavigation> _navigation = new 
            (() => (Application.Current.MainPage as NavigationPage).Navigation);

        public NavigationService(IServiceProvider serviceProvider)
        {
            _serviceProvider = serviceProvider;
            
        }

        public void  CloseCurrent()
        {
            //await Shell.Current.GoToAsync("..");
            //System.Diagnostics.Debug.WriteLine($"State= {Shell.Current.CurrentState}   Item={Shell.Current.CurrentItem}");
            _navigation.Value.RemovePage(_navigation.Value.NavigationStack.Last());
        }

       

        public async Task Navigate( Type navigateTo, Dictionary<string, object> parameters)
        {
            var page = _serviceProvider.GetService(navigateTo) as ContentPage;
            new PageInitializer(page, parameters).InitParams();
            await _navigation.Value.PushAsync(page);

            //await Shell.Current.GoToAsync(route, parameters);
            //System.Diagnostics.Debug.WriteLine($"State= {Shell.Current.CurrentState.Location}   Item={Shell.Current.CurrentItem}");
        }

        public async Task CloseAndNavigate( Type navigateTo, Dictionary<string, object> parameters)
        {
            await Navigate(navigateTo, parameters);
            _navigation.Value.RemovePage(_navigation.Value.NavigationStack[^2]);
        }
        
    }
}
