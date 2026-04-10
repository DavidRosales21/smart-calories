using Microsoft.Extensions.Logging;

namespace SmartCaloriesApp;

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

        //create application services and prepare pages for dependency injection
        builder.Services.AddSingleton<Planner>();
        builder.Services.AddTransient<ShoppingList>();
        builder.Services.AddTransient<DayPage>();

        return builder.Build();
    }
}
