using Microsoft.Extensions.DependencyInjection;
using SmartCaloriesLibrary;
namespace SmartCaloriesApp;

public partial class App : Application
{
    public App()
    {
        InitializeComponent();
        
        LoadDataAsync();

    }
    
    public static DataLibrary Library { get; private set; } = new DataLibrary();
    
    
    protected override Window CreateWindow(IActivationState? activationState)
    {
        return new Window(new AppShell());
    }

    private async void LoadDataAsync()
    {
        using Stream mealsStream = await FileSystem.OpenAppPackageFileAsync("recipes.json");
        await Library.LoadMeals(mealsStream);

        using Stream workoutsStream = await FileSystem.OpenAppPackageFileAsync("workouts.json");
        await Library.LoadWorkouts(workoutsStream);
    }
    
}