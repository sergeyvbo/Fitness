
using System.Linq;

namespace Fitness.Services
{
    class MauiNavigationService : INavigationService
    {

        public T GetPageViewModel<T>() where T : new()
        {
            var pageDetails = Shell.Current.CurrentItem.CurrentItem.Stack.Where(x => x is not null && x.BindingContext.GetType() == typeof(T)).FirstOrDefault();
            return pageDetails is not null
                ? (T)pageDetails.BindingContext
                : default(T);
        }

        public Task InitializeAsync()
        {
            throw new NotImplementedException();
        }

        public Task NavigateToAsync(string route, IDictionary<string, object> routeParameters = null)
        {
            return
                routeParameters is not null
                    ? Shell.Current.GoToAsync(route, routeParameters)
                    : Shell.Current.GoToAsync(route);
        }

        public Task PopAsync()
        {
            throw new NotImplementedException();
        }
        public async Task GoBackAsync()
        {
            await Shell.Current.GoToAsync("../");
        }
    }
}
