using Microsoft.Extensions.Logging;
using SmartCaloriesLibrary;

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

        builder.Services.AddSingleton<User>(); 

        builder.Services.AddTransient<UserPage>();
        builder.Services.AddTransient<Planner>();
        builder.Services.AddTransient<ShoppingList>();
        builder.Services.AddTransient<DayPage>();

        return builder.Build();
    }
}
