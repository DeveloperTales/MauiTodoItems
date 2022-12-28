using TodoItems.Services;
using TodoItems.Views;

namespace TodoItems;

public static class MauiProgram
{
	public static MauiApp CreateMauiApp()
	{
		var builder = MauiApp.CreateBuilder();
		builder
			.UseMauiApp<App>()
			.ConfigureFonts(fonts =>
			{
				fonts.AddFont("OpenSans-Regular.ttf", "OpenSansRegular");
				fonts.AddFont("OpenSans-Semibold.ttf", "OpenSansSemibold");
			});

		builder.Services.AddServices();
		builder.Services.AddTodoServices();

        return builder.Build();
	}

	private static void AddServices(this IServiceCollection services)
	{
        services.AddSingleton<TodoItemsPage>();
        services.AddTransient<TodoItemPage>();
        services.AddSingleton<QuotesPage>();
        services.AddTransient<QuotePage>();
		services.AddSingleton<SettingsPage>();
    }
}
