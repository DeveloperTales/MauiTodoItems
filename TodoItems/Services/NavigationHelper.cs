
using TodoItems.Services.Services;

namespace TodoItems.Services
{
    public class NavigationHelper : INavigationHelper
    {
        public async Task GoToAsync(string route)
        {
            await AppShell.Current.GoToAsync(route);
        }

        public async Task GoToAsync(string route, bool animate, IDictionary<string, object> parameters)
        {
            await AppShell.Current.GoToAsync(route, animate, parameters);
        }
    }
}
