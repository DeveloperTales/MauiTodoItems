using Microsoft.Extensions.DependencyInjection;
using TodoItems.Pages;
using TodoItems.ViewModels;

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

		return builder.Build();
	}

	private static void AddServices(this IServiceCollection services)
	{
        services.AddTransient<TodoItemsPage>();
        services.AddTransient<TodoItemsViewModel>();
        services.AddTransient<TodoItemPage>();
		services.AddTransient<TodoItemViewModel>();
	}
}
