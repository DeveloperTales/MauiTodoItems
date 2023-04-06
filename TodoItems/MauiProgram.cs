using TodoItems.Services;
using TodoItems.Services.Services;
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
				fonts.AddFont("fa-400.otf", "FA");
                fonts.AddFont("fa-solid-900.otf", "FAS");
                fonts.AddFont("fa-solid-900.ttf", "FASTTF");
            });

		builder.Services.AddServices();
		builder.Services.AddTodoServices(FileSystem.Current.AppDataDirectory);

        return builder.Build();
	}

	private static void AddServices(this IServiceCollection services)
	{
		services.AddSingleton<INavigationHelper, NavigationHelper>();

		// Pages
        services.AddSingleton<TodoItemsPage>();
        services.AddTransient<TodoItemPage>();
        services.AddSingleton<QuotesPage>();
    }
}
