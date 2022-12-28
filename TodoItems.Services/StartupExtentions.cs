using TodoItems.Services.ViewModels;
using Microsoft.Extensions.DependencyInjection;

namespace TodoItems.Services
{
    public static class StartupExtentions
    {
        public static void AddTodoServices(this IServiceCollection services)
        {
            services.AddSingleton<TodoItemsViewModel>();
            services.AddTransient<TodoItemViewModel>();
            services.AddSingleton<QuotesViewModel>();
            services.AddTransient<QuoteViewModel>();
            services.AddSingleton<SettingsViewModel>();
        }
    }
}
