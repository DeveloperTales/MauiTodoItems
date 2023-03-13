using TodoItems.Services.ViewModels;
using Microsoft.Extensions.DependencyInjection;
using TodoItems.Services.Services;

namespace TodoItems.Services
{
    public static class StartupExtentions
    {
        public static void AddTodoServices(this IServiceCollection services, string appDirectoryPath)
        {
            services.AddSingleton<IDatabaseService>(new DatabaseService(appDirectoryPath));
            services.AddSingleton<TodoItemsViewModel>();
            services.AddTransient<TodoItemViewModel>();
            services.AddSingleton<QuotesViewModel>();
            services.AddTransient<QuoteViewModel>();
            services.AddSingleton<SettingsViewModel>();
        }
    }
}
