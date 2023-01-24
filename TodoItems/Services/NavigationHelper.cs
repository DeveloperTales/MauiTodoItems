
using TodoItems.Services.Services;

namespace TodoItems.Services
{
    public class NavigationHelper : INavigationHelper
    {

        public async Task GoToAsync(string route)
        {
            await AppShell.Current.GoToAsync(route);
        }
    }
}
