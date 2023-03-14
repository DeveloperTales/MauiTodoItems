
namespace TodoItems.Services.Services
{
    public interface INavigationHelper
    {
        Task GoToAsync(string route);
        Task GoToAsync(string route, bool animate, IDictionary<string, object> parameters);
    }
}
